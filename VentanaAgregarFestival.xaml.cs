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
            var nombre = NombreTextBox.Text;
            var ubicacion = UbicacionTextBox.Text;
            var fecha = FechaDatePicker.SelectedDate ?? DateTime.Now;
            var artistas = ArtistasTextBox.Text.Split(',').Select(a => a.Trim()).ToArray();

            if (!string.IsNullOrWhiteSpace(nombre) && !string.IsNullOrWhiteSpace(ubicacion))
            {
                var nuevoFestival = new Festival
                {
                    Nombre = nombre,
                    Ubicacion = ubicacion,
                    Fecha = fecha,
                    Artistas = artistas
                };

                FestivalAdded?.Invoke(this, nuevoFestival); // Notificar que se ha agregado un nuevo festival
                Close();
            }
            else
            {
                MessageBox.Show("Por favor, complete los campos Nombre y Ubicacion");
            }
        }

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