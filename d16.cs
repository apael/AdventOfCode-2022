using System;
using System.Linq;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;


public class d16
{
    public static List<string[]> input = new List<string[]>();
    public static Dictionary<string, string[]> dict = new Dictionary<string, string[]>();
    public static HashSet<string> fields = new HashSet<string>();
    public static Dictionary<int, List<string>> dict2 = new Dictionary<int, List<string>>();

    public static void dayfunc()
    {
        string[] myTicket = "191,89,73,139,71,103,109,53,97,179,59,67,79,101,113,157,61,107,181,137".Split(",");
        string line = "";
        string[] data = { };

        System.IO.StreamReader file = new System.IO.StreamReader(@"I:\ftp_kansio\Arttu\AdventOfCode\16.txt");
        while ((line = file.ReadLine()) != null)
        {
            if (!Regex.IsMatch(line, @"\b[0-1][0-9]\b|\b[2][0-7]\b|\b[9][7][5-9]\b|\b[9][8-9][0-9]\b|\b[0-9]\b"))
            {
                data = line.Split(",");
                input.Add(data);
            }

        }


        //Console.WriteLine(input.Count);

        file.Close();
        for (var i = 0; i < 20; i++)
            dict2.Add(i, new List<string>());

        System.IO.StreamReader file2 = new System.IO.StreamReader(@"I:\ftp_kansio\Arttu\AdventOfCode\test2.txt");
        while ((line = file2.ReadLine()) != null)
        {
            line = Regex.Replace(line, @"\b or \b|-", ",");
            data = line.Split(":");
            dict.Add(data[0], data[1].Split(","));

        }
        file2.Close();
        var z = 0;

        while (z < 20)
        {
            foreach (var x in dict)
            {
                var min = Int32.Parse(x.Value[0]);
                var minb = Int32.Parse(x.Value[2]);
                var max = Int32.Parse(x.Value[1]);
                var maxb = Int32.Parse(x.Value[3]);
                var q = 0;
                for (int i = 0; i < input.Count; i++)
                {
                    var nmbr = Int32.Parse(input[i][z]);
                    if ((nmbr >= min && nmbr <= max) || (nmbr >= minb && nmbr <= maxb))
                    {
                        if (i == input.Count - 1 && i == q)
                        {
                            // Console.WriteLine("element: " + x.Key + " column: " + z);
                            dict2[z].Add(x.Key);
                            break;
                        }
                        q++;
                    }
                }
            }
            z++;
        }
        var t = 1;
        long count = 1;
        while (t < 21)
        {
            foreach (var x in dict2)
            {
                if (x.Value.Count == t)
                {
                    foreach (var q in fields)
                        x.Value.Remove(q);
                    // Console.WriteLine("column:" + x.Key + " First element: " + x.Value[0]);
                    fields.Add(x.Value[0]);
                    if (x.Value[0].StartsWith("departure"))
                        count *= Int32.Parse(myTicket[x.Key]);
                }
            }
            t++;
        }
        Console.WriteLine(count);
    }
}