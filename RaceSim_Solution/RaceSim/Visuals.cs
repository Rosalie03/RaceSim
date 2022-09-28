using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        //public static int space = 4;


        public static void Initialize()
        {
            Console.CursorVisible = false;
            Direction = Directions.East;


        }
        #region Graphics


        private static string[] _finishHorizontal = { "════", " #  ", " #  ", "════" };
        private static string[] _finishVertical = { "║  ║", "║  ║", "║##║", "║  ║" };

        private static string[] _startHorizontal = { "════", " *  ", " *  ", "════" };
        private static string[] _startVertical = { "║  ║", "║  ║", "║**║", "║  ║" };

        private static string[] _straightHorizontal = { "════", "    ", "    ", "════" };
        private static string[] _straightVertical = { "║  ║", "║  ║", "║  ║", "║  ║" };


        private static string[] _leftCornerHorizontal = { "═══╗", 
                                                          "   ║", 
                                                          "   ║", 
                                                          "╗  ║" };

        private static string[] _leftCornerVertical = { "║  ╚", 
                                                        "║   ", 
                                                        "║   ", 
                                                        "╚═══" };

        private static string[] _rightCornerHorizontal = { "╔════", 
                                                           "║    ", 
                                                           "║    ",
                                                           "║  ╔═" };

        private static string[] _rightCornerVertical = { "╝  ║", 
                                                         "   ║", 
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

            foreach (Section section in track.Sections)
            {
                switch (section.SectionType)
                {
                    case Section.SectionTypes.Startgrid:
                        if (Direction == Directions.West || Direction == Directions.East)
                        {
                            ConsoleWriteSectionV(_startHorizontal, 4, 0);
                        }
                        else
                            ConsoleWriteSectionV(_startVertical, 0, 0);
                        break;

                    case Section.SectionTypes.Straight:
                        if (Direction == Directions.West || Direction == Directions.East)
                        {
                            ConsoleWriteSectionV(_straightHorizontal, 4, 0);
                        }
                        else
                            ConsoleWriteSectionV(_straightVertical, 0, 0);
                        break;

                    case Section.SectionTypes.Finish:
                        if (Direction == Directions.West || Direction == Directions.East)
                        {
                            ConsoleWriteSectionV(_finishHorizontal, 4,0);
                        }
                        else
                            ConsoleWriteSectionV(_finishVertical,0,0);
                        break;

                    case Section.SectionTypes.Lefcorner:
                    if(Direction == Directions.East)
                        {
                            ConsoleWriteSectionV(_rightCornerVertical,0,0 );
                            //    Direction = Directions.North;
                           
                        }
                    if(Direction == Directions.South)
                        {
                            ConsoleWriteSectionV(_leftCornerVertical,0,0);
                          //  Direction = Directions.East;
                        }
                    if(Direction == Directions.North)
                        {
                            ConsoleWriteSectionV(_leftCornerHorizontal,0,0);
                          //  Direction = Directions.West;
                        }
                        if(Direction == Directions.West)
                        {
                            ConsoleWriteSectionV(_rightCornerHorizontal,0,0) ;          
                          //  Direction = Directions.South;
                        }
                        Direction = SetDirection(Section.SectionTypes.Lefcorner, Direction);
                        break;

                    case Section.SectionTypes.Rightcorner:
                        if (Direction == Directions.East)
                        {
                            ConsoleWriteSectionV(_leftCornerHorizontal, 0, 0) ;
                          //  Direction = Directions.South;
                        }
                        if (Direction == Directions.South)
                        {
                            ConsoleWriteSectionV(_rightCornerVertical, 0, 0);
                           // Direction = Directions.West;
                        }
                        if (Direction == Directions.North)
                        {
                            ConsoleWriteSectionV(_rightCornerHorizontal, 0, 0);
                           // Direction = Directions.East;
                        }
                        if (Direction == Directions.West)
                        {
                            ConsoleWriteSectionV(_leftCornerVertical, 0, 0);      
                          //  Direction = Directions.North;
                            
                        }
                        Direction = SetDirection(Section.SectionTypes.Rightcorner, Direction);
                        break;
                }
            }
        }
        public static void ConsoleWriteSectionV(string[] sectionStrings, int tx, int ty)
        {   
            x = x + tx;
            y = y + ty;

            if (Lchanged == true && (sectionStrings == _straightHorizontal || sectionStrings == _startHorizontal || sectionStrings == _finishHorizontal))
            {
                if (Direction == Directions.South)
                {
                    y -= 4;
                }

                if(Direction == Directions.West)
                {
                    y -= 4;
                    x -= 8;
                }
                if(Direction == Directions.East)
                {
                    y -= 4;
                }
               
            }
            if(Lchanged == true && (sectionStrings == _startVertical || sectionStrings == _straightVertical || sectionStrings == _finishVertical))
            {
                if(Direction == Directions.North)
                {
                    y -= 8;
                }
            }
            if(Rchanged == true && (sectionStrings == _straightHorizontal || sectionStrings == _startHorizontal || sectionStrings == _finishHorizontal))
            {
                if (Direction == Directions.South)
                {
                    y -= 4;
                    x -= 8;
                }
                if(Direction == Directions.West)
                {
                    y -= 4;
                    x -= 8;
                }
                if(Direction == Directions.North)
                {
                   // y -= 4;
                }
                if (Direction == Directions.East)
                {
                    y -= 4;                   
                }

            }
            if(Rchanged == true && (sectionStrings == _straightVertical || sectionStrings == _startVertical || sectionStrings == _finishVertical))
            {

                if (Direction == Directions.North)
                {
                    y -= 8;
                }
                if(Direction == Directions.South)
                {

                }

            }

                if ((Lchanged == false && Rchanged == false) && (sectionStrings == _straightHorizontal || sectionStrings == _startHorizontal || sectionStrings == _finishHorizontal))
                {
                    y = 0;

                }
            
            if (Rchanged == false && (sectionStrings == _startVertical || sectionStrings == _straightVertical || sectionStrings == _finishVertical))
            {
                x = x;
                y = y;
            }

            if (sectionStrings == _leftCornerHorizontal && Direction == Directions.East)
            {
                x += 4;
                y -= 4;
            }
            if (sectionStrings == _leftCornerVertical && Direction == Directions.West)
            {
                x -= 4;
                y -= 4;
            }
            if(sectionStrings == _leftCornerHorizontal && Direction == Directions.North)
            {
                y -= 4;
            }
            if(sectionStrings == _rightCornerHorizontal && Direction == Directions.North)
            {
                y -= 8;
            }
            if(sectionStrings == _rightCornerHorizontal && Direction == Directions.West)
            {
                x-=5;
                y-=4;
            }
            if(sectionStrings == _rightCornerVertical && Direction == Directions.East)
            {
                y -= 4;
            }



            foreach (string s in sectionStrings)
            {             
                Console.SetCursorPosition(x, y);
                Console.WriteLine(s);
                y++;
                
            }


        }
        
       static bool Lchanged =false; 
       static bool Rchanged = false; 
        public static Directions SetDirection(Section.SectionTypes sectionTypes, Directions dr)
        {
            Lchanged = false;
            Rchanged =false;
            if (sectionTypes == Section.SectionTypes.Lefcorner)
            {

                switch (dr)
                {
                    case(Directions.North):
                        Direction = Directions.West;
                        break;

                    case(Directions.East):
                        Direction = Directions.North;
                        break;

                        case(Directions.West):
                        Direction = Directions.South;
                        break;

                        case(Directions.South):
                        Direction = Directions.East;
                        break;

                }
/*                if (Direction == Directions.North)
                {
                     Direction = Directions.West;
                }
                if (Direction == Directions.East)
                {
                     Direction = Directions.North;
                }
                if (Direction == Directions.South)
                {
                     Direction = Directions.East;
                }
                if (Direction == Directions.West )
                {
                     Direction = Directions.South;
                }*/
                Lchanged = true;
                           
               }

            Console.SetCursorPosition(x, y);

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

            Console.SetCursorPosition(x, y);
            return Direction;
        }
        #endregion
    }
    
}


