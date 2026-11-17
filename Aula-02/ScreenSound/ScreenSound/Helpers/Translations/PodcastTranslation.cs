using ScreenSound.Enums.Language;
using ScreenSound.Podcast;

namespace ScreenSound.Translations.PodcastTranslation
{
    public static class PodcastTranslation
    {
        public static readonly Dictionary<Tuple<Language, string>, string> translations = new()
        {
            { new Tuple<Language, string>(Language.English, "Podcast"), "Podcast" },
            { new Tuple<Language, string>(Language.English, "TotalEpisodes"), "Total Episodes" },
            { new Tuple<Language, string>(Language.English, "PodcastInfo"), "{0}: {1}, {2}: {3}." },
            { new Tuple<Language, string>(Language.English, "PodcastFullInfo"), "{0}: {1}, {2}: {3}, {4}: {5}." },
            { new Tuple<Language, string>(Language.Portuguese, "Podcast"), "Podcast" },
            { new Tuple<Language, string>(Language.Portuguese, "TotalEpisodes"), "Total de Episódios" },
            { new Tuple<Language, string>(Language.Portuguese, "PodcastInfo"), "{0}: {1}, {2}: {3}." },
            { new Tuple<Language, string>(Language.Portuguese, "PodcastFullInfo"), "{0}: {1}, {2}: {3}, {4}: {5}." },
        };

        public static readonly Dictionary<Tuple<Language, PersonStatus>, string> hostTranslations = new()
        {
            { new Tuple<Language, PersonStatus>(Language.English, PersonStatus.PersonMale), "Host" },
            { new Tuple<Language, PersonStatus>(Language.English, PersonStatus.PersonFemale), "Host" },
            { new Tuple<Language, PersonStatus>(Language.English, PersonStatus.PersonNonBinary), "Host" },
            { new Tuple<Language, PersonStatus>(Language.Portuguese, PersonStatus.PersonMale), "Apresentador" },
            { new Tuple<Language, PersonStatus>(Language.Portuguese, PersonStatus.PersonFemale), "Apresentadora" },
            { new Tuple<Language, PersonStatus>(Language.Portuguese, PersonStatus.PersonNonBinary), "Apresentador(a)" }
        };
    }
}
