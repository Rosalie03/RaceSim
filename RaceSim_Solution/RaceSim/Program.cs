// See https://aka.ms/new-console-template for more information
using Model;
using Controller;
using RaceSim;

internal class Program
{    
    private static void Main(string[] args)
    {


        Console.BackgroundColor = ConsoleColor.Blue;
        Data.Initialize();
        Visuals.Initialize();

        //Visuals.DrawTrack(Data.Competition.NextTrack());
        //Data.NextRace();       
        //Visuals.DrawTrack(Data.Competition.NextTrack());
        //Data.NextRace();
        //Visuals.DrawTrack(Data.Competition.NextTrack());
        //Data.NextRace();
        //Visuals.DrawTrack(Data.Competition.NextTrack());
       // Data.NextRace();
        Data.NextRace();
        //Visuals.DrawTrack(Data.CurrentRace);
        Visuals.DrawTrack(Data.Competition.NextTrack());

        for (; ; )
        {
            Thread.Sleep(500);
        }
    }
}