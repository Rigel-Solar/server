using System;
using System.Collections.Generic;

namespace RigelSolarAPI.Models;

public partial class TensaoNominal
{
    public int Id { get; set; }

    public string Tensao { get; set; } = null!;

    public virtual FichaFotovoltaico? FichaFotovoltaico { get; set; }
}
