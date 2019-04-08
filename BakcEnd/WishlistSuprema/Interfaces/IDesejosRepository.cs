using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishlistSuprema.Domains;

namespace WishlistSuprema.Interfaces
{
    interface IDesejosRepository
    {
        void Cadastrar(Desejos desejo);

        List<Desejos> ListaDesejos();
    }
}
