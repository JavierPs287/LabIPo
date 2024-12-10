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
                    Artistas = new[] { "Queen", "The Rolling Stones" }
                },
                new Festival
                {
                    Nombre = "Jazz Nights",
                    Fecha = new DateTime(2024, 5, 20),
                    Ubicacion = "Barcelona, España",
                    Artistas = new[] { "Miles Davis", "John Coltrane" }
                },
                new Festival
                {
                    Nombre = "Trap Beats",
                    Fecha = new DateTime(2024, 12, 10),
                    Ubicacion = "Buenos Aires, Argentina",
                    Artistas = new[] { "Bad Bunny", "Anuel AA" }
                },
                new Festival
                {
                    Nombre = "Reggaeton Party",
                    Fecha = new DateTime(2025, 3, 10),
                    Ubicacion = "Miami, USA",
                    Artistas = new[] { "Daddy Yankee", "J Balvin" }
                },
                new Festival
                {
                    Nombre = "Electronic Beats",
                    Fecha = new DateTime(2024, 7, 12),
                    Ubicacion = "Ibiza, España",
                    Artistas = new[] { "Calvin Harris", "David Guetta" }
                },
                new Festival
                {
                    Nombre = "Blues Legends",
                    Fecha = new DateTime(2024, 8, 10),
                    Ubicacion = "Chicago, USA",
                    Artistas = new[] { "B.B. King", "Muddy Waters" }
                },
                new Festival
                {
                    Nombre = "Metal Mayhem",
                    Fecha = new DateTime(2024, 9, 5),
                    Ubicacion = "Berlin, Alemania",
                    Artistas = new[] { "Metallica", "Iron Maiden" }
                },
                new Festival
                {
                    Nombre = "Classical Evenings",
                    Fecha = new DateTime(2024, 6, 30),
                    Ubicacion = "Viena, Austria",
                    Artistas = new[] { "Ludwig van Beethoven", "Wolfgang Amadeus Mozart" }
                },
                new Festival
                {
                    Nombre = "Reggae Sun",
                    Fecha = new DateTime(2024, 7, 25),
                    Ubicacion = "Kingston, Jamaica",
                    Artistas = new[] { "Bob Marley", "Peter Tosh" }
                },
                new Festival
                {
                    Nombre = "PopFest",
                    Fecha = new DateTime(2024, 10, 2),
                    Ubicacion = "Los Ángeles, USA",
                    Artistas = new[] { "Ariana Grande", "Taylor Swift" }
                },
                new Festival
                {
                    Nombre = "Indie Vibes",
                    Fecha = new DateTime(2024, 8, 20),
                    Ubicacion = "Londres, UK",
                    Artistas = new[] { "The Strokes", "Arctic Monkeys" }
                },
                new Festival
                {
                    Nombre = "Country Jam",
                    Fecha = new DateTime(2024, 9, 15),
                    Ubicacion = "Nashville, USA",
                    Artistas = new[] { "Johnny Cash", "Dolly Parton" }
                },
                new Festival
                {
                    Nombre = "R&B Soul Fest",
                    Fecha = new DateTime(2024, 11, 1),
                    Ubicacion = "Atlanta, USA",
                    Artistas = new[] { "Aretha Franklin", "Marvin Gaye" }
                },
                new Festival
                {
                    Nombre = "Latin Fusion",
                    Fecha = new DateTime(2024, 6, 25),
                    Ubicacion = "México D.F., México",
                    Artistas = new[] { "Carlos Santana", "Shakira" }
                },
                new Festival
                {
                    Nombre = "Punk Rock Riot",
                    Fecha = new DateTime(2024, 7, 19),
                    Ubicacion = "Los Ángeles, USA",
                    Artistas = new[] { "Green Day", "The Offspring" }
                },
                new Festival
                {
                    Nombre = "Hip Hop Summit",
                    Fecha = new DateTime(2024, 9, 25),
                    Ubicacion = "Nueva York, USA",
                    Artistas = new[] { "Kendrick Lamar", "Drake" }
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

    }

    public class Festival
    {
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }  // Fecha única del festival
        public string Ubicacion { get; set; }  // Ubicación del festival
        public string[] Artistas { get; set; }  // Lista de artistas
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