using myBooks.ViewModels.Services;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace myBooks.ViewModels
{
    public class SignUpViewModel
    {
        public ICommand NavigateToSignInCommand { get; set; }

        private readonly INavigationService _navigationService;
        public SignUpViewModel()
        {
            NavigateToSignInCommand = new Command(NavigateToSignIn);
            _navigationService = DependencyService.Get<INavigationService>();
        }

        private void NavigateToSignIn()
        {
            _navigationService.NavigateToSignIn();
        }
    }
}
