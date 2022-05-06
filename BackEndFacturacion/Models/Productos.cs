using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndFacturacion.Models
{
    public class Productos
    {
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int Existencia { get; set; }
    }
}