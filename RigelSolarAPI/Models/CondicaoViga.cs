using System;
using System.Collections.Generic;

namespace RigelSolarAPI.Models;

public partial class CondicaoViga
{
    public int Id { get; set; }

    public string Condicao { get; set; } = null!;

    public virtual FichaFotovoltaico? FichaFotovoltaico { get; set; }
}
