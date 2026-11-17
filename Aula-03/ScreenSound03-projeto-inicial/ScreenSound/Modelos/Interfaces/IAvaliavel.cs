namespace Alura.ScreenSound.Modelos.Interfaces;

public interface IAvaliavel
{
    void AdicionarNota(Avaliacao avaliacao);
    double Media { get; }
    List<Avaliacao> Notas { get; set; }
}
