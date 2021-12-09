using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solicitud_Fondos_Avance_API
{
    public class Producto
    {
        public int codProducto { get; set; }
        public string nombre { get; set; }
        public bool vigente { get; set; }
        public string clienteAsociado { get; set; }
    }
}
