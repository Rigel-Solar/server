using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RigelSolarAPI.Dto;
using RigelSolarAPI.Models;
using RigelSolarAPI.Repositories;

namespace RigelSolarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FichaFotovoltaicoController : ControllerBase
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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_fichaFotovoltaicoRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create(FichaFotovoltaicoDTO fichaFotovoltaico)
        {
            var fichaFotovoltaicoMapeada = _mapper.Map<FichaFotovoltaico>(fichaFotovoltaico);

            _fichaFotovoltaicoRepository.Add(fichaFotovoltaicoMapeada);

            return Ok();
        }

        [HttpPut]
        public IActionResult Update(FichaFotovoltaicoDTO fichaFotovoltaico)
        {
            var fichaFotovoltaicoMapeada = _mapper.Map<FichaFotovoltaico>(fichaFotovoltaico);

            _fichaFotovoltaicoRepository.Update(fichaFotovoltaicoMapeada);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _fichaFotovoltaicoRepository.Delete(id);
            return Ok();
        }
    }
}
