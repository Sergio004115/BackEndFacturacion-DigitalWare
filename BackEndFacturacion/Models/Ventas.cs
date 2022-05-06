using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndFacturacion.Models
{
    public class Ventas
    {
        public string Cliente { get; set; }
        public int IdProducto { get; set; }
        public int CodigoProducto { get; set; }
        public int CantidadProducto { get; set; }
        public int TotalVenta { get; set; }
        
    }
}