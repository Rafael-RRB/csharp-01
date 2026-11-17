using Alura.ScreenSound.Modelos.Interfaces;

namespace Alura.ScreenSound.Modelos;

public class Banda : IAvaliavel
{
    private List<Album> _albuns = new List<Album>();
    public List<Album> Albuns
    {
        get { return _albuns; }
    }
    private List<Avaliacao> _notas = new List<Avaliacao>();
    public List<Avaliacao> Notas
    {
        get { return _notas; }
        set { _notas = value; }
    }

    public Banda(string nome)
    {
        Nome = nome;
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
    public string ExibirMedia()
    {
        if (Media == 0)
        {
            return "Não há avaliações para esta Banda.";
        }
        else
        {
            return $"Média: {Media:F1}";
        }
    }

    public bool TentarAdicionarAlbum(string album) 
    {
        Album converted = new Album(album);
        
        if (Albuns.Any(a => a.Nome.Equals(album, StringComparison.OrdinalIgnoreCase)))
        {
            return false;
        }
        else
        {
            _albuns.Add(converted);
            return true;
        }
    }
    public void RemoverAlbum(Album album)
    {
        _albuns.Remove(album);
    }

    public void AdicionarNota(Avaliacao nota)
    {
        Notas.Add(nota);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"Discografia da banda {Nome}");
        foreach (Album album in Albuns)
        {
            Console.WriteLine($"Álbum: {album.Nome} ({album.DuracaoTotal})");
        }
    }
}