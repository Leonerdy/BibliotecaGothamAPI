using BibliotecaGothamApp.Models;
using BibliotecaGothamApp.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaGothamApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        #region Atributo
        private INavigationService _navigationService;

        #endregion

        #region Propriedades
        private int _pagina;
        public int Pagina
        {
            get { return _pagina; }
            set { SetProperty(ref _pagina, value); }
        }

        private int _registrosPorPagina;
        public int RegistrosPorPagina
        {
            get { return _registrosPorPagina; }
            set { SetProperty(ref _registrosPorPagina, value); } 
            
        }
        #endregion

        //Comando para navegar para outra Page
        #region Comandos
        private DelegateCommand _navigateCommand;
        public DelegateCommand NavigateCommand => _navigateCommand ?? (_navigateCommand = new DelegateCommand((Navigate)));
        //Comando para navegar para Page Sobre
        private DelegateCommand _aboutCommand;
        public DelegateCommand AboutCommand => _aboutCommand ?? (_aboutCommand = new DelegateCommand((About)));
        #endregion

        #region Construtor
        public MainPageViewModel(INavigationService navigationService)
           : base(navigationService)
        {
            Title = "Biblioteca Gotham";
            _navigationService = navigationService;

        }

        #endregion

        #region Métodos
        private async void About()
        {
            await _navigationService.NavigateAsync(nameof(AboutPage));
        }

        private async void Navigate()
        {

            await _navigationService.NavigateAsync(nameof(LivrosPage));
        } 
        #endregion

    }
}
