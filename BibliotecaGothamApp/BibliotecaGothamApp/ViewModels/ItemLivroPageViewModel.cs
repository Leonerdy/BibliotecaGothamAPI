using BibliotecaGothamApp.Models;
using BibliotecaGothamApp.Services;
using BibliotecaGothamApp.Views;
using FluentValidation;
using FluentValidation.Results;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xamarin.Essentials;

namespace BibliotecaGothamApp.ViewModels
{
    public class ItemLivroPageViewModel : BindableBase, INavigationAware
    {
        #region Atributos
        readonly Validador _validator;
        private IPageDialogService _dialogService;
        private INavigationService _navigationService;
        #endregion

     

        #region Construtor
        public ItemLivroPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _validator = new Validador();
            _dialogService = dialogService;
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
            IsNotConnected = Connectivity.NetworkAccess != NetworkAccess.Internet;
            
        }
        ~ItemLivroPageViewModel()
        {
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }
        #endregion

        #region Propriedades
        private string _disponivel;
        public string Disponivel
        {
            get => _disponivel; 
            set => SetProperty(ref _disponivel, value); 
        }
        public string Nome { get; set; }
        public long Telefone { get; set; }

        private Lista _livroSelecionado;
        public Lista LivroSelecionado
        {
            get => _livroSelecionado;
            set => SetProperty(ref _livroSelecionado, value);
        }
        private bool _isNotConnected;
        public bool IsNotConnected
        {
            get => _isNotConnected;
            set => SetProperty(ref _isNotConnected, value);
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }
        #endregion
              

        #region Comandos
        //Comando para Emprestar Livro
        private DelegateCommand _emprestarCommand;
        public DelegateCommand EmprestarCommand => _emprestarCommand ??  (_emprestarCommand = new DelegateCommand(EmprestarLivro));

        private DelegateCommand _aboutCommand;
        public DelegateCommand AboutCommand => _aboutCommand ?? (_aboutCommand = new DelegateCommand((About)));
        #endregion

        #region Métodos
        //Requisição a API
        private async void EmprestarLivro()
        {
            try
            {
                IsRefreshing = true;
                if (!IsNotConnected)
                {
                    SolicitacaoEmprestimo solicitacaoEmprestimo = new SolicitacaoEmprestimo();
                    solicitacaoEmprestimo.Nome = Nome;
                    solicitacaoEmprestimo.Telefone = Telefone.ToString();
                    solicitacaoEmprestimo.Livro = LivroSelecionado;
                    //Validações com FluentValidation
                    ValidationResult resultadoValidacoes = _validator.Validate(solicitacaoEmprestimo);
                    if (resultadoValidacoes.IsValid)
                    {
                        var request = JsonConvert.SerializeObject(solicitacaoEmprestimo);
                        var content = new StringContent(request, Encoding.UTF8, "application/json");

                        var client = new HttpClient
                        {
                            BaseAddress = new Uri(EndPoints.BaseUrl)
                        };
                        var url = $"api/livro/emprestimo";

                        var response = await client.PostAsync(url, content);
                        var result = await response.Content.ReadAsStringAsync();

                        if (result == "true")
                        {
                            await _dialogService.DisplayAlertAsync("Boa Leitura", "Livro emprestado com Sucesso.", "ok");
                            IsRefreshing = false;
                        }

                        else
                        {
                            await _dialogService.DisplayAlertAsync("Aviso", "Livro indisponível no momento.", "ok");
                            IsRefreshing = false;
                        }
                           
                    }
                    else
                    {
                        await _dialogService.DisplayAlertAsync("Aviso", resultadoValidacoes.Errors[0].ErrorMessage, "Ok");
                        IsRefreshing = false;
                    }
                }
                else
                {
                    await _dialogService.DisplayAlertAsync("Aviso", "Sem conexão com a internet", "ok");
                    IsRefreshing = false;
                }  

            }
            catch (Exception)
            {
                await _dialogService.DisplayAlertAsync("Aviso", "Nenhum livro para retornar", "ok");
                IsRefreshing = false;
            }
        }
        //Verifica mudança de conexão
        void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            IsNotConnected = e.NetworkAccess != NetworkAccess.Internet;
        }
        private async void About()
        {
            await _navigationService.NavigateAsync(nameof(AboutPage));
        }
      
        //Interfaces de navegação e passagem de parâmetros
        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            LivroSelecionado = parameters["livro"] as Lista;
            Disponivel = LivroSelecionado.Disponivel ? "Sim" : "Não";

        }
    } 
    #endregion
}
