using System;
using System.Collections.Generic;

namespace myBooksAppService.Models
{
    public partial class Livros
    {
        public short BookId { get; set; }
        public string BookImgName { get; set; }
        public byte[] BookImgVb { get; set; }
        public string Title { get; set; }
        public short Year { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public bool Favorite { get; set; }
        public bool Wishlist { get; set; }
        public short UserId { get; set; }

        //public virtual Usuarios Book { get; set; }
    }
}
