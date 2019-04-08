using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WishlistSuprema.Domains
{
    public partial class Desejos
    {
        public int Id { get; set; }
        public DateTime DataDoDesejo { get; set; }

        [Required(ErrorMessage ="Desejo não informado")]
        public string Desejo { get; set; }
    }
}
