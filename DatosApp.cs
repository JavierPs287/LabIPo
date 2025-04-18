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
        public static ObservableCollection<Artista> Artistas { get; set; } = new ObservableCollection<Artista>();
        public static ObservableCollection<Escenario> Escenarios { get; set; } = new ObservableCollection<Escenario>();
    }
}
