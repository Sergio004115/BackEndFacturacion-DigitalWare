using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndFacturacion.Models
{
    public class Clientes
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Telefono { get; set; }
        public string TipoIdentificacion { get; set; }
        public int NroIdentificacion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string DireccionResidencia { get; set; }
    }
}