using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiDgii.Models;

public partial class Contribuyente
{
    public string RncCedula { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Tipo { get; set; }

    public string? Estatus { get; set; }

    [JsonIgnore]

    public virtual ICollection<ComprobantesFiscale> ComprobantesFiscales { get; set; } = new List<ComprobantesFiscale>();

    //public virtual ComprobantesFiscale? oComprobante { get; set; } 
}
