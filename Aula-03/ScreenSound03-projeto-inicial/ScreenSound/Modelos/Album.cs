using Alura.ScreenSound.Modelos.Interfaces;

namespace Alura.ScreenSound.Modelos;

public class Album : IAvaliavel
{
    private static int _contadorDeAlbuns = 0;
    public static int ContadorDeAlbuns
    {
        get { return _contadorDeAlbuns; }
        private set { _contadorDeAlbuns = value; }
    }
    private List<Musica> _musicas = new List<Musica>();
    public List<Musica> Musicas => _musicas;
    private List<Avaliacao> _notas = new List<Avaliacao>();
    public List<Avaliacao> Notas
    {
        get { return _notas; }
        set { _notas = value; }
    }
    public string Nome { get; }
    public double Media
    {
        get
        {
            if (_notas.Count == 0)
            {
                return 0;
            }
            else
            {
                return _notas.Average(a => a.Nota);
            }
        }
    }
    public int DuracaoTotal => _musicas.Sum(m => m.Duracao);

    public string ExibirMedia()
    {
        if (Media == 0)
        {
            return "Não há avaliações para este Álbum.";
        }
        else
        {
            return $"Média: {Media:F1}";
        }
    }

    public void AdicionarMusica(Musica musica)
    {
        _musicas.Add(musica);
    }

    public void AdicionarNota(Avaliacao nota)
    {
        Notas.Add(nota);
    }
    public void ExibirMusicasDoAlbum()
    {
        Console.WriteLine($"Lista de músicas do álbum {Nome}:\n");
        foreach (var musica in _musicas)
        {
            Console.WriteLine($"Música: {musica.Nome}");
        }
        Console.WriteLine($"\nPara ouvir este álbum inteiro você precisa de {DuracaoTotal}");
    }

    public Album(string nome)
    {
        Nome = nome;
        ContadorDeAlbuns++;
    }
}