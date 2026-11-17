using ScreenSound.Enums.Language;

namespace ScreenSound.Translations.PersonTranslation
{
    public static class PersonTranslation
    {
        public static readonly Dictionary<Tuple<Language, string>, string> translations = new()
        {
            { new Tuple<Language, string>(Language.English, "Name"), "Name" },
            { new Tuple<Language, string>(Language.English, "NameInfo"), "{0}: {1}" },
            { new Tuple<Language, string>(Language.English, "Biography"), "Biography" },
            { new Tuple<Language, string>(Language.English, "BiographyInfo"), "{0}: {1}" },
            { new Tuple<Language, string>(Language.Portuguese, "Name"), "Nome" },
            { new Tuple<Language, string>(Language.Portuguese, "NameInfo"), "{0}: {1}" },
            { new Tuple<Language, string>(Language.Portuguese, "Biography"), "Biografia" },
            { new Tuple<Language, string>(Language.Portuguese, "BiographyInfo"), "{0}: {1}" }
        };
    }
}
