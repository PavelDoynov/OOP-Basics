using System;

public class InvalidSongNameException : InvalidSongException
{
    private const string INVALID_SONG_NAME_EXCEPTION = "Song name should be between 3 and 30 symbols.";

    public InvalidSongNameException():base(INVALID_SONG_NAME_EXCEPTION)
    {
        
    }

    public InvalidSongNameException(string message):base(message)
    {
        
    }
}