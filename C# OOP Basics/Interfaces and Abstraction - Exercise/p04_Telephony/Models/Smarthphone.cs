using System;
using System.Linq;

public class Smarthphone : ICallable, IBrowsable
{
    private string phoneNumber;
    private string browseUrl;

    public string PhoneNumber
    {
        get { return phoneNumber; }
        set
        {
            if (value.Any(x => !char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid number!");
            }

            phoneNumber = value;
        }
    }

    public string BrowseUrl
    {
        get { return browseUrl; }
        set
        {
            if (value.Any(char.IsDigit))
            {
                throw new ArgumentException("Invalid URL!");
            }

            browseUrl = value;
        }
    }

    public string Call()
    {
        return $"Calling... {PhoneNumber}";
    }

    public string Browse()
    {
        return $"Browsing: {BrowseUrl}!";
    }
}