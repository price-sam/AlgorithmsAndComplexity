using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndComplexityA1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialise method classes
            Sorts sortAlgorithms = new Sorts();
            Searches searchAlgorithms = new Searches();
            Merging mergeAlgorithms = new Merging();

            int[] networkDataFromFile = {}; 
            List<String> NetworkDataPaths = new List<String>();

            //Get the current path - ensuring the program still runs on a different system
            string currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            // Loop until network data is selected - handle errors
            foreach (var file in Directory.EnumerateFiles(currentPath + "/NetworkData"))
            {
                //Store path for reference in 
                NetworkDataPaths.Add(file);
            }
            //Handle selection
            Console.WriteLine("Available Network Data files: ");
            int count = 0;
            foreach (string path in NetworkDataPaths)
            {
                count++;
                string[] pathSplit = path.Split('/');
                Console.WriteLine("[" + count.ToString() + "] " + pathSplit[pathSplit.Length-1]);
            }
            Console.Write("Select file: ");
            string fileSelection = Console.ReadLine(); // ADD ERROR HANDLING HERE
            Console.WriteLine(fileSelection);
            Console.WriteLine(NetworkDataPaths[Convert.ToInt32(fileSelection)-1]);

            //Ask user what they'd like to do with that data
            Console.WriteLine("What would you like to do with the data in the selected file?\n[1] Sort\n[2] Search\n[3] Merge\n[0] Main Menu");
            Console.Write("Enter Selection: ");
            string modeSelection = Console.ReadLine();
            if (modeSelection == "1")
            {
                //sort
            
            } 
            else if (modeSelection == "2")
            {
                //search
            }
            else if (modeSelection == "3")
            {
                //merge
            }
            else if (modeSelection == "0")
            {
                //mm
            }

            int[] ar = { 9, 392, 2, 1, 92 };
            sortAlgorithms.QuickSort(ar, 0, ar.Length-1);
            foreach (var item in ar)
            {
                Console.WriteLine(item);
            }
        }
    }
}
