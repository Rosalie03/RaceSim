using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Competition
    {
        public List<IParticipant> Participants { get; set; }

        public Queue<Track> Tracks {get; set;}

        public Competition()
        {
            Tracks = new Queue<Track>();
            Participants = new List<IParticipant>();
        }


        #region methods
        public Track NextTrack()
        {
            if(Tracks.TryDequeue(out Track result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
