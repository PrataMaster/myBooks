using myBooks.CustomRenderer;
using myBooks.Models;
//using myBooks.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace myBooks.ViewModels
{
    public class MyBooksViewModel : BaseViewModel
    {
        public ObservableCollection<Livro> Livros { get; set; }

        public MyBooksViewModel()
        {
            Livros = new ObservableCollection<Livro>();
            for (int i = 0; i < 30; i++)
            {
                Livros.Add(new Livro { Title = "Fala Fiote", Genre = "Ah um genero ai", Year = Convert.ToInt16(1990 + i) });
            }
        }
    }
}
