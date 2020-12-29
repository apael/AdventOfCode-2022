using System;
using System.Linq;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;


public class d20
{
    public static int count;
    public static Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
    public static Dictionary<int, string> dict2 = new Dictionary<int, string>();
    public static List<string> input = new List<string>();
    public static HashSet<string> matches = new HashSet<string>();
    public static void dayfunc()
    {

        string line = "";
        string lineAll = "";
        string[] data = { };
        System.IO.StreamReader file = new System.IO.StreamReader(@"I:\ftp_kansio\Arttu\AdventOfCode\20.txt");
        while ((line = file.ReadLine()) != null)
        {
            lineAll += line + "\n";

        }
        // Console.WriteLine(lineAll);
        data = lineAll.Split("\n\n");

        file.Close();

        foreach (var x in data)
        {

            var splitData = x.Split("\n");

            dict.Add(splitData[0], new List<string>());
            matches.Add(splitData[0]);
            dict[splitData[0]].Add(splitData[1]);
            dict[splitData[0]].Add(splitData[10]);
            line = "";
            lineAll = "";
            for (int y = 1; y < splitData.Length - 1; y++)
            {
                line += splitData[y][0].ToString();
                lineAll += splitData[y][9].ToString();

            }

            dict[splitData[0]].Add(line);
            dict[splitData[0]].Add(lineAll);


        }

        foreach (var x in dict)
        {
            findmatch(x.Value, x.Key);

        }
        foreach (var b in matches)
            Console.WriteLine(b);
    }


    public static void findmatch(List<string> side, string key)
    {
        List<string> asd = new List<string>();
        int[] arr = new int[4] { 0, 1, 2, 3 };


        var Revcount = 0;

        var count = 0;
        foreach (var v in arr)
            foreach (var x in dict)
            {
                if (key != x.Key)
                    if (x.Value.Contains(Reverse(side[v])))
                        if (isMatch(Reverse(side[(v + 1) % 4])))
                        {
                            //  Console.WriteLine(key + "matches " + side[(v + 1) % 4] + " and " + side[v]);

                            count++;
                        }

            }
        if (count != 1)
        {
            matches.Remove(key);
        }
        //Console.WriteLine(" matches to" + key);

        count = 0;
        foreach (var v in arr)
            foreach (var x in dict)
            {
                if (key != x.Key)
                    if (x.Value.Contains(side[v]))
                        if (isMatch(side[(v + 1) % 4]))
                        {
                            //Console.WriteLine(key + "matches " + side[(v + 1) % 4] + " and " + side[v]);

                            count++;
                        }

            }
        if (count != 1)
            matches.Remove(key);
    }

    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
    public static bool isMatch(string row)
    {
        foreach (var x in dict)
            if (x.Value.Contains(row))
                return true;
        return false;
    }

}