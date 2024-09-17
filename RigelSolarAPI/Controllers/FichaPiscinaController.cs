using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RigelSolarAPI.Dto;
using RigelSolarAPI.Models;
using RigelSolarAPI.Repositories;

namespace RigelSolarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FichaPiscinaController : ControllerBase
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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_fichaPiscinaRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create(FichaPiscinaDTO fichaPiscina)
        {
            var fichaPiscinaMapeada = _mapper.Map<FichaPiscina>(fichaPiscina);

            _fichaPiscinaRepository.Add(fichaPiscinaMapeada);

            return Ok();
        }

        [HttpPut]
        public IActionResult Update(FichaPiscinaDTO fichaPiscina)
        {
            var fichaPiscinaMapeada = _mapper.Map<FichaPiscina>(fichaPiscina);

            _fichaPiscinaRepository.Update(fichaPiscinaMapeada);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _fichaPiscinaRepository.Delete(id);
            return Ok();
        }
    }
}
