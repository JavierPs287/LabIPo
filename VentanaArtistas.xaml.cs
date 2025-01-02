using System.Collections.Generic;
using System.Windows;

namespace ProyectoIPo
{
    public partial class VentanaArtistas : Window
    {
        private List<string> artistas;
        private Dictionary<string, EstadoArtista> estadoArtistas;

        public VentanaArtistas(List<string> artistas)
        {
            InitializeComponent();
            this.artistas = artistas;

            // Asegurarse de que ArtistasListBox esté vacío antes de establecer ItemsSource
            if (ArtistasListBox.Items.Count > 0)
            {
                ArtistasListBox.Items.Clear();
            }
            ArtistasListBox.ItemsSource = this.artistas;

            ArtistasListBox.SelectionChanged += ArtistasListBox_SelectionChanged;

            // Inicializar el diccionario de estados de artistas con datos de ejemplo
            estadoArtistas = new Dictionary<string, EstadoArtista>
            {
                { "Freddie Mercury", new EstadoArtista
                    {
                        GeneroMusical = "Rock",
                        DatosPersonales = "Freddie Mercury",
                        CorreoElectronico = "freddie@queen.com",
                        RedesSociales = "@freddiemercury",
                        Cache = "$100000",
                        DiaHoraActuacion = "12/12/2023 20:00",
                        Escenario = "Main Stage",
                        LugarAlojamiento = "Hotel XYZ",
                        PeticionEspecial = "Sin peticiones especiales",
                        Estado = "Confirmado",
                        Detalles = "Freddie Mercury fue un cantante, compositor y productor británico, conocido por ser el vocalista principal de la banda de rock Queen."
                    }
                }
            };
        }

        private void ArtistasListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ArtistasListBox.SelectedItem != null)
            {
                string artistaSeleccionado = ArtistasListBox.SelectedItem.ToString();
                if (estadoArtistas != null && estadoArtistas.ContainsKey(artistaSeleccionado))
                {
                    dataGridArtistas.ItemsSource = new List<EstadoArtista> { estadoArtistas[artistaSeleccionado] };
                    txtDetallesArtista.Text = estadoArtistas[artistaSeleccionado].Detalles;
                }
            }
        }

        private void AñadirArtista_Click(object sender, RoutedEventArgs e)
        {
            var agregarArtistaWindow = new AgregarArtistas();
            if (agregarArtistaWindow.ShowDialog() == true)
            {
                var nuevoArtista = agregarArtistaWindow.NuevoArtista;
                if (nuevoArtista != null)
                {
                    string nombreArtista = nuevoArtista.DatosPersonales; // Asume que DatosPersonales contiene el nombre del artista
                    artistas.Add(nombreArtista);
                    estadoArtistas[nombreArtista] = nuevoArtista;
                    ArtistasListBox.Items.Refresh();
                }
            }
        }

        public void AñadirArtista(string artista)
        {
            artistas.Add(artista);
            ArtistasListBox.Items.Refresh();
        }
    }

    public class EstadoArtista
    {
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
