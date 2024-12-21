using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace FleetComander_Console
{
    internal class Program
    {
      
        static void Main(string[] args)
        {
            PlaySequence play = new PlaySequence();
            play.PlayMode();
        }
    }
}
