﻿namespace RigelSolarAPI.Dto;

public class UsuarioDTO
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Senha { get; set; }
}
