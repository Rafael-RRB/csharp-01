using ScreenSound.Enums.Language;

namespace ScreenSound.Translations.EpisodeTranslation
{
    public static class EpisodeTranslation
    {
        public static readonly Dictionary<Tuple<Language, string>, string> translations = new()
        {
            { new Tuple<Language, string>(Language.English, "Episode"), "Episode" },
            { new Tuple<Language, string>(Language.English, "Guest"), "Guest(s)" },
            { new Tuple<Language, string>(Language.English, "EpisodeInfo"), "{0} #{1}: {2} ({3}) - {4}: " },
            { new Tuple<Language, string>(Language.Portuguese, "Episode"), "Episódio" },
            { new Tuple<Language, string>(Language.Portuguese, "Guest"), "Presença(s)" },
            { new Tuple<Language, string>(Language.Portuguese, "EpisodeInfo"), "{0} #{1}: {2} ({3}) - {4}: " },
        };
    }
}
