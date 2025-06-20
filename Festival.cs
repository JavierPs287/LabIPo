﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

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

        public ObservableCollection<Escenario> Escenarios { get; set; } = new ObservableCollection<Escenario>();


        public event PropertyChangedEventHandler PropertyChanged;

        public Festival() { }

        public Festival(string nombre, string ubicacion, DateTime fecha, ObservableCollection<Artista> artistas, ObservableCollection<Escenario> escenarios)
        {
            Nombre = nombre;
            Ubicacion = ubicacion;
            Fecha = fecha;
            Artistas = artistas ?? new ObservableCollection<Artista>();  // Si no se pasa artistas, se inicializa una lista vacía.
            Escenarios = escenarios ?? new ObservableCollection<Escenario>(); // Si no se pasa escenarios, se inicializa una lista vacía.
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
        private Artista artistaSeleccionado;
        public Artista ArtistaSeleccionado
        {
            get => artistaSeleccionado;
            set
            {
                if (artistaSeleccionado != value)
                {
                    artistaSeleccionado = value;
                    OnPropertyChanged(nameof(ArtistaSeleccionado));  // Esto notifica el cambio del artista seleccionado.
                    OnPropertyChanged(nameof(Artista.DetalleArtistas));     // Esto notifica el cambio de los detalles del artista.
                }
            }
        }

    }
}
