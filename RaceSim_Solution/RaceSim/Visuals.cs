using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static RaceSim.Visuals;

namespace RaceSim
{
    public static class Visuals
    {
        public static Directions Direction;


        public static int x = 30;
        public static int y = 0;


        public static SectionData sd;


        public static void Initialize()
        {
            Console.CursorVisible = false;
            Direction = Directions.East;
            Data.CurrentRace.DriversChanged += DriversChangedHandler;

        }
        #region Graphics


        private static string[] _finishHorizontal = {         "════",
                                                              "  # ",
                                                              "  # ",
                                                              "════" };

        private static string[] _startHorizontal = {         "════",
                                                             "  * ",
                                                             "  * ",
                                                             "════" };

        private static string[] _finishVertical = {         "║  ║",
                                                            "║##║",
                                                            "║##║",
                                                            "║  ║" };

        private static string[] _startVertical = {         "║  ║",
                                                           "║**║",
                                                           "║**║",
                                                           "║  ║" };

        private static string[] _straightHorizontal = {         "════",
                                                                "  1 ",
                                                                "  2 ",
                                                                "════" };

        private static string[] _straightVertical = {         "║  ║",
                                                              "║ 1║",
                                                              "║2 ║",
                                                              "║  ║" };


        private static string[] _corner1 = {         "═══╗",
                                                     "   ║",
                                                     "1  ║",
                                                     "╗2 ║" };

        private static string[] _corner2 = {         "║ 1╚",
                                                     "║  2",
                                                     "║   ",
                                                     "╚═══" };

        private static string[] _corner3 = {         "╔═══",
                                                     "║   ",
                                                     "║  1",
                                                     "║ 2╔" };

        private static string[] _corner4 = {         "╝1 ║",
                                                     "2  ║",
                                                     "   ║",
                                                     "═══╝" };

        #endregion

        public enum Directions
        {
            North,
            East,
            South,
            West
        }

        #region Methods


        public static void DrawTrack(Track track)
        {
            Race race = Data.CurrentRace;
            Track track1 = race.track;           
            var inQueue = track1.Sections.First;
            if (inQueue != null) { 

                sd = race.GetSectionData(inQueue.Value);
               
                foreach (Section section in track.Sections)
                {
                    switch (section.SectionType)
                    {
                        case Section.SectionTypes.Startgrid:
                            if (Direction == Directions.West || Direction == Directions.East)
                            {
                                ConsoleWriteSectionV(_startHorizontal, section, sd);
                            }
                            else
                                ConsoleWriteSectionV(_startVertical, section,sd);
                            break;

                        case Section.SectionTypes.Straight:
                            if (Direction == Directions.West || Direction == Directions.East)
                            {
                                ConsoleWriteSectionV(_straightHorizontal, section, sd);
                            }
                            else
                                ConsoleWriteSectionV(_straightVertical, section, sd);
                            break;

                        case Section.SectionTypes.Finish:
                            if (Direction == Directions.West || Direction == Directions.East)
                            {
                                ConsoleWriteSectionV(_finishHorizontal, section, sd);
                            }
                            else
                                ConsoleWriteSectionV(_finishVertical, section, sd);
                            break;

                        case Section.SectionTypes.Lefcorner:
                            if (Direction == Directions.East)
                            {
                                ConsoleWriteSectionV(_corner4, section, sd);
                            }
                            if (Direction == Directions.South)
                            {
                                ConsoleWriteSectionV(_corner2, section, sd);
                            }
                            if (Direction == Directions.North)
                            {
                                ConsoleWriteSectionV(_corner1, section, sd);
                            }
                            if (Direction == Directions.West)
                            {
                                ConsoleWriteSectionV(_corner3, section, sd);
                            }
                            Direction = SetDirection(Section.SectionTypes.Lefcorner, Direction);
                            break;

                        case Section.SectionTypes.Rightcorner:
                            if (Direction == Directions.East)
                            {
                                ConsoleWriteSectionV(_corner1, section, sd);
                            }
                            if (Direction == Directions.South)
                            {
                                ConsoleWriteSectionV(_corner4, section, sd);
                            }
                            if (Direction == Directions.North)
                            {
                                ConsoleWriteSectionV(_corner3, section, sd);
                            }
                            if (Direction == Directions.West)
                            {
                                ConsoleWriteSectionV(_corner2, section, sd);

                            }
                            Direction = SetDirection(Section.SectionTypes.Rightcorner, Direction);
                            break;
                    }
                }
            }
        }
        public static void ConsoleWriteSectionV(string[] sectionStrings, Section section, SectionData sd)
        {
            if (Lchanged == true && (sectionStrings == _straightHorizontal || sectionStrings == _startHorizontal || sectionStrings == _finishHorizontal))
            {
                if (Direction == Directions.South)
                {
                    y -= 4;
                }

                if (Direction == Directions.West)
                {
                    y -= 4;
                    x -= 4;
                }
                if (Direction == Directions.East)
                {
                    y -= 4;
                    x += 4;
                }

            }
            if (Lchanged == true && (sectionStrings == _startVertical || sectionStrings == _straightVertical || sectionStrings == _finishVertical))
            {
                if (Direction == Directions.North)
                {
                    y -= 8;
                }
            }
            if (Rchanged == true && (sectionStrings == _straightHorizontal || sectionStrings == _startHorizontal || sectionStrings == _finishHorizontal))
            {
                if (Direction == Directions.South)
                {
                    y -= 4;
                    x -= 4;
                }
                if (Direction == Directions.West)
                {
                    y -= 4;
                    x -= 4;
                }
                if (Direction == Directions.East)
                {
                    y -= 4;
                    x += 4;
                }
            }
            if (Rchanged == true && (sectionStrings == _straightVertical || sectionStrings == _startVertical || sectionStrings == _finishVertical))
            {
                if (Direction == Directions.North)
                {
                    y -= 8;
                }
            }

            if ((Lchanged == false && Rchanged == false) && (sectionStrings == _straightHorizontal || sectionStrings == _startHorizontal || sectionStrings == _finishHorizontal))
            {
                if (Direction == Directions.East)
                {
                    y = 0;
                    x += 4;
                }
            }

            if (sectionStrings == _corner1)
            {
                if (Direction == Directions.East)
                {
                    x += 4;
                    y -= 4;
                }
                if (Direction == Directions.North)
                {
                    y -= 4;
                }
            }

            if (sectionStrings == _corner3)
            {
                if (Direction == Directions.North)
                {
                    y -= 8;
                }
                if (Direction == Directions.West)
                {
                    x -= 8;
                    y -= 4;
                }
            }
            if (sectionStrings == _corner4)
            {
                if (Direction == Directions.East)
                {
                    y -= 4;
                }
            }

            if (sectionStrings == _corner2)
            {
                if (Direction == Directions.West)
                {
                    x -= 4;
                    y -= 4;
                }
            }

            foreach (string s in sectionStrings)
            {
                string s2 = s;
                s2 = PlaceDrivers(s, sd);
                Console.SetCursorPosition(x, y);
                Console.WriteLine(s2);
                y++;

            }
        }
        public static string PlaceDrivers(string st, SectionData sd)
        {
            if (sd.Left != null)
            {
                st = st.Replace("1", sd.Left.Name.Substring(0, 1));
            }
            else
            {
                st = st.Replace("1", " ");
            }

            if (sd.Right != null)
            {
                st = st.Replace("2", sd.Right.Name.Substring(0, 1));
            }
            else
            {

                st = st.Replace("2", " ");
            }

            return st;
        }


        static bool Lchanged;
        static bool Rchanged;
        public static Directions SetDirection(Section.SectionTypes sectionTypes, Directions dr)
        {
            Lchanged = false;
            Rchanged = false;
            if (sectionTypes == Section.SectionTypes.Lefcorner)
            {

                switch (dr)
                {
                    case (Directions.North):
                        Direction = Directions.West;
                        break;

                    case (Directions.East):
                        Direction = Directions.North;
                        break;

                    case (Directions.West):
                        Direction = Directions.South;
                        break;

                    case (Directions.South):
                        Direction = Directions.East;
                        break;

                }
                Lchanged = true;

            }

            if (sectionTypes == Section.SectionTypes.Rightcorner)
            {
                switch (dr)
                {
                    case Directions.North:
                        Direction = Directions.East;
                        break;
                    case Directions.East:
                        Direction = Directions.South;
                        break;
                    case Directions.South:
                        Direction = Directions.West;
                        break;
                    case Directions.West:
                        Direction = Directions.North;
                        break;
                }
                Rchanged = true;
            }
            return Direction;
        }


        public static void DriversChangedHandler(object s, DriversChangedEventArgs d )
        {
            DrawTrack(d.Track);
        }
        #endregion
    }
    
}


