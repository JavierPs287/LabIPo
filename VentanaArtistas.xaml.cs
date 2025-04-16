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

  





        public VentanaArtistas(Festival festival)
        {
            InitializeComponent();
            this.festivalSeleccionado = festival;

            // Agrupar solo los artistas del festival seleccionado
            Artistas = new ObservableCollection<Artista>(festival.Artistas);
            dataGridArtistas.ItemsSource = Artistas;
            DataContext = this;

            // Verificación de que la colección Artistas no está vacía
            if (Artistas == null || Artistas.Count == 0)
            {

                MessageBox.Show("No hay artistas disponibles para este festival.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {

                // Agrupando escenarios sin duplicados para este festival
                Escenarios = new ObservableCollection<Escenario>(
                    festival.Escenarios.GroupBy(e => e.Nombre)
                                       .Select(g => g.First())
                );

                // para cada Artista, se asigna su información para seleccionar y mostrar cada uno su información
                foreach (var artista in Artistas)
                {
                    artista.Nombre = artista.Nombre;
                    artista.GeneroMusical = artista.GeneroMusical;
                    artista.DatosPersonales = artista.DatosPersonales;
                    artista.CorreoElectronico = artista.CorreoElectronico;
                    artista.RedesSociales = artista.RedesSociales;
                    artista.Cache = artista.Cache;
                    artista.FechaInicioFestival = festival.Fecha;
                    artista.DuracionFestival = festival.Duracion;
                }
                // ahora la información metela en cada listBox



                ArtistasListBox.ItemsSource = Artistas;
                EscenariosListBox.ItemsSource = Escenarios;
                EscenariosListBox.SelectionChanged += EscenariosListBox_SelectionChanged;
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
                    // Añadiendo el nuevo artista a la lista y al estado del festival
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

        private void ArtistasListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ArtistasListBox.SelectedItem is Artista artistaSeleccionado)
            {
                dataGridArtistas.ItemsSource = new List<Artista> { artistaSeleccionado };
            }
        }


        private void EscenariosListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (EscenariosListBox.SelectedItem is Escenario escenarioSeleccionado)
            {
                // Actualizando detalles del escenario seleccionado
                dataGridEscenarios.ItemsSource = new List<Escenario> { escenarioSeleccionado };
                txtDetallesEscenario.Text = $"Nombre: {escenarioSeleccionado.Nombre}\n" +
                                             $"Aforo Máximo: {escenarioSeleccionado.AforoMax}\n" +
                                             $"Localización Entradas/Salidas: {escenarioSeleccionado.LocalizacionEntradasSalidas}\n" +
                                             $"Servicios Médicos: {escenarioSeleccionado.ServiciosMedicos}\n" +
                                             $"Aseos: {escenarioSeleccionado.Aseos}\n" +
                                             $"Seguridad: {escenarioSeleccionado.Seguridad}";
            }
        }

        private void AñadirEscenario_Click(object sender, RoutedEventArgs e)
        {
            var agregarEscenariosWindow = new AgregarEscenarios();
            if (agregarEscenariosWindow.ShowDialog() == true)
            {
                foreach (var nuevoEscenario in agregarEscenariosWindow.NuevosEscenarios)
                {
                    // Añadiendo el nuevo escenario al festival si no existe
                    if (!festivalSeleccionado.Escenarios.Any(escenario => escenario.Nombre == nuevoEscenario.Nombre))
                    {
                        festivalSeleccionado.Escenarios.Add(nuevoEscenario);
                        Escenarios.Add(nuevoEscenario); // También se agrega al listado de la UI
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
