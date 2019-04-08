using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WishlistSuprema.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha"),
        StringLength(150, MinimumLength = 3, ErrorMessage = "A senha deve ter entre 3 e 150 caracteres")]
        public string Senha { get; set; }
    }
}
