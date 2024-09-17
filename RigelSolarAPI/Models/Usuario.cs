using System;
using System.Collections.Generic;

namespace RigelSolarAPI.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Senha { get; set; }

    public virtual Gestor? Gestor { get; set; }

    public virtual Tecnico? Tecnico { get; set; }
}
