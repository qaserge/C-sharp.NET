using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07Travel
{
    class Trip
    {
        // TODO: implement getters and setters with verification
        public string Destanation;
        public string Name;
        public string PassportInfo;
        public string DepartTime;
        public string ReturnTime;
                
        public override string ToString()
        {
            return $"{Name} ({PassportInfo}) to {Destanation} ({DepartTime}-{ReturnTime})";
        }

        public static bool IsDestanationValid(string destanation)
        {
            // NEWBIE solution:
            // if (name.Length < 1 || name.Length > 50) return false; else return true;
            return destanation.Length >= 2 && destanation.Length <= 30 && !destanation.Contains(";");
        }

        public static bool IsNameValid(string name)
        {
            // NEWBIE solution:
            // if (name.Length < 1 || name.Length > 50) return false; else return true;
            return name.Length >= 2 && name.Length <= 30 && !name.Contains(";");
        }

        //public static bool IsAgeValid(int age)
        //{
        //    return age >= 1 && age <= 150;
        //}

        //public static bool IsAgeValid(string ageStr)
        //{
        //    bool result = int.TryParse(ageStr, out int age);
        //    if (!result) return false;
        //    return IsAgeValid(age);
        //}
    }
}
