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
        public List<String> Artistas { get; set; } // Lista de artistas del festival
        public string ArtistasTexto => string.Join(", ", Artistas);

        public Festival() { }

        public Festival(string nombre, DateTime fecha, string ubicacion, List<String> artistas)
        {
            Nombre = nombre;
            Fecha = fecha;
            Ubicacion = ubicacion;
            Artistas = artistas;
        }

        public void AgregarArtista(String artista)
        {
            Artistas.Add(artista);
        }

        public void EliminarArtista(String artista)
        {
            Artistas.Remove(artista);
        }
    }
}
