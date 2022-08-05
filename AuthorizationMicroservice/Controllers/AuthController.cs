using AuthorizationMicroservice.Data;
using AuthorizationMicroservice.Models;
using AuthorizationMicroservice.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {


        private readonly IRepo _irepo;
        public AuthController(IRepo irepo)
        {

            _irepo = irepo;

        }



        [HttpPost, Route("login")]


        public IActionResult Login([FromBody] LoginModel user)
        {

            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid Client Request");

                dynamic user1 = _irepo.getuserByAadhar(user);
                if ((user1 != null))

                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    var tokenOptions = new JwtSecurityToken(
                        issuer: "https://localhost:44328",
                        audience: "https://localhost:44328",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: signinCredentials
                        );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    return Ok(new { Token = tokenString });
                }
                else
                {
                    return Unauthorized();

                }

            }
            catch (Exception) { throw; }

        }
    }
}