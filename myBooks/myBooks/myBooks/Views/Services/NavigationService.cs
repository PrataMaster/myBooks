using myBooks.ViewModels.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace myBooks.Views.Services
{
    public class NavigationService : INavigationService
    {

        public async Task NavigateToSignIn()
        {
            await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new SignIn());
        }

        public async Task NavigateToSignUp()
        {
            await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new SignUp());
        }

        public async Task NavigateToMyBooks()
        {
            await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new MyBooks());
        }
    }
}
