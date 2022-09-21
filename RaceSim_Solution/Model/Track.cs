using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model
{
    public class Track
    {
        public string Name { get; set; }          
        public LinkedList<Section> Sections { get; set; }

        #region constructors
        public Track(string name, Section.SectionTypes[] sections)
        {
            Name = name;
            LinkedList<Section> sectionList = new LinkedList<Section>();

            for (int i = 0; i < sections.Length; i++)
            {
                Section section = new Section(sections[i]);
                sectionList.AddLast(section);
            }
        }

    }


    }
#endregion

