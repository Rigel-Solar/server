using System;
using System.Collections.Generic;

namespace RigelSolarAPI.Models;

public partial class Gestor
{
    public int Id { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Coordenador? Coordenador { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
