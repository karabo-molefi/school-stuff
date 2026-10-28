using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        enum Menu
        {
            Capture =1,
            Display,
            DisplayAQIAVerages,
            Search,
            Exit
        }

        static string signature = "The Environmental Agency of Cape Town is powered by ";

        static  SortedList<string, string> TownDetails = new SortedList<string, string>();
        static List<double> averageReadings = new List<double>();
        static void Main(string[] args)
        {
           // display menu
           bool isRunning = true;
           while (isRunning)
            {
                Console.Clear();
                Console.WriteLine($"1. Capture Signature" +
                    $"\n2. Display" +
                    $"\n3. Display AQI Averages" +
                    $"\n4. Search For A Town" +
                    $"\n5. Exit");
                Console.Write("Enter an option (1-4): ");
                int userInput = int.Parse(Console.ReadLine());

                switch ((Menu)userInput)
                {
                    case Menu.Capture:
                        Capture();
                        break;
                    case Menu.Display:
                        Display();
                        break;
                    case Menu.DisplayAQIAVerages:
                        DisplayAQIAverages();
                        break;
                    case Menu.Search:
                        Search();
                        break;
                    case Menu.Exit:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

            }
        }

        static void Display()
        {
            Console.Clear();
           
            Console.WriteLine(signature);

            int i = 0; // counter for average readings
            // write captured data
            // TOWN NAME | DAY 1 AQI | DAY 2 AQI | DAY 3 AQI | Average AQI
            Console.WriteLine($"SUBURB|DAY 1 AQI|DAY2 AQI|DAY 3 AQI|");
            foreach (var town in TownDetails)
            {
                Console.WriteLine($"{town.Key}|{town.Value} + {averageReadings[i]}");
                i++;
                
            }
            Console.ReadKey();

        }
        static void Capture()
        {
            Console.Clear();
            // signature
            Console.WriteLine("Enter Signature: ");
            string inputsignature = Console.ReadLine();
            // display signature
            // unpack the signature
            // i tried to get the second alphabetic char to add a spcae before it so the name and surname has a space
            //foreach (char c in inputsignature)
            //{
            //    if c.Equals(c.ToUpper)
            //}
            signature += inputsignature;


            // town and 3 day air quality data
            string[] towns = new string[] { "Table View", "Khayelitsha", "Constansia", "Mitchells Plain", "Bellville", "Hout Bay" };// 6 towns
            //string[] towns = new string[] { "Table View" };// 1 town to test

            // loop through towns and ask for averages
            foreach (var town in towns)
            {
                // add to town details
                Console.WriteLine($"Capturing deatails for {town}");
                Console.WriteLine("Please enter the AQI on");
                Console.WriteLine("Day 1: ");
                double reading1 = double.Parse(Console.ReadLine());
                Console.WriteLine("Day 2:");
                double reading2 = double.Parse(Console.ReadLine());
                Console.WriteLine("Day 3:");
                double reading3 = double.Parse(Console.ReadLine());

                string readings = string.Join("|", reading1.ToString(), reading2.ToString(), reading3.ToString());
                // add to list
                TownDetails.Add(town, readings);
                Console.WriteLine("Town Captured Successfully!");
            }
            Console.WriteLine("ALL Towns Captured Successfully!");

            Console.ReadKey();

        }

        static void DisplayAQIAverages()
        {
            Console.Clear();
            // get town details
            // list for all readings
            List<string> allReadings = new List<string>();

            // list for all average readings
            //List<double> averageReadings = new List<double>();

            foreach (var town in TownDetails)
            {
                string readings = town.Value;
                // split by bar
                string[] reading = readings.Split('|');
                // add each reading to all readings
                foreach (string r in reading)
                {
                    allReadings.Add(r);
                }

                // get average of readings
                double average = Convert.ToDouble(reading[0] + reading[1] + reading[2]) / 3;
                // add to averageReadings list
                averageReadings.Add(average);

                // write town name and average
               
                Console.WriteLine($"Town: {town.Key} Average: {average}");
            }

            // calculate overall average
            double sum = 0;
            foreach (string reading in allReadings)
            {
                sum += Convert.ToDouble(reading);
            }
            double overallAverage = sum / allReadings.Count;

            Console.ReadKey();


        }

        static void Search()
        {
            Console.Clear();
            // get town name
            Console.WriteLine("Enter Town Name to Search for: ");
            string townName = Console.ReadLine();
            // check if town exists
            if (TownDetails.ContainsKey(townName))
            {
                // print aqi levels for each day and average aqi
                int i = 0; // counter for averages from list
                

                foreach (var town in TownDetails)
                {
                    // write town name
                    Console.WriteLine($"{town.Key}");

                    // unpack the string
                    string[] details = town.Value.Split('|');
                    // write days and aqi readings
                    Console.WriteLine($"Day 1 AQI: {details[0]}");
                    Console.WriteLine($"Day 2 AQI: {details[1]}");
                    Console.WriteLine($"Day 3 AQI: {details[2]}");
                    Console.WriteLine($"Average AQI: {averageReadings[i]}");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Town not found.");
            }

            Console.ReadKey();

        }

    }
}
