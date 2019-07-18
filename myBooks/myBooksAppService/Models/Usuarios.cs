using System;
using System.Collections.Generic;

namespace myBooksAppService.Models
{
    public partial class Usuarios
    {
        public short UserId { get; set; }
        public string UserImgName { get; set; }
        public byte[] UserImgVb { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual Livros Livros { get; set; }
    }
}
