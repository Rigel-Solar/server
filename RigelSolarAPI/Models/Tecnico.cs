﻿using System;
using System.Collections.Generic;

namespace RigelSolarAPI.Models;

public partial class Tecnico
{
    public int Id { get; set; }

    public string Crea { get; set; } = null!;

    public int? IdUsuario { get; set; }

    public virtual Coordenador? Coordenador { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Vistorium> Vistoria { get; set; } = new List<Vistorium>();
}
