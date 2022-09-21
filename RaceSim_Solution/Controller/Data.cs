using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Model;
using Controller;


namespace Controller
{
    public static class Data
    {
        public static Competition Competition;

        public static Race CurrentRace;

        #region Methods
        public static void Initialize() 
        {
           Competition = new Competition();
          
           AddParticipent(); 
           AddTrack();
        }
        public static void AddParticipent()
        {
            Competition.Participants.Add(new Driver("A", 0, new Car(10, 10, 10, false), IParticipant.TeamColors.blue));
            Competition.Participants.Add(new Driver("B", 0, new Car(10, 10, 10, false), IParticipant.TeamColors.red));
            Competition.Participants.Add(new Driver("C", 0, new Car(10, 10, 10, false), IParticipant.TeamColors.green));
        }



        public static void AddTrack()
        {
            Section.SectionTypes[]? R1 =
 {
                Section.SectionTypes.Startgrid,
                Section.SectionTypes.Lefcorner,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Rightcorner,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Finish,

            };

            Competition.Tracks.Enqueue(new Track("r1", R1));

            Section.SectionTypes[]? R2 =
{
                Section.SectionTypes.Startgrid,
                Section.SectionTypes.Lefcorner,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Rightcorner,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Finish,

            };

            Competition.Tracks.Enqueue(new Track("r2", R2));

            Section.SectionTypes[]? R3 =
{
                Section.SectionTypes.Startgrid,
                Section.SectionTypes.Lefcorner,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Rightcorner,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Finish,

            };

            Competition.Tracks.Enqueue(new Track("r3", R3));

        }

        public static void NextRace()
        {
            Track r = Competition.NextTrack();
            if (r != null)
            {
                CurrentRace = new Race(r, Competition.Participants);
            }
            else return;
        }

        #endregion
    }
}
