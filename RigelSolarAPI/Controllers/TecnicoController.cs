using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RigelSolarAPI.Dto;
using RigelSolarAPI.Models;
using RigelSolarAPI.Repositories;

namespace RigelSolarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnicoController : ControllerBase
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

        [HttpGet]
        public IActionResult Get() 
        {
            return Ok(_tecnicoRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create(TecnicoDTO tecnico)
        {
            var tecnicoMapeado = _mapper.Map<Tecnico>(tecnico);

            var usuarioMapeado = _mapper.Map<Usuario>(tecnico.Usuario);

            tecnicoMapeado.IdUsuarioNavigation = usuarioMapeado;
            
            _tecnicoRepository.Add(tecnicoMapeado);

            return Ok();
        }

        [HttpPut]
        public IActionResult Update(TecnicoDTO tecnico)
        {
            var tecnicoMapeado = _mapper.Map<Tecnico>(tecnico);

            _tecnicoRepository.Update(tecnicoMapeado);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await  _tecnicoRepository.Delete(id);
            return Ok();
        }
    }
}
