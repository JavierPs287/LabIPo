using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoIPo
{
    public partial class VentanaPrincipal : Window
    {
        public ObservableCollection<Festival> Festivales { get; set; }

        public VentanaPrincipal()
        {
            InitializeComponent();

            // Datos de ejemplo
            Festivales = new ObservableCollection<Festival>
            {
               new Festival
{
                    Nombre = "Rock Fest",
                    Fecha = new DateTime(2024, 6, 15),
                    Ubicacion = "Madrid, España",
                    Artistas = new List<Artista>
                    {
                        new Artista
                        {
                            Nombre = "Queen",
                            Imagen = "Recursos/queen.jpg", // URL o ruta de imagen (puedes dejar vacía o especificar una ruta si tienes una imagen)
                            Genero = "Rock",
                            Biografia = "Una banda de rock icónica formada en 1970 en Londres, conocida por éxitos como 'Bohemian Rhapsody' y 'We Will Rock You'.",
                            RedesSociales = new List<KeyValuePair<string, string>>
                            {
                                new KeyValuePair<string, string>("Facebook", "https://www.facebook.com/Queen/"),
                                new KeyValuePair<string, string>("Twitter", "https://twitter.com/queenwillrock"),
                                new KeyValuePair<string, string>("Instagram", "https://www.instagram.com/queen/")
                            }
                        },
                        new Artista
                        {
                            Nombre = "The Rolling Stones",
                            Imagen = "Recursos/rollingstones.jpg", // URL o ruta de imagen (puedes dejar vacía o especificar una ruta si tienes una imagen)
                            Genero = "Rock",
                            Biografia = "Una banda de rock británica formada en 1962, famosa por su estilo musical enérgico y éxitos como 'Paint It Black' y 'Sympathy for the Devil'.",
                            RedesSociales = new List<KeyValuePair<string, string>>
                            {
                                new KeyValuePair<string, string>("Facebook", "https://www.facebook.com/rollingstones/"),
                                new KeyValuePair<string, string>("Twitter", "https://twitter.com/rollingstones"),
                                new KeyValuePair<string, string>("Instagram", "https://www.instagram.com/therollingstones/")
                            }
                        }
                    }
                },
                new Festival
                {
                    Nombre = "Jazz Nights",
                    Fecha = new DateTime(2024, 5, 20),
                    Ubicacion = "Barcelona, España",
                    Artistas = new List<Artista>
                    {
                        new Artista
                        {
                            Nombre = "Miles Davis",
                            Imagen = "Recursos/milesdavis.jpg",
                            Genero = "Jazz",
                            Biografia = "Una de las figuras más influyentes en la historia del jazz, conocido por su estilo único y por álbumes como 'Kind of Blue'.",
                            RedesSociales = new List<KeyValuePair<string, string>>
                            {
                                new KeyValuePair<string, string>("Facebook", "https://www.facebook.com/MilesDavis/"),
                                new KeyValuePair<string, string>("Twitter", "https://twitter.com/milesdavis"),
                                new KeyValuePair<string, string>("Instagram", "https://www.instagram.com/milesdavis/")
                            }
                        },
                        new Artista
                        {
                            Nombre = "John Coltrane",
                            Imagen = "Recursos/johncoltrane.jpg",
                            Genero = "Jazz",
                            Biografia = "Pionero del saxofón tenor, conocido por su estilo avant-garde y álbumes icónicos como 'A Love Supreme'.",
                            RedesSociales = new List<KeyValuePair<string, string>>
                            {
                                new KeyValuePair<string, string>("Facebook", "https://www.facebook.com/johncoltrane/"),
                                new KeyValuePair<string, string>("Twitter", "https://twitter.com/johncoltrane"),
                                new KeyValuePair<string, string>("Instagram", "https://www.instagram.com/johncoltrane/")
                            }
                        }
                    }
                },

                new Festival
                {
                    Nombre = "Trap Beats",
                    Fecha = new DateTime(2024, 12, 10),
                    Ubicacion = "Buenos Aires, Argentina",
                    Artistas = new List<Artista>
                    {
                        new Artista
                        {
                            Nombre = "Bad Bunny",
                            Imagen = "Recursos/badbunny.jpg",
                            Genero = "Trap",
                            Biografia = "Una de las figuras más influyentes del trap, conocido por éxitos como 'YHLQMDLG' y su estilo único de fusión.",
                            RedesSociales = new List<KeyValuePair<string, string>>
                            {
                                new KeyValuePair<string, string>("Facebook", "https://www.facebook.com/BadBunny/"),
                                new KeyValuePair<string, string>("Twitter", "https://twitter.com/soybadbunny"),
                                new KeyValuePair<string, string>("Instagram", "https://www.instagram.com/badbunny/")
                            }
                        },
                        new Artista
                        {
                            Nombre = "Anuel AA",
                            Imagen = "Recursos/anuelaa.jpg",
                            Genero = "Trap",
                            Biografia = "Un pionero del reggaetón y el trap, conocido por sus colaboraciones y éxitos como 'Adictiva'.",
                            RedesSociales = new List<KeyValuePair<string, string>>
                            {
                                new KeyValuePair<string, string>("Facebook", "https://www.facebook.com/anuel/"),
                                new KeyValuePair<string, string>("Twitter", "https://twitter.com/anuel_2blea"),
                                new KeyValuePair<string, string>("Instagram", "https://www.instagram.com/anuel/")
                            }
                        }
                    }
                },

                new Festival
                {
                    Nombre = "Reggaeton Party",
                    Fecha = new DateTime(2025, 3, 10),
                    Ubicacion = "Miami, USA",
                    Artistas = new List<Artista>
                    {
                        new Artista
                        {
                            Nombre = "Daddy Yankee",
                            Imagen = "Recursos/daddyyankee.jpg",
                            Genero = "Reggaeton",
                            Biografia = "Una leyenda del reggaetón, conocido por éxitos como 'Gasolina' y su influencia en el género.",
                            RedesSociales = new List<KeyValuePair<string, string>>
                            {
                                new KeyValuePair<string, string>("Facebook", "https://www.facebook.com/daddyyankee/"),
                                new KeyValuePair<string, string>("Twitter", "https://twitter.com/daddyyankee"),
                                new KeyValuePair<string, string>("Instagram", "https://www.instagram.com/daddyyankee/")
                            }
                        },
                        new Artista
                        {
                            Nombre = "J Balvin",
                            Imagen = "Recursos/jbalvin.jpg",
                            Genero = "Reggaeton",
                            Biografia = "Uno de los artistas más influyentes del reggaetón, conocido por éxitos como 'Mi Gente' y su estilo innovador.",
                            RedesSociales = new List<KeyValuePair<string, string>>
                            {
                                new KeyValuePair<string, string>("Facebook", "https://www.facebook.com/JBalvin/"),
                                new KeyValuePair<string, string>("Twitter", "https://twitter.com/jbalvin"),
                                new KeyValuePair<string, string>("Instagram", "https://www.instagram.com/jbalvin/")
                            }
                        }
                    }
                },

                new Festival
                {
                    Nombre = "Electronic Beats",
                    Fecha = new DateTime(2024, 7, 12),
                    Ubicacion = "Ibiza, España",
                    Artistas = new List<Artista>
                    {
                        new Artista
                        {
                            Nombre = "Calvin Harris",
                            Imagen = "Recursos/calvinharris.jpg",
                            Genero = "Electronic",
                            Biografia = "Un DJ y productor líder en música electrónica, conocido por éxitos como 'Summer' y su estilo dance-pop.",
                            RedesSociales = new List<KeyValuePair<string, string>>
                            {
                                new KeyValuePair<string, string>("Facebook", "https://www.facebook.com/calvinharris/"),
                                new KeyValuePair<string, string>("Twitter", "https://twitter.com/calvinharris"),
                                new KeyValuePair<string, string>("Instagram", "https://www.instagram.com/calvinharris/")
                            }
                        },
                        new Artista
                        {
                            Nombre = "David Guetta",
                            Imagen = "Recursos/davidguetta.jpg",
                            Genero = "Electronic",
                            Biografia = "Un DJ y productor innovador, conocido por éxitos como 'Titanium' y 'Hey Mama'.",
                            RedesSociales = new List<KeyValuePair<string, string>>
                            {
                                new KeyValuePair<string, string>("Facebook", "https://www.facebook.com/davidguetta/"),
                                new KeyValuePair<string, string>("Twitter", "https://twitter.com/davidguetta"),
                                new KeyValuePair<string, string>("Instagram", "https://www.instagram.com/davidguetta/")
                            }
                        }
                    }
                },
                new Festival
                {
                    Nombre = "Blues Legends",
                    Fecha = new DateTime(2024, 8, 10),
                    Ubicacion = "Chicago, USA",
                    Artistas = new[] { "B.B. King", "Muddy Waters" }.Select(nombre => new Artista { Nombre = nombre }).ToList()
                },
                new Festival
                {
                    Nombre = "Metal Mayhem",
                    Fecha = new DateTime(2024, 9, 5),
                    Ubicacion = "Berlin, Alemania",
                    Artistas = new[] { "Metallica", "Iron Maiden" }.Select(nombre => new Artista { Nombre = nombre }).ToList()
                },
                new Festival
                {
                    Nombre = "Classical Evenings",
                    Fecha = new DateTime(2024, 6, 30),
                    Ubicacion = "Viena, Austria",
                    Artistas = new[] { "Ludwig van Beethoven", "Wolfgang Amadeus Mozart" }.Select(nombre => new Artista { Nombre = nombre }).ToList()
                },
                new Festival
                {
                    Nombre = "Reggae Sun",
                    Fecha = new DateTime(2024, 7, 25),
                    Ubicacion = "Kingston, Jamaica",
                    Artistas = new[] { "Bob Marley", "Peter Tosh" }.Select(nombre => new Artista { Nombre = nombre }).ToList()
                },
                new Festival
                {
                    Nombre = "PopFest",
                    Fecha = new DateTime(2024, 10, 2),
                    Ubicacion = "Los Ángeles, USA",
                    Artistas = new[] { "Ariana Grande", "Taylor Swift" }.Select(nombre => new Artista { Nombre = nombre }).ToList()
                },
                new Festival
                {
                    Nombre = "Indie Vibes",
                    Fecha = new DateTime(2024, 8, 20),
                    Ubicacion = "Londres, UK",
                    Artistas = new[] { "The Strokes", "Arctic Monkeys" }.Select(nombre => new Artista { Nombre = nombre }).ToList()
                },
                new Festival
                {
                    Nombre = "Country Jam",
                    Fecha = new DateTime(2024, 9, 15),
                    Ubicacion = "Nashville, USA",
                    Artistas = new[] { "Johnny Cash", "Dolly Parton" }.Select(nombre => new Artista { Nombre = nombre }).ToList()
                },
                new Festival
                {
                    Nombre = "R&B Soul Fest",
                    Fecha = new DateTime(2024, 11, 1),
                    Ubicacion = "Atlanta, USA",
                    Artistas = new[] { "Aretha Franklin", "Marvin Gaye" }.Select(nombre => new Artista { Nombre = nombre }).ToList()
                },
                new Festival
                {
                    Nombre = "Latin Fusion",
                    Fecha = new DateTime(2024, 6, 25),
                    Ubicacion = "México D.F., México",
                    Artistas = new[] { "Carlos Santana", "Shakira" }.Select(nombre => new Artista { Nombre = nombre }).ToList()
                },
                new Festival
                {
                    Nombre = "Punk Rock Riot",
                    Fecha = new DateTime(2024, 7, 19),
                    Ubicacion = "Los Ángeles, USA",
                    Artistas = new[] { "Green Day", "The Offspring" }.Select(nombre => new Artista { Nombre = nombre }).ToList()
                },
                new Festival
                {
                    Nombre = "Hip Hop Summit",
                    Fecha = new DateTime(2024, 9, 25),
                    Ubicacion = "Nueva York, USA",
                    Artistas = new[] { "Kendrick Lamar", "Drake" }.Select(nombre => new Artista { Nombre = nombre }).ToList()
                }
            };


            // Ordenar los festivales por la fecha
            Festivales = new ObservableCollection<Festival>(Festivales.OrderBy(f => f.Fecha));

            // Establecer el contexto de datos para el enlace
            DataContext = this;
        }
        private void Window_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            // Verificar si el desplazamiento es vertical
            if (FestivalScrollViewer != null)
            {
                // Aplicar desplazamiento hacia arriba o hacia abajo según el movimiento de la rueda
                if (e.Delta > 0)
                {
                    FestivalScrollViewer.ScrollToVerticalOffset(FestivalScrollViewer.VerticalOffset - 30); // Ajusta el valor de desplazamiento
                }
                else
                {
                    FestivalScrollViewer.ScrollToVerticalOffset(FestivalScrollViewer.VerticalOffset + 30); // Ajusta el valor de desplazamiento
                }
            }

            e.Handled = true;  // Evita que el evento sea manejado de otra manera
        }

        private void OnAddFestivalClick(object sender, RoutedEventArgs e)
        {
            // Crear una nueva ventana para ingresar los datos del nuevo festival
            var ventanaAgregarFestival = new VentanaAgregarFestival();
            ventanaAgregarFestival.FestivalAdded += OnFestivalAdded; // Suscribimos al evento para actualizar la lista
            ventanaAgregarFestival.ShowDialog();
        }

        private void OnFestivalAdded(object sender, Festival nuevoFestival)
        {
            // Agregar el nuevo festival al principio
            Festivales.Add(nuevoFestival);

            // Ordenar nuevamente los festivales por la fecha
            Festivales = new ObservableCollection<Festival>(Festivales.OrderBy(f => f.Fecha));

            // Notificar el cambio para que la vista se actualice
            FestivalListBox.ItemsSource = null; // Vaciar el ItemsSource
            FestivalListBox.ItemsSource = Festivales; // Asignar la nueva colección ordenada
        }

        private void ExpanderHeader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Expander expander)
            {
                expander.IsExpanded = !expander.IsExpanded; // Alternar el estado del Expander
            }
        }

        private void FestivalListBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Iterar sobre los items en el ListBox para buscar el Expander asociado
            var item = e.OriginalSource as FrameworkElement;
            while (item != null && !(item is Expander))
            {
                item = item.Parent as FrameworkElement;
            }

            if (item is Expander expander)
            {
                expander.IsExpanded = !expander.IsExpanded; // Alternar el estado del Expander
            }
        }

        private void OnViewArtistsClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                // Obtener el festival asociado a este botón
                var festivalSeleccionado = button.DataContext as Festival;
                if (festivalSeleccionado != null)
                {
                    var ventanaDetallesArtistas = new VentanaDetallesArtistas(festivalSeleccionado.Artistas);
                    ventanaDetallesArtistas.ShowDialog(); // Mostrar la ventana de detalles de los artistas
                }
            }
        }

    }

    public class FutureDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime fecha)
            {
                return fecha > DateTime.Now; // Devolver un valor booleano
            }
            return false; // En caso de no ser DateTime, se devuelve false
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class PastDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime fecha)
            {
                return fecha < DateTime.Now; // Devolver un valor booleano
            }
            return false; // En caso de no ser DateTime, se devuelve false
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class TodayDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime fecha)
            {
                // Compara solo la fecha, sin tener en cuenta la hora
                return fecha.Date == DateTime.Now.Date;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}