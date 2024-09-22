namespace RigelSolarAPI.Dto;

public class TecnicoDTO
{
    public string Crea { get; set; } = null!;
    public GetUsuarioDTO? Usuario { get; set; }
}

public class GetTecnicoDTO : TecnicoDTO 
{
    public int Id { get; set; }
}