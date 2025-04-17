using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIPo
{
    public static class DatosApp
    {
        // Diccionario estático para almacenar usuarios y contraseñas
        public static Dictionary<string, string> UsuariosYContraseñas = new Dictionary<string, string>();
        public static ObservableCollection<Festival> Festivales { get; set; } = new ObservableCollection<Festival>();
        public static DateTime FechaFestivalAct { get; set; }
        public static int DuracionFestivalAct { get; set; }
    }
}
