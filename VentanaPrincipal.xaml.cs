using System;
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
            Festivales = DatosApp.Festivales;
            if (!Festivales.Any())
            {
                Festivales.Add(new Festival
                {
                    Nombre = "Rock fest",
                    Fecha = new DateTime(2027, 6, 15),
                    Ubicacion = "Madrid, España",
                    Artistas = new ObservableCollection<Artista>
            {
               new Artista(
                    nombre: "Queen",
                    generoMusical: "Rock",
                    datosPersonales: "Información personal de Queen",
                    correoElectronico: "contacto@queen.com",
                    redesSociales: "X: @QueenOfficial",
                    cache: "100,000,000",
                    fechaFestival: new DateTime(2027, 6, 15),
                    diaYHoraInicioActuacion: null,
                    diaYHoraFinActuacion: null,
                    escenario: null,
                    alojamiento: "Hotel Beatriz",
                    peticionEspecial: "nada",
                    estado: "ACTIVO"
                ),

                new Artista(
                    nombre: "Bon Jovi",
                    generoMusical: "Rock",
                    datosPersonales: "Información personal de Bon Jovi",
                    correoElectronico: "info@bonjovi.com",
                    redesSociales: "X: @BonJovi",
                    cache: "90,000,000",
                    fechaFestival: new DateTime(2027, 6, 15),
                    diaYHoraInicioActuacion: null,
                    diaYHoraFinActuacion: null,
                    escenario: null,
                    alojamiento: "Hotel Beatriz",
                    peticionEspecial: "nada",
                    estado: "ACTIVO"
                ),

                new Artista(
                     nombre: "Guns N' Roses",
                    generoMusical: "Rock",
                    datosPersonales: "Información personal de Guns N' Roses",
                    correoElectronico: "contact@gunsnroses.com",
                    redesSociales: "X: @GunsNRoses",
                    cache: "95,000,000",
                    fechaFestival: new DateTime(2027, 6, 15),
                    diaYHoraInicioActuacion: null,
                    diaYHoraFinActuacion: null,
                    escenario: null,
                    alojamiento: "Hotel Beatriz",
                    peticionEspecial: "nada",
                    estado: "ACTIVO"
                )
                 },
                    PrecioEstandar = 60.00m,
                    PrecioVIP = 150.00m
                });

                Festivales.Add(new Festival
                {
                    Nombre = "Jazz Nights",
                    Fecha = new DateTime(2024, 5, 20),
                    Ubicacion = "Barcelona, España",
                    Artistas = new ObservableCollection<Artista>
            {
                new Artista(
                    nombre: "Miles Davis",
                    generoMusical: "Jazz",
                    datosPersonales: "Información personal de Miles Davis",
                    correoElectronico: "milesdavis@jazz.com",
                    redesSociales: "@MilesDavisJazz",
                    cache: "100,000",
                    fechaFestival: new DateTime(2024, 5, 20),
                    diaYHoraInicioActuacion: null,
                    diaYHoraFinActuacion: null,
                    escenario: null,
                    alojamiento: "Hotel Jazz",
                    peticionEspecial: "Ninguna",
                    estado: "ACTIVO"
                ),
                new Artista(
                    nombre: "John Coltrane",
                    generoMusical: "Jazz",
                    datosPersonales: "Información personal de John Coltrane",
                    correoElectronico: "coltrane@jazz.com",
                    redesSociales: "@JohnColtraneJazz",
                    cache: "100,000",
                    fechaFestival: new DateTime(2024, 5, 20),
                    diaYHoraInicioActuacion: null,
                    diaYHoraFinActuacion: null,
                    escenario: null,
                    alojamiento: "Hotel Jazz",
                    peticionEspecial: "Ninguna",
                    estado: "ACTIVO"
                )
                 },
                    PrecioEstandar = 50.00m,
                    PrecioVIP = 180.00m
                });

                Festivales.Add(new Festival
                {
                    Nombre = "Trap Beats",
                    Fecha = new DateTime(2024, 12, 10),
                    Ubicacion = "Buenos Aires, Argentina",
                    Artistas = new ObservableCollection<Artista>
            {
                new Artista(
            nombre: "Duki",
            generoMusical: "Trap",
            datosPersonales: "Información personal de Duki",
            correoElectronico: "duki@trap.com",
            redesSociales: "@DukiTrap",
            cache: "100,000",
                    fechaFestival: new DateTime(2024, 12, 10),
            diaYHoraInicioActuacion: null,
            diaYHoraFinActuacion: null,
            escenario: null,
            alojamiento: "Hotel Trap",
            peticionEspecial: "Ninguna",
            estado: "ACTIVO"
        ),
        new Artista(
            nombre: "Bad Bunny",
            generoMusical: "Trap",
            datosPersonales: "Información personal de Bad Bunny",
            correoElectronico: "badbunny@trap.com",
            redesSociales: "@BadBunnyTrap",
            cache: "100,000",
                    fechaFestival: new DateTime(2024, 12, 10),
            diaYHoraInicioActuacion: null,
            diaYHoraFinActuacion: null,
            escenario: null,
            alojamiento: "Hotel Trap",
            peticionEspecial: "Ninguna",
            estado: "ACTIVO"
        ),
        new Artista(
            nombre: "Eladio Carrión",
            generoMusical: "Trap",
            datosPersonales: "Información personal de Eladio Carrión",
            correoElectronico: "eladio@trap.com",
            redesSociales: "@EladioCarrion",
            cache: "100,000",
                    fechaFestival: new DateTime(2024, 12, 10),
            diaYHoraInicioActuacion: null,
            diaYHoraFinActuacion: null,
            escenario: null,
            alojamiento: "Hotel Trap",
            peticionEspecial: "Ninguna",
            estado: "ACTIVO"
        )
    },
                    PrecioEstandar = 40.00m,
                    PrecioVIP = 100.00m
                });

                Festivales.Add(new Festival
                {
                    Nombre = "Reggaeton Party",
                    Fecha = new DateTime(2025, 3, 10),
                    Ubicacion = "Miami, USA",
                    Artistas = new ObservableCollection<Artista>
            {
                new Artista(
            nombre: "Daddy Yankee",
            generoMusical: "Reggaeton",
            datosPersonales: "Información personal de Daddy Yankee",
            correoElectronico: "daddyyankee@reggaeton.com",
            redesSociales: "@DaddyYankee",
            cache: "100,000",
                    fechaFestival: new DateTime(2025, 3, 10),
            diaYHoraInicioActuacion: null,
            diaYHoraFinActuacion: null,
            escenario: null,
            alojamiento: "Hotel Reggaeton",
            peticionEspecial: "Ninguna",
            estado: "ACTIVO"
        ),
        new Artista(
            nombre: "Feid",
            generoMusical: "Reggaeton",
            datosPersonales: "Información personal de Feid",
            correoElectronico: "feid@reggaeton.com",
            redesSociales: "@Feid",
            cache: "100,000",
                    fechaFestival: new DateTime(2025, 3, 10),
            diaYHoraInicioActuacion: null,
            diaYHoraFinActuacion: null,
            escenario: null,
            alojamiento: "Hotel Reggaeton",
            peticionEspecial: "Ninguna",
            estado: "ACTIVO"
        ),
        new Artista(
            nombre: "Anuel AA",
            generoMusical: "Reggaeton",
            datosPersonales: "Información personal de Anuel AA",
            correoElectronico: "anuel@reggaeton.com",
            redesSociales: "@AnuelAA",
            cache: "100,000",
                    fechaFestival: new DateTime(2025, 3, 10),
            diaYHoraInicioActuacion: null,
            diaYHoraFinActuacion: null,
            escenario: null,
            alojamiento: "Hotel Reggaeton",
            peticionEspecial: "Ninguna",
            estado: "ACTIVO"
        )
    },
                    PrecioEstandar = 70.00m,
                    PrecioVIP = 200.00m
                });

                Festivales.Add(new Festival
                {
                    Nombre = "Electronic Beats",
                    Fecha = new DateTime(2024, 7, 12),
                    Ubicacion = "Ibiza, España",
                    Artistas = new ObservableCollection<Artista>
            {
               new Artista(
            nombre: "David Guetta",
            generoMusical: "Electrónica",
            datosPersonales: "Información personal de David Guetta",
            correoElectronico: "davidguetta@electronica.com",
            redesSociales: "@DavidGuetta",
            cache: "100,000",
                    fechaFestival: new DateTime(2024, 7, 12),
            diaYHoraInicioActuacion: null,
            diaYHoraFinActuacion: null,
            escenario: null,
            alojamiento: "Hotel Electrónica",
            peticionEspecial: "Ninguna",
            estado: "ACTIVO"
        ),
        new Artista(
            nombre: "Calvin Harris",
            generoMusical: "Electrónica",
            datosPersonales: "Información personal de Calvin Harris",
            correoElectronico: "calvinharris@electronica.com",
            redesSociales: "@CalvinHarris",
            cache: "100,000",
                    fechaFestival: new DateTime(2024, 7, 12),
            diaYHoraInicioActuacion: null,
            diaYHoraFinActuacion: null,
            escenario: null,
            alojamiento: "Hotel Electrónica",
            peticionEspecial: "Ninguna",
            estado: "ACTIVO"
        )
    },
                    PrecioEstandar = 65.00m,
                    PrecioVIP = 175.00m
                });
            }

            Festivales = new ObservableCollection<Festival>(Festivales.OrderBy(f => f.Fecha));

            DataContext = this;
        }


        private void FiltrarFestivales(object sender, RoutedEventArgs e)
        {
            string filtroNombre = txtFiltroNombre.Text?.ToLower() ?? string.Empty;
            string filtroArtista = txtFiltroArtista.Text?.ToLower() ?? string.Empty;
            DateTime? filtroFecha = dpFiltroFecha.SelectedDate;

            var festivalesFiltrados = Festivales.Where(f =>
                (string.IsNullOrWhiteSpace(filtroNombre) || f.Nombre.ToLower().Contains(filtroNombre)) &&
                (string.IsNullOrWhiteSpace(filtroArtista) || f.Artistas.Any(a => a.Nombre.ToLower().Contains(filtroArtista))) &&
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
            DatosApp.Festivales.Add(festival);
            Festivales.Add(festival);
            Festivales = new ObservableCollection<Festival>(Festivales.OrderBy(f => f.Fecha));

            actualizarDataGrid();

        }


        private void CerrarSesionClick(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }


        private void VisualizarButton_Click(object sender, RoutedEventArgs e)
        {
            var boton = sender as Button;
            var festival = boton?.DataContext as Festival;

            if (festival != null)
            {
                var ventanaArtistas = new VentanaArtistas(festival);  // Pasando el festival directamente
                ventanaArtistas.ShowDialog();
            }
        }



        private void OnDeleteFestivalClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                Festival festivalToDelete = button.DataContext as Festival;
                if (festivalToDelete != null)
                {
                    MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres dar de baja el festival " + festivalToDelete.Nombre + "?", "Confirmar eliminación", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        DatosApp.Festivales.Remove(festivalToDelete);
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
                    tb.Text = value.ToString("F2", CultureInfo.InvariantCulture);

                    if (tb.Tag is Festival festival)
                    {
                        // Verifica qué precio se debe actualizar
                        if (tb.Name == "PrecioEstandarTextBox") // Reemplaza con el nombre real del TextBox
                        {
                            festival.PrecioEstandar = value;
                        }
                        else if (tb.Name == "PrecioVIPTextBox") // Reemplaza con el nombre real del TextBox
                        {
                            festival.PrecioVIP = value;
                        }

                        // Actualiza el festival en la colección local
                        int index = Festivales.IndexOf(festival);
                        if (index >= 0)
                        {
                            Festivales[index] = festival;
                        }

                        // Actualiza el festival en la colección de DatosApp
                        index = DatosApp.Festivales.IndexOf(festival);
                        if (index >= 0)
                        {
                            DatosApp.Festivales[index] = festival;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Introduce un número válido", "Número inválido", MessageBoxButton.OK, MessageBoxImage.Error);

                    if (tb.Tag != null)
                    {
                        tb.Text = tb.Tag.ToString(); // Restaura el valor anterior
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