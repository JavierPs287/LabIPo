using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ProyectoIPo
{
    public partial class VentanaPrincipal : Window
    {
        public string Username { get; set; }
        public string ProfileImagePath { get; set; }
        public DateTime LastAccessDate { get; set; }

        public ObservableCollection<Festival> Festivales { get; set; }
        public ObservableCollection<Festival> FestivalesFiltrados { get; set; }


        public VentanaPrincipal()
        {
            InitializeComponent();
            InicializarDatos();
        }
        public VentanaPrincipal(string username, string profileImagePath, DateTime lastAccessDate)
        {
            InitializeComponent();
            Username = username;
            ProfileImagePath = profileImagePath;
            LastAccessDate = lastAccessDate;
            InicializarDatos();
        }
        private void InicializarDatos()
        { 
        // Datos de ejemplo
        Festivales = new ObservableCollection<Festival>
        {
            new Festival
            {
                Nombre = "Rock fest",
                Fecha = new DateTime(2024, 6, 15),
                Ubicacion = "Madrid, España",
                Artistas = new List<String> {"Queen", "Bon Jovi", "Guns N' Roses", "AC/DC"}
            },
            new Festival
                {
                    Nombre = "Jazz Nights",
                    Fecha = new DateTime(2024, 5, 20),
                    Ubicacion = "Barcelona, España",
                    Artistas = new List<String> {"Miles Davis","John Coltrane"}
                },
                new Festival
                {
                    Nombre = "Trap Beats",
                    Fecha = new DateTime(2024, 12, 10),
                    Ubicacion = "Buenos Aires, Argentina",
                    Artistas = new List<String> {"Duki", "Bad Bunny", "Eladio Carrión"}
                },
                new Festival
                {
                    Nombre = "Reggaeton Party",
                    Fecha = new DateTime(2025, 3, 10),
                    Ubicacion = "Miami, USA",
                    Artistas = new List<String> {"Daddy Yankee", "Feid", "JhayCo"}
                },
                new Festival
                {
                    Nombre = "Electronic Beats",
                    Fecha = new DateTime(2024, 7, 12),
                    Ubicacion = "Ibiza, España",
                    Artistas = new List<String> {"David Guetta","Calvin Harris"}
                },
                new Festival
                {
                    Nombre = "Blues Legends",
                    Fecha = new DateTime(2024, 8, 10),
                    Ubicacion = "Chicago, USA",
                    Artistas = new List<String> {"B.B. King","Muddy Water"}
                },
                new Festival
                {
                    Nombre = "Metal Mayhem",
                    Fecha = new DateTime(2024, 9, 5),
                    Ubicacion = "Berlin, Alemania",
                    Artistas = new List<String> {"Iron mayden","Metallica"}
                },
                new Festival
                {
                    Nombre = "Classical Evenings",
                    Fecha = new DateTime(2024, 6, 30),
                    Ubicacion = "Viena, Austria",
                    Artistas = new List<String> {"Ludwig Van Beethoven","Wolfgang Amadeus Mozart"}
                },
                new Festival
                {
                    Nombre = "Reggae Sun",
                    Fecha = new DateTime(2024, 7, 25),
                    Ubicacion = "Kingston, Jamaica",
                    Artistas = new List<String> {"Bob Marley", "Peter Tosh"}
                },
                new Festival
                {
                    Nombre = "PopFest",
                    Fecha = new DateTime(2024, 10, 2),
                    Ubicacion = "Los Ángeles, USA",
                    Artistas = new List<String> {"Ariana Granda","Taylor Swift"}
                },
                new Festival
                {
                    Nombre = "Indie Vibes",
                    Fecha = new DateTime(2024, 8, 20),
                    Ubicacion = "Londres, UK",
                    Artistas = new List<String> {"The Strokes","Artic Monkeys"}
                },
                new Festival
                {
                    Nombre = "Country Jam",
                    Fecha = new DateTime(2024, 9, 15),
                    Ubicacion = "Nashville, USA",
                    Artistas = new List<String> {"Johnny Cash","Dolly Parton"}
                },
                new Festival
                {
                    Nombre = "R&B Soul Fest",
                    Fecha = new DateTime(2024, 11, 1),
                    Ubicacion = "Atlanta, USA",
                    Artistas = new List<String> { "Aretha Franklin", "Marvin Gaye" }
                },
                new Festival
                {
                    Nombre = "Latin Fusion",
                    Fecha = new DateTime(2024, 6, 25),
                    Ubicacion = "México D.F., México",
                    Artistas = new List<String> {"Carlos Santana, Shakira"}
                },
                new Festival
                {
                    Nombre = "Punk Rock Riot",
                    Fecha = new DateTime(2024, 7, 19),
                    Ubicacion = "Los Ángeles, USA",
                    Artistas = new List<String> { "Green Day", "The Offspring" }
                },
                new Festival
                {
                    Nombre = "Hip Hop Summit",
                    Fecha = new DateTime(2024, 9, 25),
                    Ubicacion = "Nueva York, USA",
                    Artistas = new List<String> { "Kendrick Lamar", "Drake" }
                }
            };

            Festivales = new ObservableCollection<Festival>(Festivales.OrderBy(f => f.Fecha));

            // Establecer el contexto de datos para la ventana
            DataContext = this;
        }

        private void FiltrarFestivales(object sender, RoutedEventArgs e)
        {
            string filtroNombre = txtFiltroNombre.Text?.ToLower() ?? string.Empty;
            string filtroArtista = txtFiltroArtista.Text?.ToLower() ?? string.Empty;
            DateTime? filtroFecha = dpFiltroFecha.SelectedDate;

            var festivalesFiltrados = Festivales.Where(f =>
                (string.IsNullOrWhiteSpace(filtroNombre) || f.Nombre.ToLower().Contains(filtroNombre)) &&
                (string.IsNullOrWhiteSpace(filtroArtista) || f.Artistas.Any(a => a.ToLower().Contains(filtroArtista))) &&
                (!filtroFecha.HasValue || f.Fecha.Date == filtroFecha.Value.Date));

            FestivalesFiltrados = new ObservableCollection<Festival>(festivalesFiltrados);
            FestivalDataGrid.ItemsSource = FestivalesFiltrados; // Refrescar el DataGrid
        }

        private void CancelarFiltros(object sender, RoutedEventArgs e)
        {
            txtFiltroNombre.Clear();
            txtFiltroArtista.Clear();
            dpFiltroFecha.SelectedDate = null;

            // Refrescar el DataGrid llamando a Items.Refresh
            FestivalDataGrid.Items.Refresh(); // Asegura que los datos se actualizan

            FestivalDataGrid.ItemsSource = null; // Resetear el ItemsSource antes de asignar nuevamente
            FestivalDataGrid.ItemsSource = Festivales; // Refrescar el DataGrid
        }

        private void OnAddFestivalClick(object sender, RoutedEventArgs e)
        {
            var ventanaAgregarFestival = new VentanaAgregarFestival();
            ventanaAgregarFestival.FestivalAdded += OnFestivalAdded; // Suscripción al evento
            ventanaAgregarFestival.ShowDialog(); // Muestra la ventana de agregar festival
        }

        private void OnFestivalAdded(object sender, Festival festival)
        {
            Festivales.Add(festival);
            Festivales = new ObservableCollection<Festival>(Festivales.OrderBy(f => f.Fecha));
            FestivalDataGrid.ItemsSource = null; // Refrescar el DataGrid
            FestivalDataGrid.ItemsSource = Festivales;

        }

        private void EscenariosButton_Click(object sender, RoutedEventArgs e)
        {
            var boton = sender as Button;
            dynamic fila = boton.DataContext;

            if (fila != null)
            {
                var agregarEscenariosVentana = new AgregarEscenarios();
                if (agregarEscenariosVentana.ShowDialog() == true)
                {
                    if (agregarEscenariosVentana.NuevosEscenarios.Count > 0)
                    {
                        // Aquí puedes agregar la lógica para manejar los nuevos escenarios como desees
                        // Por ejemplo, podrías agregar los nuevos escenarios a la lista de escenarios del festival actual
                        fila.Escenarios.AddRange(agregarEscenariosVentana.NuevosEscenarios);
                    }
                }
            }
        }

        private List<string> ObtenerTodosLosArtistas()
        {
            return Festivales.SelectMany(f => f.Artistas).Distinct().ToList();
        }

        private void VisualizarTodosLosArtistasButton_Click(object sender, RoutedEventArgs e)
        {
            var ventanaArtistas = new VentanaArtistas(Festivales.ToList());
            if (ventanaArtistas.ShowDialog() == true)
            {
                var artistasAsignados = ventanaArtistas.ObtenerArtistasAsignados();

                // Actualizar los festivales con los artistas asignados
                foreach (var festival in Festivales)
                {
                    var artistasFestival = artistasAsignados.Where(a => festival.Artistas.Contains(a)).ToList();
                    festival.Artistas = artistasFestival;
                }

                FestivalDataGrid.ItemsSource = null; // Refrescar el DataGrid
                FestivalDataGrid.ItemsSource = Festivales;
            }
        }





        private void VisualizarButton_Click(object sender, RoutedEventArgs e)
        {
            var boton = sender as Button;
            var festival = boton?.DataContext as Festival;

            if (festival != null)
            {
                var ventanaArtistas = new VentanaArtistas(new List<Festival> { festival });
                ventanaArtistas.ShowDialog();
            }
        }













        private void OnDeleteFestivalClick(object sender, RoutedEventArgs e)
        {
            // Obtener el botón que fue clickeado.
            Button button = sender as Button;
            if (button != null)
            {
                // Obtener el objeto Festival vinculado a la fila del botón clickeado.
                Festival festivalToDelete = button.DataContext as Festival;
                if (festivalToDelete != null)
                {
                    // Confirmar la eliminación con el usuario
                    MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres borrar el festival " + festivalToDelete.Nombre + "?", "Confirmar eliminación", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        // Eliminar el festival de la colección.
                        Festivales.Remove(festivalToDelete);
                        MessageBox.Show("Festival borrado.");
                    }
                }
            }
        }   

        private void OnTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Text == string.Empty)
            {
                if (textBox.Name == "txtFiltroNombre")
                {
                    textBlockNombre.Visibility = Visibility.Collapsed;
                }
                else if (textBox.Name == "txtFiltroArtista")
                {
                    textBlockArtista.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void OnTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (textBox.Text == string.Empty)
                {
                    if (textBox.Name == "txtFiltroNombre")
                    {
                        textBlockNombre.Visibility = Visibility.Visible;
                    }
                    else if (textBox.Name == "txtFiltroArtista")
                    {
                        textBlockArtista.Visibility = Visibility.Visible;
                    }
                }
            }
        }
    }
}