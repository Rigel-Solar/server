using System;
using System.Collections.Generic;

namespace RigelSolarAPI.Models;

public partial class TipoCliente
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual FichaFotovoltaico? FichaFotovoltaico { get; set; }
}
