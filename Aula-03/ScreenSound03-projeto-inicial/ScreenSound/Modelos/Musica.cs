using Alura.ScreenSound.Modelos.Interfaces;

namespace Alura.ScreenSound.Modelos;

public class Musica : IAvaliavel
{    
    private List<Avaliacao> _notas = new List<Avaliacao>();
    public List<Avaliacao> Notas
    {
        get { return _notas; }
        set { _notas = value; }
    }
    public string Nome { get; }
    public Banda Artista { get; }
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
    public int Duracao { get; set; }
    public bool Disponivel { get; set; }
    public string DescricaoResumida => $"A música {Nome} pertence à banda {Artista}";

    public string ExibirMedia()
    {
        if (Media == 0)
        {
            return "Não há avaliações para esta Música.";
        }
        else
        {
            return $"Média: {Media:F1}";
        }
    }

    public void AdicionarNota(Avaliacao nota)
    {
        Notas.Add(nota);
    }

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Artista: {Artista.Nome}");
        Console.WriteLine($"Duração: {Duracao}");
        if (Disponivel)
        {
            Console.WriteLine("Disponível no plano.");
        } else
        {
            Console.WriteLine("Adquira o plano Plus+");
        }
    }

    public Musica(Banda artista, string nome)
    {
        Artista = artista;
        Nome = nome;
    }
}