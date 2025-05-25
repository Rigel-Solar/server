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
    public class ClienteController : ApiController
    {
        private readonly ClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteController(
            ClienteRepository clienteRepository,
            IMapper mapper
            ) 
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        /// <summary>
        ///     Retorna os clientes da aplicação
        /// </summary>
        /// 
        /// 
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        /// 
        /// <returns> Clientes </returns>
        /// 
        [HttpGet]
        [ProducesResponseType(typeof(List<GetClienteDTO>), StatusCodes.Status200OK)]
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

            var clientes = _clienteRepository.GetAll();

            var mappedClientes = _mapper.Map<List<GetClienteDTO>>(clientes);

            return Ok(mappedClientes);
        }

        /// <summary>
        ///     Cria os clientes da aplicação
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
        public IActionResult Create(ClienteDTO cliente)
        {
            var type = GetJwt().FirstOrDefault(c => c.Type == "typ")?.Value!;

            var isGestor = VerifyUser.IsGestor(type);

            var isCoordenador = VerifyUser.IsCoordenador(type);

            if (isGestor.IsError && isCoordenador.IsError)
            {
                return Problem(isGestor.Errors);
            }

            var clienteMapeado = _mapper.Map<Cliente>(cliente);

            _clienteRepository.Add(clienteMapeado);

            return Ok();
        }

        /// <summary>
        ///     Atualiza os clientes da aplicação
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
        public IActionResult Update([FromBody] ClienteDTO cliente, [FromQuery] int id)
        {
            var type = GetJwt().FirstOrDefault(c => c.Type == "typ")?.Value!;

            var isGestor = VerifyUser.IsGestor(type);

            var isCoordenador = VerifyUser.IsCoordenador(type);
        
            if (isGestor.IsError && isCoordenador.IsError)
            {
                return Problem(isGestor.Errors);
            }

            var clienteMapeado = _mapper.Map<Cliente>(cliente);

            clienteMapeado.Id = id;

            _clienteRepository.Update(clienteMapeado);

            return Ok();
        }

        /// <summary>
        ///     Deleta os clientes da aplicação
        /// </summary>
        /// 
        /// 
        /// <response code="204">Sucesso</response>
        /// <response code="400">Erro</response>
        /// 
        /// <returns> Ok </returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var type = GetJwt().FirstOrDefault(c => c.Type == "typ")?.Value!;

            var isGestor = VerifyUser.IsGestor(type);

            var isCoordenador = VerifyUser.IsCoordenador(type);

            if (isGestor.IsError && isCoordenador.IsError)
            {
                return Problem(isGestor.Errors);
            }

            await  _clienteRepository.Delete(id);

            return Ok();
        }
    }
}
