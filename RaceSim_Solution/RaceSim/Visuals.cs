using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RaceSim
{
    public static class Visuals
    {
        public static void Initialize()
        {

        }

        #region Graphics
        private static string[] _finishHorizontal = {   "----","  # ", "  # ", "----" };
        private static string[] _startHorizontal = { "----", "  # ", "  # ", "----" };
        private static string[] _straightHorizontal = { "----", "  # ", "  # ", "----" };
    
        private static string[] _finishVertical = { "----", 
                                                    "  # ", 
                                                    "  # ", 
                                                    "----" };

        private static string[] _startVertical = {  "----",                                                              
                                                    "  # ", 
                                                    "  # ", 
                                                    "----" };

        private static string[] _straigthVertical = {   "----",   
                                                        "  # ", 
                                                        "  # ", 
                                                        "----" };


    

        #endregion

        public static void DrawTrack(Track track)
        {

        }


    }
}
