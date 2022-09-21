using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class Race
    {
       public Track track { get; set; }
       public List<IParticipant> participants { get; set; }
        public DateTime Startime { get; set; }

        private Random _random { get; set; }
        

        private Dictionary<Section, SectionData> _positions;

        #region Constructors
        public Race(Track track, List<IParticipant> participant)
        {
            this.participants = participant;
            this.track = track;
            _random = new Random(DateTime.Now.Millisecond);
            Startime = DateTime.Now;
            _positions = new Dictionary<Section, SectionData>();
        }
        #endregion

        #region methodes

        public SectionData GetSectionData(Section section)
        {
            if (!_positions.ContainsKey(section))
            {
                _positions.Add(section, new SectionData());
            }
            return _positions[section];
        }

        public void RandomizeEquipment()
        {
            foreach(IParticipant driver in participants)
            {
                driver.equiqement.Quility = _random.Next(0,25);
                driver.equiqement.Performance = _random.Next(0,25);
            }
        
        }

        #endregion
    }
}
