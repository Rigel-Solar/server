using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RigelSolarAPI.BLL;
using RigelSolarAPI.Dto;
using RigelSolarAPI.Models;
using RigelSolarAPI.Repositories;
using RigelSolarAPI.Utils;

namespace RigelSolarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FotoController : ApiController
    {
        private readonly BlobStorage _blob;
        private readonly FotoRepository _fotoRepository;
        public FotoController(    
            BlobStorage blob
        ) 
        {
            _blob = blob; 
        }

        /// <summary>
        ///     Tipo ficha: 1 - fotovoltaico; 2 - Piscina; 3 - Banho
        /// </summary>
        /// 
        /// <returns> Ok </returns>
        /// 
        [AllowAnonymous]
        [HttpPost()]
        public async Task<IActionResult> UploadFotos([FromForm] UploadFotosDTO request)
        {
            foreach(var foto in request.Fotos)
            {
                var uploadedPicture = await _blob.UploadAsync(foto);

                var fotoNova = new Foto { Foto1 = uploadedPicture.Blob.Uri! };

                if(request.TipoFicha == 1)
                {
                    fotoNova.IdFichaFotovoltaico = request.CodigoFicha;
                } else if(request.TipoFicha == 2)
                {
                    fotoNova.IdFichaPiscina = request.CodigoFicha;
                } else if(request.TipoFicha == 3)
                {
                    fotoNova.IdFichaBanho = request.CodigoFicha;
                }

                _fotoRepository.Add( fotoNova );
            }

            return Ok();
        }
    }
}
