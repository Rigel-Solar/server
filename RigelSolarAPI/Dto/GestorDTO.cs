using RigelSolarAPI.Models;

namespace RigelSolarAPI.Dto;

public class GestorDTO
{
    public int Id { get; set; }

    public int? IdUsuario { get; set; }

    public virtual UsuarioDTO? IdUsuarioNavigation { get; set; }
}
