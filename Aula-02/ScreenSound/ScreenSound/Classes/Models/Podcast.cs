using ScreenSound.DataObjects.Name;
using ScreenSound.Enums.Language;
using ScreenSound.Translations.PodcastTranslation;

namespace ScreenSound.Podcast
{
    public class Podcast
    {
        PodcastHost host;
        public PodcastName Name { get; private set; } = PodcastName.Empty;
        public EpisodeNumber Episodes { get; private set; } = new EpisodeNumber(1);
        public List<PodcastEpisode> episodes { get; private set; } = new List<PodcastEpisode>();

        public void AddEpisode(PodcastEpisode episode)
        {
            episodes.Add(episode);
            Episodes = new EpisodeNumber(Episodes.Value + 1);
        }

        public void RemoveEpisode(PodcastEpisode episode)
        {
            episodes.Remove(episode);
            // Note: We do not decrease the episode number, as episode numbers are unique identifiers.
        }

        public string GetPodcastInfo(Language language)
        {
            // Aim: "Podcast: Name, Host: Host.Name, Total Episodes: Episodes"
            Tuple<Language, string> podcastKey = new Tuple<Language, string>(language, "Podcast");
            string podcastString = PodcastTranslation.translations[podcastKey];
            Tuple<Language, string> totalEpisodesKey = new Tuple<Language, string>(language, "TotalEpisodes");
            string totalEpisodesString = PodcastTranslation.translations[totalEpisodesKey];
            Tuple<Language, string> podcastInfoKey = new Tuple<Language, string>(language, "PodcastInfo");
            string podcastInfoString = PodcastTranslation.translations[podcastInfoKey];

            return string.Format(podcastInfoString, podcastString, Name.Value, totalEpisodesString, episodes.Count);            
        }

        public string GetFullPodcastInfo(Language language)
        {
            Tuple<Language, string> podcastKey = new Tuple<Language, string>(language, "Podcast");
            string podcastString = PodcastTranslation.translations[podcastKey];
            Tuple<Language, PersonStatus> hostKey = new Tuple<Language, PersonStatus>(language, host.Gender);
            string hostString = PodcastTranslation.hostTranslations[hostKey];
            Tuple<Language, string> totalEpisodesKey = new Tuple<Language, string>(language, "TotalEpisodes");
            string totalEpisodesString = PodcastTranslation.translations[totalEpisodesKey];
            Tuple<Language, string> podcastInfoKey = new Tuple<Language, string>(language, "PodcastFullInfo");
            string podcastInfoString = PodcastTranslation.translations[podcastInfoKey];

            return string.Format(podcastInfoString, podcastString, Name.Value, hostString, host.Name.Value, totalEpisodesString, episodes.Count);
        }

        public void PrintFullPodcastInfo(Language language)
        {
            Console.WriteLine(GetFullPodcastInfo(language));
        }

        public void PrintPodcastInfo(Language language)
        {
            Console.WriteLine(GetPodcastInfo(language));
        }

        public Podcast(PodcastHost getHost, string setName)
        {
            host = getHost;
            Name = new PodcastName(setName);
        }
    }
}
