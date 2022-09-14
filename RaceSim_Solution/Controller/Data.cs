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
        // Competition.Participants.Add(driver);
        //Competition.Participants.Add((IParticipant)driver);
        public static void AddParticipent()
        {
            Driver driver = new Driver();
            Competition.Participants.Add((IParticipant)driver);
        }

        public static void AddTrack()
        {
            Track track = new Track();
            Competition.Tracks.Enqueue(track);
        }
        #endregion

    }
}
