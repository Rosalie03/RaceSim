using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Competition
    {
        public List<IParticipant> Participants;
        
        public Queue<Track> Tracks;

        

        #region Constructor
        public Track NextTrack()
        {
           return Tracks.Dequeue();
        }
        #endregion
    }
}
