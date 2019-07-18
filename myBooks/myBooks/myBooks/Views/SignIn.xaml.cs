using myBooks.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myBooks.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignIn : ContentPage
    {
        public SignIn()
        {
            InitializeComponent();
            BindingContext = new SignInViewModel();
        }
    }
}