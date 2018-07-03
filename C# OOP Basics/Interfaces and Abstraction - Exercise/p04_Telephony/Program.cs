using System;
using System.Linq;
using System.Reflection.Metadata;

public class Program
{
    public static void Main()
    {
        var phones = Console.ReadLine().Split().ToArray();
        var browseUrls = Console.ReadLine().Split().ToArray();

        foreach (var phone in phones)
        {
            try
            {
                var smartphone = new Smarthphone
                {
                    PhoneNumber = phone
                };
                Console.WriteLine(smartphone.Call());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        foreach (var url in browseUrls)
        {
            try
            {
                var smartphone = new Smarthphone
                {
                    BrowseUrl = url
                };

                Console.WriteLine(smartphone.Browse());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}