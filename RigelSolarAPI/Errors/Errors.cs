using ErrorOr;

namespace RigelSolarAPI.Errors;

public static class Errors
{
    public static Error CredenciaisInvalidas => Error.Unauthorized(
        code: "Usuario.CredenciaisInvalidas",
        description: "Credenciais Inválidas"
    );

    public static Error UsuarioJaCadastrado => Error.Validation(
        code: "Usuario.UsuarioJaCadastrado",
        description: "Usuario já cadastrado"
    );

    public static Error NivelDeAcessoIncompativel => Error.Forbidden(
        code: "Usuario.NivelDeAcessoIncompativel",
        description: "Nível De Acesso Incompatível"
    );
}