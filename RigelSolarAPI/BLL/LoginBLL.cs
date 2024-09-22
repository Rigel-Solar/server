using ErrorOr;
using RigelSolarAPI.Models;
using RigelSolarAPI.Repositories;
using RigelSolarAPI.Utils;

namespace RigelSolarAPI.BLL;

public class LoginBLL
{
    private readonly GestorRepository _gestorRepository;
    private readonly TecnicoRepository _tecnicoRepository;
    private readonly CoordenadorRepository _coordenadorRepository;
    private readonly GenerateJwt _generateJwt;
    private readonly Encrypt _encrypt;

    public LoginBLL
    (
        GestorRepository gestorRepository,
        TecnicoRepository tecnicoRepository,
        CoordenadorRepository coordenadorRepository,
        GenerateJwt generateJwt,
        Encrypt encrypt
    )
    {
        _gestorRepository = gestorRepository;
        _tecnicoRepository = tecnicoRepository;
        _coordenadorRepository = coordenadorRepository;
        _generateJwt = generateJwt;
        _encrypt = encrypt;
    }

    public async Task<ErrorOr<TokenResponse>> Handle(LoginRequest login)
    {
        var coordenador = await _coordenadorRepository.VerDadosPorEmail(login.Email);

        if (coordenador is not null)
        {
            var matchedPassword = _encrypt.Verify(coordenador.IdTecnicoNavigation.IdUsuarioNavigation.Senha, login.Password);
            
            return GenerateToken(coordenador, matchedPassword);
        }

        var tecnico = await _tecnicoRepository.VerDadosPorEmail(login.Email);

        if (tecnico is not null)
        {
            var matchedPassword = _encrypt.Verify(tecnico.IdUsuarioNavigation.Senha, login.Password);

            return GenerateToken(tecnico, matchedPassword);
        }

        var gestor = await _gestorRepository.VerDadosPorEmail(login.Email);

        if (gestor is not null)
        {
            var matchedPassword = _encrypt.Verify(gestor.IdUsuarioNavigation.Senha, login.Password);

            return GenerateToken(gestor, matchedPassword);
        }

        return Errors.Errors.CredenciaisInvalidas;
    }

    private ErrorOr<TokenResponse> GenerateToken(Coordenador coordenador, bool matchedPassword)
    {
        if (matchedPassword)
        {
            var coordenadorToken = _generateJwt.GenerateToken(coordenador);

            return coordenadorToken;
        }

        return Errors.Errors.CredenciaisInvalidas;
    }

    private ErrorOr<TokenResponse> GenerateToken(Tecnico tecnico, bool matchedPassword)
    {
        if (matchedPassword)
        {
            var tecnicoToken = _generateJwt.GenerateToken(tecnico);

            return tecnicoToken;
        }

        return Errors.Errors.CredenciaisInvalidas;
    }

    private ErrorOr<TokenResponse> GenerateToken(Gestor gestor, bool matchedPassword)
    {
        if (matchedPassword)
        {
            var gestorToken = _generateJwt.GenerateToken(gestor);

            return gestorToken;
        }

        return Errors.Errors.CredenciaisInvalidas;
    }
}
