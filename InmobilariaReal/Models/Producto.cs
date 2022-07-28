using System;
using System.Collections.Generic;

namespace InmobilariaReal.Models
{
    public partial class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; } = null!;
        public int Precio { get; set; }
        public int CantPieza { get; set; }
        public int CantBano { get; set; }
        public int Idcategoria { get; set; }

        public virtual Categorium oCategoria { get; set; } = null!;
    }
}
