using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameJam2014TeamSemiColon
{
    class Globals
    {
        public bool light;
        private static Globals instance;

        private Globals()
        {
            light = true;
        }

        public static void Initialise()
        {
            if (instance == null)
            {
                instance = new Globals();
            }
        }

        public static Globals Instance
        {
            get { return instance; }
        }
    }
}
