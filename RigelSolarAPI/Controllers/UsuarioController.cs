﻿using AutoMapper;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using RigelSolarAPI.Dto;
using RigelSolarAPI.Models;
using RigelSolarAPI.Repositories;
using RigelSolarAPI.Utils;

namespace RigelSolarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ApiController
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

        /// <summary>
        ///     Retorna os usuários da aplicação
        /// </summary>
        /// 
        /// 
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        /// 
        /// <returns> Clientes </returns>
        /// 
        [HttpGet]
        [ProducesResponseType(typeof(List<GetUsuarioDTO>), StatusCodes.Status200OK)]
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

            var usuarios = _usuarioRepository.GetAll();

            var mappedUsuarios = _mapper.Map<List<GetUsuarioDTO>>(usuarios);

            return Ok(mappedUsuarios);
        }

        /// <summary>
        ///     Cria usuários da aplicação
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
        public IActionResult Create(UsuarioDTO usuario)
        {
            var type = GetJwt().FirstOrDefault(c => c.Type == "typ")?.Value!;

            var isCoordenador = VerifyUser.IsCoordenador(type);

            if (isCoordenador.IsError)
            {
                return Problem(isCoordenador.Errors);
            }

            var usuarioMapeado = _mapper.Map<Usuario>(usuario);

            _usuarioRepository.Add(usuarioMapeado);

            return Ok();
        }

        /// <summary>
        ///     Atualiza os usuários da aplicação
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
        public IActionResult Update(UsuarioDTO usuario)
        {
            var type = GetJwt().FirstOrDefault(c => c.Type == "typ")?.Value!;

            var isCoordenador = VerifyUser.IsCoordenador(type);

            if (isCoordenador.IsError)
            {
                return Problem(isCoordenador.Errors);
            }

            var usuarioMapeado = _mapper.Map<Usuario>(usuario);

            _usuarioRepository.Update(usuarioMapeado);

            return Ok();
        }

        /// <summary>
        ///     Deleta os usuários da aplicação
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

            await _usuarioRepository.Delete(id);

            return Ok();
        }
    }
}
