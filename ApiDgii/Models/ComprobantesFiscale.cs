using System;
using System.Collections.Generic;

namespace ApiDgii.Models;

public partial class ComprobantesFiscale
{
    public int Id { get; set; }

    public string? RncCedula { get; set; }

    public string? Ncf { get; set; }

    public decimal? Monto { get; set; }

    public decimal? Itbis18 { get; set; }

    public virtual Contribuyente? RncCedulaNavigation { get; set; }
}
