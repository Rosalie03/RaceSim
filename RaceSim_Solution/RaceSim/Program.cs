// See https://aka.ms/new-console-template for more information
using Model;
using Controller;

internal class Program
{
    private static void Main(string[] args)
    {
        Data.Initialize();
        Data.NextRace();

        Console.WriteLine(Data.CurrentRace.track.Name);
        Data.NextRace();
        Console.WriteLine(Data.CurrentRace.track.Name);
        Data.NextRace();
        Console.WriteLine(Data.CurrentRace.track.Name);


        for (; ; )
        {
            Thread.Sleep(500);
        }
    }
}