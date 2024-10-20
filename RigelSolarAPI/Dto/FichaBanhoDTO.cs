﻿using RigelSolarAPI.Models;

namespace RigelSolarAPI.Dto;

public class FichaBanhoDTO
{
    public decimal BaseCaixa { get; set; }

    public decimal BaseBoiler { get; set; }

    public decimal DistanciaBoiler { get; set; }

    public decimal RegistroCaixa { get; set; }

    public decimal RegistroBarrilete { get; set; }

    public decimal DisjuntorBipolar { get; set; }

    public int? IdVistoria { get; set; }
}

public class GetFichaBanhoDTO : FichaBanhoDTO
{
    public int Id { get; set; }
    public virtual GetVistoriaFichaDTO? VistoriaDTO { get; set; }
}
