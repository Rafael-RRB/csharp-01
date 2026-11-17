using Alura.ScreenSound.Helpers;
using Alura.ScreenSound.Modelos;

namespace Alura.ScreenSound.Menus;

public static class MenuExibirDetalhes
{
    public static async Task ExibirDetalhes(Dictionary<string, List<Banda>> bandasRegistradas)
    {
        Console.Clear();
        MenuExibirTitulo.ExibirTitulo("Exibir detalhes da banda", true);
        Console.Write("Digite o nome da banda que deseja conhecer melhor: ");
        string nomeDaBanda = Console.ReadLine()!;

        if (BandaHelper.ObterBandaPorNome(bandasRegistradas, nomeDaBanda, out Banda? bandaAlvo))
        {
            if (bandaAlvo!.Notas.Count == 0)
            {
                Console.WriteLine($"A banda {nomeDaBanda} ainda não possui avaliações.");
            }
            else
            {
                Console.WriteLine($"A média da banda {nomeDaBanda} é {bandaAlvo!.Media:F2} com {bandaAlvo!.Notas.Count} avaliações.");
            }

            /**
            * ESPAÇO RESERVADO PARA COMPLETAR A FUNÇÃO (QUANTOS ALBUMS, MEDIA DELES, CADA MUSICA DENTRO E MEDIA DE CADA UMA)
            */

            Console.WriteLine("");
            Console.WriteLine("Digite uma tecla para votar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            return;
        }
        else
        {
            Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
        }
    }
}
