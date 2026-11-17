using Alura.ScreenSound.Enums;
using Alura.ScreenSound.Modelos;
using Google.Modelos.Gemini;

namespace Alura.ScreenSound.Menus;

public static class MenuSubMenu
{
    public static async Task ExibirSubOpcoes(Dictionary<string, List<Banda>> bandasRegistradas, OpcoesModelos opcao, GeminiService service)
    {
        Dictionary<Tuple<OpcoesModelos, int>, Func<Task>> dicionario = new Dictionary<Tuple<OpcoesModelos, int>, Func<Task>>()
        {
            { new Tuple<OpcoesModelos, int>(OpcoesModelos.Banda, 1), async () => await MenuRegistrarBandas.RegistrarBanda(bandasRegistradas) },
            { new Tuple<OpcoesModelos, int>(OpcoesModelos.Banda, 2), async () => await MenuAvaliarBandas.AvaliarBanda(bandasRegistradas) },
            { new Tuple<OpcoesModelos, int>(OpcoesModelos.Banda, 3), async () => await MenuExibirBandas.ExibirBandas(bandasRegistradas, service) },
            { new Tuple<OpcoesModelos, int>(OpcoesModelos.Album, 1), async () => await MenuRegistrarAlbuns.RegistrarAlbum(bandasRegistradas) },
            { new Tuple<OpcoesModelos, int>(OpcoesModelos.Album, 2), async () => await MenuAvaliarAlbuns.AvaliarAlbum(bandasRegistradas) },
            { new Tuple<OpcoesModelos, int>(OpcoesModelos.Album, 3), async () => await MenuExibirAlbuns.ExibirAlbuns(bandasRegistradas, service) },
            { new Tuple<OpcoesModelos, int>(OpcoesModelos.Musica, 1), async () => await MenuRegistrarMusicas.RegistrarMusica(bandasRegistradas) },
            { new Tuple<OpcoesModelos, int>(OpcoesModelos.Musica, 2), async () => await MenuAvaliarMusicas.AvaliarMusica(bandasRegistradas) },
            { new Tuple<OpcoesModelos, int>(OpcoesModelos.Musica, 3), async () => await MenuExibirMusicas.ExibirMusicas(bandasRegistradas, service) },
        };

        Console.Clear();
        MenuExibirLogo.ExibirLogo();
        if (opcao == OpcoesModelos.Banda)
        {
            Console.WriteLine("Digite 1 para registrar uma banda");
            Console.WriteLine("Digite 2 para avaliar uma banda");
            Console.WriteLine("Digite 3 para exibir todas as bandas");
        }
        else if (opcao == OpcoesModelos.Album)
        {
            Console.WriteLine("Digite 1 para registrar um álbum para uma banda");
            Console.WriteLine("Digite 2 para avaliar um álbum de uma banda");
            Console.WriteLine("Digite 3 para exibir todos os álbums de uma banda");
        }
        else if (opcao == OpcoesModelos.Musica)
        {
            Console.WriteLine("Digite 1 para registrar uma música em um álbum de uma banda");
            Console.WriteLine("Digite 2 para avaliar uma música em um álbum de uma banda");
            Console.WriteLine("Digite 3 para exibir todas as músicas em um álbum de uma banda");
        }
        Console.WriteLine("Digite -1 para retornar");
        Console.WriteLine("");
        Console.WriteLine("Digite a sua opção abaixo:");
        Console.Write("└► ");

        string opcaoEscolhida = "";
        int escolhaConvertida = 0;
        bool opcaoValida = false;
        string errorMessage1 = "Opção Inválida, não é um número! ";
        string errorMessage2 = "Opção fora do intervalo permitido! ";
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

            if (escolhaConvertida >= 1 && escolhaConvertida <= 3 || escolhaConvertida == -1)
            {
                opcaoValida = true;
            }
            else
            {
                Console.WriteLine(errorMessage2);
                Console.Write(inputMessage);
            }
        }

        if (escolhaConvertida == -1)
        {
            return;
        }
        else
        {
            await dicionario[new Tuple<OpcoesModelos, int>(opcao, escolhaConvertida)]();
        }
    }
}
