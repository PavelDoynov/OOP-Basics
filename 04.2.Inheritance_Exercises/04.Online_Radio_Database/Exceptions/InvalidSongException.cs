using System;

public class InvalidSongException : Exception
{
    private const string INVALID_SONG_EXCEPTION = "Invalid song.";

    public InvalidSongException():base(INVALID_SONG_EXCEPTION)
    {
        
    }

    public InvalidSongException(string message):base(message)
    {
        
    }
}