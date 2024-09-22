using Microsoft.AspNetCore.Mvc;
using RigelSolarAPI.BLL;
using RigelSolarAPI.Utils;

namespace RigelSolarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiController
    {
        private readonly LoginBLL _loginBLL;
        
        public AuthController(
            LoginBLL loginBLL
        ) 
        {
            _loginBLL = loginBLL;
        }
        
        /// <summary>
        ///     Realiza login de usuários no sistema
        /// </summary>
        /// 
        /// 
        /// <response code="200">Sucesso e token</response>
        /// <response code="401">Não autorizado</response>
        /// 
        /// <returns> Token </returns>
        /// 

        [HttpPost]

        [ProducesResponseType(typeof(TokenResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var servico = await _loginBLL.Handle(request);

            return servico.Match
            (
                success => Ok(success),
                erros => Problem(erros)
            );
        }
    }
}
