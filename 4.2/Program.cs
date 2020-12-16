using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using Microsoft.Win32.SafeHandles;

namespace _4._2
{
    class Passport
    {
        int byr;
        int iyr;
        int eyr;
        string hgt;
        string hcl;
        string ecl;
        string pid;
        string cid; //Optional

        public bool IsValid()
        {
            var validity = true;

            if (!(1920 <= byr && byr <= 2003))
            {
                validity = false;
            }

            if (!(2010 <= iyr && iyr <= 2020))
            {
                validity = false;
            }

            if (!(2020 <= eyr && eyr <= 2030))
            {
                validity = false;
            }

            if (!IsHgtValid(hgt))
            {
                validity = false;
            }

            if (!IsHclValid(hcl))
            {
                validity = false;
            }

            if (!IsEclValid(ecl))
            {
                validity = false;
            }

            if (!IsPidValid(pid))
            {
                validity = false;
            }


            return validity;
        }

        private bool IsPidValid(string pid)
        {
            if (pid == null)
            {
                return false;
            }
            if (pid.Length == 9)
            {
                Int64 eclNr = Convert.ToInt64(pid);
                return true;
            }
            return false;
        }

        private bool IsEclValid(string ecl)
        {
            string[] allowedValues = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            var validity = false;

            if (ecl == null)
            {
                return false;
            }

            foreach (string value in allowedValues)
            {
                if (value == ecl)
                {
                    validity = true;
                }
            }
            return validity;
        }

        private bool IsHgtValid(string hgt)
        {
            var validity = false;
            Int32 hgtValue;

            if (hgt == null)
            {
                return false;
            }

            if (hgt.EndsWith("cm"))
            {
                hgt = hgt.Replace("cm", "");
                try
                {
                    hgtValue = Convert.ToInt32(hgt);
                }
                catch
                {
                    Console.WriteLine(hgt + " was not in the right hgt format");
                    return false;
                }
                if (150 <= hgtValue && hgtValue <= 193)
                {
                    validity = true;
                }
            }
            else if (hgt.EndsWith("in"))
            {
                hgt = hgt.Replace("in", "");
                try
                {
                    hgtValue = Convert.ToInt32(hgt);
                }
                catch
                {
                    Console.WriteLine(hgt + " was not in the right hgt format");
                    return false;
                }
                if (59 <= hgtValue && hgtValue <= 76)
                {
                    validity = true;
                }
            }

            return validity;
        }

        private bool IsHclValid(string hcl)
        {
            var validity = false;
            var charList = "0123456789abcdef";

            if (hcl == null)
            {
                return false;
            }

            if (hcl.StartsWith("#") && hcl.Length == 7)
            {
                hcl = hcl.Remove(0, 1);
                var charValidity = true;
                foreach (char character in hcl)
                {
                    if (!charList.Contains(character))
                    {
                        charValidity = false;
                    }
                }
                validity = charValidity;
            }

            return validity;
        }

        public Passport(string sequence)
        {
            string[] pairs = sequence.Split(" ");

            foreach (string pair in pairs)
            {
                string[] attribute = pair.Split(":");

                switch (attribute[0])
                {
                    case "byr":
                        byr = Convert.ToInt32(attribute[1]);
                        break;
                    case "iyr":
                        iyr = Convert.ToInt32(attribute[1]);
                        break;
                    case "eyr":
                        eyr = Convert.ToInt32(attribute[1]);
                        break;
                    case "hgt":
                        hgt = attribute[1];
                        break;
                    case "hcl":
                        hcl = attribute[1];
                        break;
                    case "ecl":
                        ecl = attribute[1];
                        break;
                    case "pid":
                        pid = attribute[1];
                        break;
                    case "cid":
                        cid = attribute[1];
                        break;
                }
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fileStream = new FileStream("input/input.txt", FileMode.Open, FileAccess.Read);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                string line;
                var validPassports = 0;
                string attributesString = "";
                Passport passport;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line == "")
                    {
                        passport = new Passport(attributesString.TrimStart());
                        attributesString = "";
                        if (passport.IsValid())
                        {
                            validPassports++;
                        }
                    }
                    else
                    {
                        attributesString += " " + line;
                    }
                }
                passport = new Passport(attributesString.TrimStart());
                if (passport.IsValid())
                {
                    validPassports++;
                }


                Console.WriteLine(validPassports + "\n");
            }
        }
    }
}
