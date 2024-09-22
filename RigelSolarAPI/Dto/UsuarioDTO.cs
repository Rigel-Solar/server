namespace RigelSolarAPI.Dto;

public class UsuarioDTO
{
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Senha { get; set; }
}

public class GetUsuarioDTO : UsuarioDTO
{
    public int Id { get; set; }
}

