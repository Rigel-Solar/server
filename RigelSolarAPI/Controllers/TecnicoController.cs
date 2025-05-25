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
    public class TecnicoController : ApiController
    {
        private readonly TecnicoRepository _tecnicoRepository;
        private readonly IMapper _mapper;

        public TecnicoController(
            TecnicoRepository tecnicoRepository,
            IMapper mapper
        ) 
        {
            _tecnicoRepository = tecnicoRepository;
            _mapper = mapper;
        }

        /// <summary>
        ///     Retorna os técnicos da aplicação
        /// </summary>
        /// 
        /// 
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        /// 
        /// <returns> Clientes </returns>
        /// 
        [HttpGet]
        [ProducesResponseType(typeof(List<GetTecnicoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public IActionResult Get() 
        {
            var type = GetJwt().FirstOrDefault(c => c.Type == "typ")?.Value!;

            var isGestor = VerifyUser.IsGestor(type);

            var isCoordenador = VerifyUser.IsCoordenador(type);

            if (isGestor.IsError && isCoordenador.IsError)
            {
                return Problem(isGestor.Errors);
            }

            var tecnicos = _tecnicoRepository.GetAll();

            var mappedTecnicos = _mapper.Map<List<GetTecnicoDTO>>(tecnicos);

            return Ok(mappedTecnicos);
        }

        /// <summary>
        ///     Cria técnico da aplicação
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
        public IActionResult Create(TecnicoDTO tecnico)
        {
            var type = GetJwt().FirstOrDefault(c => c.Type == "typ")?.Value!;

            var isCoordenador = VerifyUser.IsCoordenador(type);

            if (isCoordenador.IsError)
            {
                return Problem(isCoordenador.Errors);
            }

            var tecnicoMapeado = _mapper.Map<Tecnico>(tecnico);

            var usuarioMapeado = _mapper.Map<Usuario>(tecnico.Usuario);

            tecnicoMapeado.IdUsuarioNavigation = usuarioMapeado;
            
            _tecnicoRepository.Add(tecnicoMapeado);

            return Ok();
        }

        /// <summary>
        ///     Atualiza os técnicos da aplicação
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
        public IActionResult Update([FromBody] TecnicoDTO tecnico, [FromQuery] int id)
        {
            var type = GetJwt().FirstOrDefault(c => c.Type == "typ")?.Value!;

            var isCoordenador = VerifyUser.IsCoordenador(type);

            if (isCoordenador.IsError)
            {
                return Problem(isCoordenador.Errors);
            }

            var tecnicoMapeado = _mapper.Map<Tecnico>(tecnico);

            tecnicoMapeado.Id = id;

            _tecnicoRepository.Update(tecnicoMapeado);

            return Ok();
        }

        /// <summary>
        ///     Deleta os técnicos da aplicação
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

            var isCoordenador = VerifyUser.IsCoordenador(type);

            if (isCoordenador.IsError)
            {
                return Problem(isCoordenador.Errors);
            }

            await  _tecnicoRepository.Delete(id);

            return Ok();
        }
    }
}
