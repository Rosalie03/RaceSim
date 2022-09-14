using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Track
    {
        string Name;
        LinkedList<Section> Sections;

        #region constructors
        public Track (string name, Section.SectionTypes[] sections)
        {
            this.Name = name;
            this.Sections = new LinkedList<Section>();
        }

        public Track()
        {

        }
        #endregion


    }
}
