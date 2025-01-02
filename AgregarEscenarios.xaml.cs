// AgregarEscenarios.xaml.cs
using System.Collections.Generic;
using System.Windows;

namespace ProyectoIPo
{
    public partial class AgregarEscenarios : Window
    {
        public List<string> NuevosEscenarios { get; private set; } = new List<string>();

        public AgregarEscenarios()
        {
            InitializeComponent();
            txtNuevoEscenario.GotFocus += RemovePlaceholder;
            txtNuevoEscenario.LostFocus += ShowPlaceholder;
            ShowPlaceholder(null, null);
            dataGridNuevosEscenarios.ItemsSource = NuevosEscenarios;
        }

        private void RemovePlaceholder(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNuevoEscenario.Text))
            {
                placeholderTextBlock.Visibility = Visibility.Collapsed;
            }
        }

        private void ShowPlaceholder(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNuevoEscenario.Text))
            {
                placeholderTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void AgregarEscenario_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNuevoEscenario.Text))
            {
                NuevosEscenarios.Add(txtNuevoEscenario.Text);
                dataGridNuevosEscenarios.Items.Refresh();
                txtNuevoEscenario.Clear();
                ShowPlaceholder(null, null);
            }
        }

        private void Cerrar_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
