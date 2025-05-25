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
    public class VistoriaController : ApiController
    {
        private readonly VistoriaRepository _vistoriaRepository;
        private readonly IMapper _mapper;

        public VistoriaController(
            VistoriaRepository vistoriaRepository,
            IMapper mapper
        )
        {
            _vistoriaRepository = vistoriaRepository;
            _mapper = mapper;
        }

        /// <summary>
        ///     Retorna as vistorias da aplicação
        /// </summary>
        /// 
        /// 
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        /// 
        /// <returns> Clientes </returns>
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
            var vistorias = _vistoriaRepository.GetAll();
            
            var mappedVistorias = _mapper.Map<List<GetVistoriaDTO>>(vistorias);

            return Ok(mappedVistorias);
        }

        /// <summary>
        ///     Retorna as vistorias de um técnico da aplicação
        /// </summary>
        /// 
        /// 
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        /// 
        /// <returns> Clientes </returns>
        /// 
        [HttpGet("getByTecnicoId")]
        [ProducesResponseType(typeof(List<GetVistoriaDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByTecnicoId()
        {
            var type = GetJwt().FirstOrDefault(c => c.Type == "typ")?.Value!;

            var isTecnico = VerifyUser.IsTecnico(type);

            if (isTecnico.IsError)
            {
                return Problem(isTecnico.Errors);
            }

            int tecnicoId = int.Parse(GetJwt().FirstOrDefault(c => c.Type == "idTecnico")?.Value!);
            
            var vistorias = await _vistoriaRepository.GetAllByTecnicoId(tecnicoId);

            var mappedVistorias = _mapper.Map<List<GetVistoriaDTO>>(vistorias);

            return Ok(mappedVistorias);
        }

        /// <summary>
        ///     Cria as vistorias da aplicação
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
        public IActionResult Create(VistoriaDTO vistoria)
        {
            var type = GetJwt().FirstOrDefault(c => c.Type == "typ")?.Value!;

            var isGestor = VerifyUser.IsGestor(type);

            var isCoordenador = VerifyUser.IsCoordenador(type);

            if (isGestor.IsError && isCoordenador.IsError)
            {
                return Problem(isGestor.Errors);
            }

            var idGestor = GetJwt().FirstOrDefault(c => c.Type == "idGestor")?.Value!;

            var mappedVistoria = _mapper.Map<Vistorium>(vistoria);

            mappedVistoria.IdGestor = int.Parse(idGestor);

            _vistoriaRepository.Add(mappedVistoria);

            return Ok();
        }

        /// <summary>
        ///     Atualiza as vistorias da aplicação
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
        public IActionResult Update([FromBody] VistoriaDTO vistoria, [FromQuery] int id)
        {
            var type = GetJwt().FirstOrDefault(c => c.Type == "typ")?.Value!;

            var isGestor = VerifyUser.IsGestor(type);

            var isCoordenador = VerifyUser.IsCoordenador(type);

            if (isGestor.IsError && isCoordenador.IsError)
            {
                return Problem(isGestor.Errors);
            }

            var mappedVistoria = _mapper.Map<Vistorium>(vistoria);

            mappedVistoria.Id = id;

            _vistoriaRepository.Update(mappedVistoria);

            return Ok();
        }

        /// <summary>
        ///     Deleta as vistorias da aplicação
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

            var isGestor = VerifyUser.IsGestor(type);

            var isCoordenador = VerifyUser.IsCoordenador(type);

            if (isGestor.IsError && isCoordenador.IsError)
            {
                return Problem(isGestor.Errors);
            }

            await _vistoriaRepository.Delete(id);

            return Ok();
        }
    }
}
