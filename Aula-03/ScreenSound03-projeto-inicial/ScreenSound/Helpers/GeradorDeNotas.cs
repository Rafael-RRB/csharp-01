using Alura.ScreenSound.Modelos;
using Alura.ScreenSound.Modelos.Interfaces;

namespace Alura.ScreenSound.Helpers;

static class GeradorDeNotas
{
    static int[] _notas = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    public static void GerarNotas(IAvaliavel avaliavel, int repeticoes, int[] pesos)
    {
        ThreadLocal<Random> aleatorio = new ThreadLocal<Random>(() => new Random());
        int repeticoesAtual = 0;
        int somaPesos = pesos.Sum();
        int notasAtuais = avaliavel.Notas.Count;

        if (pesos == null)
        {
            throw new ArgumentNullException(nameof(pesos), "O array de pesos não pode ser nulo.");
        }
        foreach (int peso in pesos)
        {
            if (peso < 0)
            {
                throw new ArgumentException("O array de pessos não pode conter pessos negativos.");
            }
        }
        if (pesos.Length != _notas.Length)
        {
            throw new ArgumentException($"O array de pesos deve conter exatamente {_notas.Length} elementos.");
        }
        if (somaPesos <= 0)
        {
            throw new ArgumentException("A soma dos pesos deve ser maior que zero.");
        }

        while (repeticoesAtual < repeticoes)
        {
            int roll = aleatorio.Value!.Next(0, somaPesos);
            int cumulacao = 0;

            for (int i = 0; i < pesos.Length; i++)
            {
                cumulacao += pesos[i];
                if (roll < cumulacao)
                {
                    avaliavel.AdicionarNota(new Avaliacao(_notas[i]));
                    repeticoesAtual++;
                    break;
                }
            }
        }

        if (notasAtuais + repeticoes != avaliavel.Notas.Count)
        {
            throw new Exception("Método GerarNotas falhou ao gerar as notas.");
        }
    }
}
