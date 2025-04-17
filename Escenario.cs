using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ProyectoIPo
{
    public class Escenario
    {
        public string Nombre { get; set; }
        public string AforoMax { get; set; }
        public string LocalizacionEntradasSalidas { get; set; }
        public string ServiciosMedicos { get; set; }
        public string Aseos { get; set; }
        public string Seguridad { get; set; }
        public DateTime DiaHoraActuacion { get; set; } // Día y hora de la actuación
        public string FotoPath { get; set; } // Ruta de la foto
    }

}
