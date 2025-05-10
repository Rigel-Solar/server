namespace RigelSolarAPI.Dto;

public class UploadFotosDTO
{
    public List<IFormFile> Fotos { get; set; }
    public int CodigoFicha { get; set; }
    public int TipoFicha { get; set; }
}
