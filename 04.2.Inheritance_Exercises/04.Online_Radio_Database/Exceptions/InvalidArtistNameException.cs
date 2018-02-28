using System;

public class InvalidArtistNameException : InvalidSongException
{
    private const string INVALID_ARTIST_NAME_EXCEPTION = "Artist name should be between 3 and 20 symbols.";

    public InvalidArtistNameException():base(INVALID_ARTIST_NAME_EXCEPTION)
    {
        
    }

    public InvalidArtistNameException(string message):base(message)
    {
        
    }
}