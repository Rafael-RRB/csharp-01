namespace Alura.ScreenSound.Helpers;

using Alura.ScreenSound.Modelos;
using System.Globalization;

public static class BandaHelper
{
    [Obsolete("Use BandaExiste em vez disso.")]
    public static bool BandaExiste(Dictionary<string, List<Banda>> bandasRegistradas, string bandaAlvo)
    {
        for (int i = 0; i < bandasRegistradas.Count; i++)
        {
            if (string.Equals(bandasRegistradas.ElementAt(i).Key, bandaAlvo, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }

    public static bool ObterBandaPorNome(Dictionary<string, List<Banda>> bandasRegistradas, string bandaAlvo, out Banda? bandaEncontrada)
    {
        bandaEncontrada = null;

        if (bandasRegistradas.TryGetValue(bandaAlvo, out List<Banda>? bandas))
        {
            foreach (Banda banda in bandas)
            {
                if (banda.Nome.Equals(bandaAlvo, StringComparison.OrdinalIgnoreCase))
                {
                    bandaEncontrada = banda;
                    return true;
                }
            }
        }
        return false;
    }

    public static bool ObterAlbumPorNome(List<Album> albunsRegistrados, string albumAlvo, out Album? albumEncontrado)
    {
        albumEncontrado = null;
        foreach (Album album in albunsRegistrados)
        {
            if (album.Nome.Equals(albumAlvo, StringComparison.OrdinalIgnoreCase))
            {
                albumEncontrado = album;
                return true;
            }
        }
        return false;
    }

    public static bool ObterMusicaPorNome(List<Musica> musicasRegistradas, string musicaAlvo, out Musica? musicaEncontrada)
    {
        musicaEncontrada = null;
        foreach (Musica musica in musicasRegistradas)
        {
            if (musica.Nome.Equals(musicaAlvo, StringComparison.OrdinalIgnoreCase))
            {
                musicaEncontrada = musica;
                return true;
            }
        }
        return false;
    }

    public static string NormalizarNome(string nome)
    {
        // I want to trim, lowercase, and titlecase the band name
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.Trim().ToLower());
    }
}
