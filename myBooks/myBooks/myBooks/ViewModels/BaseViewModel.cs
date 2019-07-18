using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace myBooks.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnNotifyPropertyChangend([CallerMemberName] string propertyName = null)
        {
            if (propertyName != null && !string.IsNullOrEmpty(propertyName))
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
