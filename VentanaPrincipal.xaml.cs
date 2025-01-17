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
                fechaInicioFestival: new DateTime(2027, 6, 15),
                duracionFestival: 6,
                diaActuacion: null,
                horaInicio: null,
                horaFin: null,
                escenario: null,
                alojamiento: "Hotel Beatriz",
                peticionEspecial: "nada",
                estado: "ACTIVO",
                logoPath: "Recursos/Queen.jpg"
            ),
            new Artista(
                nombre: "Bon Jovi",
                generoMusical: "Rock",
                datosPersonales: "Información personal de Bon Jovi",
                correoElectronico: "info@bonjovi.com",
                redesSociales: "X: @BonJovi",
                cache: "90,000,000",
                fechaInicioFestival: new DateTime(2027, 6, 15),
                duracionFestival: 6,
                diaActuacion: null,
                horaInicio: null,
                horaFin: null,
                escenario: null,
                alojamiento: "Hotel Beatriz",
                peticionEspecial: "nada",
                estado: "ACTIVO",
                logoPath: "Recursos/Bon Jovi.jpg"
            ),
            new Artista(
                nombre: "Guns N' Roses",
                generoMusical: "Rock",
                datosPersonales: "Información personal de Guns N' Roses",
                correoElectronico: "contact@gunsnroses.com",
                redesSociales: "X: @GunsNRoses",
                cache: "95,000,000",
                fechaInicioFestival: new DateTime(2027, 6, 15),
                duracionFestival: 6,
                diaActuacion: null,
                horaInicio: null,
                horaFin: null,
                escenario: null,
                alojamiento: "Hotel Beatriz",
                peticionEspecial: "nada",
                estado: "ACTIVO",
                logoPath: "Recursos/Guns N' Roses.jpg"
            )
        },
                    PrecioEstandar = 60,
                    PrecioVIP = 150,
                    Duracion = 6
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
                fechaInicioFestival: new DateTime(2024, 5, 20),
                duracionFestival: 5,
                diaActuacion: null,
                horaInicio: null,
                horaFin: null,
                escenario: null,
                alojamiento: "Hotel Jazz",
                peticionEspecial: "Ninguna",
                estado: "ACTIVO",
                logoPath: "Recursos/MilesDavis.jpg"
            ),
            new Artista(
                nombre: "John Coltrane",
                generoMusical: "Jazz",
                datosPersonales: "Información personal de John Coltrane",
                correoElectronico: "coltrane@jazz.com",
                redesSociales: "@JohnColtraneJazz",
                cache: "100,000",
                fechaInicioFestival: new DateTime(2024, 5, 20),
                duracionFestival: 5,
                diaActuacion: null,
                horaInicio: null,
                horaFin: null,
                escenario: null,
                alojamiento: "Hotel Jazz",
                peticionEspecial: "Ninguna",
                estado: "ACTIVO",
                logoPath: "Recursos/John Coltrane.jpg"
            )
        },
                    PrecioEstandar = 50,
                    PrecioVIP = 180,
                    Duracion = 5
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
                fechaInicioFestival: new DateTime(2024, 12, 10),
                duracionFestival: 4,
                diaActuacion: null,
                horaInicio: null,
                horaFin: null,
                escenario: null,
                alojamiento: "Hotel Trap",
                peticionEspecial: "Ninguna",
                estado: "ACTIVO",
                logoPath: "Recursos/Duki.jpg"
            ),
            new Artista(
                nombre: "Bad Bunny",
                generoMusical: "Trap",
                datosPersonales: "Información personal de Bad Bunny",
                correoElectronico: "badbunny@trap.com",
                redesSociales: "@BadBunnyTrap",
                cache: "100,000",
                fechaInicioFestival: new DateTime(2024, 12, 10),
                duracionFestival: 4,
                diaActuacion: null,
                horaInicio: null,
                horaFin: null,
                escenario: null,
                alojamiento: "Hotel Trap",
                peticionEspecial: "Ninguna",
                estado: "ACTIVO",
                logoPath: "Recursos/Bad Bunny.jpg"
            ),
            new Artista(
                nombre: "Eladio Carrión",
                generoMusical: "Trap",
                datosPersonales: "Información personal de Eladio Carrión",
                correoElectronico: "eladio@trap.com",
                redesSociales: "@EladioCarrion",
                cache: "100,000",
                fechaInicioFestival: new DateTime(2024, 12, 10),
                duracionFestival: 4,
                diaActuacion: null,
                horaInicio: null,
                horaFin: null,
                escenario: null,
                alojamiento: "Hotel Trap",
                peticionEspecial: "Ninguna",
                estado: "ACTIVO",
                logoPath: "Recursos/Eladio Carrión.jpg"
            )
        },
                    PrecioEstandar = 40,
                    PrecioVIP = 100,
                    Duracion = 4
                });

                Festivales.Add(new Festival
                {
                    Nombre = "EDM Wonderland",
                    Fecha = new DateTime(2025, 7, 18),
                    Ubicacion = "Ibiza, España",
                    Artistas = new ObservableCollection<Artista>
        {
            new Artista(
                nombre: "Martin Garrix",
                generoMusical: "EDM",
                datosPersonales: "Información personal de Martin Garrix",
                correoElectronico: "martin@edm.com",
                redesSociales: "@MartinGarrix",
                cache: "150,000",
                fechaInicioFestival: new DateTime(2025, 7, 18),
                duracionFestival: 3,
                diaActuacion: null,
                horaInicio: null,
                horaFin: null,
                escenario: null,
                alojamiento: "Hotel Ibiza Beats",
                peticionEspecial: "Ninguna",
                estado: "ACTIVO",
                logoPath: "Recursos/user-profile-icon-in-flat-style-member-avatar-illustration-on-isolated-background.jpg"
            ),
            new Artista(
                nombre: "David Guetta",
                generoMusical: "EDM",
                datosPersonales: "Información personal de David Guetta",
                correoElectronico: "david@edm.com",
                redesSociales: "@DavidGuetta",
                cache: "180,000",
                fechaInicioFestival: new DateTime(2025, 7, 18),
                duracionFestival: 3,
                diaActuacion: null,
                horaInicio: null,
                horaFin: null,
                escenario: null,
                alojamiento: "Hotel Ibiza Beats",
                peticionEspecial: "Ninguna",
                estado: "ACTIVO",
                logoPath: "Recursos/David Guetta.jpg"
            )
        },
                    PrecioEstandar = 70,
                    PrecioVIP = 200,
                    Duracion = 3
                });

                Festivales.Add(new Festival
                {
                    Nombre = "Pop Paradise",
                    Fecha = new DateTime(2026, 8, 25),
                    Ubicacion = "Miami, USA",
                    Artistas = new ObservableCollection<Artista>
        {
            new Artista(
                nombre: "Taylor Swift",
                generoMusical: "Pop",
                datosPersonales: "Información personal de Taylor Swift",
                correoElectronico: "taylor@pop.com",
                redesSociales: "@TaylorSwift",
                cache: "300,000",
                fechaInicioFestival: new DateTime(2026, 8, 25),
                duracionFestival: 2,
                diaActuacion: null,
                horaInicio: null,
                horaFin: null,
                escenario: null,
                alojamiento: "Hotel Miami Luxe",
                peticionEspecial: "Ninguna",
                estado: "ACTIVO",
                logoPath: "Recursos/user-profile-icon-in-flat-style-member-avatar-illustration-on-isolated-background.jpg"
            ),
            new Artista(
                nombre: "Ariana Grande",
                generoMusical: "Pop",
                datosPersonales: "Información personal de Ariana Grande",
                correoElectronico: "ariana@pop.com",
                redesSociales: "@ArianaGrande",
                cache: "250,000",
                fechaInicioFestival: new DateTime(2026, 8, 25),
                duracionFestival: 2,
                diaActuacion: null,
                horaInicio: null,
                horaFin: null,
                escenario: null,
                alojamiento: "Hotel Miami Luxe",
                peticionEspecial: "Ninguna",
                estado: "ACTIVO",
                logoPath: "Recursos/user-profile-icon-in-flat-style-member-avatar-illustration-on-isolated-background.jpg"
            )
        },
                    PrecioEstandar = 100,
                    PrecioVIP = 300,
                    Duracion = 2
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
                DatosApp.FechaFestivalAct = festival.Fecha;
                DatosApp.DuracionFestivalAct= festival.Duracion;
                foreach (var artista in festival.Artistas)
                {
                    if (festival.Estado == "APLAZADO" || festival.Estado == "PASADO" || festival.Estado == "CANCELADO")
                    {
                        artista.Estado = festival.Estado;
                    }

                    if (festival.Fecha != artista.FechaInicioFestival||festival.Duracion!=artista.DuracionFestival)
                    {
                        artista.FechaInicioFestival = festival.Fecha;
                        artista.DuracionFestival=festival.Duracion;
                        artista.DiaActuacion = null;
                        artista.HoraInicio = null;
                        artista.HoraFin = null;
                    }
                }

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

        private void NumeroValido(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                // Intentar parsear el texto a entero usando la cultura invariante
                if (int.TryParse(tb.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out int value))
                {
                    // Formatear el valor como entero (sin decimales)
                    tb.Text = value.ToString("N0", CultureInfo.InvariantCulture);

                    if (tb.Tag is Festival festival)
                    {
                        // Verificar qué TextBox se está editando y actualizar la propiedad correspondiente
                        if (tb.Name == "PrecioEstandarTextBox")
                        {
                            festival.PrecioEstandar = value;
                        }
                        else if (tb.Name == "PrecioVIPTextBox")
                        {
                            festival.PrecioVIP = value;
                        }
                        else if (tb.Name == "DuracionTextBox")
                        {
                            festival.Duracion = value;
                        }

                        // Actualizar el festival en la colección local
                        int index = Festivales.IndexOf(festival);
                        if (index >= 0)
                        {
                            Festivales[index] = festival;
                        }

                        // Actualizar el festival en la colección global
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




        private void AlmacenarValor(object sender, RoutedEventArgs e)
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