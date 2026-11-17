using ScreenSound.DataObjects.Biography;
using ScreenSound.DataObjects.Name;
using ScreenSound.Enums.Language;
using ScreenSound.Translations.PersonTranslation;

namespace ScreenSound.Podcast
{
    public class Person
    {
        public PersonName Name { get; private set; } = PersonName.Empty;
        public PersonStatus Gender { get; private set; } = default;
        public Biography Biography { get; private set; } = Biography.Empty;
        /// <summary>
        /// maxNameLength of 800 is based on the longest personal name ever used, which is 747 characters long.
        /// </summary>
        public const int maxNameLength = 800;
        public const int maxBiographyLength = 5000;

        public string[] GetPersonFullInfo(Language language)
        {
            Tuple<Language, string> nameKey = new Tuple<Language, string>(language, "Name");
            string nameString = PersonTranslation.translations[nameKey];
            Tuple<Language, string> biographyKey = new Tuple<Language, string>(language, "Biography");
            string biographyString = PersonTranslation.translations[biographyKey];
            Tuple<Language, string> nameInfoKey = new Tuple<Language, string>(language, "NameInfo");
            string nameInfoString = PersonTranslation.translations[nameInfoKey];
            Tuple<Language, string> biographyInfoKey = new Tuple<Language, string>(language, "BiographyInfo");
            string biographyInfoString = PersonTranslation.translations[biographyInfoKey];

            string[] lines = new string[2];
            lines[0] = string.Format(nameInfoString, nameString, Name.Value);
            lines[1] = string.Format(biographyInfoString, biographyString, Biography.Value);

            return lines;
        }

        public void PrintPersonFullInfo(Language language)
        {
            foreach (string line in GetPersonFullInfo(language))
            {
                Console.WriteLine(line);
            }
        }

        public Person(string setName, PersonStatus setGender, string setBiography)
        {
            Name = new PersonName(setName, maxNameLength);
            Gender = setGender;
            Biography = new Biography(setBiography, maxBiographyLength);
        }
    }
}
