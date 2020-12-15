using System;
using System.Linq;
using System.Text.RegularExpressions;


public class day4
{
    public static void day4func()
    {
        int count = 0;
        string line;
        string tempLine = "";
        System.IO.StreamReader file = new System.IO.StreamReader(@"I:\ftp_kansio\Arttu\AdventOfCode\input4.txt");
        while ((line = file.ReadLine()) != null)
        {
            tempLine += line + " ";

            if (line == "")
            {
                var passport = tempLine.Split(" ");
                passport = passport.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                if (passport.Length == 8)
                    if (isValid2(passport))
                        count++;

                if (passport.Length == 7)
                    if (isValid(passport))
                        count++;

                tempLine = "";
            }
        }
        file.Close();
        Console.WriteLine(count);
    }

    public static Boolean isValid(string[] passport)
    {
        foreach (var data in passport)
            if (data.Split(":")[0] == "cid")
                return false;

        return isValid2(passport);
    }
    public static Boolean isValid2(string[] passport)
    {
        foreach (var d in passport)
        {
            var data = d.Split(":");
            if (data[0] == "hcl" && !Regex.IsMatch(data[1], @"#[a-f0-9]{6}"))
                return false;
            if (data[0] == "byr" && (Int32.Parse(data[1]) < 1920 || Int32.Parse(data[1]) > 2002))
                return false;
            if (data[0] == "iyr" && (Int32.Parse(data[1]) < 2010 || Int32.Parse(data[1]) > 2020))
                return false;
            if (data[0] == "eyr" && (Int32.Parse(data[1]) < 2020 || Int32.Parse(data[1]) > 2030))
                return false;
            if (data[0] == "hgt" && !Regex.IsMatch(data[1], @"1[5-8][0-9]cm|19[0-3]cm|59in|6[0-9]in|7[0-6]in"))
                return false;
            if (data[0] == "ecl" && !Regex.IsMatch(data[1], @"amb|blu|brn|gry|grn|hzl|oth"))
                return false;
            if (data[0] == "pid" && !Regex.IsMatch(data[1], @"^[0-9]{9}$"))
                return false;
        }
        return true;
    }
}
