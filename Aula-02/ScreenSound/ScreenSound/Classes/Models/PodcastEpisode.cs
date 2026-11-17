using ScreenSound.Enums.Language;
using ScreenSound.Translations.EpisodeTranslation;

namespace ScreenSound.Podcast
{
    public class PodcastEpisode
    {
        // "Episode" class must have a Title, a Duration, Episode Number, a Summary, a list of "Guests", a method to add and remove guests, and a method to get the "Episode" info.
        Podcast show;
        public List<Person> Guests { get; private set; } = new List<Person>();
        public string[] guestNames = new string[0];
        public EpisodeTitle Title { get; private set; } = EpisodeTitle.Empty;
        public EpisodeDuration Duration { get; private set; } = default;
        int Episode { get; } = 0;
        public EpisodeSummary Summary { get; private set; } = EpisodeSummary.Empty;

        public void AddGuest(Person guest)
        {
            Guests.Add(guest);
            UpdateGuestNames();
        }

        public void AddGuest(Person[] guests)
        {
            foreach (Person person in guests)
            {
                Guests.Add(person);
            }
            UpdateGuestNames();
        }

        public void RemoveGuest(Person guest)
        {
            Guests.Remove(guest);
            UpdateGuestNames();
        }

        public string GetEpisodeInfo(Language language)
        {
            Tuple<Language, string> episodeKey = new Tuple<Language, string>(language, "Episode");
            string episodeString = EpisodeTranslation.translations[episodeKey];
            Tuple<Language, string> guestKey = new Tuple<Language, string>(language, "Guest");
            string guestString = EpisodeTranslation.translations[guestKey];
            Tuple<Language, string> episodeInfoKey = new Tuple<Language, string>(language, "EpisodeInfo");
            string episodeInfoString = EpisodeTranslation.translations[episodeInfoKey];
            string guestNamesString = string.Join(", ", guestNames);

            return string.Format(episodeInfoString, episodeString, Episode, Title.Value, Duration.Value.ToString(), guestString) + guestNamesString;
        }

        public void PrintEpisodeInfo(Language language)
        {
            Console.WriteLine(GetEpisodeInfo(language));
        }

        private void UpdateGuestNames()
        {
            if (guestNames.Length != Guests.Count)
            {
                guestNames = new string[Guests.Count];
            }
            for (int i = 0; i < Guests.Count; i++)
            {
                if (Guests[i] != null)
                {
                    guestNames[i] = Guests[i].Name.Value;
                }
            }
        }

        private void SaveFullHistory()
        {
            // Protect against null reference exceptions. Not implemented yet.
            UpdateGuestNames();
        }

        // For an episode with a single guest.
        public PodcastEpisode(Podcast getShow, Person guest, string setTitle, TimeSpan setDuration, string setEpisodeSummary)
        {
            this.show = getShow;
            this.AddGuest(guest);
            this.Title = new EpisodeTitle(setTitle);
            this.Duration = new EpisodeDuration(setDuration);
            this.Episode = show.Episodes.Value;
            this.Summary = new EpisodeSummary(setEpisodeSummary);
        }

        // For an episode with multiple guests.
        public PodcastEpisode(Podcast getShow, Person[] guest, string setTitle, TimeSpan setDuration, string setEpisodeSummary)
        {
            this.show = getShow;
            this.AddGuest(guest);
            this.Title = new EpisodeTitle(setTitle);
            this.Duration = new EpisodeDuration(setDuration);
            this.Episode = show.Episodes.Value;
            this.Summary = new EpisodeSummary(setEpisodeSummary);
        }
    }
}
