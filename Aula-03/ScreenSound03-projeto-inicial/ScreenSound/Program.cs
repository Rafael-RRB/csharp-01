using Alura.ScreenSound.Helpers;
using Alura.ScreenSound.Menus;
using Alura.ScreenSound.Modelos;
using Google.Modelos.Gemini;

internal class Program
{
    private static async Task Main(string[] args)
    {
        bool useArgs = false;
        if (args.Length > 0 && useArgs)
        {
            foreach (string arg in args)
            {
                Console.WriteLine($"- {arg}");
            }
            Console.ReadLine();
            Console.Clear();
        }

        /*
        Filme theGodfather2 = new Filme("O Poderoso Chefão II", new TimeSpan(3, 22, 0));
        Filme heat = new Filme("Fogo Contra Fogo", new TimeSpan(2, 50, 0));
        Artista deNiro = new Artista("Robert De Niro", 80);
        Artista alPacino = new Artista("Al Pacino", 83);
        Artista robertDuvall = new Artista("Robert Duvall", 91);
        Artista valKilmer = new Artista("Val Kilmer", 63);
        theGodfather2.AdicionarArtistaAoElenco(deNiro);
        theGodfather2.AdicionarArtistaAoElenco(alPacino);
        theGodfather2.AdicionarArtistaAoElenco(robertDuvall);
        heat.AdicionarArtistaAoElenco(deNiro);
        heat.AdicionarArtistaAoElenco(alPacino);
        heat.AdicionarArtistaAoElenco(valKilmer);

        deNiro.PrintarFilmesAtuados();
        Console.WriteLine();
        alPacino.PrintarFilmesAtuados();
        Console.WriteLine();
        robertDuvall.PrintarFilmesAtuados();
        Console.WriteLine();
        valKilmer.PrintarFilmesAtuados();
        Console.WriteLine();
        theGodfather2.PrintarElenco();
        Console.WriteLine();
        heat.PrintarElenco();

        theGodfather2.RemoverArtistaDoElenco(deNiro);
        Console.WriteLine();
        deNiro.PrintarFilmesAtuados();
        theGodfather2.PrintarElenco();

        Console.ReadLine();
        */

        Dictionary<string, List<Banda>> bandasRegistradas = new Dictionary<string, List<Banda>>(StringComparer.OrdinalIgnoreCase);
        MenuPrincipal menu = new MenuPrincipal(bandasRegistradas);
        bandasRegistradas.Add("Linkin Park", new List<Banda> { new Banda("Linkin Park") });
        bandasRegistradas.Add("The Beatles", new List<Banda> { new Banda("The Beatles") });
        bandasRegistradas.Add("David Bowie", new List<Banda> { new Banda("David Bowie") });
        bandasRegistradas.Add("Sewerslvt", new List<Banda> { new Banda("Sewerslvt") });
        bandasRegistradas.Add("INTERFLUG", new List<Banda> { new Banda("INTERFLUG") });
        bandasRegistradas.Add("Músicas de Anime", new List<Banda> { new Banda("Músicas de Anime") });
        GeradorDeNotas.GerarNotas(bandasRegistradas["Linkin Park"][0], 1000, new int[] { 1, 1, 2, 2, 3, 4, 5, 15, 20, 60 });
        GeradorDeNotas.GerarNotas(bandasRegistradas["The Beatles"][0], 1000, new int[] { 1, 1, 2, 2, 3, 4, 5, 15, 20, 60 });
        GeradorDeNotas.GerarNotas(bandasRegistradas["David Bowie"][0], 1000, new int[] { 1, 1, 2, 2, 3, 4, 5, 15, 20, 100 });
        GeradorDeNotas.GerarNotas(bandasRegistradas["Sewerslvt"][0], 1000, new int[] { 1, 1, 2, 2, 3, 4, 5, 15, 20, 100 });
        GeradorDeNotas.GerarNotas(bandasRegistradas["INTERFLUG"][0], 1000, new int[] { 1, 1, 2, 2, 3, 4, 5, 15, 20, 80 });
        bandasRegistradas["Linkin Park"][0].TentarAdicionarAlbum("Hybrid Theory");
        bandasRegistradas["Músicas de Anime"][0].TentarAdicionarAlbum("Nova Pasta");
        GeradorDeNotas.GerarNotas(bandasRegistradas["Linkin Park"][0].Albuns[0], 1000, new int[] { 1, 1, 2, 2, 3, 4, 5, 15, 20, 100 });
        bandasRegistradas["Linkin Park"][0].Albuns[0].AdicionarMusica(new Musica(bandasRegistradas["Linkin Park"][0], "Papercut"));
        bandasRegistradas["Músicas de Anime"][0].Albuns[0].AdicionarMusica(new Musica(bandasRegistradas["Músicas de Anime"][0], "Dancing Mad"));
        bandasRegistradas["Músicas de Anime"][0].Albuns[0].AdicionarMusica(new Musica(bandasRegistradas["Músicas de Anime"][0], "One-Winged Angel"));
        bandasRegistradas["Músicas de Anime"][0].Albuns[0].AdicionarMusica(new Musica(bandasRegistradas["Músicas de Anime"][0], "Kaneda's Theme"));
        bandasRegistradas["Músicas de Anime"][0].Albuns[0].AdicionarMusica(new Musica(bandasRegistradas["Músicas de Anime"][0], "Nausicaa Opening Theme"));
        bandasRegistradas["Músicas de Anime"][0].Albuns[0].AdicionarMusica(new Musica(bandasRegistradas["Músicas de Anime"][0], "Giygas' Theme"));
        GeradorDeNotas.GerarNotas(bandasRegistradas["Linkin Park"][0].Albuns[0].Musicas[0], 1000, new int[] { 1, 1, 2, 2, 3, 4, 5, 15, 20, 100 });

        // Oops, haha... use o **SEU** key.
        GeminiService service = new GeminiService("");

        bool running = true;
        while (running)
        {
            running = await MenuPrincipal.ExibirOpcoes(bandasRegistradas, service);
        }
    }
}