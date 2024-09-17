using System;
using System.Collections.Generic;

namespace RigelSolarAPI.Models;

public partial class TelhadoAcesso
{
    public int Id { get; set; }

    public string Acesso { get; set; } = null!;

    public virtual FichaFotovoltaico? FichaFotovoltaico { get; set; }
}
