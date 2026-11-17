namespace Alura.Modelos;

public class Artista
{
    private string _nome = string.Empty;
    public string Nome
    {
        get { return _nome; }
        set { _nome = value; }
    }
    private int _idade = 0;
    public int Idade
    {
        get { return _idade; }
        set
        {
            if (value < 0 || value > 120)
            {
                throw new ArgumentException("A idade deve estar entre 0 e 120 anos.");
            }
            else
            {
                _idade = value;
            }
        }
    }
    private List<Filme> _filmesAtuados = new List<Filme>();

    public void AdicionarFilmeAtuado(Filme filme)
    {
        if(!_filmesAtuados.Contains(filme))
        {
            _filmesAtuados.Add(filme);
            filme.AdicionarArtistaAoElenco(this);
        }
    }

    public void RemoverFilmeAtuado(Filme filme)
    {
        if(_filmesAtuados.Contains(filme))
        {
            _filmesAtuados.Remove(filme);
            filme.RemoverArtistaDoElenco(this);
        }
    }

    public void PrintarFilmesAtuados()
    {
        Console.WriteLine($"Filmes atuados por {Nome}:");
        foreach (var filme in _filmesAtuados)
        {
            Console.WriteLine($"- {filme.Titulo} ({filme.Duracao}), elenco: {filme.ObterElenco()}");
        }
    }

    public Artista(string definirNome, int definirIdade)
    {
        Nome = definirNome;
        Idade = definirIdade;
    }
}