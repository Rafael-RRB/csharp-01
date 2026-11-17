using ScreenSound.Enums.Language;
using ScreenSound.Translations.AlbumTranslation;

namespace ScreenSound.Music
{
    public class Album
    {
        public AlbumName Name { get; private set; } = AlbumName.Empty;
        public AlbumDuration Duration { get; private set; } = default;
        public List<Song> songs = new List<Song>();
        public Entity entity;
        /// <summary>
        /// The maximum album name length of 900 is based on the longest album name recorded in the Guinness World Records.
        /// Currently, the record is held by the album The Boy Bands Have Won by Chumbawamba, which has 156 words and 865 characters.
        /// </summary>
        private const int maxAlbumNameLength = 900;
        /// <summary>
        /// The maximum song duration of 604800 is not based on anything in particular, but instead, is the total amount of seconds in 7 days.
        /// </summary>
        private const int maxAlbumDuration = 604800;

        public string GetAlbumInfo(Language language)
        {
            Tuple<Language, string> albumKey = new Tuple<Language, string>(language, "Album");
            string albumString = AlbumTranslation.translations[albumKey];
            Tuple<Language, string> albumInfoKey = new Tuple<Language, string>(language, "AlbumInfo");
            string albumInfoString = AlbumTranslation.translations[albumInfoKey];

            return string.Format(albumInfoString, albumString, Name.Value, Duration.Value);
        }

        public void AddSong(Song song)
        {
            songs.Add(song);
            Duration = new AlbumDuration((int)(Duration.Value.TotalSeconds + song.Duration.Value.TotalSeconds), maxAlbumDuration);
        }

        public void RemoveSong(Song song)
        {
            songs.Remove(song);
            Duration = new AlbumDuration((int)(Duration.Value.TotalSeconds - song.Duration.Value.TotalSeconds), maxAlbumDuration);
        }

        public void ClearAlbum()
        {
            songs.Clear();
            Duration = new AlbumDuration(0, maxAlbumDuration);
        }

        public string[] GetFullAlbumInfo(Language language)
        {
            int index = 0;
            string[] lines = new string[1 + songs.Count];
            lines[index] = GetAlbumInfo(language);
            index++;
            foreach (Song song in songs)
            {
                lines[index] = " * " + song.GetSongInfo(language);
                index++;
            }

            return lines;
        }

        public void PrintFullAlbumInfo(Language language)
        {
            string[] lines = GetFullAlbumInfo(language);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }

        public string[] GetAllSongsInfo(Language language)
        {
            string[] lines = new string[songs.Count];
            int index = 0;
            foreach (Song song in songs)
            {
                lines[index] = song.GetSongInfo(language);
                index++;
            }

            return lines;
        }

        public void PrintAllSongsInfo(Language language)
        {
            foreach (Song song in songs)
            {
                Console.WriteLine(song.GetSongInfo(language));
            }
        }

        public Album(string setAlbumName, Entity setEntity)
        {
            Name = new AlbumName(setAlbumName, maxAlbumNameLength);
            entity = setEntity;
        }
    }
}
