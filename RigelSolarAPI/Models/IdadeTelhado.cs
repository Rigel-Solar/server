using System;
using System.Collections.Generic;

namespace RigelSolarAPI.Models;

public partial class IdadeTelhado
{
    public int Id { get; set; }

    public int Idade { get; set; }

    public virtual FichaFotovoltaico? FichaFotovoltaico { get; set; }
}
