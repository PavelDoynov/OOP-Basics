using System;

public class InvalidSongLengthException : InvalidSongException
{
    private const string INVALID_SONG_LENGTH_EXCEPTION = "Invalid song length.";

    public InvalidSongLengthException():base(INVALID_SONG_LENGTH_EXCEPTION)
    {
        
    }

    public InvalidSongLengthException(string message):base(message)
    {
        
    }
}