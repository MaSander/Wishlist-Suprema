using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WishlistSuprema.Domains;
using WishlistSuprema.Interfaces;
using WishlistSuprema.Repositories;

namespace WishlistSuprema.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository {get; set;}

        public UsuarioController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            try
            {
                var verEmail = UsuarioRepository.VerificarEmail(usuario.Email);

                if(verEmail != null)
                {
                    return BadRequest(error: "Email ja utilizado");
                }

                UsuarioRepository.Cadastrar(usuario);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

        }

    }
}