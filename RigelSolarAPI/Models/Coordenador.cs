using System;
using System.Collections.Generic;

namespace RigelSolarAPI.Models;

public partial class Coordenador
{
    public int Id { get; set; }

    public int? IdTecnico { get; set; }

    public int? IdGestor { get; set; }

    public virtual Gestor? IdGestorNavigation { get; set; }

    public virtual Tecnico? IdTecnicoNavigation { get; set; }

}
