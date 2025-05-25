using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RigelSolarAPI.Dto;
using RigelSolarAPI.Models;
using RigelSolarAPI.Repositories;
using RigelSolarAPI.Utils;

namespace RigelSolarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FichaBanhoController : ApiController
    {
        private readonly FichaBanhoRepository _fichaBanhoRepository;
        private readonly IMapper _mapper;

        public FichaBanhoController(
            FichaBanhoRepository fichaBanhoRepository,
            IMapper mapper
        )
        {
            _fichaBanhoRepository = fichaBanhoRepository;
            _mapper = mapper;
        }

        /// <summary>
        ///     Retorna as fichas da aplicação
        /// </summary>
        /// 
        /// 
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        /// 
        /// <returns> Fichas </returns>
        /// 
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(List<GetVistoriaDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            var type = GetJwt().FirstOrDefault(c => c.Type == "typ")?.Value!;

            var isGestor = VerifyUser.IsGestor(type);

            var isCoordenador = VerifyUser.IsCoordenador(type);

            if (isGestor.IsError && isCoordenador.IsError)
            {
                return Problem(isGestor.Errors);
            }
            var fichas = _fichaBanhoRepository.GetAll();

            var mappedFichas = _mapper.Map<List<GetFichaBanhoDTO>>(fichas);

            return Ok(mappedFichas);
        }

        /// <summary>
        ///     Retorna ficha banho da aplicação
        /// </summary>
        /// 
        /// 
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        /// 
        /// <returns> Clientes </returns>
        /// 
        [HttpGet]
        [ProducesResponseType(typeof(List<GetFichaBanhoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var type = GetJwt().FirstOrDefault(c => c.Type == "typ")?.Value!;

            var isTecnico = VerifyUser.IsTecnico(type);

            if (isTecnico.IsError)
            {
                return Problem(isTecnico.Errors);
            }

            int tecnicoId = int.Parse(GetJwt().FirstOrDefault(c => c.Type == "idTecnico")?.Value!);

            var fichasBanho = await _fichaBanhoRepository.GetAllByTecnicoId(tecnicoId);

            var mappedFichasBanho = _mapper.Map<List<GetFichaBanhoDTO>>(fichasBanho);

            return Ok(mappedFichasBanho);
        }

        /// <summary>
        ///     Cria ficha banho da aplicação
        /// </summary>
        /// 
        /// 
        /// <response code="200">Sucesso</response>
        /// <response code="400">Erro</response>
        /// 
        /// <returns> Ok </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public IActionResult Create(FichaBanhoDTO fichaBanho)
        {
            var type = GetJwt().FirstOrDefault(c => c.Type == "typ")?.Value!;

            var isTecnico = VerifyUser.IsTecnico(type);

            if (isTecnico.IsError)
            {
                return Problem(isTecnico.Errors);
            }

            var fichaBanhoMapeada = _mapper.Map<FichaBanho>(fichaBanho);

            _fichaBanhoRepository.Add(fichaBanhoMapeada);

            return Ok();
        }

        /// <summary>
        ///     Atualiza ficha banho da aplicação
        /// </summary>
        /// 
        /// 
        /// <response code="200">Sucesso</response>
        /// <response code="400">Erro</response>
        /// 
        /// <returns> Ok </returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody] FichaBanhoDTO fichaBanho, [FromQuery] int id)
        {
            var type = GetJwt().FirstOrDefault(c => c.Type == "typ")?.Value!;

            var isTecnico = VerifyUser.IsTecnico(type);

            if (isTecnico.IsError)
            {
                return Problem(isTecnico.Errors);
            }

            var fichaBanhoMapeada = _mapper.Map<FichaBanho>(fichaBanho);

            fichaBanhoMapeada.Id = id;

            _fichaBanhoRepository.Update(fichaBanhoMapeada);

            return Ok();
        }

        /// <summary>
        ///     Deleta ficha banho da aplicação
        /// </summary>
        /// 
        /// 
        /// <response code="204">Sucesso</response>
        /// <response code="400">Erro</response>
        /// 
        /// <returns> Ok </returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            var type = GetJwt().FirstOrDefault(c => c.Type == "typ")?.Value!;

            var isTecnico = VerifyUser.IsTecnico(type);

            if (isTecnico.IsError)
            {
                return Problem(isTecnico.Errors);
            }

            await _fichaBanhoRepository.Delete(id);

            return Ok();
        }
    }
}
