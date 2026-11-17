using ScreenSound.Enums.Language;

namespace ScreenSound.Podcast
{
    public class PodcastHost : Person
    {
        public List<Podcast> Podcasts { get; private set; } = new List<Podcast>();

        public void AddPodcast(Podcast podcast)
        {
            Podcasts.Add(podcast);
        }

        public void AddPodcast(Podcast[] podcasts)
        {
            foreach (Podcast podcast in podcasts)
            {
                Podcasts.Add(podcast);
            }
        }

        public void AddPodcast(List<Podcast> podcasts)
        {
            foreach (Podcast podcast in podcasts)
            {
                Podcasts.Add(podcast);
            }
        }

        public void RemovePodcast(Podcast podcast)
        {
            Podcasts.Remove(podcast);
        }

        public List<string> GetHostPodcastsInfo(Language language)
        {            
            List<string> podcastInfo = new List<string>();
            foreach (string line in this.GetPersonFullInfo(language))
            {
                podcastInfo.Add(line);
            }

            foreach (Podcast podcast in Podcasts)
            {
                podcastInfo.Add(" - " + podcast.GetPodcastInfo(language));
                foreach (PodcastEpisode episode in podcast.episodes)
                {
                    podcastInfo.Add("  *  " + episode.GetEpisodeInfo(language));
                }
            }

            return podcastInfo;
        }

        public void PrintHostPodcastsInfo(Language language)
        {
            foreach (string line in GetHostPodcastsInfo(language))
            {
                Console.WriteLine(line);
            }
        }

        public PodcastHost(string setName, PersonStatus setGender, string setBiography) : base(setName, setGender, setBiography) {}

        public PodcastHost(string setName, PersonStatus setGender, string setBiography, Podcast podcast) : base(setName, setGender, setBiography)
        {
            AddPodcast(podcast);
        }

        public PodcastHost(string setName, PersonStatus setGender, string setBiography, Podcast[] podcasts) : base(setName, setGender, setBiography)
        {
            AddPodcast(podcasts);
        }

        public PodcastHost(string setName, PersonStatus setGender, string setBiography, List<Podcast> podcasts) : base(setName, setGender, setBiography)
        {
            AddPodcast(podcasts);
        }
    }
}
