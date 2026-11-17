using ScreenSound.Music;
using ScreenSound.Enums.Language;

namespace ScreenSound.Translations.AvailabilityTranslation
{
    public static class AvailabilityTranslation
    {
        public static readonly Dictionary<Tuple<Language, Availability>, string> translations = new()
        {
            { new Tuple<Language, Availability>(Language.English, Availability.Available), "available" },
            { new Tuple<Language, Availability>(Language.English, Availability.Unavailable), "unavailable" },
            { new Tuple<Language, Availability>(Language.Portuguese, Availability.Available), "disponível" },
            { new Tuple<Language, Availability>(Language.Portuguese, Availability.Unavailable), "indisponível" }
        };
    }
}
