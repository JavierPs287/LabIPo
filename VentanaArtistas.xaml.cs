using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ProyectoIPo
{
    public partial class VentanaArtistas : Window
    {
        private Festival festivalSeleccionado;
        public DateTime FechaInicioFestival => festivalSeleccionado.FechaFestival;
        public DateTime FechaFinFestival => festivalSeleccionado.FechaFestival.AddDays(festivalSeleccionado.Duracion - 1);
        public ObservableCollection<Artista> Artistas { get; set; }
        public ObservableCollection<Escenario> Escenarios { get; set; } 
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

        private DateTime? fechaInicialDatePicker = null;

        private void DatePicker_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is DatePicker dp)
            {
                // Guardamos la fecha inicial que tenía el DatePicker
                fechaInicialDatePicker = dp.SelectedDate;

                dp.DisplayDateStart = FechaInicioFestival;
                dp.DisplayDateEnd = FechaFinFestival;
            }
        }

        private void ComboBox_DropDownOpened(object sender, EventArgs args)
        {
            // Obtener la lista actualizada de nombres de escenarios
            var listaActualizada = Escenarios.Select(esc => esc.Nombre).ToList();

            if (sender is ComboBox comboBox)
            {
                comboBox.ItemsSource = listaActualizada;
            }
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DatePicker dp && dp.SelectedDate.HasValue)
            {
                var fecha = dp.SelectedDate.Value;
                if (fecha < FechaInicioFestival || fecha > FechaFinFestival)
                {
                    dp.SelectedDate = fechaInicialDatePicker;
                    MessageBox.Show($"La fecha debe estar entre {FechaInicioFestival:dd/MM/yyyy} y {FechaFinFestival:dd/MM/yyyy}.", "Fecha inválida", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    fechaInicialDatePicker = fecha;
                }
            }
        }

        private void ArtistasListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ArtistasListBox.SelectedItem is Artista artistaSeleccionado)
            {
                // El DataGrid mostrará la colección completa, para que edites directamente
                dataGridArtistas.ItemsSource = Artistas;
                // Seleccionar en DataGrid el artista actual para facilitar edición
                dataGridArtistas.SelectedItem = artistaSeleccionado;

                // Mostrar detalles actualizados
                txtDetallesArtista.Text = artistaSeleccionado.DetalleArtistas;
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

        private void EliminarArtista_Click(object sender, RoutedEventArgs e)
        {
            if (ArtistasListBox.SelectedItem is Artista artistaSeleccionado)
            {
                MessageBoxResult confirmacion = MessageBox.Show(
                    $"¿Estás seguro de que deseas eliminar al artista: {artistaSeleccionado.Nombre}?",
                    "Confirmar eliminación",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (confirmacion == MessageBoxResult.Yes)
                {
                    Artistas.Remove(artistaSeleccionado);
                    festivalSeleccionado.Artistas.Remove(artistaSeleccionado);

                    // Refrescar los datos en la lista de festivales (si se usa por referencia no es necesario, pero por si acaso)
                    DatosApp.Festivales.Remove(festivalSeleccionado);
                    DatosApp.Festivales.Add(festivalSeleccionado);

                    // Refrescar la lista visual
                    ArtistasListBox.Items.Refresh();

                    MessageBox.Show("Artista eliminado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un artista para eliminar.", "Ningún artista seleccionado", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private static List<TimeSpan> GenerarHoras()
        {
            var lista = new List<TimeSpan>();
            for (int h = 12; h < 24; h++)
            {
                lista.Add(new TimeSpan(h, 0, 0));
                lista.Add(new TimeSpan(h, 30, 0));
            }
            for (int h = 0; h < 2; h++)
            {
                lista.Add(new TimeSpan(h, 0, 0));
                lista.Add(new TimeSpan(h, 30, 0));
            }
            lista.Add(new TimeSpan(2, 0, 0));
            return lista;
        }
        private void HoraInicio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.DataContext is Artista artista)
            {
                var nuevaHoraInicio = comboBox.SelectedItem as TimeSpan?;

                if (nuevaHoraInicio == null)
                    return;

                var horaInicioOriginal = artista.HoraInicio;

                artista.HoraInicio = nuevaHoraInicio;

                if (HaySolapamiento(artista, Artistas))
                {
                    MessageBox.Show("No se pueden solapar las horas de las actuaciones.\n Cambia el horario o estado.", "Solapamiento Actuaciones", MessageBoxButton.OK, MessageBoxImage.Error);

                    artista.HoraInicio = horaInicioOriginal;
                    comboBox.SelectedItem = horaInicioOriginal;
                }
                else
                {
                    if (artista.HoraFin.HasValue && artista.HoraInicio >= artista.HoraFin)
                    {
                        MessageBox.Show("La hora de inicio debe ser menor que la hora de fin.", "Horas No Validas", MessageBoxButton.OK, MessageBoxImage.Error);

                        artista.HoraInicio = horaInicioOriginal;
                        comboBox.SelectedItem = horaInicioOriginal;
                    }
                }
            }
        }


        private void HoraFin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.DataContext is Artista artista)
            {
                var nuevaHoraFin = comboBox.SelectedItem as TimeSpan?;

                if (nuevaHoraFin == null)
                    return;

                var horaFinOriginal = artista.HoraFin;
                artista.HoraFin = nuevaHoraFin;

                if (HaySolapamiento(artista, Artistas))
                {
                    MessageBox.Show("¡Solapamiento detectado! Cambia el horario o estado.", "Error");

                    artista.HoraFin = horaFinOriginal;
                    comboBox.SelectedItem = horaFinOriginal;
                }
                else
                {
                    if (artista.HoraInicio.HasValue && artista.HoraInicio >= artista.HoraFin)
                    {
                        MessageBox.Show("La hora de inicio debe ser menor que la hora de fin.", "Error");

                        artista.HoraFin = horaFinOriginal;
                        comboBox.SelectedItem = horaFinOriginal;
                    }
                }
            }
        }


        public bool HaySolapamiento(Artista artistaActual, IEnumerable<Artista> listaArtistas)
        {
            foreach (var artista in listaArtistas)
            {
                if (artista == artistaActual)
                    continue;

                if (artista.DiaActuacion == artistaActual.DiaActuacion &&
                    artista.Escenario == artistaActual.Escenario)
                {
                    // Comprobar si los horarios se solapan
                    // Condición para solapamiento de intervalos [a1,a2) y [b1,b2):
                    // a1 < b2 && b1 < a2
                    if (artistaActual.HoraInicio < artista.HoraFin &&
                        artista.HoraInicio < artistaActual.HoraFin)
                    {
                        return true; // Hay solapamiento
                    }
                }
            }
            return false; // No hay solapamientos
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
                                             $"Seguridad: {escenarioSeleccionado.Seguridad}\n";

                dataGridEscenarios.ItemsSource = new List<Escenario> { escenarioSeleccionado };

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

        private void BotonAyudaArtista_Click(object sender, EventArgs e)
        {
            MessageBox.Show("En la lista de la izquierda, selecciona el artista del cual quiera ver los datos.\n" +
                "Si quiere modificar algun dato, haga click en el cuadro de texto correspondiente.\n" +
                "Si quiere añadir algun artista haga click en 'Añadir Artista'.\n" +
                "Si quiere ver la información de los escenarios, haga click en el tab 'Escenarios'.", "Ayuda Artistas", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BotonAyudaEscenario_Click(object sender, EventArgs e)
        {
            MessageBox.Show("En la lista de la izquierda, selecciona el escenario del cual quiera ver los datos.\n" +
                "Si quiere modificar algun dato, haga click en el cuadro de texto correspondiente.\n" +
                "Si quiere añadir algun escenario haga click en 'Añadir Escenario'.\n" +
                "Si quiere ver la información de los artistas, haga click en el tab 'Artistas'.", "Ayuda Escenarios", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public void EliminarEscenario_Click(object sender, RoutedEventArgs e)
        {
            if (EscenariosListBox.SelectedItem is Escenario escenarioSeleccionado)
            {
                MessageBoxResult confirmacion = MessageBox.Show(
                    $"¿Estás seguro de que deseas eliminar el escenario: {escenarioSeleccionado.Nombre}?",
                    "Confirmar eliminación",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
                if (confirmacion == MessageBoxResult.Yes)
                {
                    Escenarios.Remove(escenarioSeleccionado);
                    festivalSeleccionado.Escenarios.Remove(escenarioSeleccionado);
                    // Refrescar los datos en la lista de festivales (si se usa por referencia no es necesario, pero por si acaso)
                    DatosApp.Festivales.Remove(festivalSeleccionado);
                    DatosApp.Festivales.Add(festivalSeleccionado);
                    // Refrescar la lista visual
                    EscenariosListBox.Items.Refresh();
                    MessageBox.Show("Escenario eliminado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un escenario para eliminar.", "Ningún escenario seleccionado", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
