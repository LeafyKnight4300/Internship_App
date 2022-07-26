using System;
using System.Collections.Generic;
using System.Text;
using static Notes.planes;

namespace Notes
{
    public static class Info
    {
        static string runwayData;
        static string activePlane;
        
        public static void setRunwayData(string runway)
        {
            runwayData = runway;
        }

        public static object getRunwayData()
        {
            return runwayData;
        }

        public static void setActivePlane(string plane)
        {
            activePlane = plane;
              
        }

        public static object getActivePlane()
        {
            return activePlane;
        }

    }

}
