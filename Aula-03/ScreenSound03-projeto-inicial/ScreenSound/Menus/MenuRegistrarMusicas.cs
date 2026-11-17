using Alura.ScreenSound.Helpers;
using Alura.ScreenSound.Modelos;

namespace Alura.ScreenSound.Menus;

public static class MenuRegistrarMusicas
{
    public static async Task RegistrarMusica(Dictionary<string, List<Banda>> bandasRegistradas)
    {
        Console.Clear();
        MenuExibirTitulo.ExibirTitulo("Registro de músicas", true);

        Console.Write("Digite a banda cuja música deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (BandaHelper.ObterBandaPorNome(bandasRegistradas, nomeDaBanda, out Banda? bandaAlvo))
        {
            if (bandaAlvo!.Albuns.Count == 0)
            {
                Console.Write($"A banda {nomeDaBanda} não possui álbuns registrados... por favor, registre um álbum primeiro. ");
                Thread.Sleep(4000);
                Console.Clear();
                return;
            }
            Console.Write("Agora digite o título do álbum: ");
            string nomeDoAlbum = Console.ReadLine()!;
            if (BandaHelper.ObterAlbumPorNome(bandaAlvo!.Albuns, nomeDoAlbum, out Album? albumAlvo))
            {
                Console.Write("Finalmente, digite o título da música que você quer registar: ");
                string nomeDaMusica = Console.ReadLine()!;
                if (BandaHelper.ObterMusicaPorNome(albumAlvo!.Musicas, nomeDaMusica, out _))
                {
                    Console.Write($"A música {nomeDaMusica} já existe para o álbum {nomeDoAlbum} da banda {nomeDaBanda}... ");
                }
                else
                {
                    Musica musicaNormalizada = new Musica(bandaAlvo, BandaHelper.NormalizarNome(nomeDaMusica));
                    albumAlvo!.AdicionarMusica(musicaNormalizada);
                    Console.Write($"A música {nomeDaMusica} foi registrada com sucesso! ");
                }
            }
            else
            {
                Console.WriteLine($"O álbum {nomeDoAlbum} não foi encontrado.");
            }
        }
        else
        {
            Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada.");
        }
        Thread.Sleep(4000);
        Console.Clear();
    }
}
