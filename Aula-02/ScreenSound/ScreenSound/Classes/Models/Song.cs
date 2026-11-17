using ScreenSound.Translations.AvailabilityTranslation;
using ScreenSound.Translations.SongTranslation;
using ScreenSound.Enums.Language;
using ScreenSound.Utilities.String;

namespace ScreenSound.Music
{
    public class Song
    {
        public SongTitle Title { get; private set; } = SongTitle.Empty;
        public SongDuration Duration { get; private set; } = default;
        public Availability Availability { get; private set; } = default;
        public Entity artist;
        /// <summary>
        /// The maximum song title length of 200 is based on "Cranky Old Yank (In A Clanky Old Tank)" by "Hoagy Carmichael" -- the full title is 156 characters long.
        /// </summary>
        private const int maxSongTitleLength = 200;

        public string GetSummary(Language language)
        {
            Tuple<Language, string> songSummaryKey = new Tuple<Language, string>(language, "Summary");
            string songSummaryString = SongTranslation.translations[songSummaryKey];
            Tuple<Language, EntityStatus> entityKey = new Tuple<Language, EntityStatus>(language, artist.Type);
            string entityString = SongTranslation.entityTranslations[entityKey];

            return string.Format(songSummaryString, Title.Value, artist.Name.Value, entityString);
        }

        public string GetSongInfo(Language language)
        {
            Tuple<Language, string> songInfoKey = new Tuple<Language, string>(language, "SongInfo");
            string songInfoString = SongTranslation.translations[songInfoKey];
            int maxShortTitleLength = 30;
            string songTitle = StringUtility.ShortenString(Title.Value, maxShortTitleLength);
            songTitle = songTitle.PadRight(maxShortTitleLength);

            // - 2 is for the asterisk and space at the start of the string.
            string spaceBetweenString = new string(' ', 3);
            spaceBetweenString = spaceBetweenString.Substring(0, spaceBetweenString.Length / 2) + "-" + spaceBetweenString.Substring(spaceBetweenString.Length / 2 + 1);

            return string.Format(songInfoString, songTitle, Duration.Value, spaceBetweenString);
        }

        public string GetSongFullInfo(Language language)
        {
            Tuple<Language, string> songInfoKey = new Tuple<Language, string>(language, "FullSongInfo");
            string songInfoString = SongTranslation.translations[songInfoKey];
            Tuple<Language, Availability> availabilityKey = new Tuple<Language, Availability>(language, Availability);
            string availabilityString = AvailabilityTranslation.translations[availabilityKey];

            return string.Format(songInfoString, Title.Value, artist.Name.Value, Duration.Value, availabilityString);
        }

        // Note: we could have primitive properties with data objects fields, but... maybe for other classes.
        public void SetSongTitle(string newSongTitle)
        {
            Title = new SongTitle(newSongTitle, maxSongTitleLength);
        }

        public void SetSongDuration(TimeSpan newSongDuration)
        {
            Duration = new SongDuration(newSongDuration);
        }

        public void SetSongStatus(Availability availability)
        {
            Availability = availability;
        }

        public Song(string setSongTitle, TimeSpan setSongDuration, Availability setSongStatus, Entity getArtist)
        {
            Title = new SongTitle(setSongTitle, maxSongTitleLength);
            Duration = new SongDuration(setSongDuration);
            Availability = setSongStatus;
            artist = getArtist;
        }
    }
}
