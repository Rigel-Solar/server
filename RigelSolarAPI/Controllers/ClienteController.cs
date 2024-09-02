using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RigelSolarAPI.Dto;
using RigelSolarAPI.Models;
using RigelSolarAPI.Repositories;

namespace RigelSolarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
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

        [HttpGet]
        public IActionResult Get() 
        {
            return Ok(_clienteRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create(ClienteDTO cliente)
        {
            var clienteMapeado = _mapper.Map<Cliente>(cliente);
            _clienteRepository.Add(clienteMapeado);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(ClienteDTO cliente)
        {
            var clienteMapeado = _mapper.Map<Cliente>(cliente);
            _clienteRepository.Update(clienteMapeado);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await  _clienteRepository.Delete(id);
            return Ok();
        }
    }
}
