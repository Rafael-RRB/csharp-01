using ScreenSound.Enums.Language;

namespace ScreenSound.Translations.AlbumTranslation
{
    public static class AlbumTranslation
    {
        public static readonly Dictionary<Tuple<Language, string>, string> translations = new()
        {
            { new Tuple<Language, string>(Language.English, "Album"), "Album" },
            { new Tuple<Language, string>(Language.English, "AlbumInfo"), "{0}: {1} - {2}" },
            { new Tuple<Language, string>(Language.Portuguese, "Album"), "Álbum" },
            { new Tuple<Language, string>(Language.Portuguese, "AlbumInfo"), "{0}: {1} - {2}" },
        };
    }
}
