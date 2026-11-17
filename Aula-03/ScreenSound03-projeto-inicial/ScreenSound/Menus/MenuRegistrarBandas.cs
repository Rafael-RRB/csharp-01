using Alura.ScreenSound.Helpers;
using Alura.ScreenSound.Modelos;

namespace Alura.ScreenSound.Menus;

public static class MenuRegistrarBandas
{
    public static async Task RegistrarBanda(Dictionary<string, List<Banda>> bandasRegistradas)
    {
        Console.Clear();
        MenuExibirTitulo.ExibirTitulo("Registro das bandas", true);
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;

        if (BandaHelper.ObterBandaPorNome(bandasRegistradas, nomeDaBanda, out _))
        {
            Console.Write($"A banda {nomeDaBanda} já está registrada em nossa aplicação... ");
        }
        else
        {
            string nomeNormalizado = BandaHelper.NormalizarNome(nomeDaBanda);
            bandasRegistradas.Add(nomeNormalizado, new List<Banda> { new Banda(nomeNormalizado) });
            Console.Write($"A banda {nomeNormalizado} foi registrada com sucesso! ");
        }

        Thread.Sleep(4000);
    }
}
