using myBooks.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myBooks.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUp : ContentPage
    {
        public SignUp()
        {
            InitializeComponent();
            BindingContext = new SignUpViewModel();
        }
    }
}