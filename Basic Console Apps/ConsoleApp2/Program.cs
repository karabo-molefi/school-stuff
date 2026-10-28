using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fit
{
    internal class Program
    {
        // Menu
        enum Menu
        {
            CaptureMemberDetails = 1,
            CheckWellnessRewardQualification,
            DisplayAllQualifyingMembers,
            ShowFitForgeStats,
            Exit
        }

        static void Main(string[] args)
        {
            var qualifyingMembersDict = new Dictionary<string, (
                string, // Name
                int, // Age
                string, // Employment Status
                int, // Membership Rank
                int, // Number Of YearsActive
                double, // Treadmill Record
                int, // Total Smoothies Purchased
                string, // Favourite Smoothie Flavour
                int // Average Smoothie Consumption
            )>();

            var nonQualifyingMembersDict = new Dictionary<string, (
                string, // Same values as qualifying dictionary 
                int,
                string,
                int,
                int,
                double,
                int,
                string,
                int
            )>();

            int numberOfNewMembers = 0;

            // Initialise Qualifying Members
            qualifyingMembersDict["MEM001"] = ("Thabo", 23, "Employed", 5750, 4, 50.5, 75, "Strawberry Stinger", 12);
            qualifyingMembersDict["MEM002"] = ("Cindy", 16, "Employed", 3000, 2, 36.0, 25, "C-Breeze", 5);
            qualifyingMembersDict["MEM004"] = ("John", 57, "Employed", 500, 2, 25.5, 14, "Banana Bliss", 5);
            qualifyingMembersDict["MEM006"] = ("Sipho", 34, "Employed", 3200, 6, 45.5, 60, "Mango Madness", 10);
            qualifyingMembersDict["MEM008"] = ("Aisha", 28, "Employed", 1900, 3, 22.5, 80, "Banana Bliss", 6);

            // Initialise Non-Qualifying Members
            nonQualifyingMembersDict["MEM010"] = ("Lebo", 17, "Unemployed", 2200, 2, 19.5, 35, "C-Breeze", 5);
            nonQualifyingMembersDict["MEM003"] = ("Katy", 26, "Unemployed", 2700, 3, 312.9, 104, "Banana Bliss", 32);
            nonQualifyingMembersDict["MEM005"] = ("Zanele", 29, "Employed", 4000, 5, 80.0, 90, "ChocoChurned Chaos", 6);
            nonQualifyingMembersDict["MEM007"] = ("Lesedi", 21, "Unemployed", 1500, 1, 5.5, 10, "Pineapple Please", 2);
            nonQualifyingMembersDict["MEM009"] = ("Jason", 40, "Employed", 2100, 3, 15.5, 300, "Strawberry Stinger", 25);

            // Display menu
            while (true)
            {
                Console.WriteLine("\nFitForge Menu:");
                Console.WriteLine("--------------");

                Console.WriteLine("\t1. Capture Member Details");
                Console.WriteLine("\t2. Check Wellness Reward Qualification");
                Console.WriteLine("\t3. Display All Qualifying Members");
                Console.WriteLine("\t4. Show FitForge Stats");
                Console.WriteLine("\t5. Exit");
                Console.Write("Please select an option (1-4): ");

                string selectedChoice = Console.ReadLine();

                Menu menuChoice = (Menu)Enum.Parse(typeof(Menu), selectedChoice, true);


                switch (menuChoice)
                {
                    case Menu.CaptureMemberDetails:
                        var (number, newMembersDict) = CaptureMemberDetails((qualifyingMembersDict, nonQualifyingMembersDict));
                        numberOfNewMembers = number;
                        break;
                      
                    case Menu.DisplayAllQualifyingMembers:
                        DisplayAllQualifyingMembers(qualifyingMembersDict);
                        break;

                    case Menu.CheckWellnessRewardQualification:
                        CheckRewardQualification(qualifyingMembersDict,nonQualifyingMembersDict);
                        break;

                    case Menu.ShowFitForgeStats:
                        GetFitForgeStatistics(numberOfNewMembers, qualifyingMembersDict, nonQualifyingMembersDict);
                        break;

                    case Menu.Exit:
                        Console.WriteLine("\nExiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        continue;
                }
            }
        }

        // Method to display all members that qualify for a reward
        public static void DisplayAllQualifyingMembers(Dictionary<string, (string Name, int, string, int, int, double, int, string, int)> qualifyingMembersDict)
        {
            Console.WriteLine("\nQualifing Members:");
            Console.WriteLine("------------------");

            foreach (var member in qualifyingMembersDict)
            {
                Console.Write($"\tName: \t{member.Value.Name}");
                Console.WriteLine($"\tMembership Number: \t{member.Key}");
            }
        }

        // Method to Capture Member Details
        static (int, Dictionary<string, (string, int, string, int, int, double, int, string, int)>)
            CaptureMemberDetails(
            (
            Dictionary<string, (string, int, string, int, int, double, int, string, int)> QualifyingDict,
            Dictionary<string, (string, int, string, int, int, double, int, string, int)> NonQualifyingDict
            ) input
            )
        {
            var newMembersDict = new Dictionary<string, (string, int, string, int, int, double, int, string, int)>();

            // Capurting Details
            


            bool isactive = true;
            while (isactive)
            {
                Console.WriteLine("\nCaputuring Member Details.");
                Console.WriteLine("--------------------------");

                Console.Write("Personal Details.\n");

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Age: ");
                int age = int.Parse(Console.ReadLine());

                // ask for employment status if under 18 ask if guardian is employed
                if (age < 18)
                {
                    Console.Write("Guardian Employment Status (Employed/Unepmplyed): ");
                }
                else
                {
                    Console.Write("Employment Status (Employed/Unepmplyed): ");
                }
                string employmentStatus = (Console.ReadLine());
                // done entering personal details

                Console.WriteLine("\n--------------------------"); // divider for personal details and membership details

                Console.Write("Membership Deatails.\n");

                Console.Write("Membership Number: ");
                string membershipNumber = Console.ReadLine();

                Console.Write("Membersip Rank: ");
                int membershipRank = int.Parse(Console.ReadLine());

                Console.Write("Number of Years Active: ");
                int numberOfYearsActive = int.Parse(Console.ReadLine());

                Console.Write("Treadmill Record: ");
                double treadmillRecord = double.Parse(Console.ReadLine());

                Console.Write("Number of Smoothies Purchased: ");
                int numberOfSmoothiesPurchased = int.Parse(Console.ReadLine());

                Console.Write("Favourite Smoothie Flavour: ");
                string favouriteSmoothieFlavour = Console.ReadLine();

                Console.Write("Avaerage Smoothie Consumption: ");
                int averageSmoothieConsumption = int.Parse(Console.ReadLine());

                //  temporary dictionary for newly captured member, to be processed

                newMembersDict[membershipNumber] = (
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


                // notify user of members eligibility status and add to respective dictionary 

                var (Qualifying, NonQualifying) = ProcessNewMemberQualification(newMembersDict);

                var qualified = Qualifying;
                var notQualified = NonQualifying;

                foreach (var member in qualified)
                {
                    if (member.Key == membershipNumber)
                    {
                        Console.WriteLine($"\n{name} qualifies for the Wellness Reward!");

                        // add to dictionary 

                        input.QualifyingDict[membershipNumber] = (
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
                    }
                }

                foreach (var member in notQualified)
                {
                    if (member.Key == membershipNumber)
                    {
                        Console.WriteLine($"\n{name} does NOT qualify for the Wellness Reward.");

                        // add to dictionary

                        input.NonQualifyingDict[membershipNumber] = (
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
                    }
                }

                // notify user of successfull capture
                Console.WriteLine("Captured Successfully!\n");

                // ask if user is done caputring members
                Console.Write("Do you want to enter another applicant? (yes/no): ");

                while (true)
                {
                    string choice = Console.ReadLine();
                    choice = choice.ToLower();


                    if (choice == "y" || choice == "yes" || choice == "n" || choice == "no")
                    {
                        if (choice == "y" || choice == "yes")
                        {
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
                        Console.Write("\nNot a valid option. Enter (yes/no): ");
                        continue;
                    }
                }
            }

            int numberOfNewMembers = newMembersDict.Count;
            // return 
            return (numberOfNewMembers, newMembersDict);
        }

        // Method to process new members who qualify or dont qualify for reward
        static (
            Dictionary<string, string> Qualifying,
            Dictionary<string, string> NonQualifying
        ) ProcessNewMemberQualification(Dictionary<string, (string Name, int Age, string EmploymentStatus, int MembershipRank, int NumberOfYearsActive, double TreadmillRecord, int TotalSmoothiesPurchased, string FavouriteSmoothieFlavour, int AverageSmoothieConsumption)> newMembersDict)
        {
            // create structures for qualifying and non-qualifying newly caputred members
            var qualifyingMembersDict = new Dictionary<string, string>();
            var nonQualifyingMembersDict = new Dictionary<string, string>();

            foreach (var member in newMembersDict)
            {
                if (
                    member.Value.EmploymentStatus == "Employed" &&
                    member.Value.NumberOfYearsActive >= 2 &&
                    (member.Value.MembershipRank >= 2000 || member.Value.TreadmillRecord >= 20.0) &&
                    (member.Value.AverageSmoothieConsumption >= 4 && member.Value.AverageSmoothieConsumption <= 20) &&
                    member.Value.FavouriteSmoothieFlavour != "ChocoChurned Chaos"
                )
                {
                    qualifyingMembersDict[member.Key] = member.Value.Name;
                }
                else
                {
                    nonQualifyingMembersDict[member.Key] = member.Value.Name;
                }
            }

            return (Qualifying: qualifyingMembersDict, NonQualifying: nonQualifyingMembersDict);
        }

        // Method to Check if a member qualifies for a reward by searching
        public static void CheckRewardQualification(
            Dictionary<string, (string Name, int, string, int, int, double, int, string, int)> Qualifying,
            Dictionary<string, (string Name, int, string, int, int, double, int, string, int)> NonQualifying)
        {
            // ask for membership number or name
            Console.Write("\nEnter Member's name or membership number: ");
            string userInput = Console.ReadLine();
            // iterate through dictionary and check if they qualify

            // display qualify
            bool validMember = false;
            foreach (var member in Qualifying)
            {
                if (userInput.Contains(member.Key) || userInput == member.Value.Name)
                {
                    Console.WriteLine($"\n{member.Value.Name} ({member.Key}), qualifies for the Wellness Reward!");
                    validMember = true;
                }
            }

            // display not qualify
            foreach (var member in NonQualifying)
            {
                if (userInput.Contains(member.Key) || userInput == member.Value.Name)
                {
                    Console.WriteLine($"\n{member.Value.Name} ({member.Key}), does not qualify for the Wellness Reward.");
                    validMember = true;
                }
            } 

            // not a valid memebr
            if (!validMember)
            {
                Console.WriteLine("\nNot a valid Member! Please try again.");
            }

        }

        // Statistic Method 
        static void GetFitForgeStatistics(
            int numberOfNewMembers,
            Dictionary<string, (string, int, string, int, int, double, int, string, int)> qualifyingMembersDict,
            Dictionary<string, (string, int, string, int, int, double, int, string, int)> nonQualifyingMembersDict
            )
        {
            Console.WriteLine("\nFitForge Statistics:");
            Console.WriteLine("--------------------");


            // Count statistics
            var (Qualifying, NonQualifying) = CountNumberOfMembers(qualifyingMembersDict, nonQualifyingMembersDict);
            int countQualifying = Qualifying;
            int countNonQualifying = NonQualifying;

            int total = Qualifying + NonQualifying;
            Console.WriteLine("\nTotal number of members:" +
                $"\n\t{total}");

            Console.WriteLine("\nNumber of members qualifying for Wellness Reward:" +
                $"\n\t{countQualifying}");

            Console.WriteLine("\nNumber of members not qualifying for Wellness Reward:" +
                $"\n\t{countNonQualifying}");

            // Number of new members
            Console.WriteLine("\nNumber of new members:" +
                $"\n\t{numberOfNewMembers}");
           
            
            // Percentage employed vs Unemployed 
            double numberUnemployed = 0;

            foreach (var member in nonQualifyingMembersDict)
            {
                if (member.Value.Item3 == "Unemployed")
                {
                    numberUnemployed++;
                }
            }

            double total2 = Convert.ToDouble(total);

            double percentage = (numberUnemployed/total2) * 100;
            Console.WriteLine("\nPercentage of Employed members:" +
                $"\n\t{(100 - percentage):F1}%");

            Console.WriteLine("\nPercentage of Unemployed members:" +
                $"\n\t{(percentage):F1}%");


            // Most popular smoothie flavour

            List<string> flavours = new List<string>();

            // Add flavours from qualifying members
            foreach (var member in qualifyingMembersDict.Values)
            {
                flavours.Add(member.Item8);
            }

            // Add flavours from non-qualifying members
            foreach (var member in nonQualifyingMembersDict.Values) // Assuming you have a separate dictionary
            {
                flavours.Add(member.Item8);
            }

            // most popular
            var mostPopularFlavours = flavours
                .GroupBy(item => item)
                .OrderByDescending(group => group.Count())
                .Where(group => group.Count() == flavours.GroupBy(i => i).Max(g => g.Count()))
                .Select(group => group.Key);

            Console.WriteLine("\nMost Popular Flavour/s:" +
                $"\n\t{string.Join(", ", mostPopularFlavours)}");

            // least popular
            var leastPopularFlavours = flavours
                .GroupBy(item => item)
                .OrderBy(group => group.Count()) 
                .Where(group => group.Count() == flavours.GroupBy(i => i).Min(g => g.Count())) 
                .Select(group => group.Key);

            Console.WriteLine("\nLeast Popular Flavour/s:" +
                $"\n\t{ string.Join(", ", leastPopularFlavours)}");

        }

        // Method to count number of members
        static (int QualifyingCount, int NonQualifyingCount) CountNumberOfMembers(
            Dictionary<string, (string, int, string, int, int, double, int, string, int)> qualifyingMembersDict,
            Dictionary<string, (string, int, string, int, int, double, int, string, int)> nonQualifyingMembersDict
            )
        {
            return (QualifyingCount: qualifyingMembersDict.Count, NonQualifyingCount: nonQualifyingMembersDict.Count);
        }

    }
}
