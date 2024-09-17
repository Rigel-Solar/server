namespace RigelSolarAPI.Dto;

public class TecnicoDTO
{
    public int Id { get; set; }

    public string Crea { get; set; } = null!;
    public UsuarioDTO? Usuario { get; set; }
}
