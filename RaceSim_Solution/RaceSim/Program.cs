// See https://aka.ms/new-console-template for more information
using Model;
using Controller;
using RaceSim;

internal class Program
{
    private static void Main(string[] args)
    {
        Track t = new Track("t", new[]
{
                Section.SectionTypes.Startgrid,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Rightcorner,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Lefcorner,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Finish,
            });

        Track t2 = new Track("t", new[]
{
                Section.SectionTypes.Startgrid,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Rightcorner,              
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Rightcorner,                
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,               
                Section.SectionTypes.Rightcorner,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Rightcorner,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Finish,
            });
        Track t3 = new Track("t", new[]
{
                Section.SectionTypes.Startgrid,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Rightcorner,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Lefcorner,
                Section.SectionTypes.Straight,              
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Lefcorner,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Rightcorner,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Rightcorner,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Rightcorner,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Finish,
            });

        Console.BackgroundColor = ConsoleColor.Blue;
        Data.Initialize();
        Visuals.Initialize();

        //Visuals.DrawTrack(t);
        Visuals.DrawTrack(t);

        



 //       Data.Initialize();
 /*       Data.NextRace();*/


/*        Console.WriteLine(Data.CurrentRace.track.Name);
        Data.NextRace();
        Console.WriteLine(Data.CurrentRace.track.Name);
        Data.NextRace();
        Console.WriteLine(Data.CurrentRace.track.Name);*/



        for (; ; )
        {
            Thread.Sleep(500);
        }
    }
}