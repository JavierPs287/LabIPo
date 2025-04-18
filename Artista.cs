using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIPo
{
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
        public DateTime FechaInicioFestival { get; set; }

        public DateTime? DiaActuacion { get; set; }
        public TimeSpan? HoraInicio { get; set; }
        public TimeSpan? HoraFin { get; set; }
        public int DuracionFestival { get; set; }
        public string LogoPath { get; set; }
        public bool EsGrupo { get; set; }

        public string DetalleArtistas { get; set; }
        // Propiedad calculada que determina si la actuación ha pasado
        public bool EsPasado
        {
            get
            {
                if (FechaInicioFestival == DateTime.MinValue || DuracionFestival <= 0)
                {
                    return false;
                }

                // Sumar la duración al inicio del festival para obtener la fecha final
                DateTime fechaFinal = FechaInicioFestival.AddDays(DuracionFestival);
                return fechaFinal < DateTime.Now; // Comparar la fecha final con la fecha actual
            }
        }

        // Constructor
        public Artista(string nombre, string generoMusical, string datosPersonales,
            string correoElectronico, string redesSociales, string cache, DateTime fechaInicioFestival, int duracionFestival,
            DateTime? diaActuacion, TimeSpan? horaInicio, TimeSpan? horaFin, string escenario,
            string alojamiento, string peticionEspecial, string estado, string logoPath, string detalleArtistas, bool esGrupo)
        {
            Nombre = nombre;
            GeneroMusical = generoMusical;
            DatosPersonales = datosPersonales;
            CorreoElectronico = correoElectronico;
            RedesSociales = redesSociales;
            Cache = cache;
            FechaInicioFestival = fechaInicioFestival;
            DuracionFestival = duracionFestival;
            DiaActuacion = diaActuacion;
            HoraInicio = horaInicio;
            HoraFin = horaFin;
            Escenario = escenario;
            Alojamiento = alojamiento;
            PeticionEspecial = peticionEspecial;
            Estado = estado;
            LogoPath = logoPath;
            DetalleArtistas = detalleArtistas;
            EsGrupo = esGrupo;


        }


        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;

        // Lista de estados disponibles para el artista dependiendo de si su actuación ya pasó
        public IEnumerable<string> EstadosDisponibles
        {
            get
            {
                if (EsPasado)
                {
                    return new[] { "PASADO" }; // Bloquea los estados disponibles si ya está pasado o aplazado
                }
                else if (Estado == "APLAZADO")
                {
                    return new[] { "APLAZADO" };
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
            get => EsPasado || Estado == "APLAZADO" ? Estado : Estado;
            set
            {
                // Bloquea el cambio si el estado es PASADO o APLAZADO
                if (EsPasado || Estado == "APLAZADO")
                {
                    return; // No se permite cambiar el estado si ya está PASADO o APLAZADO
                }

                // Solo cambia el estado si es distinto al actual
                if (Estado != value)
                {
                    Estado = value;
                    OnPropertyChanged(nameof(EstadoFinal));
                    OnPropertyChanged(nameof(EstadosDisponibles));  // Actualiza los estados disponibles

                    // Si el estado no es "ACTIVO" o "PASADO", borra las fechas de inicio y fin
                    if (Estado != "ACTIVO" && Estado != "PASADO")
                    {
                        DiaActuacion = null;
                        HoraInicio = null;
                        HoraFin = null;
                    }
                }
            }
        }

    }
}
