using System;
using System.Collections.Generic;

namespace InmobilariaReal.Models
{
    public partial class Reporte
    {
        public int IdReporte { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
    }
}
