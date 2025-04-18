using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ProyectoIPo
{
    public partial class VentanaArtistas : Window
    {
        private Festival festivalSeleccionado;
        public ObservableCollection<Artista> Artistas { get; set; }
        public ObservableCollection<Escenario> Escenarios { get; set; } = new ObservableCollection<Escenario>();
        public List<TimeSpan> HorasDisponibles { get; } = GenerarHoras();

        public VentanaArtistas(Festival festival)
        {
            InitializeComponent();
            this.festivalSeleccionado = festival;

            // Agrupar solo los artistas del festival seleccionado
            Artistas = new ObservableCollection<Artista>(festival.Artistas);
            ArtistasListBox.ItemsSource = Artistas;

            Escenarios = new ObservableCollection<Escenario>(
                festival.Escenarios.GroupBy(e => e.Nombre)
                                   .Select(g => g.First())
            );
            EscenariosListBox.ItemsSource = Escenarios;

            ArtistasListBox.SelectionChanged += ArtistasListBox_SelectionChanged;
            EscenariosListBox.SelectionChanged += EscenariosListBox_SelectionChanged;

            DataContext = this;

            if (Artistas == null || Artistas.Count == 0)
            {
                MessageBox.Show("No hay artistas disponibles para este festival.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (Escenarios == null || Escenarios.Count == 0)
            {
                MessageBox.Show("No hay escenarios disponibles para este festival.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ArtistasListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ArtistasListBox.SelectedItem is Artista artistaSeleccionado)
            {
                dataGridArtistas.ItemsSource = new List<Artista> { artistaSeleccionado };
            }
        }

        private void AñadirArtista_Click(object sender, RoutedEventArgs e)
        {
            var agregarArtistaWindow = new AgregarArtistas();
            if (agregarArtistaWindow.ShowDialog() == true)
            {
                var nuevoArtista = agregarArtistaWindow.NuevoArtista;
                if (nuevoArtista != null && !string.IsNullOrEmpty(nuevoArtista.Nombre) && !Artistas.Any(a => a.Nombre == nuevoArtista.Nombre))
                {
                    Artistas.Add(nuevoArtista);
                    festivalSeleccionado.Artistas.Add(nuevoArtista);
                    DatosApp.Festivales.Remove(festivalSeleccionado);
                    DatosApp.Festivales.Add(festivalSeleccionado);
                }
                else
                {
                    MessageBox.Show("El artista ya existe o el nombre es inválido.");
                }
            }
        }

        private static List<TimeSpan> GenerarHoras()
        {
            var lista = new List<TimeSpan>();
            for (int h = 0; h < 24; h++)
            {
                lista.Add(new TimeSpan(h, 0, 0));
                lista.Add(new TimeSpan(h, 30, 0));
            }
            return lista;
        }

        // GESTIÓN DE ESCENARIOS

        private void EscenariosListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (EscenariosListBox.SelectedItem is Escenario escenarioSeleccionado)
            {
                dataGridEscenarios.ItemsSource = new List<Escenario> { escenarioSeleccionado };
                txtDetallesEscenario.Text = $"Nombre: {escenarioSeleccionado.Nombre}\n" +
                                             $"Aforo Máximo: {escenarioSeleccionado.AforoMax}\n" +
                                             $"Localización Entradas/Salidas: {escenarioSeleccionado.LocalizacionEntradasSalidas}\n" +
                                             $"Servicios Médicos: {escenarioSeleccionado.ServiciosMedicos}\n" +
                                             $"Aseos: {escenarioSeleccionado.Aseos}\n" +
                                             $"Seguridad: {escenarioSeleccionado.Seguridad}\n" +
                                             $"Día y Hora de Actuación: {escenarioSeleccionado.DiaHoraActuacion}";
            }
        }

        private void AñadirEscenario_Click(object sender, RoutedEventArgs args)
        {
            var agregarEscenariosWindow = new AgregarEscenarios();
            if (agregarEscenariosWindow.ShowDialog() == true)
            {
                foreach (var nuevoEscenario in agregarEscenariosWindow.NuevosEscenarios)
                {
                    if (!festivalSeleccionado.Escenarios.Any(esc => esc.Nombre == nuevoEscenario.Nombre))
                    {
                        festivalSeleccionado.Escenarios.Add(nuevoEscenario);
                        Escenarios.Add(nuevoEscenario);
                    }
                    else
                    {
                        MessageBox.Show($"El escenario {nuevoEscenario.Nombre} ya existe.");
                    }
                }
            }
        }
    }
}
