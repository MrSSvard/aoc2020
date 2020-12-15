using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using Microsoft.Win32.SafeHandles;

namespace _4._1
{
    class Passport
    {
        string byr;
        string iyr;
        string eyr;
        string hgt;
        string hcl;
        string ecl;
        string pid;
        string cid; //Optional

        public bool IsValid()
        {
            return (byr != null && iyr != null && eyr != null
                && hgt != null && hcl != null && ecl != null && pid != null);
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
                        byr = attribute[1];
                        break;
                    case "iyr":
                        iyr = attribute[1];
                        break;
                    case "eyr":
                        eyr = attribute[1];
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


                Console.WriteLine(validPassports);
            }
        }
    }
}
