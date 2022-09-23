using Model;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerTest
{
    [TestFixture]

    internal class Model_Competition_NextTrackShould
    {
        private Competition _competition;

        #region Methods

        [SetUp]
        public void SetUp()
        {
            _competition = new Competition();
        }

        [Test]
        public void NextTrack_EmptyQueue_ReturnNull()
        {
            Track result = _competition.NextTrack();
            Assert.IsNull(result);
        }

        public void NextTrack_OneInQueue_ReturnTrack()
        {
            Track tr = new Track("R4", new[]
            {
                Section.SectionTypes.Startgrid,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Rightcorner, 
                Section.SectionTypes.Finish,
            });

            _competition.Tracks.Enqueue(tr);
            Track result = _competition.NextTrack();
            Assert.AreEqual(tr, result);
        }

        public void NextTrack_OneInQueue_RemoveTrackFromQueue()
        {
            Track tr2 = new Track("R5", new[]
            {
                Section.SectionTypes.Startgrid,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Finish,

            });

            _competition.Tracks.Enqueue(tr2);

            Track result2 = _competition.NextTrack();   
            result2 = _competition.NextTrack();  
            
            Assert.IsNull(result2);
        }

        public void NextTrack_TwoInQueue_ReturnNextTrack()
        {
            Track tr3 = new Track("R6", new[]
            {
                Section.SectionTypes.Startgrid,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Lefcorner,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Finish,

            });

        _competition.Tracks.Enqueue(tr3);

            Track tr4 = new Track("R7", new[]
{
                Section.SectionTypes.Startgrid,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Rightcorner,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Straight,
                Section.SectionTypes.Finish,

            });

            _competition.Tracks.Enqueue(tr4);

            _competition.NextTrack();

            Track result = _competition.NextTrack();

            Assert.AreEqual(tr4, result);
            
        }
        #endregion
    }
}




   



