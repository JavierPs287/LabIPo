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

        public Login Login { get; set; }
        public ObservableCollection<Festival> Festivales { get; set; }
        public ObservableCollection<Festival> FestivalesFiltrados { get; set; }
        public Escenario esce { get; set; }

        public VentanaPrincipal()
        {
            InitializeComponent();
            InicializarDatos();
        }
        public VentanaPrincipal(string username, DateTime lastAccessDate)
        {
            InitializeComponent();
            Username = username;
            LastAccessDate = lastAccessDate;
            InicializarDatos();

        }
        private VentanaUsuario ventanaUsuario; // Creamos la variable a nivel de clase

        private void btnEntrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (ventanaUsuario == null || !ventanaUsuario.IsLoaded)
            {
                ventanaUsuario = new VentanaUsuario(Username, this.LastAccessDate);
                ventanaUsuario.Show();
            }
            else
            {
                ventanaUsuario.Activate(); // Si ya estaba abierta, la traemos al frente
            }
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
                logoPath: "Recursos/Queen.jpg",
                detalleArtistas: "Queen es una banda británica de rock formada en 1970 en Londres, integrada originalmente por el cantante y pianista Freddie Mercury, el guitarrista Brian May, el baterista Roger Taylor y el bajista John Deacon (el cual llegaría un año después al grupo para completar la formación clásica)",
                esGrupo: true

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
                escenario: "Escenario Principal",
                alojamiento: "Hotel Beatriz",
                peticionEspecial: "nada",
                estado: "ACTIVO",
                logoPath: "Recursos/Bon Jovi.jpg",
                detalleArtistas: "Bon Jovi es una banda de rock estadounidense formada en 1983 en Sayreville, Nueva Jersey. La banda fue fundada por el cantante Jon Bon Jovi, el tecladista David Bryan, el bajista Alec John Such, el guitarrista Richie Sambora y el baterista Tico Torres.",
                esGrupo: true
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
                escenario : "Escenario Principal",
                alojamiento: "Hotel Beatriz",
                peticionEspecial: "nada",
                estado: "ACTIVO",
                logoPath: "Recursos/Guns N' Roses.jpg",
                detalleArtistas:"Guns N' Roses es una banda de rock estadounidense formada en 1985 en Los Ángeles, California. La banda fue fundada por el vocalista Axl Rose y el guitarrista Slash, y se considera una de las bandas más influyentes y exitosas de la historia del rock.",
                esGrupo: true
            )
        },
                    // CREACION DE ESCENARIOS YA TU SBS BB
                    Escenarios = new ObservableCollection<Escenario>
                    {
                        new Escenario(
                            
                            nombre: "Escenario Principal",
                            aforoMax: "10000",
                            localizacionEntradasSalidas: "Entrada Principal",
                            serviciosMedicos: "Servicio de Emergencias",
                            aseos: "Aseos Públicos",
                            seguridad: "Seguridad Privada",
                            fotoPath: "Recursos/EscenarioPrincipal.jpg"
                            ),
                    },

                    // AÑADE AQUI LO QUE QUIERAS TU BB
                    // NEW ESCENARIO(..............)








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
                logoPath: "Recursos/Miles Davis.jpg",
                detalleArtistas: "Miles Davis fue un trompetista, compositor y líder de banda estadounidense, considerado uno de los músicos más influyentes del siglo XX. Su estilo innovador y su enfoque vanguardista en el jazz lo convirtieron en una figura clave en la evolución del género.",
                esGrupo: false
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
                logoPath: "Recursos/John Coltrane.jpg",
                detalleArtistas:"John Coltrane fue un saxofonista y compositor estadounidense, conocido por su virtuosismo y su enfoque innovador en el jazz. Su trabajo abarcó desde el bebop hasta el free jazz, y su álbum 'A Love Supreme' es considerado una obra maestra del género.",
                esGrupo: false
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
                logoPath: "Recursos/Duki.jpg",
                detalleArtistas: "Duki es un rapero y cantante argentino, conocido por su estilo innovador y su influencia en la escena del trap latino. Su música combina elementos de trap, reguetón y hip-hop, y ha colaborado con varios artistas destacados en la industria.",
                esGrupo: false
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
                logoPath: "Recursos/Bad Bunny.jpg",
                detalleArtistas:"Bad Bunny es un cantante y rapero puertorriqueño, conocido por su estilo único y su impacto en la música urbana. Su música combina reguetón, trap y otros géneros, y ha sido aclamado por su innovación y autenticidad en la industria musical.",
                esGrupo: false
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
                logoPath: "Recursos/Eladio Carrión.jpg",
                detalleArtistas:"Eladio Carrión es un rapero y cantante puertorriqueño, conocido por su estilo fresco y su habilidad lírica. Ha ganado reconocimiento en la escena del trap latino y ha colaborado con varios artistas destacados, consolidándose como una figura influyente en la música urbana.",
                esGrupo: false
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
                logoPath: "Recursos/Martin Garrix.jpg",
                detalleArtistas:"Martin Garrix es un DJ y productor holandés, conocido por su estilo innovador en la música electrónica. Ha sido reconocido como uno de los mejores DJs del mundo y ha colaborado con varios artistas destacados, creando éxitos que han dominado las listas de popularidad.",
                esGrupo: false
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
                logoPath: "Recursos/David Guetta.jpg",
                detalleArtistas: "David Guetta es un DJ y productor francés, conocido por su influencia en la música electrónica y su capacidad para fusionar géneros. Ha trabajado con numerosos artistas de renombre y ha sido pionero en la popularización de la música dance a nivel mundial.",
                esGrupo: false
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
                logoPath: "Recursos/Taylor Swift.jpg",
                detalleArtistas:"Taylor Swift es una cantante y compositora estadounidense, conocida por su estilo versátil que abarca country, pop y rock. Ha ganado numerosos premios y es reconocida por su habilidad para contar historias a través de sus letras, convirtiéndose en una de las artistas más influyentes de su generación.",
                esGrupo: false
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
                logoPath: "Recursos/Ariana Grande.jpg",
                detalleArtistas:"Ariana Grande es una cantante y actriz estadounidense, conocida por su potente voz y su estilo musical que combina pop, R&B y hip-hop. Ha sido aclamada por su talento vocal y ha logrado numerosos éxitos en las listas de popularidad, convirtiéndose en una de las artistas más influyentes de la música contemporánea.",
                esGrupo: false

                ),
            new Artista(

                nombre: "Freddie Mercury",
                generoMusical: "rock",
                datosPersonales: "Cantante de la Banda",
                correoElectronico: "@freddiemercury.com",
                redesSociales: "@FreddieMercury",
                cache: "10000",
                fechaInicioFestival: new DateTime(2025, 7, 18),
                duracionFestival: 3,
                diaActuacion: null,
                horaInicio: null,
                horaFin: null,
                escenario: null,
                alojamiento: "Hotel Miami Luxe",
                peticionEspecial: "Ninguna",
                estado: "ACTIVO",
                logoPath: "queen",
                detalleArtistas:"Freddie Mercury fue un cantante, compositor y pianista británico, conocido por ser el vocalista principal de la banda de rock Queen. Su poderosa voz y su carisma en el escenario lo convirtieron en una de las figuras más icónicas de la música rock, y su legado perdura hasta hoy.",
                esGrupo: false
                ),
            new Artista(
                nombre: "Brian May",
                generoMusical: "rock",
                datosPersonales: "Guitarrista de la Banda",
                correoElectronico: "@brianmay.com",
                redesSociales: "@BrianMay",
                cache: "10000",
                fechaInicioFestival: new DateTime(2025, 7, 18),
                duracionFestival: 3,
                diaActuacion: null,
                horaInicio: null,
                horaFin: null,
                escenario: null,
                alojamiento: "Hotel Miami Luxe",
                peticionEspecial: "Ninguna",
                estado: "ACTIVO",
                logoPath: "queen",
                detalleArtistas:"Brian May es un guitarrista, compositor y astrofísico británico, conocido por ser el guitarrista principal de la banda de rock Queen. Su estilo distintivo y su habilidad para componer canciones memorables lo han convertido en una figura influyente en la música rock.",
                esGrupo: false
                ),
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

        private void BotonAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta es la pantalla principal de la aplicación.\n" +
                "Aquí se pueden observar todos los festivales, tanto pasados, como presentes y futuros.\n" +
                "Para modificar cualqueir dato, haga click en el cuadro de texto correspondiente y modifíquelo.\n" +
                "Para modificar los artistas y escenario haga click en el botón 'Visualizar Artistas y Escenerios'" , "Ayuda Ventana Gestión de Festivales", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}