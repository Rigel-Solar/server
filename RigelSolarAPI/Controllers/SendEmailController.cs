using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RigelSolarAPI.BLL;
using RigelSolarAPI.Dto;
using RigelSolarAPI.Utils;

namespace RigelSolarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ApiController
    {
        private readonly SendEmail _SendEmail;
        public SendEmailController(    
            SendEmail SendEmail
        ) 
        {
            _SendEmail = SendEmail; 
        }

        /// <summary>
        ///     Envia email
        /// </summary>
        /// 
        /// <returns> Ok </returns>
        /// 
        [AllowAnonymous]
        [HttpPost()]
        public IActionResult SendEmail([FromBody] EnviarEmailDTO request)
        {
            var SendEmail = _SendEmail.Execute(request);

            return Ok(SendEmail);
        }
    }
}
