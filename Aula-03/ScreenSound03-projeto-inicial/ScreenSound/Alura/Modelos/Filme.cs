namespace Alura.Modelos;

public class Filme
{
    private string _titulo = string.Empty;
    public string Titulo
    {
        get { return _titulo; }
        set { _titulo = value; }
    }
    private TimeSpan _duracao = TimeSpan.Zero;
    public TimeSpan Duracao
    {
        get { return _duracao; }
        set { _duracao = value; }
    }
    private List<Artista> _elenco = new List<Artista>();

    public string ObterElenco()
    {
        string[] nomesElenco = new string[_elenco.Count];
        for(int i = 0; i < _elenco.Count; i++)
        {
            nomesElenco[i] = _elenco[i].Nome;
        }
        return string.Join(", ", nomesElenco);
    }

    public void AdicionarArtistaAoElenco(Artista artista)
    {
        if(!_elenco.Contains(artista))
        {
            _elenco.Add(artista);
            artista.AdicionarFilmeAtuado(this);
        }
    }

    public void RemoverArtistaDoElenco(Artista artista)
    {
        if (_elenco.Contains(artista))
        {
            _elenco.Remove(artista);
            artista.RemoverFilmeAtuado(this);
        }
    }

    public void PrintarElenco()
    {
        Console.WriteLine($"Elenco do filme {Titulo}:");
        foreach (Artista artista in _elenco)
        {
            Console.WriteLine($"- {artista.Nome}, {artista.Idade} anos");
        }
    }

    public Filme(string definirTitulo, TimeSpan definirDuracao)
    {
        Titulo = definirTitulo;
        Duracao = definirDuracao;
    }

    public Filme(string definirTitulo, TimeSpan definirDuracao, Artista[] definirElenco)
    {
        if (definirElenco.Length < 1)
        {
            throw new ArgumentException("O elenco deve conter ao menos um ator ou atriz.");
        }

        Titulo = definirTitulo;
        Duracao = definirDuracao;
        foreach (Artista artista in definirElenco)
        {
            _elenco.Add(artista);
        }
    }
}
