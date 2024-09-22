using Microsoft.IdentityModel.Tokens;
using RigelSolarAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RigelSolarAPI.Utils;

public class GenerateJwt
{
    private readonly JwtConfig _jwtSettings;
    private readonly string _tecnico = "tecnico";
    private readonly string _coordenador = "coordenador";
    private readonly string _gestor = "gestor";

    public GenerateJwt(
        JwtConfig jwtOptions)
    {
        _jwtSettings = jwtOptions;
    }

    public TokenResponse GenerateToken(Tecnico tecnico)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.SecretKey)
            ),
            SecurityAlgorithms.HmacSha256
        );

        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Sub, tecnico.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, tecnico.Crea),
                new Claim(JwtRegisteredClaimNames.Typ, _tecnico),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationTimeInMinutes),
            claims: claims,
            signingCredentials: signingCredentials);

        return new TokenResponse
        {
            Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
            ExpiresIn = _jwtSettings.ExpirationTimeInMinutes,
            UserAccess = UserAccessLevel.Tecnico
        };
    }

    public TokenResponse GenerateToken(Gestor gestor)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.SecretKey)
            ),
            SecurityAlgorithms.HmacSha256
        );

        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Sub, gestor.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, gestor.IdUsuarioNavigation.Nome),
                new Claim(JwtRegisteredClaimNames.Typ, _gestor),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationTimeInMinutes),
            claims: claims,
            signingCredentials: signingCredentials);

        return new TokenResponse
        {
            Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
            ExpiresIn = _jwtSettings.ExpirationTimeInMinutes,
            UserAccess = UserAccessLevel.Gestor
        };
    }

    public TokenResponse GenerateToken(Coordenador coordenador)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.SecretKey)
            ),
            SecurityAlgorithms.HmacSha256
        );

        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Sub, coordenador.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, coordenador.IdTecnicoNavigation.IdUsuarioNavigation.Nome),
                new Claim(JwtRegisteredClaimNames.Typ, _coordenador),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationTimeInMinutes),
            claims: claims,
            signingCredentials: signingCredentials);

        return new TokenResponse
        {
            Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
            ExpiresIn = _jwtSettings.ExpirationTimeInMinutes,
            UserAccess = UserAccessLevel.Coordenador
        };
    }
}