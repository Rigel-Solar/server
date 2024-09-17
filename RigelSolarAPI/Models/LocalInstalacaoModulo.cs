using System;
using System.Collections.Generic;

namespace RigelSolarAPI.Models;

public partial class LocalInstalacaoModulo
{
    public int Id { get; set; }

    public string Local { get; set; } = null!;

    public virtual FichaFotovoltaico? FichaFotovoltaico { get; set; }
}
