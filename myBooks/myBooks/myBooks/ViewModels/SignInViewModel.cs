using myBooks.ViewModels.Services;
using myBooks.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace myBooks.ViewModels
{
    public class SignInViewModel
    {
        public ICommand NavigateToSignUpCommand { get; set; }
        public ICommand NavigateToMyBooksCommand { get; set; }

        private readonly INavigationService _navigationService;

        public SignInViewModel()
        {
            NavigateToSignUpCommand = new Command(NavigateToSignUp);
            NavigateToMyBooksCommand = new Command(NavigateToMyBooks);

            _navigationService = DependencyService.Get<INavigationService>();
        }

        private void NavigateToMyBooks(object obj)
        {
            _navigationService.NavigateToMyBooks();
        }

        private void NavigateToSignUp()
        {
            _navigationService.NavigateToSignUp();
        }

    }
}
