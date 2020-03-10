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
                Console.WriteLine("\nAvailable Network Data files: ");
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
                        Console.WriteLine("\\nInvalid Selection. Please enter a digit to match the file - e.g. 1\n");
                        continue; //Reiterate
                    }

                    if (fileSelection_i == NetworkDataPaths.Count + 1) System.Environment.Exit(0); //Exit with a successful exit code (0)

                    if (fileSelection_i > NetworkDataPaths.Count || fileSelection_i <= 0)
                    {
                        Console.WriteLine("\nInvalid Selection. Selection out of range.\n");
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
                        Console.WriteLine("\nInvaid data found in file. Ignoring...\n");
                        continue;
                    }


                    dataCount++;
                }

                bool isDataInArraySorted = false;

                bool modeSelectionValid = false;
                bool active = true;
              
                while (!modeSelectionValid || active)
                {
                    //Ask user what they'd like to do with that data
                    Console.WriteLine("What would you like to do with the data in the selected file?\n[1] Sort\n[2] Search\n[3] Merge\n[0] Main Menu");
                    Console.Write("Enter Selection: ");
                    string modeSelection = Console.ReadLine();
                    switch (modeSelection)
                    {
                        case "1":
                            Console.WriteLine("Which algorithm would you like to run?\n[1] Bubble Sort\n[2] Inserstion Sort\n[3] Merge Sort\n[4] Quick Sort\n[0] Back");
                            Console.Write("Enter Selection: ");
                            string algoSelection = Console.ReadLine();
                            switch (algoSelection)
                            {
                                case "1":
                                    //bubble sort
                                    Console.WriteLine("Performing bubble sort on selected data...");
                                    sortAlgorithms.bubbleSort(fileData, fileData.Length);
                                    helperFuncs.OutputArray(fileData); // Follows assignemnt brief rules with outputting different sizes 
                                    return;

                                case "2":
                                    //insertion sort
                                    Console.WriteLine("Performing Insertion Sort on selected data...");
                                    sortAlgorithms.InsertionSort(fileData);
                                    helperFuncs.OutputArray(fileData); // Follows assignemnt brief rules with outputting different sizes 
                                    return;

                                case "3":
                                    //merge
                                    Console.WriteLine("Performing Merge Sort on selected data...");
                                    sortAlgorithms.MergeSort(fileData);
                                    helperFuncs.OutputArray(fileData);
                                    return;

                                case "4":
                                    //quick
                                    //Console.WriteLine("Performing Quick Sort on selected data...");
                                    //sortAlgorithms.QuickSort(fileData); 
                                    return;

                                case "0":
                                    //back
                                    return;

                                default:
                                    Console.WriteLine("\nInvalid Selection. Please specify a digit linked to the mode. E.g. 1\n");
                                    break;
                            }
                            break;

                        case "2":
                            Console.WriteLine("Which algorithm would you like to run?\n[1] Linear Search\n[2] Binary Search\n[0] Back");
                            break;

                        case "3":
                            Console.WriteLine("Merging is not yet supported.");
                            break;

                        case "0":
                            modeSelectionValid = true;
                            active = false;
                            break;

                        default:
                            Console.WriteLine("\nInvalid Selection. Please specify a digit linked to the mode. E.g. 1\n");
                            break;


                    }
                   
                }
               

            }
           
           
            //Console.WriteLine(fileSelection);
            //Console.WriteLine(NetworkDataPaths[Convert.ToInt32(fileSelection)-1]);

            

            int[] ar = { 9, 392, 2, 1, 92 };
            sortAlgorithms.bubbleSort(ar, ar.Length);
            Console.WriteLine(searchAlgorithms.BinarySearch(ar, 92222));
           
        }
    }
}
