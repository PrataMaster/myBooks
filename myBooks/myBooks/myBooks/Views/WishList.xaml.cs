using myBooks.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myBooks.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WishList : ContentPage
    {
        public WishList()
        {
            InitializeComponent();
            BindingContext = new WishListViewModel();
        }
    }
}