using myBooks.ViewModels.Services;
using myBooks.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace myBooks.ViewModels
{
    public class SignInViewModel
    {
        private readonly INavigationService navigationService;
        public ICommand NavigateToSignUpCommand { get; set; }
        public ICommand NavigateToMyBooksCommand { get; set; }

        public SignInViewModel()
        {
            NavigateToSignUpCommand = new Command(NavigateToSignUp);
            NavigateToMyBooksCommand = new Command(NavigateToMyBooks);

            navigationService = DependencyService.Get<INavigationService>();
        }

        private void NavigateToMyBooks(object obj)
        {
            navigationService.NavigateToMyBooks();
        }

        private void NavigateToSignUp()
        {
            navigationService.NavigateToSignUp();
        }

    }
}
