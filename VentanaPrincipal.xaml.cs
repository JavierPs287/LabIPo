using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
                Artistas = new List<String> {"Queen", "Bon Jovi", "Guns N' Roses"},
                PrecioEstandar = 60.00m,
                PrecioVIP = 150.00m
            },
            new Festival
                {
                Nombre = "Jazz Nights",
                Fecha = new DateTime(2024, 5, 20),
                Ubicacion = "Barcelona, España",
                Artistas = new List<String> {"Miles Davis","John Coltrane"},
                PrecioEstandar = 50.00m,
                PrecioVIP = 180.00m
            },
            new Festival
            {
                Nombre = "Trap Beats",
                Fecha = new DateTime(2024, 12, 10),
                Ubicacion = "Buenos Aires, Argentina",
                Artistas = new List<String> {"Duki", "Bad Bunny", "Eladio Carrión"},
                PrecioEstandar = 40.00m,
                PrecioVIP = 100.00m
            },
            new Festival
            {
                Nombre = "Reggaeton Party",
                Fecha = new DateTime(2025, 3, 10),
                Ubicacion = "Miami, USA",
                Artistas = new List<String> {"Daddy Yankee", "Feid", "Anuel AA"},
                PrecioEstandar = 70.00m,
                PrecioVIP = 200.00m
            },
            new Festival
            {
                Nombre = "Electronic Beats",
                Fecha = new DateTime(2024, 7, 12),
                Ubicacion = "Ibiza, España",
                Artistas = new List<String> {"David Guetta","Calvin Harris"},
                PrecioEstandar = 65.00m,
                PrecioVIP = 175.00m
            },
              
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

            actualizarDataGrid();
            
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

            actualizarDataGrid();

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

                actualizarDataGrid();
            }
        }


        private void CerrarSesionClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
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
                    MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres dar de baja el festival " + festivalToDelete.Nombre + "?", "Confirmar eliminación", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        // Eliminar el festival de la colección.
                        Festivales.Remove(festivalToDelete);
                        MessageBox.Show("Festival dado de baja.");
                    }
                }
            }
            actualizarDataGrid();
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

        private void DatePicker(object sender, RoutedEventArgs e)
        {
            if (sender is DatePicker datePicker)
            {
                datePicker.DisplayDateStart = DateTime.Today.AddDays(1);
            }
        }

        private void PrecioValido(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (decimal.TryParse(tb.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal value))
                {
                    // Si la conversión es exitosa, formatea el valor con dos decimales
                    tb.Text = value.ToString("F2", CultureInfo.InvariantCulture);
                }
                else
                {
                    // Muestra un mensaje de error y restaura el valor previo si existe
                    MessageBox.Show("Introduce un número válido", "Número inválido", MessageBoxButton.OK, MessageBoxImage.Error);

                    if (tb.Tag != null)
                    {
                        tb.Text = tb.Tag.ToString();
                    }
                }
            }
        }


        private void AlmacenarValorPrecio(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                tb.Tag = tb.Text;
            }
        }

        private void actualizarDataGrid()
        {
            FestivalDataGrid.Items.Refresh(); // Asegura que los datos se actualizan
            FestivalDataGrid.ItemsSource = null; // Resetear el ItemsSource antes de asignar nuevamente
            FestivalDataGrid.ItemsSource = Festivales; // Refrescar el DataGrid
        }
    }
}