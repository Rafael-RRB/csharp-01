using System;
using ScreenSound.Music;
using ScreenSound.Enums.Language;
using ScreenSound.Podcast;
using ScreenSound.RandomTimeSpan;

class Program
{
    static void Main(string[] args)
    {
        // Queen Band
        Entity entity1 = new Entity("Queen", EntityStatus.Band);

        // Queen albums and songs
        Album album1 = new Album("A Night at the Opera", entity1);
        entity1.AddAlbum(album1);
        Song song1 = new Song("Death on Two Legs", new TimeSpan(0, 0, 223), Availability.Available, entity1);
        album1.AddSong(song1);
        Song song2 = new Song("Lazing on a Sunday Afternoon", new TimeSpan(0, 0, 67), Availability.Available, entity1);
        album1.AddSong(song2);
        Song song3 = new Song("I'm In Love With My Car", new TimeSpan(0, 0, 185), Availability.Available, entity1);
        album1.AddSong(song3);
        Song song4 = new Song("You're My Best Friend", new TimeSpan(0, 0, 172), Availability.Available, entity1);
        album1.AddSong(song4);
        Song song5 = new Song("Bohemian Rhapsody", new TimeSpan(0, 0, 354), Availability.Available, entity1);
        album1.AddSong(song5);

        Album album2 = new Album("The Game", entity1);
        entity1.AddAlbum(album2);
        Song song6 = new Song("Play the Game", new TimeSpan(0, 0, 211), Availability.Available, entity1);
        album2.AddSong(song6);
        Song song7 = new Song("Dragon Attack", new TimeSpan(0, 0, 258), Availability.Available, entity1);
        album2.AddSong(song7);
        Song song8 = new Song("Another One Bites the Dust", new TimeSpan(0, 0, 215), Availability.Available, entity1);
        album2.AddSong(song8);
        Song song9 = new Song("Need Your Loving Tonight", new TimeSpan(0, 0, 170), Availability.Available, entity1);
        album2.AddSong(song9);
        Song song10 = new Song("Crazy Little Thing Called Love", new TimeSpan(0, 0, 163), Availability.Available, entity1);
        album2.AddSong(song10);

        // Song Tests
        album1.PrintFullAlbumInfo(Language.English);
        Console.WriteLine();
        album2.PrintFullAlbumInfo(Language.English);
        Console.WriteLine();
        entity1.PrintDiscography(Language.English);
        Console.WriteLine();

        // Joe Rogan Podcast
        PodcastHost podcastHost1 = new PodcastHost("Joe Rogan", PersonStatus.PersonMale, "Joe Rogan is a comedian, UFC commentator, and podcast host.");
        PodcastGuest podcastGuest1 = new PodcastGuest("Elon Musk", PersonStatus.PersonMale, "Elon Musk is the CEO of SpaceX and Tesla.");
        
        Podcast podcast1 = new Podcast(podcastHost1, "The Joe Rogan Experience");
        podcastHost1.AddPodcast(podcast1);
        
        PodcastEpisode episode1 = new PodcastEpisode(podcast1, podcastGuest1, "Elon Musk on SpaceX and Tesla", RandomTimeSpan.Generate(), "Episode 1: Elon Musk discusses SpaceX and Tesla.");
        podcast1.AddEpisode(episode1);
        PodcastEpisode episode2 = new PodcastEpisode(podcast1, podcastGuest1, "The Future of AI", RandomTimeSpan.Generate(), "Episode 2: A deep dive into the future of artificial intelligence.");
        podcast1.AddEpisode(episode2);
        PodcastEpisode episode3 = new PodcastEpisode(podcast1, podcastGuest1, "Mars Colonization", RandomTimeSpan.Generate(), "Episode 3: Discussing the challenges and opportunities of colonizing Mars.");
        podcast1.AddEpisode(episode3);
        PodcastEpisode episode4 = new PodcastEpisode(podcast1, podcastGuest1, "Sustainable Energy", RandomTimeSpan.Generate(), "Episode 4: Exploring sustainable energy solutions for the future.");
        podcast1.AddEpisode(episode4);
        PodcastEpisode episode5 = new PodcastEpisode(podcast1, podcastGuest1, "Neuralink and Brain-Machine Interfaces", RandomTimeSpan.Generate(), "Episode 5: An overview of Neuralink and the potential of brain-machine interfaces.");
        podcast1.AddEpisode(episode5);

        // Podcast Tests
        podcastHost1.PrintHostPodcastsInfo(Language.English);
        Console.ReadLine();
    }
}

