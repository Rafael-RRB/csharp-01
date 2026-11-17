namespace Alura.ScreenSound.Menus;

using Alura.ScreenSound.Modelos;
using Alura.ScreenSound.Enums;
using Google.Modelos.Gemini;

public class MenuPrincipal
{
    Dictionary<string, List<Banda>> bandasRegistradas = new Dictionary<string, List<Banda>>(StringComparer.OrdinalIgnoreCase);

    public static async Task<bool> ExibirOpcoes(Dictionary<string, List<Banda>> bandasRegistradas, GeminiService service)
    {
        Console.Clear();
        MenuExibirLogo.ExibirLogo();
        Console.WriteLine("Digite 1 para ações com Bandas");
        Console.WriteLine("Digite 2 para ações com Álbuns");
        Console.WriteLine("Digite 3 para ações com Músicas");
        Console.WriteLine("Digite 4 para exibir detalhes de uma Banda");
        Console.WriteLine("Digite -1 para sair");
        Console.WriteLine("");
        Console.WriteLine("Digite a sua opção abaixo:");
        Console.Write("└► ");

        string opcaoEscolhida = "";
        int escolhaConvertida = 0;
        bool opcaoValida = false;
        string errorMessage1 = "Opção Inválida, não é um número!";
        string errorMessage2 = "Opção fora do intervalo permitido!";
        string inputMessage = "└► Digite um número correspondente às opções do menu: ";

        while (!opcaoValida)
        {
            opcaoEscolhida = Console.ReadLine()!;

            if (!int.TryParse(opcaoEscolhida, out escolhaConvertida))
            {
                Console.WriteLine(errorMessage1);
                Console.Write(inputMessage);
                continue;
            }

            if (escolhaConvertida >= 1 && escolhaConvertida <= 6 || escolhaConvertida == -1)
            {
                opcaoValida = true;
            }
            else
            {
                Console.WriteLine(errorMessage2);
                Console.Write(inputMessage);
            }
        }

        switch (escolhaConvertida)
        {
            case 1:
                await MenuSubMenu.ExibirSubOpcoes(bandasRegistradas, OpcoesModelos.Banda, service);
                break;
            case 2:
                await MenuSubMenu.ExibirSubOpcoes(bandasRegistradas, OpcoesModelos.Album, service);
                break;
            case 3:
                await MenuSubMenu.ExibirSubOpcoes(bandasRegistradas, OpcoesModelos.Musica, service);
                break;
            case 4:
                await MenuExibirBandas.ExibirBandas(bandasRegistradas, service);
                break;
            case -1:
                Console.WriteLine("Tchau tchau :)");
                return false;
            default:
                Console.WriteLine("Opção inválida...");
                break;
        }
        return true;
    }

    public MenuPrincipal(Dictionary<string, List<Banda>> definirBandasRegistradas)
    {
        bandasRegistradas = definirBandasRegistradas;
    }
}
