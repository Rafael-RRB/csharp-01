using Alura.ScreenSound.Helpers;
using Alura.ScreenSound.Modelos;
using Google.Modelos.Gemini;

namespace Alura.ScreenSound.Menus;

public static class MenuExibirMusicas
{
    private static readonly string introducao = "Baseado nos dados a seguir, crie um pequeno resumo interessante. É possível existir dados fictícios, então fique a vontade para inventar histórias.";

    public static async Task ExibirMusicas(Dictionary<string, List<Banda>> bandasRegistradas, GeminiService service)
    {
        Console.Clear();
        Console.Write("Digite o nome da banda das músicas que deseja ver: ");
        string nomeDaBanda = Console.ReadLine()!;

        if (BandaHelper.ObterBandaPorNome(bandasRegistradas, nomeDaBanda, out Banda? bandaEncontrada))
        {
            Console.Write("Finalmente, digite o nome do álbum que deseja ver as músicas: ");
            string nomeDoAlbum = Console.ReadLine()!;
            if (BandaHelper.ObterAlbumPorNome(bandaEncontrada!.Albuns, nomeDoAlbum, out Album? albumEncontrado))
            {
                List<string> musicas = new List<string>();
                musicas.Add($"Banda: \"{bandaEncontrada.Nome}\".");
                musicas.Add($" - Álbum: \"{albumEncontrado.Nome}\".");

                foreach (Musica musica in albumEncontrado!.Musicas)
                {
                    musicas.Add($"   - Música: {musica.Nome} ({musica.ExibirMedia()})");
                }
                
                string prompt = PromptBuilder.BuildBasicPrompt(introducao, musicas);
                MenuExibirTitulo.ExibirTitulo($"Exibindo todas as músicas registradas da banda {bandaEncontrada!.Nome} na nossa aplicação", true);

                foreach (string linha in musicas)
                {
                    Console.WriteLine(linha);
                }

                Console.WriteLine("");
                string result = await service.GetResponseAsync(prompt);
                Console.WriteLine(result.TrimEnd());
            }
            else
            {
                Console.WriteLine($"O álbum {nomeDoAlbum} não foi encontrado...");
            }
        }
        else
        {
            Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada...");
        }

        Console.WriteLine("");
        Console.Write("...Digite [Enter] para voltar ao menu principal. ");
        Console.ReadKey();
    }
}
