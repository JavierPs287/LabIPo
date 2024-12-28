using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Lógica de interacción para VentanaAgregarFestival.xaml
    /// </summary>
    public partial class VentanaAgregarFestival : Window
    {
        public event EventHandler<Festival> FestivalAdded;

        public VentanaAgregarFestival()
        {
            InitializeComponent();
        }

        private void OnAgregarFestivalClick(object sender, RoutedEventArgs e)
        {
            var nombre = NombreTextBox.Text?.Trim();
            var ubicacion = UbicacionTextBox.Text?.Trim();
            var fecha = FechaDatePicker.SelectedDate;
            var artistasTexto = ArtistasTextBox.Text
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Trim())
                .Where(a => !string.IsNullOrWhiteSpace(a));

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(ubicacion))
            {
                MessageBox.Show("Por favor, complete los campos Nombre y Ubicación", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (fecha == null)
            {
                MessageBox.Show("Por favor, seleccione una fecha válida.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var artistas = artistasTexto.Select(nombreArtista => new Artista { Nombre = nombreArtista }).ToList();

            var nuevoFestival = new Festival
            {
                Nombre = nombre,
                Ubicacion = ubicacion,
                Fecha = fecha.Value,
                Artistas = artistas
            };

            MessageBox.Show("Festival creado correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

            FestivalAdded?.Invoke(this, nuevoFestival); // Notificar que se ha agregado un nuevo festival
            Close();
        }

        // Manejo de eventos KeyDown para agregar el festival al presionar Enter
        private void NombreTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                OnAgregarFestivalClick(sender, e);
            }
        }

        private void UbicacionTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                OnAgregarFestivalClick(sender, e);
            }
        }

        private void ArtistasTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                OnAgregarFestivalClick(sender, e);
            }
        }
    }
}
