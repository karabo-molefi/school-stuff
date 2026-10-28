using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckQualifying
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // membersDict[membershipNumber] = (name, age, membershipRank, numberOfYearsActive, numberOfSmoothiesPurchased, treadmillRecord, isEmployed, favouriteSmoothieFlavour, averageSmoothieConsumption,hasDependents,guardianMembershipNumber, childMembershipNumber);

            var membersDict = new Dictionary<string, (
                string Name,
                int Age,
                int Rank,
                int YearsActive,
                int SmoothiesPurchased,
                double TreadmillRecord,
                bool EmploymentStatus,
                string FavouriteFlavour,
                int AverageSmoothieConsumption,
                bool Dependents,
                string Guardian,
                string ChildDependent
            )>();

            membersDict["MEM001"] = ("Karabo", 21, 2001, 3, 10, 15, true, "C-Breeze", 5, false, null, null);
            membersDict["MEM002"] = ("Cindy", 41, 1001, 5, 15, 40, true, "Strawberry", 19, true, null, "MEM003");
            membersDict["MEM003"] = ("Katy", 16, 2500, 1, 5, 27, false, "Chocolate", 3, false, "MEM002", null);

            // employed or guardian is employed
            // 
            bool isEligiableForReward = false;

            foreach (var member in membersDict.Values)
            {

                if (
                    member.EmploymentStatus == true &&
                    member.YearsActive >= 2 &&
                    (member.Rank >= 2000 || member.TreadmillRecord >= 20) &&
                    (member.AverageSmoothieConsumption >= 4 && member.AverageSmoothieConsumption <= 20) &&
                    member.FavouriteFlavour != "ChocoChurned Chaos"
                )
                {
                    isEligiableForReward = true;
                }
                else
                {
                    isEligiableForReward = false;
                }

                Console.Write($"{member.Name}: ");
                Console.WriteLine(isEligiableForReward.ToString());
            }


        }
    }
}
