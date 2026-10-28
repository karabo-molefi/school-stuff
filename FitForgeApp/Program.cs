using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitForgeApp
{
    internal class Program
    {
        enum Menu
        {
            CaptureMemberDetails = 1,
            CheckWellnessRewardQualification,
            DisplayAllQualifyingMembers,
            ShowFitForgeStats,
            GetMemberReport,
            Exit
        }

        // global variables

        static Dictionary<string, (string, int, string, int, int, double, int, string, int)> qualifyingMembersDict = 
            new Dictionary<string, (
                string Name,
                int Age,
                string EmploymentStatus,
                int MembershipRank,
                int NumberOfYearsActive,
                double TreadmillRecord,
                int TotalSmoothiesPurchased,
                string FavouriteSmoothieFlavour,
                int AverageSmoothieConsumption
                )>
            {
                ["MEM0001"] = ("Thabo", 23, "Employed", 5750, 4, 50.5, 75, "Strawberry Stinger", 12),
                ["MEM0002"] = ("Cindy", 16, "Employed", 3000, 2, 36.0, 25, "C-Breeze", 5),
                ["MEM0004"] = ("John", 57, "Employed", 500, 2, 25.5, 14, "Banana Bliss", 5),
                ["MEM0006"] = ("Sipho", 34, "Employed", 3200, 6, 45.5, 60, "Strawberry Stinger", 18),
                ["MEM0008"] = ("Aisha", 28, "Employed", 1900, 3, 22.5, 80, "Banana Bliss", 6)
            };

        static Dictionary<string, (string, int, string, int, int, double, int, string, int)> nonQualifyingMembersDict =
            new Dictionary<string, (
                string Name,
                int Age,
                string EmploymentStatus,
                int MembershipRank,
                int NumberOfYearsActive,
                double TreadmillRecord,
                int TotalSmoothiesPurchased,
                string FavouriteSmoothieFlavour,
                int AverageSmoothieConsumption
                )>
            {
                ["MEM0003"] = ("Katy", 26, "Unemployed", 2700, 3, 312.9, 104, "Banana Bliss", 32),
                ["MEM0005"] = ("Zanele", 29, "Employed", 4000, 5, 80.0, 90, "ChocoChurned Chaos", 21),
                ["MEM0007"] = ("Lesedi", 21, "Unemployed", 1500, 1, 5.5, 10, "ChocoChurned Chaos", 2),
                ["MEM0009"] = ("Jason", 40, "Employed", 2100, 3, 15.5, 300, "Mango Madness", 25),
                ["MEM0010"] = ("Lebo", 17, "Unemployed", 2200, 2, 19.5, 35, "C-Breeze", 5),
            };
        
        static int numberOfMembersCaptured = 0;
        
        static void Main(string[] args)
        {
            //Console.BackgroundColor = ConsoleColor.White;
            //Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            bool active = true;
            while (active)
            {
                Console.Clear();
                Console.WriteLine("FITFORGE MENU");
                Console.WriteLine("======================================");
                Console.WriteLine("1. Capture Member Details");
                Console.WriteLine("2. Check Wellness Reward Qualification");
                Console.WriteLine("3. Display All Qualifying Members");
                Console.WriteLine("4. Show FitForge Stats");
                Console.WriteLine("5. Get Member Report");
                Console.WriteLine("6. Exit");
                Console.Write("Please select an option (1-6): ");

                switch ((Menu)int.Parse(Console.ReadLine()))
                {
                    case Menu.CaptureMemberDetails:
                        CaptureMemeberDetails();
                        break;
                    case Menu.CheckWellnessRewardQualification:
                        CheckRewardQualification(true); // bool true displays a message
                        break;
                    case Menu.DisplayAllQualifyingMembers:
                        DisplayQualifyingMembers();
                        break;
                    case Menu.ShowFitForgeStats:
                        ShowStats();
                        break;
                    case Menu.GetMemberReport:
                        MemberReport();
                        break;
                    case Menu.Exit:
                        Console.WriteLine("Exiting...");
                        active = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static (bool, bool, string) CheckRewardQualification(bool displayStatus)// check if member qualifies by searching
        {
            Console.Clear();
            // ask for search term (name/ membership number)
            Console.Write("Enter member's name or membership number: ");
            string userInput = Console.ReadLine();

            // initialise variables getting returned:
            string memberKey = "";
            bool validMember = false;
            bool qualifies = false;

            // intialise name
            string name = "";

            // list for all the found search results:
            List<string> resultsFound = new List<string>();

            // iterate through dictionary and check if they qualify
            foreach (var member in qualifyingMembersDict)
            {
                if (userInput.ToLower().Contains(member.Key.ToLower()) || userInput.ToLower() == member.Value.Item1.ToLower())
                {
                    memberKey = member.Key;
                    name = member.Value.Item1;
                    validMember = true;
                    resultsFound.Add(memberKey);
                }
            }

            // if they werent found in qualifying check in non-qualifying or display not found

            foreach (var member in nonQualifyingMembersDict)
            {
                if (userInput.ToLower().Contains(member.Key.ToLower()) || userInput.ToLower() == member.Value.Item1.ToLower())
                {
                    memberKey = member.Key;
                    name = member.Value.Item1;
                    validMember = true;
                    resultsFound.Add(memberKey);
                }
            }

            // if more than 1 result was found (memebers with the same name) ask for specific memeber
            if (resultsFound.Count > 1)
            {
                Console.WriteLine($"Found {resultsFound.Count} results for {name}");

                for (int i = 0; i < resultsFound.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {name}, ({resultsFound[i]})"); // write each found memeber name and membership number
                }

                int choice;

                while (true)
                {
                    Console.Write($"Please enter the number of the member in the list only (1-{resultsFound.Count}): ");

                    if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= resultsFound.Count)
                    {
                        break; // valid input, exit loop
                    }

                    Console.WriteLine($"Invalid input. Please enter a valid number (1-{resultsFound.Count}).");
                }

                memberKey = resultsFound[choice-1]; // update the key to the chosen person

            }

            // update qualifies bool member
            if (qualifyingMembersDict.ContainsKey(memberKey))
            {
                qualifies = true;
            }

            // bool display status true will run this block
            if (displayStatus)
            {
                if (validMember)
                {
                    if (qualifies)
                    {
                        Console.WriteLine($"\n{name} ({memberKey}): Qualifies.");
                    }
                    else
                    {
                        Console.WriteLine($"\n{name} ({memberKey}): Does not qualify.");
                    }

                }
            }

            // not a valid memebr
            if (!validMember)
            {
                Console.WriteLine("\nNot found! Please try again.");
            }

            if (displayStatus)
            {
                Console.ReadKey();
            }

            return (validMember, qualifies, memberKey);
        }

        static Dictionary<string, (string, int, string, int, int, double, int, string, int)> CaptureMemeberDetails()
        {
            
            var newMembers = new Dictionary<string, (string, int, string, int, int, double, int, string, int)>(); 
            var allNewMembers = new Dictionary<string, (string, int, string, int, int, double, int, string, int)>(); // collection to return


            bool isactive = true; // bool for while loop

            while (isactive)
            {
                Console.Clear();
                Console.WriteLine("Personal Details");
                Console.WriteLine("----------------");

                Console.Write("Name: ");
                string name = Console.ReadLine();

                while (!name.All(char.IsLetter))
                {
                    Console.Write("Invalid input. Please enter a valid Name: ");
                    name = Console.ReadLine();
                }


                int age;
                Console.Write("Age: ");
                while(!int.TryParse(Console.ReadLine(), out age))
                {
                    Console.Write("Invalid input. Please enter a valid number for Age: ");
                }

                if (age < 18)
                {
                    Console.Write("Guardian Employment Status (Employed/e) or (Unemployed/u): ");
                }
                else
                {
                    Console.Write("Employment Status (Employed/e) or (Unemployed/u): ");
                }
                string employmentStatus = (Console.ReadLine());


                while (!employmentStatus.All(char.IsLetter))
                {
                    Console.Write("Invalid. Please enter (Employed/e) or (Unemployed/u): ");
                    employmentStatus = Console.ReadLine();
                }

                while (!(employmentStatus.ToLower() == "employed" || employmentStatus.ToLower() == "e" ||employmentStatus.ToLower() == "unemployed" || employmentStatus.ToLower() == "u"))
                {
                    Console.Write("Invalid input. Please enter (Employed/e) or (Unemployed/u): ");
                    employmentStatus = Console.ReadLine();
                }

                if (employmentStatus.StartsWith("e"))
                {
                    employmentStatus = "Employed";
                }
                else if (employmentStatus.StartsWith("u"))
                {
                    employmentStatus = "Unemployed";
                }
                
                Console.Clear(); // done entering personal details

                Console.WriteLine("Membership Details");
                Console.WriteLine("-------------------");


                // automatically assign membership number
                // get number of current members and add 1
                string membershipNumber;

                int memberNumber = qualifyingMembersDict.Count + nonQualifyingMembersDict.Count + 1;
                
                if (memberNumber < 100)
                {
                    membershipNumber = $"MEM00{memberNumber}";
                }
                else
                {
                    membershipNumber = $"MEM0{memberNumber}";
                }

                int membershipRank, numberOfYearsActive;
                double treadmillRecord;

                Console.Write("Membership Rank: ");
                while (!int.TryParse(Console.ReadLine(), out membershipRank))
                {
                    Console.Write("Invalid input. Please enter a valid integer for Membership Rank: ");
                }

                Console.Write("Number of Years Active: ");
                while (!int.TryParse(Console.ReadLine(), out numberOfYearsActive))
                {
                    Console.Write("Invalid input. Please enter a valid integer for Number of Years Active: ");
                }

                Console.Write("Treadmill Record (use comma for decimals): ");
                while (!double.TryParse(Console.ReadLine(), out treadmillRecord))
                {
                    Console.Write("Invalid input. Please enter a valid number in the form (#,#) for Treadmill Record: ");
                }

                Console.Clear();
            
                string favouriteSmoothieFlavour = "";
                //int smoothieNumber;

                bool active = true; // bool for while loop to repromt for invalid choices

                while (active)
                {
                    // display smoothies
                    Console.WriteLine("Smoothie Flavours:");
                    Console.WriteLine("------------------");

                    string[] smoothieFlavours = { "Mango Madness", "Banana Bliss", "C-Breeze", "Strawberry Stinger", "ChocoChurned Chaos" };

                    for (int i = 0; i < smoothieFlavours.Length; i++)
                    {
                        Console.WriteLine($"{i+1}. {smoothieFlavours[i]}");
                    }

                    Console.Write("Favourite Smoothie Flavour (name or number 1-5): ");
                    favouriteSmoothieFlavour = Console.ReadLine();

                    if (smoothieFlavours.Any(s => s.Equals(favouriteSmoothieFlavour, StringComparison.OrdinalIgnoreCase)))
                    {
                        active = false;
                    }
                    else
                    {
                        try
                        {
                            int smoothieNumber = Convert.ToInt32(favouriteSmoothieFlavour);

                            // Ensure the number is within valid range
                            if (smoothieNumber >= 1 && smoothieNumber <= smoothieFlavours.Length)
                            {
                                favouriteSmoothieFlavour = smoothieFlavours[smoothieNumber - 1];
                                active = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Number. Please enter a number between 1 and 5.");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Invalid Choice. Please enter a valid smoothie name or number.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                                      
                }

                Console.Write("Number of Smoothies Purchased: ");
                int numberOfSmoothiesPurchased = int.Parse(Console.ReadLine());

                Console.Write("Average Smoothie Consumption: ");
                int averageSmoothieConsumption = int.Parse(Console.ReadLine());

                // add new member to collection
                newMembers[membershipNumber] = (
                    name, age, employmentStatus, 
                    membershipRank, numberOfYearsActive, 
                    treadmillRecord, numberOfSmoothiesPurchased, 
                    favouriteSmoothieFlavour, averageSmoothieConsumption
                    );

                Console.Clear();
                
                if (ProcessNewMemberQualification(newMembers)) 
                {
                    // add to global qualifying dict
                    foreach (var member in newMembers)
                    {
                        qualifyingMembersDict[member.Key] = member.Value;
                        Console.WriteLine($"\n{member.Value.Item1} ({member.Key}): qualifies for the Wellness Reward!");
                    }
                }
                else
                {
                    // add to global non-qualifying dict
                    foreach (var member in newMembers)
                    {
                        nonQualifyingMembersDict[member.Key] = member.Value;
                        Console.WriteLine($"\n{member.Value.Item1} ({member.Key}): does not qualify for the Wellness Reward.");
                    }
                }

                

                Console.WriteLine("\nCaptured Successfully!\n"); // display success message
                numberOfMembersCaptured++;

                foreach (var member in newMembers)
                {
                    allNewMembers.Add(member.Key, member.Value);
                }

                newMembers.Clear();

                Console.Write("Do you want to enter another applicant? (yes/no): "); // ask if they want to continue adding

                while (true)
                {
                    string choice = Console.ReadLine();
                    choice = choice.ToLower();

                    if (choice == "y" || choice == "yes")
                    {
                        break;
                    }
                    else if (choice == "n" || choice == "no")
                    {
                        Console.WriteLine("Capturing Complete.");
                        isactive = false; // bool for main while loop
                        break;
                    }
                    else
                    {
                        Console.Write("Invalid option. Enter (yes/no): ");
                        continue;
                    } 
                }
            }

            return (allNewMembers);
        }

        static void DisplayQualifyingMembers()
        {
            Console.Clear();
            Console.WriteLine($"   Name: \tMembership number");
            Console.WriteLine("-----------------------------------");
            int i = 1;
            foreach (var member in qualifyingMembersDict)
            {
                Console.WriteLine($"{i}. {member.Value.Item1} \t{member.Key}");
                i++;
            }

            Console.ReadKey();
            Console.Clear();
        }

        static int Count(Dictionary<string, (string, int, string, int, int, double, int, string, int)> input)
        {
            int count = input.Count;
            return count;
        }

        static void ShowStats()
        {
            Console.Clear();

            int totalNumberOfMembers = Count(qualifyingMembersDict) + Count(nonQualifyingMembersDict);

            // Percentage employed vs Unemployed 
            double numberUnemployed = 0;
            foreach (var member in nonQualifyingMembersDict)
            {
                if (member.Value.Item3 == "Unemployed")
                {
                    numberUnemployed++;
                }
            }
            double doubleTotalNumberOfMembers = Convert.ToDouble(totalNumberOfMembers);
            double percentage = numberUnemployed / doubleTotalNumberOfMembers * 100;
            string percentageEmployed = $"{100 - percentage:F1}%";
            string percentageUnemployed =  $"{percentage:F1}%";

            // percentage adult vs minor members

            double numberMinorMembers = 0.0;

            foreach (var member in qualifyingMembersDict.Values)
            {
                if (member.Item2 < 18)
                {
                    numberMinorMembers++;
                }
            }

            foreach (var member in nonQualifyingMembersDict.Values)
            {
                if (member.Item2 < 18)
                {
                    numberMinorMembers++;
                }
            }
            double percentageMinorMembers = (numberMinorMembers / doubleTotalNumberOfMembers) * 100;
            string percentageMinor = $"{percentageMinorMembers:F1}%";

            string percentageAdult = $"{100 - percentageMinorMembers:F1}%";


            // range of mambership rank for new members (1-2 years) and older members
            List<int> oldMemberRanking = new List<int>();
            List<int> newMemberRanking = new List<int>();

            // separate new and old members
            foreach (var member in qualifyingMembersDict)
            {
                if (member.Value.Item5 > 2)
                {
                    oldMemberRanking.Add(member.Value.Item4);
                }
                else
                {
                    newMemberRanking.Add(member.Value.Item4);
                }
            }

            foreach (var member in nonQualifyingMembersDict)
            {
                if (member.Value.Item5 > 2)
                {
                    oldMemberRanking.Add(member.Value.Item4);
                }
                else
                {
                    newMemberRanking.Add(member.Value.Item4);
                }
            }

            oldMemberRanking.Sort();
            newMemberRanking.Sort();

            // range of mambership rank for new members (1-2 years) 
            var rangeOldMemberRanking = $"{oldMemberRanking[0]} to {oldMemberRanking[oldMemberRanking.Count - 1]}";
            // range of membership rank for older members (2+ years)
            var rangeNewMemberRanking = $"{newMemberRanking[0]} to {newMemberRanking[newMemberRanking.Count - 1]}";

            // most popular smoothie flavours
            // list of all smoothie flavours
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
                .Select(group => group.Key
                );
          
            string mostPopularFlavour = $"{string.Join(", ", mostPopularFlavours)}";


            // least popular
            var leastPopularFlavours = flavours
                .GroupBy(item => item)
                .OrderBy(group => group.Count())
                .Where(group => group.Count() == flavours.GroupBy(i => i).Min(g => g.Count()))
                .Select(group => group.Key);

            string leastPopularFlavour = $"{string.Join(", ", leastPopularFlavours)}";

            // other smoothie statistics
            double combinedTreadmillRecord = 0.0;
            int totalSmoothiesPurchased = 0;
            int averageSmoothiesPurchasedMonthly = 0;
            double numberOfSmoothieAddictions = 0.0;
            double numberOfUnhealthyFavouriteFlavour = 0.0;

            
            foreach (var member in qualifyingMembersDict.Values)
            {
                combinedTreadmillRecord += member.Item6;
                totalSmoothiesPurchased += member.Item7;
                averageSmoothiesPurchasedMonthly += member.Item9;
            }

            foreach (var member in nonQualifyingMembersDict.Values)
            {
                combinedTreadmillRecord += member.Item6;
                totalSmoothiesPurchased += member.Item7;
                averageSmoothiesPurchasedMonthly += member.Item9;
                if (member.Item9 > 20)
                {
                    numberOfSmoothieAddictions+=1;
                }
                if (member.Item8.Equals("ChocoChurned Chaos"))
                {
                    numberOfUnhealthyFavouriteFlavour+=1;
                }
            }

            // percentage of members with smoothie addictions:
            double percentageSmoothieAddiction = ((numberOfSmoothieAddictions / doubleTotalNumberOfMembers) * 100);
            string percentageMembersWithSmoothieAddiction = $"{(percentageSmoothieAddiction):F1}%";

            // percentage of members who's favourite flavour is unhealthy
            double percentageUnhealthyFavouriteFlavour = ((numberOfUnhealthyFavouriteFlavour / doubleTotalNumberOfMembers) * 100);
            string percentageMembersWithUnhealthyFavouriteFlavour = $"{(percentageUnhealthyFavouriteFlavour):F1}%";

            // displaying all stats in table form
            Console.WriteLine(new string('=', 75)); // Top divider

            Console.WriteLine("| {0,-50} | {1,18} |", "MEMBER DATA", "VALUE");
            Console.WriteLine("|" + new string('-', 52) + "|--------------------|");

            Console.WriteLine("| {0,-50} | {1,18} |", "Total number of members", totalNumberOfMembers);
            Console.WriteLine("| {0,-50} | {1,18} |", "Members Qualifying for Wellness Rewards", qualifyingMembersDict.Count);
            Console.WriteLine("| {0,-50} | {1,18} |", "Members NOT Qualifying for Wellness Rewards", nonQualifyingMembersDict.Count);
            Console.WriteLine("| {0,-50} | {1,18} |", "Number of New Members Captured", numberOfMembersCaptured); // new members captured not new members by years active
            Console.WriteLine("| {0,-50} | {1,18} |", "% Adult Members (Age 18+)", percentageAdult);
            Console.WriteLine("| {0,-50} | {1,18} |", "% Minor Members", percentageMinor);
            Console.WriteLine("| {0,-50} | {1,18} |", "% Employed Members", percentageEmployed);
            Console.WriteLine("| {0,-50} | {1,18} |", "% Unemployed Members", percentageUnemployed);
            Console.WriteLine("| {0,-50} | {1,18} |", "Combined Treadmill Record (km)", combinedTreadmillRecord);
            Console.WriteLine("| {0,-50} | {1,18} |", "Membership Rank Points Range (1-2 years active) ", rangeNewMemberRanking);
            Console.WriteLine("| {0,-50} | {1,18} |", "Membership Rank Points Range (2+ years active) ", rangeOldMemberRanking);

            Console.WriteLine(new string('=', 75)); // Section divider

            Console.WriteLine("| {0,-50} | {1,18} |", "SMOOTHIE DATA", "VALUE");
            Console.WriteLine("|" + new string('-', 52) + "|--------------------|");

            Console.WriteLine("| {0,-50} | {1,18} |", "Most Popular Smoothie Flavour", mostPopularFlavour);
            Console.WriteLine("| {0,-50} | {1,18} |", "Least Popular Smoothie Flavour", leastPopularFlavour);
            Console.WriteLine("| {0,-50} | {1,18} |", "% Members With Unhealthy Smoothie Addiction", percentageMembersWithSmoothieAddiction);
            Console.WriteLine("| {0,-50} | {1,18} |", "% Members Favourite Flavour is Unhealthy", percentageMembersWithUnhealthyFavouriteFlavour);
            Console.WriteLine("| {0,-50} | {1,18} |", "Average Smoothies Purchased Monthly", averageSmoothiesPurchasedMonthly);
            Console.WriteLine("| {0,-50} | {1,18} |", "Total Smoothies Purchased", totalSmoothiesPurchased);

            Console.WriteLine(new string('=', 75)); // Bottom divider

            Console.ReadKey();
       
        }

        static bool ProcessNewMemberQualification(Dictionary<string, (string , int, string, int, int, double, int, string, int)> input)
        {
            bool qualifies = false;
            foreach (var member in input)
            {
                if (
                    member.Value.Item3 == "Employed" && // must be employed
                    member.Value.Item5 >= 2 && // be a member for 2 or more years
                    (member.Value.Item4 >= 2000 || member.Value.Item6 >= 20.0) && // good ranking or treadmill record 
                    (member.Value.Item9 > 3 && member.Value.Item9 <= 20) && // healthy average smoothies consumed
                    member.Value.Item8 != "ChocoChurned Chaos" // not bad flavour
                )
                {
                    qualifies = true;
                }
            }

            return qualifies;
        }

        static void MemberReport()
        {
            // search for member without printing  
            var (boolvalidMember, boolMemeberQualifies, memberKey) = CheckRewardQualification(false); // bool false allows search only functinality

            // declare tuple to get member detailsfrom the dictionary
            (string Name, int Age, string EmploymentStatus, int MembershipRank, int NumberOfYearsActive, double TreadmillRecord, int , string FavouriteSmoothieFlavour, int AverageSmoothieConsumption) memberValues;

            memberValues = ("", 0, "", 0, 0, 0, 0, "", 0); // initialise tuple with temporary member details

            List<string> strengths = new List<string>();
            List<string> improvementAreas = new List<string>();


            while (boolvalidMember) 
            {
                Console.Clear();
                string membershipNumber = memberKey;

                if (!boolMemeberQualifies) 
                {
                    foreach (var n in nonQualifyingMembersDict.Values)
                    {
                        memberValues = nonQualifyingMembersDict[membershipNumber]; // getting tuple of details/ values from dict
                    }
                }
                else
                {
                    memberValues = qualifyingMembersDict[membershipNumber];
                }
   

                // Evaluating criteria
                if (memberValues.EmploymentStatus == "Employed")
                    strengths.Add("Good employment status (Employed).");
                else if (memberValues.EmploymentStatus == "Unemployed")
                {
                    if (memberValues.Age < 18)
                    {
                        improvementAreas.Add("Guardian is currently unemployed. Please improve employment status.");
                    }
                    else
                    {
                        improvementAreas.Add("Currently unemployed. Please improve employment status.");
                    }
                }
                

                if (memberValues.NumberOfYearsActive == 2)
                {
                    strengths.Add("Good number of years as a member (2 years).");
                }
                else if (memberValues.NumberOfYearsActive > 2)
                {
                    strengths.Add("Long-term member (2+ years).");
                }
                else
                {
                    improvementAreas.Add($"Be a member for at least{2 - memberValues.NumberOfYearsActive} more year(s).");
                }


                if (memberValues.MembershipRank >= 2000 && memberValues.MembershipRank < 5000)
                {
                    strengths.Add($"Good membership rank ({memberValues.MembershipRank} points).");
                }
                else if (memberValues.MembershipRank >= 5000)
                {
                    strengths.Add($"High membership rank ({memberValues.MembershipRank} points).");
                }
                else
                {
                    int improvementMetric = 2000 - memberValues.MembershipRank;
                    improvementAreas.Add($"Low membership rank ({memberValues.MembershipRank} points). Improve by at least {improvementMetric} points.");
                }

                if (memberValues.TreadmillRecord >= 20.0 && memberValues.TreadmillRecord < 100.0)
                {
                    strengths.Add($"Good treadmill record ({memberValues.TreadmillRecord}km).");

                }
                else if (memberValues.TreadmillRecord >= 100.0)
                {
                    strengths.Add($"Excellent treadmill record ({memberValues.TreadmillRecord}km).");
                }
                else
                {
                    double improvementMetric = 20.00 - memberValues.TreadmillRecord;
                    improvementAreas.Add($"Low treadmill record ({memberValues.TreadmillRecord}km). Improve by at least {improvementMetric}km ");
                }                   

                if (memberValues.AverageSmoothieConsumption < 4)
                {
                    improvementAreas.Add($"Low average smoothie intake ({memberValues.AverageSmoothieConsumption}). Please consume at least 4 smoothies per month.");

                }
                else if (memberValues.AverageSmoothieConsumption > 20)
                {
                    int improvementMetric = memberValues.AverageSmoothieConsumption - 20;
                    improvementAreas.Add($"Unhealthy average smoothie intake ({memberValues.AverageSmoothieConsumption}). Please decrease intake by at least {improvementMetric} smoothie(s).");
                }
                else if (memberValues.AverageSmoothieConsumption >= 17 && memberValues.AverageSmoothieConsumption < 20)
                {
                    improvementAreas.Add($"HIgh average smoothie intake ({memberValues.AverageSmoothieConsumption}). Warning: {20 - memberValues.AverageSmoothieConsumption} smoothies near the 20 smoothie limit.");
                }
                else
                {
                    strengths.Add($"Good monthly average smoothie intake ({memberValues.AverageSmoothieConsumption} smoothies).");
                }

                if (memberValues.FavouriteSmoothieFlavour == "ChocoChurned Chaos")
                {
                    improvementAreas.Add("Bad choice of  smoothie flavour \"ChocoChurned Chaos\". Please consider healthier alternatives.");
                }
                else
                {
                    strengths.Add($"Good choice of favourite smoothie flavor ({memberValues.FavouriteSmoothieFlavour}).");
                }


                Console.WriteLine("MEMBER REPORT:");
                Console.WriteLine("======================");
                Console.WriteLine($"{memberValues.Name.ToUpper()} ({membershipNumber})");

                // Display strengths
                Console.WriteLine("\nWhat You're Doing Well:");
                Console.WriteLine("-----------------------");

                if (strengths.Count == 0)
                    Console.WriteLine($"   Improvement Required In All Categegories.");
                else
                {
                    foreach (var strength in strengths)
                        Console.WriteLine($"   - {strength}");
                }
                   

                // Display improvement areas
      
                Console.WriteLine("\nAreas For Improvement:");
                Console.WriteLine("----------------------");
                if (improvementAreas.Count == 0)
                    Console.WriteLine($"   No Improvement Required. Well Done!");
                else
                {
                    foreach (var improvement in improvementAreas)
                    {
                        Console.WriteLine($"   - {improvement}");
                    }
                }

                Console.WriteLine("\nWellness Reward Qualification:");
                Console.WriteLine("------------------------------");
                if (boolMemeberQualifies)
                {
                    Console.WriteLine("Congrtatulations! You have met the requirements to qualify for the Wellness Reward.");
                }
                else
                {
                    Console.WriteLine("Unfortunately you have not met the requirements to qualify for the Wellness Reward.");
                }

                break;
            }

            Console.ReadKey();
   
        }
    }
}
