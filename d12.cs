using System;
using System.Linq;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;


public class d12
{
    public static int count;
    public static Dictionary<string, int> dict = new Dictionary<string, int>();
    public static Dictionary<string, int> dict2 = new Dictionary<string, int>();

    public static List<string[]> input = new List<string[]>();



    public static void dayfunc()
    {
        string line;
        string[] data = { };
        List<string[]> input = new List<string[]>();
        data = new string[2] { "E", "10" };
        input.Add(data);
        data = new string[2] { "N", "1" };
        input.Add(data);

        System.IO.StreamReader file = new System.IO.StreamReader(@"I:\ftp_kansio\Arttu\AdventOfCode\12.txt");
        while ((line = file.ReadLine()) != null)
        {

            data = new string[2] { line.Substring(0, 1), line.Substring(1) };
            // Console.WriteLine(data[0] + "  " + data[1]);
            input.Add(data);

        }
        file.Close();
        dict.Add("N", 0);
        dict.Add("S", 0);
        dict.Add("E", 0);
        dict.Add("W", 0);
        dict2.Add("N", 0);
        dict2.Add("S", 0);
        dict2.Add("E", 0);
        dict2.Add("W", 0);
        int[] arr = new int[4] { 0, 90, 180, 270 };
        string[] compass = new string[4] { "N", "E", "S", "W" };


        foreach (var x in input)
        {
            if (x[0] != "L" && x[0] != "R")
                if (x[0] != "F")
                    dict2[x[0]] += Int32.Parse(x[1]);
                else
                {
                    int nAxis = (dict2["N"] - dict2["S"]) * Int32.Parse(x[1]);
                    int eAxis = (dict2["E"] - dict2["W"]) * Int32.Parse(x[1]);

                    if (nAxis >= 0)
                        dict["N"] += nAxis;
                    else
                        dict["S"] += Math.Abs(nAxis);

                    if (eAxis >= 0)
                        dict["E"] += eAxis;
                    else
                        dict["W"] += Math.Abs(eAxis);
                }

            Dictionary<string, int> dict3 = new Dictionary<string, int>();

            if (x[0] == "R")
            {
                foreach (var z in dict2)
                    dict3.Add(compass[(Array.IndexOf(compass, z.Key) + Array.IndexOf(arr, Int32.Parse(x[1]))) % 4], z.Value);
                dict2 = dict3;
            }
            if (x[0] == "L")
            {
                foreach (var z in dict2)
                    dict3.Add(compass[((Array.IndexOf(compass, z.Key) + 4) - Array.IndexOf(arr, Int32.Parse(x[1]))) % 4], z.Value);
                dict2 = dict3;
            }
        }
        foreach (var y in dict)
            Console.WriteLine(y);

        Console.WriteLine(dict["N"] - dict["S"] + dict["E"] - dict["W"]);

    }

}


