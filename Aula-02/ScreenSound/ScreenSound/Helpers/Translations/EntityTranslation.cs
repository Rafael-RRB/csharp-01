using ScreenSound.Enums.Language;
using ScreenSound.Music;

namespace ScreenSound.Translations.EntityTranslation
{
    public static class EntityTranslation
    {
        public static readonly Dictionary<Tuple<Language, string>, string> translations = new()
        {
            { new Tuple<Language, string>(Language.English, "Discography"), "Discography {0} {1}:" },
            { new Tuple<Language, string>(Language.Portuguese, "Discography"), "Discografia {0} {1}:" }
        };

        public static readonly Dictionary<Tuple<Language, EntityStatus>, string> entityTranslations = new()
        {
            { new Tuple<Language, EntityStatus>(Language.English, EntityStatus.Band), "of band" },
            { new Tuple<Language, EntityStatus>(Language.English, EntityStatus.SingerMale), "of singer" },
            { new Tuple<Language, EntityStatus>(Language.English, EntityStatus.SingerFemale), "of singer" },
            { new Tuple<Language, EntityStatus>(Language.English, EntityStatus.SingerNonBinary), "of singer" },
            { new Tuple<Language, EntityStatus>(Language.Portuguese, EntityStatus.Band), "da banda" },
            { new Tuple<Language, EntityStatus>(Language.Portuguese, EntityStatus.SingerMale), "do cantor" },
            { new Tuple<Language, EntityStatus>(Language.Portuguese, EntityStatus.SingerFemale), "da cantora" },
            { new Tuple<Language, EntityStatus>(Language.Portuguese, EntityStatus.SingerNonBinary), "do(a) cantor(a)" }
        };
    }
}
