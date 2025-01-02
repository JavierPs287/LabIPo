using System.Windows;

namespace ProyectoIPo
{
    public partial class SeleccionarTipoArtista : Window
    {
        public bool EsGrupo { get; private set; }

        public SeleccionarTipoArtista()
        {
            InitializeComponent();
        }

        private void Artista_Click(object sender, RoutedEventArgs e)
        {
            EsGrupo = false;
            DialogResult = true;
            Close();
        }

        private void Grupo_Click(object sender, RoutedEventArgs e)
        {
            EsGrupo = true;
            DialogResult = true;
            Close();
        }
    }
}
