using System;

public class InvalidSongMinutesException : InvalidSongLengthException
{
    private const string INVALID_SONG_MINUTES_EXCEPTION = "Song minutes should be between 0 and 14.";

    public InvalidSongMinutesException():base(INVALID_SONG_MINUTES_EXCEPTION)
    {
        
    }

    public InvalidSongMinutesException(string message):base(message)
    {
        
    }
}