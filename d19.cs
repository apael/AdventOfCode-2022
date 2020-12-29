using System;
using System.Linq;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;


public class d19
{
    public static int count;
    public static Dictionary<int, string> dict = new Dictionary<int, string>();
    public static Dictionary<int, string> dict2 = new Dictionary<int, string>();

    public static List<int> input = new List<int>();
    public static void dayfunc()
    {
        string line;
        string[] data = { };
        string[] temppData = { };
        System.IO.StreamReader file = new System.IO.StreamReader(@"I:\ftp_kansio\Arttu\AdventOfCode\14.txt");
        while ((line = file.ReadLine()) != null)
        {
            data = line.Split(":");
            dict.Add(Int32.Parse(data[0]), data[1]);

            if (data[0] == "0")
                temppData = data[1].Split(" ");

        }
        file.Close();

        foreach (var x in temppData)
            input.Add(Int32.Parse(x));

    }




}





