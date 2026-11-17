using Alura.ScreenSound.Enums;
using Alura.ScreenSound.Helpers;
using Alura.ScreenSound.Modelos;

namespace Alura.ScreenSound.Menus;

public static class MenuAvaliarBandas
{
    public static async Task AvaliarBanda(Dictionary<string, List<Banda>> bandasRegistradas)
    {
        Console.Clear();
        MenuExibirTitulo.ExibirTitulo("Avaliar banda", true);
        Console.Write("Digite o nome da banda que deseja avaliar: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (BandaHelper.ObterBandaPorNome(bandasRegistradas, nomeDaBanda, out Banda? bandaEncontrada))
        {
            Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");

            bool opcaoValida = false;
            string notaEscolhida = "10";
            Avaliacao avaliacao = null!;
            string errorMessage1 = "Opção Inválida, não é um número!";
            string errorMessage2 = "Opção fora do intervalo permitido!";
            string inputMessage = "└► Digite um número de 1 a 10:";

            while (!opcaoValida)
            {
                notaEscolhida = Console.ReadLine()!;
                ResultadoTryParse resultado = Avaliacao.TryParse(notaEscolhida, out avaliacao);

                if (resultado == ResultadoTryParse.FormatoInvalido)
                {
                    Console.WriteLine(errorMessage1);
                    Console.Write(inputMessage);
                    continue;
                }

                if (resultado == ResultadoTryParse.IntervaloInvalido)
                {
                    Console.WriteLine(errorMessage2);
                    Console.Write(inputMessage);
                }
                else
                {
                    opcaoValida = true;
                }
            }

            bandaEncontrada!.AdicionarNota(avaliacao);
            Console.WriteLine($"A nota {avaliacao.Nota} foi registrada com sucesso para a banda {bandaEncontrada!.Nome}");
            Thread.Sleep(4000);
        }
        else
        {
            Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
        }

    }
}
