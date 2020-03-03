using System;
using System.IO;
using System.Net;
using System.Reflection;

namespace AlgorithmsAndComplexityA1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Get the current path - ensuring the program still runs on a different system
            string currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            // Loop until network data is selected - handle errors
            foreach (var file in Directory.EnumerateFiles(currentPath+"/NetworkData"))
            {
                Console.WriteLine(file);
            }
                //Handle selection
        }
    }
}


    // __     __
    //(_\    /_ )
    // \ _\  /_ / 
    //  \ _\/_ /_ _
    //  |_____/_/ /|
    //  ((_) __) J-)
    //  (  /`.,   /
    //   \/  ;   /
    //   | === |
