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

        public ObservableCollection<string> Artistas { get; set; }

        public VentanaArtistas(List<Festival> festivales)
        {
            InitializeComponent();
            this.festivales = festivales;
            Artistas = new ObservableCollection<string>(festivales.SelectMany(f => f.Artistas).Distinct());
            DataContext = this;

            ArtistasListBox.Items.Clear();
            ArtistasListBox.ItemsSource = Artistas;


            ArtistasListBox.SelectionChanged += ArtistasListBox_SelectionChanged;

            estadoArtistas = new Dictionary<string, EstadoArtista>();
            InicializarEstadoArtistas();
        }

        private void InicializarEstadoArtistas()
        {
            foreach (var artista in Artistas)
            {
                estadoArtistas[artista] = new EstadoArtista
                {
                    Nombre = artista,
                    Detalles = $"Información de {artista}"
                };
            }
        }

        private void ArtistasListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ArtistasListBox.SelectedItem is string artistaSeleccionado &&
                estadoArtistas.ContainsKey(artistaSeleccionado))
            {
                dataGridArtistas.ItemsSource = new List<EstadoArtista> { estadoArtistas[artistaSeleccionado] };
                txtDetallesArtista.Text = estadoArtistas[artistaSeleccionado].Detalles;
            }
        }

        private void AñadirArtista_Click(object sender, RoutedEventArgs e)
        {
            var agregarArtistaWindow = new AgregarArtistas();
            if (agregarArtistaWindow.ShowDialog() == true)
            {
                var nuevoArtista = agregarArtistaWindow.NuevoArtista;
                if (nuevoArtista != null && !string.IsNullOrEmpty(nuevoArtista.Nombre) && !Artistas.Contains(nuevoArtista.Nombre))
                {
                    Artistas.Add(nuevoArtista.Nombre);
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


        public List<string> ObtenerArtistasAsignados()
        {
            return Artistas.ToList(); // Convertir ObservableCollection a lista
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
        public string Detalles { get; set; } // Nueva propiedad para los detalles del artista
    }
}
