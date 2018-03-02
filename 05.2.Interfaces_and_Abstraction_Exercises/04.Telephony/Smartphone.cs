using System;
using System.Linq;

public class Smartphone : ICallable, IBrowsable
{

    public string Browsing(string url)
    {
        Validation.ValidateURL(url);
        return $"Browsing: {url}!";
    }

    public string Calling(string telephoneNumber)
    {
        Validation.ValidatePhoneNumber(telephoneNumber);
        return $"Calling... {telephoneNumber}";
    }
}