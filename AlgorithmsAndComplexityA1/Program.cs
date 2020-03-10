using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Sam Price (PRI19696086)
// Algorithms and Complexity Assignment 1
// Program Entry Point (Main)

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
            HelperFunctions helperFuncs = new HelperFunctions();

            int[] networkDataFromFile = {}; 
            List<String> NetworkDataPaths = new List<String>();

            //Initialisation

            //Get the current path - ensuring the program still runs on a different system
            string currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            // Loop until network data is selected - handle errors
            foreach (var file in Directory.EnumerateFiles(currentPath + "/NetworkData"))
            {
                //Store path for reference in 
                NetworkDataPaths.Add(file);
            }

            //Main Loop
            bool mainActive = true;

            while (mainActive)
            {
                //Handle selection
                Console.WriteLine("Available Network Data files: ");
                int count = 0;
                foreach (string path in NetworkDataPaths)
                {
                    count++;
                    string[] pathSplit = path.Split('/');
                    Console.WriteLine("[" + count.ToString() + "] " + pathSplit[pathSplit.Length - 1]);
                }
                Console.WriteLine("[" + (count + 1).ToString() + "] Exit Program");

                //Do WHILE - For player input
                bool validFile = false;
                string selectedFilePath = "";

                while (!validFile)
                {

                    Console.Write("Select file: ");
                    string fileSelection = Console.ReadLine();
                    int fileSelection_i = 0;
                    try
                    {
                        fileSelection_i = Convert.ToInt32(fileSelection);
                    }
                    catch
                    {
                        Console.WriteLine("Invalid Selection. Please enter a digit to match the file - e.g. 1");
                        continue; //Reiterate
                    }

                    if (fileSelection_i == NetworkDataPaths.Count + 1) System.Environment.Exit(0); //Exit with a successful exit code (0)

                    if (fileSelection_i > NetworkDataPaths.Count || fileSelection_i <= 0)
                    {
                        Console.WriteLine("Invalid Selection. Selection out of range.");
                        continue; //Reiterate
                    }

                    validFile = true;
                    selectedFilePath = NetworkDataPaths[fileSelection_i-1];
                    
                }
                Console.WriteLine("\nFile Selected - " + selectedFilePath.Split('/').Last());  //Display what file was selected.

                string[] fileData_string = File.ReadAllLines(selectedFilePath);
                int totalLines = fileData_string.Length;
                int[] fileData = new int[totalLines];

                int dataCount = 0;
                // Add each value as an integer to an array of integers ( as readalllines returns String[])
                foreach (string item in fileData_string)
                {
                    if (item == "") continue;
                    try
                    {
                        fileData[dataCount] = Convert.ToInt32(item);
                    }
                    catch
                    {
                        Console.WriteLine("Invaid data found in file. Ignoring...");
                        continue;
                    }


                    dataCount++;
                }

              

            }
           
           
            //Console.WriteLine(fileSelection);
            //Console.WriteLine(NetworkDataPaths[Convert.ToInt32(fileSelection)-1]);

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
            sortAlgorithms.bubbleSort(ar, ar.Length);
            Console.WriteLine(searchAlgorithms.BinarySearch(ar, 92222));
           
        }
    }
}
