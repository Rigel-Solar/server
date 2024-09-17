using System;
using System.Collections.Generic;

namespace RigelSolarAPI.Models;

public partial class NivelamentoSolo
{
    public int Id { get; set; }

    public string Nivelamento { get; set; } = null!;

    public virtual FichaFotovoltaico? FichaFotovoltaico { get; set; }
}
