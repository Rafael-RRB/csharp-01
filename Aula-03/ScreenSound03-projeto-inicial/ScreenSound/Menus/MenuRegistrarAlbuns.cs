using Alura.ScreenSound.Helpers;
using Alura.ScreenSound.Modelos;

namespace Alura.ScreenSound.Menus;

public static class MenuRegistrarAlbuns
{
    public static async Task RegistrarAlbum(Dictionary<string, List<Banda>> bandasRegistradas)
    {
        Console.Clear();
        MenuExibirTitulo.ExibirTitulo("Registro de álbuns", true);

        Console.Write("Digite a banda cujo álbum deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (BandaHelper.ObterBandaPorNome(bandasRegistradas, nomeDaBanda, out Banda? bandaAlvo))
        {
            Console.Write("Agora digite o título do álbum: ");
            string tituloAlbum = Console.ReadLine()!;
            if (bandaAlvo!.TentarAdicionarAlbum(BandaHelper.NormalizarNome(tituloAlbum)))
            {
                Console.Write($"O álbum {tituloAlbum} foi registrado com sucesso para a banda {nomeDaBanda}. ");
            }
            else
            {
                Console.Write($"O álbum {tituloAlbum} já está registrado para a banda {nomeDaBanda}... ");
            }
        }
        else
        {
            Console.Write($"A banda {nomeDaBanda} não foi encontrada... ");
        }
        Thread.Sleep(4000);
        Console.Clear();
    }
}
