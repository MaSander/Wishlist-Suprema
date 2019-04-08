using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishlistSuprema.Domains;
using WishlistSuprema.Interfaces;

namespace WishlistSuprema.Repositories
{
    public class DesejoRepository : IDesejosRepository
    {
        public void Cadastrar(Desejos desejo)
        {
            using(WishList ctx = new WishList())
            {
                ctx.Desejos.Add(desejo);
                ctx.SaveChanges();
            }
        }

        public List<Desejos> ListaDesejos()
        {

            using(WishList ctx = new WishList())
            {
                return ctx.Desejos.ToList();
            }
        }
    }
}
