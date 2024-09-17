using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RigelSolarAPI.Dto;
using RigelSolarAPI.Models;
using RigelSolarAPI.Repositories;

namespace RigelSolarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioController(
            UsuarioRepository usuarioRepository,
            IMapper mapper
        )
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuarioRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create(UsuarioDTO usuario)
        {
            var usuarioMapeado = _mapper.Map<Usuario>(usuario);

            _usuarioRepository.Add(usuarioMapeado);

            return Ok();
        }

        [HttpPut]
        public IActionResult Update(UsuarioDTO usuario)
        {
            var usuarioMapeado = _mapper.Map<Usuario>(usuario);

            _usuarioRepository.Update(usuarioMapeado);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _usuarioRepository.Delete(id);
            return Ok();
        }
    }
}
