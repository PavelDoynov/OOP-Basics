/*
 * 04. Online Radio Database
 * 
 * Create an online radio station database. It should keep information about all added songs. On the first line you are 
 * going to get the number of songs you are going to try to add. On the next lines you will get the songs to be added in
 * the format <artist name>;<song name>;<minutes:seconds>. To be valid, every song should have an artist name, a song name 
 * and length. 
 * 
 * Design a custom exception hierarchy for invalid songs: 
 * •   InvalidSongException
 *   o   InvalidArtistNameException
 *   o   InvalidSongNameException
 *   o   InvalidSongLengthException
 *     •   InvalidSongMinutesException
 *     •   InvalidSongSecondsException
 * 
 * Validation
 * •   Artist name should be between 3 and 20 symbols. 
 * •   Song name should be between 3 and 30 symbols. 
 * •   Song length should be between 0 second and 14 minutes and 59 seconds.
 * •   Song minutes should be between 0 and 14.
 * •   Song seconds should be between 0 and 59.
 * 
 * Exception Messages
 * Exception:                          Message:
 * InvalidSongException                "Invalid song."
 * InvalidArtistNameException          "Artist name should be between 3 and 20 symbols."
 * InvalidSongNameException            "Song name should be between 3 and 30 symbols."
 * InvalidSongLengthException          "Invalid song length."
 * InvalidSongMinutesException         "Song minutes should be between 0 and 14."
 * InvalidSongSecondsException         "Song seconds should be between 0 and 59."
 * 
 * Note: Check validity in the order artist name -> song name -> song length
 * 
 * Output
 * If the song is added, print "Song added.". If you can’t add a song, print an appropriate exception message. 
 * On the last two lines print the number of songs added and the total length of the playlist in format 
 * {Playlist length: 0h 7m 47s}.
 * 
 * Example
 * Input:                                      Output:
 * 3                                           Song added.
 * ABBA;Mamma Mia;3:35                         Song seconds should be between 0 and 59.
 * Nasko Mentata;Shopskata salata;4:123        Song added.
 * Nasko Mentata;Shopskata salata;4:12         Songs added: 2
 *                                             Playlist length: 0h 7m 47s
 * 
 * Input:                                      Output:
 * 5                                           Song added.
 * Nasko Mentata;Shopskata salata;14:59        Song added.
 * Nasko Mentata;Shopskata salata;14:59        Song added.
 * Nasko Mentata;Shopskata salata;14:59        Song added.
 * Nasko Mentata;Shopskata salata;14:59        Song added.
 * Nasko Mentata;Shopskata salata;0:5          Songs added: 5
 *                                             Playlist length: 1h 0m 1s
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Queue<Song> songs = GetSongs();
        Console.WriteLine($"Songs added: {songs.Count}");
        PlaylistLength(songs);
    }

    private static void PlaylistLength(Queue<Song> songs)
    {
        int allMinutes = 0;
        int allSecond = 0;

        while (songs.Count != 0)
        {
            Song currentSong = songs.Dequeue();

            allMinutes += currentSong.MinutesLength;
            allSecond += currentSong.SecondsLength;
        }

        int resultSecond = allSecond % 60;
        allMinutes += allSecond / 60;
        int resultMinutes = allMinutes % 60;
        int resultHours = allMinutes / 60;

        Console.WriteLine($"Playlist length: {resultHours}h {resultMinutes}m {resultSecond}s");
    }

    private static Queue<Song> GetSongs()
    {
        Queue<Song> songs = new Queue<Song>();

        int numberOfInputLines = int.Parse(Console.ReadLine());
        while (numberOfInputLines != 0)
        {
            try
            {
                string[] songArgs = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

                songs.Enqueue(new Song(songArgs));
                Console.WriteLine("Song added.");
            }
            catch (Exception exArgs)
            {
                Console.WriteLine(exArgs.Message);
            }
            numberOfInputLines--;
        }

        return songs;
    }
}