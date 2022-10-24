using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using static Model.Section;


namespace Controller
{
    public class Race
    {
       public Track track { get; set; }
       public List<IParticipant> participants { get; set; }
        public DateTime Startime { get; set; }

        private Random _random { get; set; }
        

        private Dictionary<Section, SectionData> _positions;

        private System.Timers.Timer _timer;

        public event EventHandler<DriversChangedEventArgs> DriversChanged;
      

        #region Constructors
        public Race(Track track, List<IParticipant> participant)
        {
            this.participants = participant;
            this.track = track;
            _random = new Random(DateTime.Now.Millisecond);
            Startime = DateTime.Now;
            _positions = new Dictionary<Section, SectionData>();

            _timer = new System.Timers.Timer(500);
            _timer.Elapsed += OnTimedEvent;

            SetDriverStartPosition(track, participants);
            Start();
        }
        #endregion

        #region methodes
        public void OnTimedEvent(object obj, EventArgs ea)
        {
            DriversChanged?.Invoke(this, new DriversChangedEventArgs(track));
        }

        public void Start()
        {
            _timer.Start();
            Startime = DateTime.Now;
        }


        public void SetDriverStartPosition(Track track, List<IParticipant> participants)
        {         
            Stack<IParticipant> Sparticipants = new Stack<IParticipant>(participants);

            foreach (Section s in track.Sections)
            {
                if (s.SectionType == Section.SectionTypes.Startgrid)
                {
                    SectionData sd = GetSectionData(s);

                    if(Sparticipants.Count == 0)                    
                        return;
                        sd!.Left = Sparticipants.Pop();

                    if (Sparticipants.Count == 0)
                        return;                  
                        sd.Right = Sparticipants.Pop();                    
                }
            }
        }
        

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
