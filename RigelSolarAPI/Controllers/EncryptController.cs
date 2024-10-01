using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RigelSolarAPI.BLL;

namespace RigelSolarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncryptController : ApiController
    {
        private readonly Encrypt _encrypt;
        public EncryptController(    
            Encrypt encrypt
        ) 
        {
            _encrypt = encrypt; 
        }

        /// <summary>
        ///     Encripta uma senha
        /// </summary>
        /// 
        /// <returns> Token </returns>
        /// 
        [AllowAnonymous]
        [HttpPost()]
        public IActionResult Encrypt(string password)
        {
            var encrypted = _encrypt.ToEncrypt(password);

            return Ok(encrypted);
        }
    }
}
