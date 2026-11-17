using Alura.ScreenSound.Helpers;
using Alura.ScreenSound.Modelos;
using Google.Modelos.Gemini;

namespace Alura.ScreenSound.Menus;

public static class MenuExibirAlbuns
{
    private static readonly string introducao = "Baseado nos dados a seguir, crie um pequeno resumo interessante. É possível existir dados fictícios, então fique a vontade para inventar histórias.";

    public static async Task ExibirAlbuns(Dictionary<string, List<Banda>> bandasRegistradas, GeminiService service)
    {
        Console.Clear();
        Console.Write("Digite o nome da banda dos álbuns que deseja ver: ");
        string nomeDaBanda = Console.ReadLine()!;

        if (BandaHelper.ObterBandaPorNome(bandasRegistradas, nomeDaBanda, out Banda? bandaEncontrada))
        {
            if (bandaEncontrada!.Albuns.Count == 0)
            {
                Console.WriteLine($"A banda \"{bandaEncontrada.Nome}\" não possui álbuns registrados...");
            }
            else
            {
                List<string> albuns = new List<string>();
                albuns.Add($"Banda: \"{bandaEncontrada.Nome}\".");

                foreach (Album album in bandaEncontrada.Albuns)
                {
                    albuns.Add($" - Album: \"{album.Nome}\" ({album.ExibirMedia()})");
                }
                string prompt = PromptBuilder.BuildBasicPrompt(introducao, albuns);

                Console.Clear();
                MenuExibirTitulo.ExibirTitulo($"Exibindo todos os álbuns registradas na banda \"{bandaEncontrada!.Nome}\" na nossa aplicação", true);

                foreach (string linha in albuns)
                {
                    Console.WriteLine(linha);
                }

                Console.WriteLine("");
                string result = await service.GetResponseAsync(prompt);
                Console.WriteLine(result.TrimEnd());
            }            
        }
        else
        {
            Console.WriteLine($"A banda \"{nomeDaBanda}\" não foi encontrada...");
        }

        Console.WriteLine("");
        Console.Write("...Digite [Enter] para voltar ao menu principal. ");
        Console.ReadKey();
    }
}
