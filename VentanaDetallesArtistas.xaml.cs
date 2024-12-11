using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoIPo
{
    /// <summary>
    /// Lógica de interacción para VentanaDetallesArtistas.xaml
    /// </summary>
    public partial class VentanaDetallesArtistas : Window
    {
        public VentanaDetallesArtistas(List<Artista> artistas)
        {
            InitializeComponent();
            DataContext = new ArtistasViewModel(artistas); // Pasar los artistas como DataContext
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e) 
        { 
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true }); 
            e.Handled = true; 
        }

    }

    public class ArtistasViewModel
    {
        public List<Artista> Artistas { get; set; }

        public ArtistasViewModel(List<Artista> artistas)
        {
            Artistas = artistas;
        }
    }
}
