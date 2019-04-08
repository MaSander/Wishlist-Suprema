using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WishlistSuprema.Domains
{
    public partial class Usuarios
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email não informado")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha não informada")]
        public string Senha { get; set; }
    }
}
