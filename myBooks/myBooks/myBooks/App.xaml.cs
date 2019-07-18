using myBooks.ViewModels.Services;
using myBooks.Views;
using myBooks.Views.Services;
using Xamarin.Forms;

namespace myBooks
{
    public partial class App : Application
    {
        public App()
        {
            DependencyService.Register<INavigationService, NavigationService>();
            InitializeComponent();
            MainPage = new NavigationPage(new SignIn());

        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
