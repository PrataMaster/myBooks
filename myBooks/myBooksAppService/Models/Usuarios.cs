using System;
using System.Collections.Generic;

namespace myBooksAppService.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Livros = new HashSet<Livros>();
        }

        public short UserId { get; set; }
        public string UserImgName { get; set; }
        public byte[] UserImgVb { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<Livros> Livros { get; set; }
    }
}
