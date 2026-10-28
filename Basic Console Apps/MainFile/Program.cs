using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MainFile
{
    internal class Program
    {   
        static int NumberOfMembers()
        {
            var membersDict = CaptureMemberDetails();
            int numberOfMembers = membersDict.Count;
            return numberOfMembers;
        }

        static Dictionary<string, (
            string Name,
            int Age,
            string EmploymentStatus,
            int MembershipRank,
            int NumberOfYearsActive,
            double TreadmillRecord,
            int TotalSmoothiesPurchased,
            string FavouriteSmoothieFlavour,
            int AverageSmoothieConsumption
            )> CaptureMemberDetails() // Method to caputre member details
        {
            var membersDict = new Dictionary<string, (
                string Name,
                int Age,
                string EmploymentStatus,
                int MembershipRank,
                int NumberOfYearsActive,
                double TreadmillRecord,
                int TotalSmoothiesPurchased,
                string FavouriteSmoothieFlavour,
                int AverageSmoothieConsumption
            )>();

            // Initialise Members
            membersDict["MEM001"] = ("Thabo", 23, "Employed", 5750, 4, 50.5, 75, "Strawberry Stinger", 12); // Qualifies
            membersDict["MEM002"] = ("Cindy", 16, "Employed", 3000, 2, 36.0, 25, "C-Breeze", 5); // Qualifies
            membersDict["MEM003"] = ("Katy", 26, "Unemployed", 2700, 3, 312.9, 104, "Banana Bliss", 32); // Disqualified
            membersDict["MEM004"] = ("John", 57, "Employed", 500, 2, 25.5, 14, "Banana Bliss", 5); //  Qualifies
            membersDict["MEM005"] = ("Zanele", 29, "Employed", 4000, 5, 80.0, 90, "ChocoChurned Chaos", 6); // Disqualified
            membersDict["MEM006"] = ("Sipho", 34, "Employed", 3200, 6, 45.5, 60, "Mango Madness", 10); // Qualifies 
            membersDict["MEM007"] = ("Lesedi", 21, "Unemployed", 1500, 1, 5.5, 10, "Pineapple Pop", 2); // Disqualified
            membersDict["MEM008"] = ("Aisha", 28, "Employed", 1900, 3, 22.5, 80, "Banana Bliss", 6); // Qualifies 
            membersDict["MEM009"] = ("Jason", 40, "Employed", 2100, 3, 15.5, 300, "Strawberry Stinger", 25); // Disqualified
            membersDict["MEM010"] = ("Lebo", 17, "Employed", 2200, 2, 19.5, 35, "C-Breeze", 5); // Qualifies 


            // Capurting Details
            Console.WriteLine("Caputuring Member Details.");
            Console.WriteLine();

            bool isactive = true;
            while (isactive)
            {
                Console.WriteLine("Personal Details.");
                Console.WriteLine();

                Console.WriteLine("Membership Number: ");
                string membershipNumber = Console.ReadLine();

                Console.WriteLine("Name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Age: ");
                int age = int.Parse(Console.ReadLine());

                // ask for employment status if under 18 ask if guardian is employed
                string employmentStatus;
                if (age < 18)
                {
                    Console.WriteLine("Guardian Employment Status (Employed/Unepmplyed): ");
                    employmentStatus = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Employment Status (Employed/Unepmplyed): ");
                    employmentStatus = Console.ReadLine();
                }
                // done entering personal details
                Console.WriteLine();
                Console.WriteLine("Membership Deatails.");
                Console.WriteLine();

                Console.WriteLine("Membersip Rank: ");
                int membershipRank = int.Parse(Console.ReadLine());

                Console.WriteLine("Number of Years Active: ");
                int numberOfYearsActive = int.Parse(Console.ReadLine());

                Console.WriteLine("Treadmill Record: ");
                double treadmillRecord = double.Parse(Console.ReadLine());

                Console.WriteLine("Number of Smoothies Purchased: ");
                int numberOfSmoothiesPurchased = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Favourite Smoothie Flavour: ");
                string favouriteSmoothieFlavour = Console.ReadLine();

                Console.WriteLine("Enter Avaerage Smoothie Consumption: ");
                int averageSmoothieConsumption = int.Parse(Console.ReadLine());

                membersDict[membershipNumber] = (
                    name, 
                    age, 
                    employmentStatus, 
                    membershipRank, 
                    numberOfYearsActive,
                    treadmillRecord,
                    numberOfSmoothiesPurchased, 
                    favouriteSmoothieFlavour, 
                    averageSmoothieConsumption
                    );

                // notify user of successfull capture
                Console.WriteLine();
                Console.WriteLine("Member Captured Successfully!");
                Console.WriteLine();

                // ask if user is done caputring members
                Console.WriteLine("Do you want to enter another applicant? (y/n): ");

                while (true)
                {
                    string choice = Console.ReadLine();
                    choice = choice.ToLower();


                    if (choice == "y" || choice == "yes" || choice == "n" || choice == "no")
                    {
                        if (choice == "y" || choice == "yes")
                        {
                            Console.WriteLine();
                            Console.WriteLine("Capture a new applicant.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Capturing Complete.");
                            isactive = false;
                            break;
                        }
                    }
                    else
                    {
                        // repromt for unexpected input
                        Console.WriteLine();
                        Console.WriteLine("Not a valid option. Enter (y/n): ");
                        Console.WriteLine();
                        continue;
                    }                        
                }   
            }
            return membersDict;
        }

        static void Main(string[] args)
        {
            int num = NumberOfMembers();

            Console.WriteLine($"NUmber of members: {num}");
            
            //var dict = CaptureMemberDetails();

            //foreach (var member in dict.Values)
            //{
            //    Console.WriteLine(member);
            //}
        }
    }
}
