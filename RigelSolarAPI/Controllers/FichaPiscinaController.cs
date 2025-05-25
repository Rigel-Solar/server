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
    public class FichaPiscinaController : ApiController
    {
        private readonly FichaPiscinaRepository _fichaPiscinaRepository;
        private readonly IMapper _mapper;

        public FichaPiscinaController(
            FichaPiscinaRepository fichaPiscinaRepository,
            IMapper mapper
        )
        {
            _fichaPiscinaRepository = fichaPiscinaRepository;
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
            var fichas = _fichaPiscinaRepository.GetAll();

            var mappedFichas = _mapper.Map<List<GetFichaPiscinaDTO>>(fichas);

            return Ok(mappedFichas);
        }

        /// <summary>
        ///     Retorna ficha piscina da aplicação
        /// </summary>
        /// 
        /// 
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        /// 
        /// <returns> Clientes </returns>
        /// 
        [HttpGet]
        [ProducesResponseType(typeof(List<GetFichaPiscinaDTO>), StatusCodes.Status200OK)]
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

            var fichasPiscina = await _fichaPiscinaRepository.GetAllByTecnicoId(tecnicoId);

            var mappedFichasPiscina = _mapper.Map<List<GetFichaPiscinaDTO>>(fichasPiscina);

            return Ok(mappedFichasPiscina);
        }

        /// <summary>
        ///     Cria ficha piscina da aplicação
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
        public IActionResult Create(FichaPiscinaDTO fichaPiscina)
        {
            var type = GetJwt().FirstOrDefault(c => c.Type == "typ")?.Value!;

            var isTecnico = VerifyUser.IsTecnico(type);

            if (isTecnico.IsError)
            {
                return Problem(isTecnico.Errors);
            }

            var fichaPiscinaMapeada = _mapper.Map<FichaPiscina>(fichaPiscina);

            _fichaPiscinaRepository.Add(fichaPiscinaMapeada);

            return Ok();
        }

        /// <summary>
        ///     Atualiza ficha piscina da aplicação
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
        public IActionResult Update([FromBody] FichaPiscinaDTO fichaPiscina, [FromQuery] int id)
        {
            var type = GetJwt().FirstOrDefault(c => c.Type == "typ")?.Value!;

            var isTecnico = VerifyUser.IsTecnico(type);

            if (isTecnico.IsError)
            {
                return Problem(isTecnico.Errors);
            }

            var fichaPiscinaMapeada = _mapper.Map<FichaPiscina>(fichaPiscina);

            fichaPiscinaMapeada.Id = id;

            _fichaPiscinaRepository.Update(fichaPiscinaMapeada);

            return Ok();
        }

        /// <summary>
        ///     Deleta ficha piscina da aplicação
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

            await _fichaPiscinaRepository.Delete(id);

            return Ok();
        }
    }
}
