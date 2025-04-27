using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIPo
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public DateTime FechaUltimoAcceso { get; set; }

        public Usuario(string Nombre, string apellidos, string correo, string nombreUsuario, string contraseña) {


            this.Nombre = Nombre;
            this.Apellidos = apellidos;
            this.Correo = correo;
            this.NombreUsuario = nombreUsuario;
            this.Contraseña = contraseña;
            FechaUltimoAcceso = DateTime.Now; // Inicializa la fecha de último acceso al momento de la creación
        }

    }

    public static class DatosApp
    {
        // Diccionario de usuarios, donde la clave es el nombre de usuario y el valor es un objeto Usuario
        public static Dictionary<string, Usuario> Usuarios = new Dictionary<string, Usuario>();

        // Otros diccionarios y propiedades
        public static ObservableCollection<Festival> Festivales { get; set; } = new ObservableCollection<Festival>();
        public static DateTime FechaFestivalAct { get; set; }
        public static int DuracionFestivalAct { get; set; }
        public static ObservableCollection<Artista> Artistas { get; set; } = new ObservableCollection<Artista>();
        public static ObservableCollection<Escenario> Escenarios { get; set; } = new ObservableCollection<Escenario>();
    }




}
