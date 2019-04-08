using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    public class DesejoController : ControllerBase
    {
        private IDesejosRepository DesejoRepository { get; set; }

        public DesejoController()
        {
            DesejoRepository = new DesejoRepository();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Desejar(Desejos desejo)
        {
            try
            {
                desejo.DataDoDesejo = DateTime.Now;
                DesejoRepository.Cadastrar(desejo);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(DesejoRepository.ListaDesejos());
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}