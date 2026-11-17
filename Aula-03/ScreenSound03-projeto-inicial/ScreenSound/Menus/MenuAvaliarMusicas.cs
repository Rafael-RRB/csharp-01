using Alura.ScreenSound.Enums;
using Alura.ScreenSound.Helpers;
using Alura.ScreenSound.Modelos;

namespace Alura.ScreenSound.Menus;

public static class MenuAvaliarMusicas
{
    public static async Task AvaliarMusica(Dictionary<string, List<Banda>> bandasRegistradas)
    {
        Console.Clear();
        MenuExibirTitulo.ExibirTitulo("Avaliar música", true);
        Console.Write("Digite o nome da banda da música que deseja avaliar: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (BandaHelper.ObterBandaPorNome(bandasRegistradas, nomeDaBanda, out Banda? bandaEncontrada))
        {
            Console.Write("Agora digite o nome do album da música que deseja avaliar: ");
            string nomeDoAlbum = Console.ReadLine()!;
            if (BandaHelper.ObterAlbumPorNome(bandaEncontrada!.Albuns, nomeDoAlbum, out Album? albumEncontrado))
            {
                Console.Write("Finalmente, digite o nome da música que deseja avaliar: ");
                string nomeDaMusica = Console.ReadLine()!;
                if (BandaHelper.ObterMusicaPorNome(albumEncontrado!.Musicas, nomeDaMusica, out Musica? musicaEncontrada))
                {
                    Console.Write($"Qual a nota que a música {musicaEncontrada!.Nome} merece? ");

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

                    musicaEncontrada!.AdicionarNota(avaliacao);
                    Console.WriteLine($"A nota {avaliacao.Nota} foi registrada com sucesso para a música {musicaEncontrada!.Nome}");
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine($"A música {nomeDaMusica} não foi encontrada!");
                    Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                    Console.ReadKey();
                }                
            }
            else
            {
                Console.WriteLine($"O álbum {nomeDoAlbum} não foi encontrado!");
                Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                Console.ReadKey();
            }
        }
        else
        {
            Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
        }

    }
}
