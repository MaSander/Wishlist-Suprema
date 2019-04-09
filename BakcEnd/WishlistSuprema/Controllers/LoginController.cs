using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WishlistSuprema.Domains;
using WishlistSuprema.Interfaces;
using WishlistSuprema.Repositories;
using WishlistSuprema.ViewModels;

namespace WishlistSuprema.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public LoginController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            Usuarios usuario = UsuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);

            try
            {
                if(usuario == null)
                {
                    return NotFound(new{mensage = "Usuario não encontrado"});
                }

                var Claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString()),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("wishlist-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "wishlist.WebApi",
                    audience: "wishlist.WebApi",
                    claims: Claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                    );



                return Ok(new {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
                
            }
            catch(Exception ex)
            {
                return BadRequest(new{mensage= "problema com o logim de usuario brimbrim" + ex.Message});
            }
        }
    }
}