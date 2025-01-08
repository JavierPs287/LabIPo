using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using System.ComponentModel;

namespace ProyectoIPo
{
    public class Festival : INotifyPropertyChanged
    {
        public string EstadoFestival { get; set; } = "ACTIVO";
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Ubicacion { get; set; }
        public decimal PrecioEstandar { get; set; }
        public decimal PrecioVIP { get; set; }
        public List<string> Artistas { get; set; } // Lista de artistas del festival
        public string ArtistasTexto => string.Join(", ", Artistas);

        // Nueva propiedad para escenarios
        public List<Escenario> Escenarios { get; set; } = new List<Escenario>();
        public string EscenariosTexto => string.Join(", ", Escenarios.Select(e => e.Nombre));

        public event PropertyChangedEventHandler PropertyChanged;

        public Festival() { }

        public Festival(string nombre, DateTime fecha, string ubicacion, List<string> artistas)
        {
            Nombre = nombre;
            Fecha = fecha;
            Ubicacion = ubicacion;
            Artistas = artistas;
        }

      
        public DateTime FechaFestival
        {
            get => Fecha;
            set
            {
                if (Fecha != value)
                {
                    Fecha = value;
                    OnPropertyChanged(nameof(FechaFestival));
                    OnPropertyChanged(nameof(EsPasado));
                    OnPropertyChanged(nameof(EstadosDisponibles));
                    // Si la fecha ha pasado, actualizar estado a PASADO.
                    if (EsPasado)
                    {
                        // Actualiza el estado internamente a PASADO.
                        // Al establecer FechaFestival, se notifican cambios que activan el getter.
                        OnPropertyChanged(nameof(EstadoFestival));
                    }
                }
            }
        }

        public string Estado
        {
            get => EsPasado ? "PASADO" : EstadoFestival;
            set
            {
                // Permitir cambiar el estado solo si el festival no ha pasado.
                if (!EsPasado && EstadoFestival != value)
                {
                    EstadoFestival = value;
                    OnPropertyChanged(nameof(Estado));
                }
            }
        }

        // Propiedad calculada que determina si el festival ya pasó.
        public bool EsPasado => FechaFestival < DateTime.Now;

        // Lista de estados disponibles según si el festival ha pasado.
        public IEnumerable<string> EstadosDisponibles
        {
            get
            {
                if (EsPasado)
                {
                    return new[] { "PASADO" }; // Muestra PASADO cuando la fecha ha pasado.
                }
                else
                {
                    return new[] { "ACTIVO", "APLAZADO", "CANCELADO" };
                }
            }
        }



        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


    public class InverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
                return !boolValue;
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
                return !boolValue;
            return false;
        }
    }
}
