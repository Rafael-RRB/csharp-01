using ScreenSound.Enums.Language;
using ScreenSound.Translations.EntityTranslation;

namespace ScreenSound.Music
{
    public class Entity
    {
        public ArtistName Name { get; private set; } = ArtistName.Empty;
        public EntityStatus Type { get; private set; } = default;
        public List<Album> albums = new List<Album>();
        /// <summary>
        /// The maximum artist name length of 100 is based on "Xavleg". It's currently the longest band name, with the full name at 77 characters.
        /// </summary>
        private const int maxArtistNameLength = 100;

        public void AddAlbum(Album album)
        {
            albums.Add(album);
        }

        public void RemoveAlbum(Album album)
        {
            albums.Remove(album);
        }

        public void ClearAlbums()
        {
            albums.Clear();
        }

        public int GetTotalSongs()
        {
            int totalSongs = 0;
            foreach(Album album in albums)
            {
                totalSongs += album.songs.Count;
            }
            return totalSongs;
        }

        public string[] GetDiscography(Language language)
        {
            Tuple<Language, string> discographyKey = new Tuple<Language, string>(language, "Discography");
            string discographyString = EntityTranslation.translations[discographyKey];
            Tuple<Language, EntityStatus> entityKey = new Tuple<Language, EntityStatus>(language, Type);
            string entityString = EntityTranslation.entityTranslations[entityKey];

            int arrayIndex = 0;

            string[] stringArrayResult = new string[albums.Count + GetTotalSongs() + 1];
            stringArrayResult[arrayIndex] = string.Format(discographyString, entityString, Name.Value);
            arrayIndex++;

            foreach (Album album in albums)
            {
                stringArrayResult[arrayIndex] = " - " + album.GetAlbumInfo(language);
                arrayIndex++;
                foreach (Song song in album.songs)
                {
                    stringArrayResult[arrayIndex] = "  *  " + song.GetSongInfo(language);
                    arrayIndex++;
                }
            }

            return stringArrayResult;
        }

        public void PrintDiscography(Language language)
        {
            string[] discography = GetDiscography(language);
            foreach (string line in discography)
            {
                Console.WriteLine(line);
            }
        }

        public Entity(string setName, EntityStatus setType)
        {
            Name = new ArtistName(setName, maxArtistNameLength);
            Type = setType;
        }
    }
}
