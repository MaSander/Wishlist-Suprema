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
            //throw new NotImplementedException();
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
    }
}
