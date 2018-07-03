using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static List<Song> songs = new List<Song>();

    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        for (var i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(new[] {";", ":"}, StringSplitOptions.RemoveEmptyEntries).ToArray();

            try
            {
                if (input.Length < 3)
                {
                    throw new InvalidSongException();
                }

                var artistName = input[0];
                var songName = input[1];
                if (!int.TryParse(input[2], out var minutes))
                {
                    throw new InvalidSongLengthException();
                }

                if (!int.TryParse(input[3], out var seconds))
                {
                    throw new InvalidSongLengthException();
                }

                songs.Add(new Song(artistName, songName, minutes, seconds));
                Console.WriteLine("Song added.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var songsCount = songs.Count;
        var totalSeconds = songs.Sum(x => x.Minutes * 60) + songs.Sum(x => x.Seconds);
        var finalHours = totalSeconds / 3600;
        var finalMinutes = totalSeconds % 3600 / 60;
        var finalSeconds = totalSeconds % 3600 % 60;

        Console.WriteLine($"Songs added: {songsCount}");
        Console.WriteLine($"Playlist length: {finalHours}h {finalMinutes}m {finalSeconds}s");
    }
}