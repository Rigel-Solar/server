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
    public class FichaFotovoltaicoController : ApiController
    {
        private readonly FichaFotovoltaicoRepository _fichaFotovoltaicoRepository;
        private readonly IMapper _mapper;

        public FichaFotovoltaicoController(
            FichaFotovoltaicoRepository fichaFotovoltaicoRepository,
            IMapper mapper
        )
        {
            _fichaFotovoltaicoRepository = fichaFotovoltaicoRepository;
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
            var fichas = _fichaFotovoltaicoRepository.GetAll();

            var mappedFichas = _mapper.Map<List<GetFichaFotovoltaicoDTO>>(fichas);

            return Ok(mappedFichas);
        }

        /// <summary>
        ///     Retorna ficha fotovoltaico da aplicação
        /// </summary>
        /// 
        /// 
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        /// 
        /// <returns> Clientes </returns>
        /// 
        [HttpGet]
        [ProducesResponseType(typeof(List<GetFichaFotovoltaicoDTO>), StatusCodes.Status200OK)]
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

            var fichasFotovoltaico = await _fichaFotovoltaicoRepository.GetAllByTecnicoId(tecnicoId);

            var mappedFichasFotovoltaico = _mapper.Map<List<GetFichaFotovoltaicoDTO>>(fichasFotovoltaico);

            return Ok(mappedFichasFotovoltaico);
        }

        /// <summary>
        ///     Cria ficha fotovoltaico da aplicação
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
        public IActionResult Create(FichaFotovoltaicoDTO fichaFotovoltaico)
        {
            var type = GetJwt().FirstOrDefault(c => c.Type == "typ")?.Value!;

            var isTecnico = VerifyUser.IsTecnico(type);

            if (isTecnico.IsError)
            {
                return Problem(isTecnico.Errors);
            }

            var fichaFotovoltaicoMapeada = _mapper.Map<FichaFotovoltaico>(fichaFotovoltaico);

            _fichaFotovoltaicoRepository.Add(fichaFotovoltaicoMapeada);

            return Ok();
        }

        /// <summary>
        ///     Atualiza ficha fotovoltaico da aplicação
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
        public IActionResult Update([FromBody] FichaFotovoltaicoDTO fichaFotovoltaico, [FromQuery] int id)
        {
            var type = GetJwt().FirstOrDefault(c => c.Type == "typ")?.Value!;

            var isTecnico = VerifyUser.IsTecnico(type);

            if (isTecnico.IsError)
            {
                return Problem(isTecnico.Errors);
            }

            var fichaFotovoltaicoMapeada = _mapper.Map<FichaFotovoltaico>(fichaFotovoltaico);

            fichaFotovoltaicoMapeada.Id = id;

            _fichaFotovoltaicoRepository.Update(fichaFotovoltaicoMapeada);

            return Ok();
        }

        /// <summary>
        ///     Deleta ficha fotovoltaico da aplicação
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
            await _fichaFotovoltaicoRepository.Delete(id);

            return Ok();
        }
    }
}
