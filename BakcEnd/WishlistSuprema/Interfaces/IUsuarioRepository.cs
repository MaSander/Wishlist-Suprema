using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishlistSuprema.Domains;

namespace WishlistSuprema.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuarios usuario);

        Usuarios BuscarPorEmailSenha(string email, string senha);

        Usuarios VerificarEmail(string email);
    }
}
