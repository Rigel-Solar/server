using ErrorOr;
using RigelSolarAPI.Models;
using RigelSolarAPI.Repositories;
using RigelSolarAPI.Utils;

namespace RigelSolarAPI.BLL;

public class CadastrarBLL
{
    private readonly UsuarioRepository _usuarioRepository;

    public CadastrarBLL
    (
        UsuarioRepository usuarioRepository
    )
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<ErrorOr<bool>> Handle(string email)
    {
        var usuario = await _usuarioRepository.VerDadosPorEmail(email);

        if (usuario is not null)
        {
            return Errors.Errors.UsuarioJaCadastrado;
        }

        return false;
    }
}
