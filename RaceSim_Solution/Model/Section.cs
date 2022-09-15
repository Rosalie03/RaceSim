using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Section
    {
        #region Props

        public SectionTypes SectionType { get; set; }
       
        public static int SectionLength { get; set; }
        #endregion

        public enum SectionTypes
        {
            Straight,
            Lefcorner,
            Rightcorner,
            Startgrid,
            Finish
        }

        public Section(SectionTypes sectionType)
        {
            SectionType = sectionType;
            SectionLength = 20;
        }

    }
}
