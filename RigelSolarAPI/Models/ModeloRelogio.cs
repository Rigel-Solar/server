using System;
using System.Collections.Generic;

namespace RigelSolarAPI.Models;

public partial class ModeloRelogio
{
    public int Id { get; set; }

    public string Modelo { get; set; } = null!;

    public virtual FichaFotovoltaico? FichaFotovoltaico { get; set; }
}
