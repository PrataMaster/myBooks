using myBooks.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myBooks.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyBooks : ContentPage
    {
        public MyBooks()
        {
            InitializeComponent();
            BindingContext = new MyBooksViewModel();
        }

    }
}