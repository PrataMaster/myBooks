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

        public async Task NavigateToWishList()
        {
            
            await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new WishList());
        }

        public async Task NavigateToFavorites()
        {
            await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new Favorites());
        }

        public async Task NavigateToSettings()
        {
            await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new Settings());
        }
    }
}
