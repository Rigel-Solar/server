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
        public IActionResult Get()
        {
            var type = GetJwt().FirstOrDefault(c => c.Type == "typ")?.Value!;

            var isTecnico = VerifyUser.IsTecnico(type);

            if (isTecnico.IsError)
            {
                return Problem(isTecnico.Errors);
            }

            int tecnicoId = int.Parse(GetJwt().FirstOrDefault(c => c.Type == "sub")?.Value!);

            var fichasFotovoltaico = _fichaFotovoltaicoRepository.GetAllByTecnicoId(tecnicoId);

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
        public IActionResult Update(FichaFotovoltaicoDTO fichaFotovoltaico)
        {
            var type = GetJwt().FirstOrDefault(c => c.Type == "typ")?.Value!;

            var isTecnico = VerifyUser.IsTecnico(type);

            if (isTecnico.IsError)
            {
                return Problem(isTecnico.Errors);
            }

            var fichaFotovoltaicoMapeada = _mapper.Map<FichaFotovoltaico>(fichaFotovoltaico);

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
