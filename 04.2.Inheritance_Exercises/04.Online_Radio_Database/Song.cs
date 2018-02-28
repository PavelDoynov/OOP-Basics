using System;
using System.Linq;

public class Song
{
    string artist;
    string song;
    int minutesLength;
    int secondLength;

    public Song(string[] inputArgs)
    {
        ValidateSongMethod(inputArgs);

        Artist = inputArgs[0];
        SongName = inputArgs[1];

        IsNumbersMethods(inputArgs[2]);

        int[] songArgs = inputArgs[2].Split(':', StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToArray();

        ValidateSongLengthMethod(songArgs);

        MinutesLength = songArgs[0];
        SecondsLength = songArgs[1];
    }

    internal string Artist
    {
        get { return artist; }
        private set
        {
            Validation.ValidateArtistName(value);
            artist = value;
        }
    }

    internal string SongName
    {
        get { return song; }
        private set
        {
            Validation.ValidateSongName(value);
            song = value;
        }
    }

    internal int MinutesLength
    {
        get { return minutesLength; }
        private set
        {
            Validation.ValidateMinutesLength(value);
            minutesLength = value;
        }
    }

    internal int SecondsLength
    {
        get { return secondLength; }
        private set
        {
            Validation.ValidateSecondsLength(value);
            secondLength = value;
        }
    }

    private void ValidateSongMethod(string[] inputArgs)
    {
        Validation.ValidateSong(inputArgs);
    }

    private void ValidateSongLengthMethod(int[] songArgs)
    {
        Validation.ValidateSongLength(songArgs);
    }

    private void IsNumbersMethods(string v)
    {
        string[] songsArgsArr = v.Split(':', StringSplitOptions.RemoveEmptyEntries);
        int minutes;
        int seconds;

        bool isMinute = int.TryParse(songsArgsArr[0], out minutes);
        bool isSeconds = int.TryParse(songsArgsArr[1], out seconds);

        if (!isMinute || !isSeconds)
        {
            throw new InvalidSongLengthException();
        }
    }
}