using ScreenSound.Enums.Language;
using ScreenSound.Music;

namespace ScreenSound.Translations.SongTranslation
{
    public static class SongTranslation
    {
        public static readonly Dictionary<Tuple<Language, string>, string> translations = new()
        {
            { new Tuple<Language, string>(Language.English, "SongInfo"), "{0}{2}{1}" },
            { new Tuple<Language, string>(Language.English, "FullSongInfo"), "Title: {0} / Artist: {1} / Duration: {2} / Availability: {3}" },            
            { new Tuple<Language, string>(Language.English, "Summary"), "{0}, {2} {1}" },
            { new Tuple<Language, string>(Language.Portuguese, "SongInfo"), "{0}{2}{1}" },
            { new Tuple<Language, string>(Language.Portuguese, "FullSongInfo"), "Título: {0} / Artista: {1} / Duração: {2} / Disponibilidade: {3}" },
            { new Tuple<Language, string>(Language.Portuguese, "Summary"), "{0}, {2} {1}" }
        };

        public static readonly Dictionary<Tuple<Language, EntityStatus>, string> entityTranslations = new()
        {
            { new Tuple<Language, EntityStatus>(Language.English, EntityStatus.Band), "by the band" },
            { new Tuple<Language, EntityStatus>(Language.English, EntityStatus.SingerMale), "by the singer" },
            { new Tuple<Language, EntityStatus>(Language.English, EntityStatus.SingerFemale), "by the singer" },
            { new Tuple<Language, EntityStatus>(Language.English, EntityStatus.SingerNonBinary), "by the singer" },
            { new Tuple<Language, EntityStatus>(Language.Portuguese, EntityStatus.Band), "da banda" },
            { new Tuple<Language, EntityStatus>(Language.Portuguese, EntityStatus.SingerMale), "do cantor" },
            { new Tuple<Language, EntityStatus>(Language.Portuguese, EntityStatus.SingerFemale), "da cantora" },
            { new Tuple<Language, EntityStatus>(Language.Portuguese, EntityStatus.SingerNonBinary), "do(a) cantor(a)" }
        };
    }
}
