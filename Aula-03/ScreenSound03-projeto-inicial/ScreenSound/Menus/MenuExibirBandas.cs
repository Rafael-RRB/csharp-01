using Alura.ScreenSound.Modelos;
using Google.Modelos.Gemini;

namespace Alura.ScreenSound.Menus;

public static class MenuExibirBandas
{
    private static readonly string introducao = "Baseado nos dados a seguir, julgue o gosto músical do usuário resumidamente e com humor. É possível existir dados fictícios, então fique a vontade para inventar histórias. Vamos considerar que nosso gosto é 'oldschool', e gostamos de bandas mais antigas e artistas pequenos -- não mencione isso na resposta.";

    public static async Task ExibirBandas(Dictionary<string, List<Banda>> bandasRegistradas, GeminiService service)
    {
        Console.Clear();
        if (bandasRegistradas.Count == 0)
        {
            MenuExibirTitulo.ExibirTitulo("Nenhuma banda registrada na nossa aplicação...", true);
        }
        else
        {
            List<string> bandas = new List<string>();
            foreach (List<Banda> banda in bandasRegistradas.Values)
            {
                bandas.Add($" - Banda: \"{banda[0].Nome}\" ({banda[0].ExibirMedia()})");
            }
            string prompt = PromptBuilder.BuildBasicPrompt(introducao, bandas);

            Console.Clear();
            MenuExibirTitulo.ExibirTitulo("Exibindo todas as bandas registradas na nossa aplicação", true);

            foreach (string linha in bandas)
            {
                Console.WriteLine(linha);
            }

            Console.WriteLine("");
            string result = await service.GetResponseAsync(prompt);
            Console.WriteLine(result.TrimEnd());
        }        

        Console.WriteLine("");
        Console.Write("...Digite [Enter] para voltar ao menu principal. ");
        Console.ReadKey();
    }
}
