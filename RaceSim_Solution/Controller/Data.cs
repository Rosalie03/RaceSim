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
           Data.NextRace();           
        }
        public static void AddParticipent()
        {
            Competition.Participants.Add(new Driver("Abigail", new Car(10, 10, 10, false), IParticipant.TeamColors.blue));
            Competition.Participants.Add(new Driver("Bernard", new Car(10, 10, 10, false), IParticipant.TeamColors.red));
            //Competition.Participants.Add(new Driver("C", 0, new Car(10, 10, 10, false), IParticipant.TeamColors.green));
        }

        public static void AddTrack()
        {

            Track t = new Track("t1", new[]
{
                Section.SectionTypes.Startgrid,

            });

            Competition.Tracks.Enqueue(t);

            Track t1 = new Track("t1", new[]
{
                Section.SectionTypes.Startgrid,
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

            Competition.Tracks.Enqueue(t1);

            Track t2 = new Track("t2", new[]

{

            Section.SectionTypes.Straight,
              Section.SectionTypes.Straight,
              Section.SectionTypes.Straight,
             Section.SectionTypes.Straight,
              Section.SectionTypes.Rightcorner,
              Section.SectionTypes.Straight,
              Section.SectionTypes.Straight,
              Section.SectionTypes.Straight,
              Section.SectionTypes.Lefcorner,
              Section.SectionTypes.Straight,
              Section.SectionTypes.Straight,
              Section.SectionTypes.Rightcorner,
              Section.SectionTypes.Straight,
              Section.SectionTypes.Rightcorner,
              Section.SectionTypes.Straight,
              Section.SectionTypes.Finish,
              Section.SectionTypes.Startgrid,
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

            });
            Competition.Tracks.Enqueue(t2);

        }

        public static void NextRace()
        {
            
            Track r = Competition.NextTrack();
            if (r != null)
            {
                CurrentRace = new Race(r, Competition.Participants);
            }
            else
            {
                CurrentRace = null;
            }           
        }

        #endregion
    }
}
