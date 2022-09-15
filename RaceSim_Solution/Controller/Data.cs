using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Model;


namespace Controller
{
    public static class Data
    {
        static Competition? Competition;

        #region Methods
        public static void Initialize() 
        {
           Competition = new Competition();
           AddTrack();
           AddParticipent();
        }
        public static void AddParticipent()
        {
            Competition.Participants.Add(new Driver("A", 0, new Car(10, 10, 10, false), IParticipant.TeamColors.blue));
            Competition.Participants.Add(new Driver("B", 0, new Car(10, 10, 10, false), IParticipant.TeamColors.red));
            Competition.Participants.Add(new Driver("C", 0, new Car(10, 10, 10, false), IParticipant.TeamColors.green));
        }

        public static void AddTrack()
        {
            Competition.Tracks.Enqueue(new Track());
            Competition.Tracks.Enqueue(new Track());
            Competition.Tracks.Enqueue(new Track());
        }
        #endregion
    }
}
