using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace ProyectoIPo
{
    public partial class VentanaArtistas : Window
    {
        private List<Festival> festivales;
        private Dictionary<string, EstadoArtista> estadoArtistas;

        public ObservableCollection<EstadoArtista> Artistas { get; set; }

        public VentanaArtistas(List<Festival> festivales)
        {
            InitializeComponent();
            this.festivales = festivales;
            Artistas = new ObservableCollection<EstadoArtista>(
                festivales.SelectMany(f => f.Artistas)
                          .Distinct()
                          .Select(nombre => new EstadoArtista { Nombre = nombre, LogoPath = ObtenerRutaLogo(nombre) })
            );
            DataContext = this;

            ArtistasListBox.Items.Clear();
            ArtistasListBox.ItemsSource = Artistas;

            ArtistasListBox.SelectionChanged += ArtistasListBox_SelectionChanged;

            estadoArtistas = new Dictionary<string, EstadoArtista>();
        }

        private void ArtistasListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ArtistasListBox.SelectedItem is EstadoArtista artistaSeleccionado)
            {
                if (!estadoArtistas.ContainsKey(artistaSeleccionado.Nombre))
                {
                    estadoArtistas[artistaSeleccionado.Nombre] = artistaSeleccionado;
                }

                dataGridArtistas.ItemsSource = new List<EstadoArtista> { estadoArtistas[artistaSeleccionado.Nombre] };
                txtDetallesArtista.Text = estadoArtistas[artistaSeleccionado.Nombre].Detalles;
            }
        }



        private void AñadirArtista_Click(object sender, RoutedEventArgs e)
        {
            var agregarArtistaWindow = new AgregarArtistas();
            if (agregarArtistaWindow.ShowDialog() == true)
            {
                var nuevoArtista = agregarArtistaWindow.NuevoArtista;
                if (nuevoArtista != null && !string.IsNullOrEmpty(nuevoArtista.Nombre) && !Artistas.Any(a => a.Nombre == nuevoArtista.Nombre))
                {
                    nuevoArtista.LogoPath = ObtenerRutaLogo(nuevoArtista.Nombre);
                    Artistas.Add(nuevoArtista);
                    if (!estadoArtistas.ContainsKey(nuevoArtista.Nombre) && nuevoArtista.Nombre != null)
                    {
                        estadoArtistas[nuevoArtista.Nombre] = nuevoArtista;
                    }

                    // Asociar el artista a los festivales seleccionados
                    foreach (var festival in festivales)
                    {
                        if (!festival.Artistas.Contains(nuevoArtista.Nombre))
                        {
                            festival.Artistas.Add(nuevoArtista.Nombre);
                        }
                    }

                    ArtistasListBox.Items.Refresh();
                }
            }
        }

        private string ObtenerRutaLogo(string nombreArtista)
        {
            // Obtener la ruta completa del directorio de la aplicación
            string directorioAplicacion = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            // Combinar la ruta del directorio de la aplicación con la ruta relativa de la imagen
            return System.IO.Path.Combine(directorioAplicacion, "Recursos", $"{nombreArtista}.jpg");
        }




        public List<string> ObtenerArtistasAsignados()
        {
            return Artistas.Select(a => a.Nombre).ToList(); // Convertir ObservableCollection a lista de nombres
        }
    }

    public class EstadoArtista
    {
        public string Nombre { get; set; }
        public string GeneroMusical { get; set; }
        public string DatosPersonales { get; set; }
        public string CorreoElectronico { get; set; }
        public string RedesSociales { get; set; }
        public string Cache { get; set; }
        public string DiaHoraActuacion { get; set; }
        public string Escenario { get; set; }
        public string LugarAlojamiento { get; set; }
        public string PeticionEspecial { get; set; }
        public string Estado { get; set; }
        public string Detalles { get; set; } 
        public string LogoPath { get; set; }
    }
}
