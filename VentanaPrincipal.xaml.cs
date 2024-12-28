using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Drawing;

namespace ProyectoIPo
{
    public partial class VentanaPrincipal : Window
    {
        public class Festival
        {
            public string Nombre { get; set; }
            public DateTime Fecha { get; set; }
            public string Ubicacion { get; set; }
            public List<Artista> Artistas { get; set; }
            public string ArtistasTexto { get; set; }
        }


        public ObservableCollection<Festival> Festivales { get; set; }
        private ObservableCollection<Festival> FestivalesOriginales { get; set; }

        public VentanaPrincipal()
        {
            InitializeComponent();

            // Datos de ejemplo
            Festivales = new ObservableCollection<Festival>
        {
            new Festival
            {
                Nombre = "Rock Fest",
                Fecha = new DateTime(2024, 6, 15),
                Ubicacion = "Madrid, España",
                Artistas = new List<Artista>
                {
                    new Artista
                    {
                        Nombre = "Queen",
                        Imagen = "Recursos/queen.jpg",
                        Genero = "Rock",
                        Biografia = "Una banda de rock icónica formada en 1970 en Londres.",
                        RedesSociales = new List<KeyValuePair<string, string>> { /* ... */ },
                        Hits = new List<KeyValuePair<string, KeyValuePair<string, string>>> { /* ... */ }
                    }
                }
            },
            new Festival
                {
                    Nombre = "Jazz Nights",
                    Fecha = new DateTime(2024, 5, 20),
                    Ubicacion = "Barcelona, España",
                    Artistas = new List<Artista>
                    {
                        new Artista
                        {
                            Nombre = "Miles Davis",
                            Imagen = "Recursos/milesdavis.jpg",
                            Genero = "Jazz",
                            Biografia = "Una de las figuras más influyentes en la historia del jazz, conocido por su estilo único y por álbumes como 'Kind of Blue'.",
                            RedesSociales = new List<KeyValuePair<string, string>>
                            {
                                new KeyValuePair<string, string>("Facebook", "https://www.facebook.com/MilesDavis/"),
                                new KeyValuePair<string, string>("Twitter", "https://twitter.com/milesdavis"),
                                new KeyValuePair<string, string>("Instagram", "https://www.instagram.com/milesdavis/"),
                                new KeyValuePair<string, string>("YouTube", "https://www.youtube.com/channel/UCI9b7tBwH9mbzgQg3Y6Kwxg"),
                                new KeyValuePair<string, string>("Spotify", "https://open.spotify.com/artist/2nF3W41fN2KiTjANkVpt9n")
                            },
                            Hits = new List<KeyValuePair<string, KeyValuePair<string, string>>>
                            {
                                new KeyValuePair<string, KeyValuePair<string, string>>("So What", new KeyValuePair<string, string>("https://open.spotify.com/intl-es/track/7azylXFRsebfrIoAtwfjaB?si=4586ef880e20402d", "700M")),
                                new KeyValuePair<string, KeyValuePair<string, string>>("Freddie Freeloader", new KeyValuePair<string, string>("https://open.spotify.com/intl-es/track/1UOH2i8z5xitX8PgVUH6nU?si=94e1fdd173b54276", "500M"))
                            }
                        },
                        new Artista
                        {
                            Nombre = "John Coltrane",
                            Imagen = "Recursos/johncoltrane.jpg",
                            Genero = "Jazz",
                            Biografia = "Pionero del saxofón tenor, conocido por su estilo avant-garde y álbumes icónicos como 'A Love Supreme'.",
                            RedesSociales = new List<KeyValuePair<string, string>>
                            {
                                new KeyValuePair<string, string>("Facebook", "https://www.facebook.com/johncoltrane/"),
                                new KeyValuePair<string, string>("Twitter", "https://twitter.com/johncoltrane"),
                                new KeyValuePair<string, string>("Instagram", "https://www.instagram.com/johncoltrane/"),
                                new KeyValuePair<string, string>("YouTube", "https://www.youtube.com/user/johncoltrane"),
                                new KeyValuePair<string, string>("Spotify", "https://open.spotify.com/artist/5eGBYz9UoRTW4Aw1XW7omI")
                            },
                            Hits = new List<KeyValuePair<string, KeyValuePair<string, string>>>
                            {
                                new KeyValuePair<string, KeyValuePair<string, string>>("A Love Supreme", new KeyValuePair<string, string>("https://open.spotify.com/intl-es/album/7Eoz7hJvaX1eFkbpQxC5PA?si=5950209d962841c9", "800M")),
                                new KeyValuePair<string, KeyValuePair<string, string>>("Naima", new KeyValuePair<string, string>("https://open.spotify.com/intl-es/track/25ajcQN4gqQ8gLwB4zwS7a?si=4d6c6aeac68447c3", "600M"))
                            }
                        }
                    }
                },
                new Festival
                {
                    Nombre = "Trap Beats",
                    Fecha = new DateTime(2024, 12, 10),
                    Ubicacion = "Buenos Aires, Argentina",
                    Artistas = new List<Artista>
                    {
                        new Artista
                        {
                            Nombre = "Bad Bunny",
                            Imagen = "Recursos/badbunny.jpg",
                            Genero = "Trap",
                            Biografia = "Una de las figuras más influyentes del trap, conocido por éxitos como 'YHLQMDLG' y su estilo único de fusión.",
                            RedesSociales = new List<KeyValuePair<string, string>>
                            {
                                new KeyValuePair<string, string>("Facebook", "https://www.facebook.com/BadBunny/"),
                                new KeyValuePair<string, string>("Twitter", "https://twitter.com/soybadbunny"),
                                new KeyValuePair<string, string>("Instagram", "https://www.instagram.com/badbunny/"),
                                new KeyValuePair<string, string>("YouTube", "https://www.youtube.com/user/badbunny"),
                                new KeyValuePair<string, string>("Spotify", "https://open.spotify.com/artist/6AfBCxRXi3EMvDQvp9Gep5")
                            },
                            Hits = new List<KeyValuePair<string, KeyValuePair<string, string>>>
                            {
                                new KeyValuePair<string, KeyValuePair<string, string>>("Safaera", new KeyValuePair<string, string>("https://open.spotify.com/intl-es/track/2DEZmgHKAvm41k4J3R2E9Y?si=4fa55e3dee794551", "1.5B")),
                                new KeyValuePair<string, KeyValuePair<string, string>>("Yonaguni", new KeyValuePair<string, string>("https://open.spotify.com/intl-es/track/2JPLbjOn0wPCngEot2STUS?si=fe44b7e7f40b48ba", "1B"))
                            }
                        },
                        new Artista
                        {
                            Nombre = "Anuel AA",
                            Imagen = "Recursos/anuelaa.jpg",
                            Genero = "Trap",
                            Biografia = "Un pionero del reggaetón y el trap, conocido por sus colaboraciones y éxitos como 'Adictiva'.",
                            RedesSociales = new List<KeyValuePair<string, string>>
                            {
                                new KeyValuePair<string, string>("Facebook", "https://www.facebook.com/anuel/"),
                                new KeyValuePair<string, string>("Twitter", "https://twitter.com/anuel_2blea"),
                                new KeyValuePair<string, string>("Instagram", "https://www.instagram.com/anuel/"),
                                new KeyValuePair<string, string>("YouTube", "https://www.youtube.com/user/AnuelAA/"),
                                new KeyValuePair<string, string>("Spotify", "https://open.spotify.com/artist/2hzPHk74TBMltuEFO0Zwd5")
                            },
                            Hits = new List<KeyValuePair<string, KeyValuePair<string, string>>>
                            {
                                new KeyValuePair<string, KeyValuePair<string, string>>("Adictiva", new KeyValuePair<string, string>("https://open.spotify.com/intl-es/track/6MJUCumnQsQEKbCy28tbCP?si=71263cf337854b39", "900M")),
                                new KeyValuePair<string, KeyValuePair<string, string>>("Amanece", new KeyValuePair<string, string>("https://open.spotify.com/intl-es/track/1LiN0Z98FkR1t0m8KmLcAH?si=1bed6a958705435c", "910M"))
                            }
                        }
                    }
                },
                new Festival
                {
                    Nombre = "Reggaeton Party",
                    Fecha = new DateTime(2025, 3, 10),
                    Ubicacion = "Miami, USA",
                    Artistas = new List<Artista>
                    {
                        new Artista
                        {
                            Nombre = "Daddy Yankee",
                            Imagen = "Recursos/daddyyankee.jpg",
                            Genero = "Reggaeton",
                            Biografia = "Una leyenda del reggaetón, conocido por éxitos como 'Gasolina' y su influencia en el género.",
                            RedesSociales = new List<KeyValuePair<string, string>>
                            {
                                new KeyValuePair<string, string>("Facebook", "https://www.facebook.com/daddyyankee/"),
                                new KeyValuePair<string, string>("Twitter", "https://twitter.com/daddyyankee"),
                                new KeyValuePair<string, string>("Instagram", "https://www.instagram.com/daddyyankee/"),
                                new KeyValuePair<string, string>("YouTube", "https://www.youtube.com/user/DaddyYankee"),
                                new KeyValuePair<string, string>("Spotify", "https://open.spotify.com/artist/0HKh6k7zNpLwX8m1HkXu02")
                            },
                            Hits = new List<KeyValuePair<string, KeyValuePair<string, string>>>
                            {
                                new KeyValuePair<string, KeyValuePair<string, string>>("Gasolina", new KeyValuePair<string, string>("https://open.spotify.com/intl-es/track/228BxWXUYQPJrJYHDLOHkj?si=3b78983f2b26452c", "1.2B")),
                                new KeyValuePair<string, KeyValuePair<string, string>>("Rompe", new KeyValuePair<string, string>("https://open.spotify.com/intl-es/track/4Xtlw8oXkIOvzV7crUBKeZ?si=ed3c233db11943ef", "950M"))
                            }
                        },
                        new Artista
                        {
                            Nombre = "J Balvin",
                            Imagen = "Recursos/jbalvin.jpg",
                            Genero = "Reggaeton",
                            Biografia = "Uno de los artistas más influyentes del reggaetón, conocido por éxitos como 'Mi Gente' y su estilo innovador.",
                            RedesSociales = new List<KeyValuePair<string, string>>
                            {
                                new KeyValuePair<string, string>("Facebook", "https://www.facebook.com/jbalvin/"),
                                new KeyValuePair<string, string>("Twitter", "https://twitter.com/jbalvin"),
                                new KeyValuePair<string, string>("Instagram", "https://www.instagram.com/jbalvin/"),
                                new KeyValuePair<string, string>("YouTube", "https://www.youtube.com/user/jbalvin"),
                                new KeyValuePair<string, string>("Spotify", "https://open.spotify.com/artist/3Cdzt4XihkmCrh6IQj9H19")
                            },
                            Hits = new List<KeyValuePair<string, KeyValuePair<string, string>>>
                            {
                                new KeyValuePair<string, KeyValuePair<string, string>>("Mi Gente", new KeyValuePair<string, string>("https://open.spotify.com/intl-es/track/7COfe3P7KgfwDwIRB8LIDw?si=7a652db019844290", "1B")),
                                new KeyValuePair<string, KeyValuePair<string, string>>("Ay Vamos", new KeyValuePair<string, string>("https://open.spotify.com/intl-es/track/6Ges5C2IE738iJh4HyQizQ?si=86a86ef7fcc04170", "850M"))
                            }
                        }
                    }
                },
                new Festival
                {
                    Nombre = "Electronic Beats",
                    Fecha = new DateTime(2024, 7, 12),
                    Ubicacion = "Ibiza, España",
                    Artistas = new List<Artista>
                    {
                        new Artista(
                            nombre: "Calvin Harris",
                            imagen: "Recursos/calvinharris.jpg",
                            genero: "Electronic",
                            biografia: "Un DJ y productor líder en música electrónica, conocido por éxitos como 'Summer' y su estilo dance-pop.",
                            redesSociales: new List<KeyValuePair<string, string>>
                            {
                                new KeyValuePair<string, string>("Facebook", "https://www.facebook.com/CalvinHarris/"),
                                new KeyValuePair<string, string>("Twitter", "https://twitter.com/CalvinHarris"),
                                new KeyValuePair<string, string>("Instagram", "https://www.instagram.com/calvinharris/"),
                                new KeyValuePair<string, string>("YouTube", "https://www.youtube.com/user/CalvinHarris/"),
                                new KeyValuePair<string, string>("Spotify", "https://open.spotify.com/artist/2jvAxNRV4wDWwF9RlUT4M2")
                            },
                            hits: new List<KeyValuePair<string, KeyValuePair<string, string>>>
                            {
                                new KeyValuePair<string, KeyValuePair<string, string>>("Summer", new KeyValuePair<string, string>("https://open.spotify.com/intl-es/track/6YUTL4dYpB9xZO5qExPf05?si=6186219dad7945a4", "200M")),
                                new KeyValuePair<string, KeyValuePair<string, string>>("I'm not alone", new KeyValuePair<string, string>("https://open.spotify.com/intl-es/track/07POri5O6Xu0aVZzlvOcpy?si=3612d4fca0e84a3a", "150M"))
                            }
                        ),
                        new Artista(
                            nombre: "David Guetta",
                            imagen: "Recursos/davidguetta.jpg",
                            genero: "Electronic",
                            biografia: "Un DJ y productor talentoso en la escena de la música electrónica, conocido por éxitos como 'Titanium' y su innovador estilo de house.",
                            redesSociales: new List<KeyValuePair<string, string>>
                            {
                                new KeyValuePair<string, string>("Facebook", "https://www.facebook.com/DavidGuetta/"),
                                new KeyValuePair<string, string>("Twitter", "https://twitter.com/DavidGuetta"),
                                new KeyValuePair<string, string>("Instagram", "https://www.instagram.com/DavidGuetta/"),
                                new KeyValuePair<string, string>("YouTube", "https://www.youtube.com/user/DavidGuetta"),
                                new KeyValuePair<string, string>("Spotify", "https://open.spotify.com/artist/3hHj7J8wB4w2LHI7X9FjZ3")
                            },
                            hits: new List<KeyValuePair<string, KeyValuePair<string, string>>>
                            {
                                new KeyValuePair<string, KeyValuePair<string, string>>("Titanium", new KeyValuePair<string, string>("https://open.spotify.com/intl-es/track/0TDLuuLlV54CkRRUOahJb4?si=2df727383af94aa8", "300M")),
                                new KeyValuePair<string, KeyValuePair<string, string>>("Play hard", new KeyValuePair<string, string>("https://open.spotify.com/intl-es/track/5YPMEOJ58kfl56VHxTgwx3?si=109f622a012d4f79", "120M"))
                            }
                        )
                    }
                },
                new Festival
                {
                    Nombre = "Blues Legends",
                    Fecha = new DateTime(2024, 8, 10),
                    Ubicacion = "Chicago, USA",
                    Artistas = new[] { "B.B. King", "Muddy Waters" }.Select(nombre => new Artista { Nombre = nombre }).ToList()
                },
                new Festival
                {
                    Nombre = "Metal Mayhem",
                    Fecha = new DateTime(2024, 9, 5),
                    Ubicacion = "Berlin, Alemania",
                    Artistas = new[] { "Metallica", "Iron Maiden" }.Select(nombre => new Artista { Nombre = nombre }).ToList()
                },
                new Festival
                {
                    Nombre = "Classical Evenings",
                    Fecha = new DateTime(2024, 6, 30),
                    Ubicacion = "Viena, Austria",
                    Artistas = new[] { "Ludwig van Beethoven", "Wolfgang Amadeus Mozart" }.Select(nombre => new Artista { Nombre = nombre }).ToList()
                },
                new Festival
                {
                    Nombre = "Reggae Sun",
                    Fecha = new DateTime(2024, 7, 25),
                    Ubicacion = "Kingston, Jamaica",
                    Artistas = new[] { "Bob Marley", "Peter Tosh" }.Select(nombre => new Artista { Nombre = nombre }).ToList()
                },
                new Festival
                {
                    Nombre = "PopFest",
                    Fecha = new DateTime(2024, 10, 2),
                    Ubicacion = "Los Ángeles, USA",
                    Artistas = new[] { "Ariana Grande", "Taylor Swift" }.Select(nombre => new Artista { Nombre = nombre }).ToList()
                },
                new Festival
                {
                    Nombre = "Indie Vibes",
                    Fecha = new DateTime(2024, 8, 20),
                    Ubicacion = "Londres, UK",
                    Artistas = new[] { "The Strokes", "Arctic Monkeys" }.Select(nombre => new Artista { Nombre = nombre }).ToList()
                },
                new Festival
                {
                    Nombre = "Country Jam",
                    Fecha = new DateTime(2024, 9, 15),
                    Ubicacion = "Nashville, USA",
                    Artistas = new[] { "Johnny Cash", "Dolly Parton" }.Select(nombre => new Artista { Nombre = nombre }).ToList()
                },
                new Festival
                {
                    Nombre = "R&B Soul Fest",
                    Fecha = new DateTime(2024, 11, 1),
                    Ubicacion = "Atlanta, USA",
                    Artistas = new[] { "Aretha Franklin", "Marvin Gaye" }.Select(nombre => new Artista { Nombre = nombre }).ToList()
                },
                new Festival
                {
                    Nombre = "Latin Fusion",
                    Fecha = new DateTime(2024, 6, 25),
                    Ubicacion = "México D.F., México",
                    Artistas = new[] { "Carlos Santana", "Shakira" }.Select(nombre => new Artista { Nombre = nombre }).ToList()
                },
                new Festival
                {
                    Nombre = "Punk Rock Riot",
                    Fecha = new DateTime(2024, 7, 19),
                    Ubicacion = "Los Ángeles, USA",
                    Artistas = new[] { "Green Day", "The Offspring" }.Select(nombre => new Artista { Nombre = nombre }).ToList()
                },
                new Festival
                {
                    Nombre = "Hip Hop Summit",
                    Fecha = new DateTime(2024, 9, 25),
                    Ubicacion = "Nueva York, USA",
                    Artistas = new[] { "Kendrick Lamar", "Drake" }.Select(nombre => new Artista { Nombre = nombre }).ToList()
                }
            };

            // Guardar la lista original de festivales
            FestivalesOriginales = new ObservableCollection<Festival>(Festivales);

            // Ordenar los festivales por la fecha
            Festivales = new ObservableCollection<Festival>(Festivales.OrderBy(f => f.Fecha));

            // Añadir la propiedad ArtistasTexto para mostrar los nombres de los artistas en una sola columna
            foreach (var festival in Festivales)
            {
                festival.ArtistasTexto = string.Join(", ", festival.Artistas.Select(a => a.Nombre));
            }

            // Establecer el contexto de datos para el enlace
            DataContext = this;
        }

        // Método para aplicar filtros
        private void FiltrarFestivales(object sender, RoutedEventArgs e)
        {
            var filtroNombre = txtFiltroNombre.Text.ToLower();
            var filtroArtista = txtFiltroArtista.Text.ToLower();
            var filtroFecha = dpFiltroFecha.SelectedDate;

            var festivalesFiltrados = FestivalesOriginales.Where(f =>
                (string.IsNullOrWhiteSpace(filtroNombre) || f.Nombre.ToLower().Contains(filtroNombre)) &&
                (string.IsNullOrWhiteSpace(filtroArtista) || f.Artistas.Any(a => a.Nombre.ToLower().Contains(filtroArtista))) &&
                (!filtroFecha.HasValue || f.Fecha.Date == filtroFecha.Value.Date));

            Festivales = new ObservableCollection<Festival>(festivalesFiltrados);
            FestivalDataGrid.ItemsSource = Festivales; // Refrescar el DataGrid
        }

        // Método para cancelar los filtros
        private void CancelarFiltros(object sender, RoutedEventArgs e)
        {
            txtFiltroNombre.Clear();
            txtFiltroArtista.Clear();
            dpFiltroFecha.SelectedDate = null;
            Festivales = new ObservableCollection<Festival>(FestivalesOriginales);
            FestivalDataGrid.ItemsSource = Festivales; // Refrescar el DataGrid
        }

        // Evento para agregar un nuevo festival
        private void OnAddFestivalClick(object sender, RoutedEventArgs e)
        {
            var ventanaAgregarFestival = new VentanaAgregarFestival();
            ventanaAgregarFestival.FestivalAdded += OnFestivalAdded;
            ventanaAgregarFestival.ShowDialog();
        }

        // Evento que maneja la adición de un nuevo festival
        private void OnFestivalAdded(object sender, Festival nuevoFestival)
        {
            if (nuevoFestival == null) return;

            nuevoFestival.ArtistasTexto = string.Join(", ", nuevoFestival.Artistas.Select(a => a.Nombre));
            Festivales.Add(nuevoFestival);
            Festivales = new ObservableCollection<Festival>(Festivales.OrderBy(f => f.Fecha));
            FestivalDataGrid.ItemsSource = null; // Necesario para refrescar el DataGrid
            FestivalDataGrid.ItemsSource = Festivales;
        }



        // Evento para ver los artistas de un festival
        private void OnViewArtistsClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                var festivalSeleccionado = button.DataContext as Festival;
                if (festivalSeleccionado != null)
                {
                    var ventanaDetallesArtistas = new VentanaDetallesArtistas(festivalSeleccionado.Artistas);
                    ventanaDetallesArtistas.ShowDialog();
                }
            }
        }

        // Evento para cancelar un festival
        private void OnCancelFestivalClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                var festivalSeleccionado = button.DataContext as Festival;
                if (festivalSeleccionado != null)
                {
                    MessageBoxResult result = MessageBox.Show($"¿Estás seguro de que deseas cancelar el festival '{festivalSeleccionado.Nombre}'?",
                        "Confirmar Cancelación", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        Festivales.Remove(festivalSeleccionado);
                        FestivalDataGrid.ItemsSource = Festivales; // Refrescar el DataGrid
                    }
                }
            }
        }
    }
}

