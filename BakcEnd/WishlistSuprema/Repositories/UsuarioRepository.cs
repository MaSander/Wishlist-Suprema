using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishlistSuprema.Domains;
using WishlistSuprema.Interfaces;

namespace WishlistSuprema.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuarios BuscarPorEmailSenha(string email, string senha)
        {
            using (WishList ctx = new WishList())
            {
                return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
            }
        }

        public void Cadastrar(Usuarios usuarios)
        {
            using(WishList ctx = new WishList())
            {
                ctx.Usuarios.Add(usuarios);
                ctx.SaveChanges();                
            }
        }

        public Usuarios VerificarEmail(string email)
        {
            using(WishList ctx = new WishList())
            {
                var usuarioEncontrado = ctx.Usuarios.FirstOrDefault(x => x.Email == email);

                if (usuarioEncontrado != null)
                {
                    return usuarioEncontrado;
                }

                return null;
            }
        }
    }
}
