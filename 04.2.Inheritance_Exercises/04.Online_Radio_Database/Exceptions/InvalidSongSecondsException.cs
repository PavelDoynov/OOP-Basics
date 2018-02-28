using System;

public class InvalidSongSecondsException : InvalidSongLengthException
{
    private const string INVALID_SONG_SECONDS_EXCEPTION = "Song seconds should be between 0 and 59.";

    public InvalidSongSecondsException():base(INVALID_SONG_SECONDS_EXCEPTION)
    {
        
    }

    public InvalidSongSecondsException(string message):base(message)
    {
        
    }
}