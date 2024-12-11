using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIPo
{
    public class Festival
    {
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Ubicacion { get; set; }
        public List<Artista> Artistas { get; set; } // Lista de artistas del festival

    public Festival() { }

        public Festival(string nombre, DateTime fecha, string ubicacion, List<Artista> artistas)
        {
            Nombre = nombre;
            Fecha = fecha;
            Ubicacion = ubicacion;
            Artistas = artistas;
        }

        public void AgregarArtista(Artista artista)
        {
            Artistas.Add(artista);
        }

        public void EliminarArtista(Artista artista)
        {
            Artistas.Remove(artista);
        }
    }

    public class Artista
    {
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public string Genero { get; set; }
        public string Biografia { get; set; }
        public List<KeyValuePair<string, string>> RedesSociales { get; set; } = new List<KeyValuePair<string, string>>();

        public Artista() { }

        public Artista(string nombre, string imagen, string genero, string biografia, List<KeyValuePair<string, string>> redesSociales)
        {
            Nombre = nombre;
            Imagen = imagen;
            Genero = genero;
            Biografia = biografia;
            RedesSociales = redesSociales;
        }
    }


}
