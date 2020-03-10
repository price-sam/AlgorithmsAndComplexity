﻿using System;
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
            bool mergedArrayEnabled = false;

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
                mergedArrayEnabled = false;
                string[] fileData_string = File.ReadAllLines(selectedFilePath);
                int totalLines = fileData_string.Length;
                int[] fileData = helperFuncs.stringToIntArray(fileData_string);
                

                bool isDataInArraySorted = false;

                bool active = true;
              
                while (active)
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
                            string sortSelection = Console.ReadLine();
                            int stepCount = 0;
                            switch (sortSelection)
                            {
                                case "1":
                                    //bubble sort
                                    Console.WriteLine("\nPerforming bubble sort on selected data...");
                                    if (!mergedArrayEnabled)
                                    {
                                        stepCount = sortAlgorithms.bubbleSort(fileData, fileData.Length);
                                        helperFuncs.OutputArray(fileData); // Follows assignemnt brief rules with outputting different sizes
                                    }
                                    else
                                    {
                                        stepCount = sortAlgorithms.bubbleSort(mergedFileData, fileData.Length);
                                        helperFuncs.OutputArray(mergedFileData); // Follows assignemnt brief rules with outputting different sizes
                                    }
                                    Console.WriteLine("Completed in " + stepCount.ToString() + " steps.");
                                    isDataInArraySorted = true;
                                    break;

                                case "2":
                                    //insertion sort
                                    Console.WriteLine("\nPerforming Insertion Sort on selected data...");
                                    stepCount = sortAlgorithms.InsertionSort(fileData);
                                    helperFuncs.OutputArray(fileData); // Follows assignemnt brief rules with outputting different sizes 
                                    Console.WriteLine("Completed in " + stepCount.ToString() + " steps.");
                                    isDataInArraySorted = true;
                                    break;

                                case "3":
                                    //merge
                                    Console.WriteLine("\nPerforming Merge Sort on selected data...");
                                    stepCount = sortAlgorithms.MergeSort(fileData);
                                    helperFuncs.OutputArray(fileData);
                                    Console.WriteLine("Completed in " + stepCount.ToString() + " steps.");
                                    isDataInArraySorted = true;
                                    break;

                                case "4":
                                    //quick
                                    Console.WriteLine("\nPerforming Quick Sort on selected data...");
                                    sortAlgorithms.QuickSort(fileData, 0, fileData.Length-1);
                                    helperFuncs.OutputArray(fileData); 
                                    isDataInArraySorted = true;
                                    break;

                                case "0":
                                    //back
                                    break;

                                default:
                                    Console.WriteLine("\nInvalid Selection. Please specify a digit linked to the mode. E.g. 1\n");
                                    break;
                            }
                            break;

                        case "2":
                            Console.WriteLine("Which algorithm would you like to run?\n[1] Linear Search\n[2] Binary Search\n[0] Back");
                            Console.Write("Enter Selection: ");
                            string searchSelection = Console.ReadLine();
                            switch (searchSelection)
                            {
                                case "1":
                                    //linear
                                    Console.Write("Enter the integer you'd like to search for: ");
                                    string linearTarget_str = Console.ReadLine();
                                    int linearTarget = helperFuncs.ParseInt(linearTarget_str);
                                    if (linearTarget == -999999)
                                    {
                                        Console.WriteLine("\nInvalid Selection. You must enter an integer value.");
                                        break;
                                    }

                                    Console.WriteLine("\nPerforming Linear Search to find " + linearTarget_str + " in selected data..");
                                    int linearResult = searchAlgorithms.LinearSearch(fileData, linearTarget);
                                    if (linearResult == -1)
                                    {
                                        Console.WriteLine("Target not found in data.");
                                        break;
                                    }

                                    Console.WriteLine(linearTarget_str + " found at position " + linearResult.ToString() + " in selected data.");
                                    break;

                                case "2":
                                    //Binary -- only allow if data sorted
                                    if (!isDataInArraySorted)
                                    {
                                        Console.WriteLine("\nFunction unavailable while data unsorted. To enable this function, run a sorting algorithm on it first.\n");
                                        break;
                                    }
                                    Console.Write("Enter the integer you'd like to search for: ");
                                    string binaryTarget_str = Console.ReadLine();
                                    int binaryTarget = helperFuncs.ParseInt(binaryTarget_str);
                                    if (binaryTarget == -999999)
                                    {
                                        Console.WriteLine("\nInvalid Selection. You must enter an integer value.");
                                        break;
                                    }

                                    Console.WriteLine("\nPerforming Binary Search to find " + binaryTarget_str + " in selected data..");
                                    int binaryResult = searchAlgorithms.BinarySearch(fileData, binaryTarget);
                                    if (binaryResult == -1)
                                    {
                                        Console.WriteLine("Target not found in data.");
                                        break;
                                    }

                                    Console.WriteLine(binaryTarget_str + " found at position " + binaryResult.ToString() + " in selected data.");

                                    break;
                            }

                            break;

                        case "3":
                            Console.WriteLine("/nWhat network data file would you like to merge with your current selection?");
                            int mergeCount = 0;
                            string mergeFilePath = "";
                            foreach (string path in NetworkDataPaths)
                            {
                                mergeCount++;
                                string[] pathSplit = path.Split('/');
                                Console.WriteLine("[" + mergeCount.ToString() + "] " + pathSplit[pathSplit.Length - 1]);
                            }
                            Console.WriteLine("[" + (mergeCount + 1).ToString() + "] Back");
                            Console.Write("Enter Selection: ");
                            string mergeSelection = Console.ReadLine();
                            int mergeSelection_i = 0;
                            try
                            {
                                mergeSelection_i = Convert.ToInt32(mergeSelection);
                            }
                            catch
                            {
                                Console.WriteLine("\nInvalid Selection. Please enter a digit to match the file - e.g. 1\n");
                                break;
                            }
                            if (mergeSelection_i == mergeCount + 1) break;
                            mergeFilePath = NetworkDataPaths[mergeSelection_i - 1];
                            Console.WriteLine("\nMerging two selected files.");
                            Console.WriteLine(fileData.Length);
                            string[] mergeData_string = File.ReadAllLines(mergeFilePath);
                            int[] newArray = mergeAlgorithms.mergeFiles(fileData, helperFuncs.stringToIntArray(mergeData_string));
                            newArray.CopyTo(mergedFileData, 0);
                            Console.WriteLine("\nMerging Complete. You can now sort and search this new merged array.");
                            Console.WriteLine(fileData.Length);
                            break;

                        case "0":
                            active = false;
                            break;

                        default:
                            Console.WriteLine("\nInvalid Selection. Please specify a digit linked to the mode. E.g. 1\n");
                            break;


                    }
                }
            }
        }
    }
}
