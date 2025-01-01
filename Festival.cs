using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace ProyectoIPo
{
    public class Festival
    {
        public string Estado { get; set; } = "ACTIVO";
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Ubicacion { get; set; }
        public List<String> Artistas { get; set; } // Lista de artistas del festival
        public string ArtistasTexto => string.Join(", ", Artistas);

        public Festival() { }

        public Festival(string nombre, DateTime fecha, string ubicacion, List<String> artistas)
        {
            Nombre = nombre;
            Fecha = fecha;
            Ubicacion = ubicacion;
            Artistas = artistas;
        }
     
    }

    public class DateVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime fecha)
            {
                DateTime today = DateTime.Today;

                if (parameter?.ToString() == "Delete")
                {
                    // Botón de Borrar visible solo si la fecha es menor a la actual
                    return fecha.Date < today ? Visibility.Visible : Visibility.Collapsed;
                }
                else
                {
                    // Botones de Aplazar y Cancelar visibles si la fecha es igual o mayor a la actual
                    return fecha.Date >= today ? Visibility.Visible : Visibility.Collapsed;
                }
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
