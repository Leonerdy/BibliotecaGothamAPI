using BibliotecaGothamApp.Models;
using BibliotecaGothamApp.Services;
using BibliotecaGothamApp.Views;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BibliotecaGothamApp.ViewModels
{
    public class LivrosPageViewModel : ViewModelBase
    {
        #region Atributos
        IPageDialogService _dialogService;
        private INavigationService _navigationService;

        private Paginador paginador;
        #endregion

        #region Construtor
        public LivrosPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
           : base(navigationService)
        {
            Title = "Biblioteca Gotham";
            _dialogService = dialogService;
            _navigationService = navigationService;
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
            IsNotConnected = Connectivity.NetworkAccess != NetworkAccess.Internet;
            LivrosCollection = new ObservableCollection<Lista>();
            paginador = new Paginador();
            if(!IsNotConnected)
            ObterLivros();

        }
        #endregion

        ~LivrosPageViewModel()
        {
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }

        void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            IsNotConnected = e.NetworkAccess != NetworkAccess.Internet;
        }

        #region Propriedades
        private Lista[] livros { get; set; }
        public Lista SelectedItem { get; set; }

        private ObservableCollection<Lista> _livrosCollection;
        public ObservableCollection<Lista> LivrosCollection
        {
            get { return _livrosCollection; }
            set { SetProperty(ref _livrosCollection, value); }
        }

        private LivroRespostaLista livroRespostaLista { get; set; }

        private int _pagina;
        public int Pagina
        {
            get => _pagina;
            set => SetProperty(ref _pagina, value);
        }

        private int _registrosPorPagina;
        public int RegistrosPorPagina
        {
            get => _registrosPorPagina;
            set => SetProperty(ref _registrosPorPagina, value);
        }

        private int _totalRegistros;
        public int TotalRegistros
        {
            get => _totalRegistros;
            set => SetProperty(ref _totalRegistros, value);
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }
        private bool _isNotConnected;
        public bool IsNotConnected 
        {
            get => _isNotConnected; 
            set =>  SetProperty(ref _isNotConnected, value);
        }
        #endregion

        #region Comandos
        //Buscar Paginação
        private DelegateCommand _buscarCommand;
        public DelegateCommand BuscarCommand => _buscarCommand ?? (_buscarCommand = new DelegateCommand(Buscar));
        //Navegar para Page Sobre.
        private DelegateCommand _aboutCommand;
        public DelegateCommand AboutCommand => _aboutCommand ?? (_aboutCommand = new DelegateCommand((About)));
        //Comando para disparar RefreshView.
        public ICommand RefreshCommand => new Command(RefreshItemsAsync);
        //Comando para selecionar o item da lista de livros.
        public ICommand ItemSelectedCommand
        {
            get
            {
                return new Command(_ =>
                {
                    if (SelectedItem == null)
                        return;
                    var navigationParams = new NavigationParameters();
                    navigationParams.Add("livro", SelectedItem);

                    _navigationService.NavigateAsync(nameof(ItemLivroPage), navigationParams);

                });
            }
        }
        #endregion

        #region Métodos
        //Navegação
        private async void About()
        {
            await _navigationService.NavigateAsync(nameof(AboutPage));
        }
        private void Buscar()
        {
            paginador.Pagina = Pagina;
            paginador.RegistrosPorPagina = RegistrosPorPagina;

            ObterLivros();
        }

        void RefreshItemsAsync()
        {
            ObterLivros();
        }

        //Requisição a API HttpClient.
        public async void ObterLivros()
        {
            try
            {
                IsRefreshing = true;
                var request = JsonConvert.SerializeObject(paginador);
                var content = new StringContent(request, Encoding.UTF8, "application/json");

                var client = new HttpClient
                {
                    BaseAddress = new Uri(EndPoints.BaseUrl)
                };
                var url = $"api/livro/listalivros";

                var response = await client.PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();

                livroRespostaLista = JsonConvert.DeserializeObject<LivroRespostaLista>(result);
                TotalRegistros = livroRespostaLista.paginador.totalRegistros;
                livros = livroRespostaLista.lista;
                ObservableCollection<Lista> retorno = new ObservableCollection<Lista>(livros);
                LivrosCollection = retorno;
                IsRefreshing = false;
            }
            catch (Exception)
            {
                await _dialogService.DisplayAlertAsync("Aviso", "Nenhum livro para retornar", "ok");
                IsRefreshing = false;
            }

        } 
        #endregion
    }
}
