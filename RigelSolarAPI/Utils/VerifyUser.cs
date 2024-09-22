using ErrorOr;

namespace RigelSolarAPI.Utils;

public class VerifyUser
{
    public static ErrorOr<bool> IsCoordenador(string tipo)
    {
        var _coordenador = "coordenador";
        if (tipo == _coordenador)
            return true;
        else return Errors.Errors.NivelDeAcessoIncompativel;
    }

    public static ErrorOr<bool> IsGestor(string tipo)
    {
        var _gestor = "gestor";
        if (tipo == _gestor)
            return true;
        else return Errors.Errors.NivelDeAcessoIncompativel;
    }

    public static ErrorOr<bool> IsTecnico(string tipo)
    {
        var _tecnico = "tecnico";
        if (tipo == _tecnico)
            return true;
        else return Errors.Errors.NivelDeAcessoIncompativel;
    }
}
