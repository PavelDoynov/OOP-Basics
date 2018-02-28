using System;
using System.Linq;

public class Validation
{
    private const int MIN_NAME_LENGTH = 3;
    private const int MAX_ARTIST_NAME_LENGTH = 20;
    private const int MAX_SONG_NAME_LENGTH = 30;
    private const int MIN_LENGTH = 0;
    private const int MAX_MINUTES_LENGTH = 14;
    private const int MAX_SECONDS_LENGTH = 59;

    public static void ValidateSong (string[] songArgs)
    {
        if (songArgs.Length != 3)
        {
            throw new InvalidSongException();
        }
    }

    public static void ValidateArtistName(string name)
    {
        if (name.Length < MIN_NAME_LENGTH || name.Length > MAX_ARTIST_NAME_LENGTH || string.IsNullOrWhiteSpace(name))
        {
            throw new InvalidArtistNameException();
        }
    }

    public static void ValidateSongName(string songName)
    {
        if (songName.Length < MIN_NAME_LENGTH || songName.Length > MAX_SONG_NAME_LENGTH || string.IsNullOrWhiteSpace(songName))
        {
            throw new InvalidSongNameException();
        }
    }

    public static void ValidateSongLength(int[] songLength)
    {
        if (songLength.Length != 2 || songLength[0] < MIN_LENGTH || songLength[1] < MIN_LENGTH)
        {
            throw new InvalidSongLengthException();
        }
    }

    public static void ValidateMinutesLength(int minutesLength)
    {
        if (minutesLength > MAX_MINUTES_LENGTH)
        {
            throw new InvalidSongMinutesException();
        }
    }

    public static void ValidateSecondsLength(int secondLength)
    {
        if (secondLength > MAX_SECONDS_LENGTH)
        {
            throw new InvalidSongSecondsException();
        }
    }
}
