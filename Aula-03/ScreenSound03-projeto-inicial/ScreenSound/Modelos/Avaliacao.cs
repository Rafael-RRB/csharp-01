using Alura.ScreenSound.Modelos.Interfaces;
using Alura.ScreenSound.Enums;

namespace Alura.ScreenSound.Modelos;

public class Avaliacao
{
    private int _nota = 1;
    public int Nota
    {
        get { return _nota; }
        set
        {
            if (value < 1 || value > 10)
            {
                throw new ArgumentException("A nota deve estar entre 1 e 10.");
            }
            else
            {
                _nota = value;
            }
        }
    }

    public static ResultadoTryParse TryParse(string notaString, out Avaliacao avaliacao)
    {
        avaliacao = null!;


        if (!int.TryParse(notaString, out int nota))
        {
            return ResultadoTryParse.FormatoInvalido;
        }

        if (nota < 1 || nota > 10)
        {
            return ResultadoTryParse.IntervaloInvalido;
        }

        avaliacao = new Avaliacao(nota);
        return ResultadoTryParse.Sucesso;
    }

    public Avaliacao(int definirNota)
    {
        Nota = definirNota;
    }
}
