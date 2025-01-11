using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ProyectoIPo
{
    public class Festival : INotifyPropertyChanged
    {
        public string EstadoFestival { get; set; } = "ACTIVO";
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Ubicacion { get; set; }
        public int PrecioEstandar { get; set; }
        public int PrecioVIP { get; set; }
        public int Duracion { get; set; }

        // Lista de artistas del festival, ahora contiene objetos Artista
        public ObservableCollection<Artista> Artistas { get; set; } = new ObservableCollection<Artista>();

        // Método para obtener los nombres de los artistas en formato de texto
        public string ArtistasTexto => string.Join(", ", Artistas.Select(a => a.DatosPersonales));

        public List<Escenario> Escenarios { get; set; } = new List<Escenario>();
        public string EscenariosTexto => string.Join(", ", Escenarios.Select(e => e.Nombre));

        public event PropertyChangedEventHandler PropertyChanged;

        public Festival() { }

        public Festival(string nombre, string ubicacion, DateTime fecha, ObservableCollection<Artista> artistas)
        {
            Nombre = nombre;
            Ubicacion = ubicacion;
            Fecha = fecha;
            Artistas = artistas ?? new ObservableCollection<Artista>();  // Si no se pasa artistas, se inicializa una lista vacía.
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

        // Método para agregar un artista al festival
        public void AgregarArtista(Artista artista)
        {
            if (!Artistas.Contains(artista))
            {
                Artistas.Add(artista);
                OnPropertyChanged(nameof(Artistas));
                OnPropertyChanged(nameof(ArtistasTexto));
            }
        }

        // Método para eliminar un artista del festival
        public void EliminarArtista(Artista artista)
        {
            if (Artistas.Contains(artista))
            {
                Artistas.Remove(artista);
                OnPropertyChanged(nameof(Artistas));
                OnPropertyChanged(nameof(ArtistasTexto));
            }
        }
    }


    public class Artista : INotifyPropertyChanged
    {
        // Propiedades
        public string Nombre { get; set; }
        public string GeneroMusical { get; set; }
        public string DatosPersonales { get; set; }
        public string CorreoElectronico { get; set; }
        public string RedesSociales { get; set; }
        public string Cache { get; set; }
        public string Escenario { get; set; }
        public string Alojamiento { get; set; }
        public string PeticionEspecial { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaFestival { get; set; }

        public DateTime? DiaYHoraInicioActuacion { get; set; }
        public DateTime? DiaYHoraFinActuacion { get; set; }

        // Propiedad calculada que determina si la actuación ha pasado
        public bool EsPasado => FechaFestival < DateTime.Now;

        // Lista de estados disponibles para el artista dependiendo de si su actuación ya pasó
        public IEnumerable<string> EstadosDisponibles
        {
            get
            {
                if (EsPasado)
                {
                    return new[] { "PASADO" }; // Muestra PASADO cuando la fecha de actuación ha pasado
                }
                else
                {
                    return new[] { "ACTIVO", "APLAZADO", "CANCELADO" };
                }
            }
        }

        // Propiedad calculada que devuelve el estado del artista según la fecha de actuación
        public string EstadoFinal
        {
            get => EsPasado ? "PASADO" : Estado;
            set
            {
                if (!EsPasado && Estado != value)
                {
                    Estado = value;
                    OnPropertyChanged(nameof(EstadoFinal));

                    // Si el estado no es "ACTIVO" o "PASADO", borra las fechas de inicio y fin
                    if (Estado != "ACTIVO" && Estado != "PASADO")
                    {
                        DiaYHoraInicioActuacion = null;
                        DiaYHoraFinActuacion = null;
                    }
                }
            }
        }

        // Constructor
        public Artista(string nombre, string generoMusical, string datosPersonales,
            string correoElectronico, string redesSociales, string cache, DateTime? fechaFestival,
            DateTime? diaYHoraInicioActuacion, DateTime? diaYHoraFinActuacion, string escenario,
            string alojamiento, string peticionEspecial, string estado)
        {
            Nombre = nombre;
            GeneroMusical = generoMusical;
            DatosPersonales = datosPersonales;
            CorreoElectronico = correoElectronico;
            RedesSociales = redesSociales;
            Cache = cache;
            FechaFestival = fechaFestival;
            DiaYHoraInicioActuacion = diaYHoraInicioActuacion;
            DiaYHoraFinActuacion = diaYHoraFinActuacion;
            Escenario = escenario;
            Alojamiento = alojamiento;
            PeticionEspecial = peticionEspecial;
            Estado = estado;
        }

        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;
    }


    public class Escenario
    {
        public string Nombre { get; set; }
        public string AforoMax { get; set; }
        public string LocalizacionEntradasSalidas { get; set; }
        public string ServiciosMedicos { get; set; }
        public string Aseos { get; set; }
        public string Seguridad { get; set; }
        public DateTime DiaHoraActuacion { get; set; } // Día y hora de la actuación
        public string FotoPath { get; set; } // Ruta de la foto
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

    public static class DatosApp
    {
        // Diccionario estático para almacenar usuarios y contraseñas
        public static Dictionary<string, string> UsuariosYContraseñas = new Dictionary<string, string>();
        public static ObservableCollection<Festival> Festivales { get; set; } = new ObservableCollection<Festival>();
    }

    public class DateTimeToDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime)
            {
                return dateTime.Date; // Solo la parte de la fecha sin la hora
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime date)
            {
                return date.AddHours(0); // Aquí puedes ajustar la hora según sea necesario
            }
            return null;
        }
    }


}
