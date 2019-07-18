using System;
using System.Collections.Generic;
using System.Text;

namespace myBooks.Models
{
    public class Usuario
    {
        public short UserId { get; set; }
        public string UserImgName { get; set; }
        public byte[] UserImgVb { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
