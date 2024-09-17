using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RigelSolarAPI.Dto;
using RigelSolarAPI.Models;
using RigelSolarAPI.Repositories;

namespace RigelSolarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FichaBanhoController : ControllerBase
    {
        private readonly FichaBanhoRepository _fichaBanhoRepository;
        private readonly IMapper _mapper;

        public FichaBanhoController(
            FichaBanhoRepository fichaBanhoRepository,
            IMapper mapper
        )
        {
            _fichaBanhoRepository = fichaBanhoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_fichaBanhoRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create(FichaBanhoDTO fichaBanho)
        {
            var fichaBanhoMapeada = _mapper.Map<FichaBanho>(fichaBanho);

            _fichaBanhoRepository.Add(fichaBanhoMapeada);

            return Ok();
        }

        [HttpPut]
        public IActionResult Update(FichaBanhoDTO fichaBanho)
        {
            var fichaBanhoMapeada = _mapper.Map<FichaBanho>(fichaBanho);

            _fichaBanhoRepository.Update(fichaBanhoMapeada);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _fichaBanhoRepository.Delete(id);
            return Ok();
        }
    }
}
