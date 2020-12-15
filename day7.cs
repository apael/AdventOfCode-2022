using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;


public class day7
{
    static int count = 0;

    public static void dayfunc()
    {
        string line;
        string[] data = { };
        List<string[]> ruleList = new List<string[]>(); ;
        HashSet<string> SSet = new HashSet<string>();

        Dictionary<string, int> bag = new Dictionary<string, int>();

        System.IO.StreamReader file = new System.IO.StreamReader(@"I:\ftp_kansio\Arttu\AdventOfCode\input7.txt");
        while ((line = file.ReadLine()) != null)
        {
            line = Regex.Replace(line, @"bags contain", ",");
            line = Regex.Replace(line, @"\.|bags", "");
            line = Regex.Replace(line, @"bag|\s+", "");
            data = line.Split(',');
            ruleList.Add(data);

            if (data[0] == "shinygold")
                for (var i = 1; i < data.Length; i++)
                {
                    bag.Add(data[i].Substring(1), Int32.Parse(data[i].Substring(0, 1)));
                    count += Int32.Parse(data[i].Substring(0, 1));
                }
        }
        file.Close();
        //count = SSet.Count();
        Console.WriteLine(count + "alku count");

        getGoldBag(ruleList, bag);
        // getMatchingColour(ruleList, SSet);
        Console.WriteLine("Total: " + count);
    }
    public static void getGoldBag(List<string[]> ruleList, Dictionary<string, int> bag)
    {
        int index = 0;
        foreach (var x in ruleList)
        {
            index++;
            if (bag.ContainsKey(x[0]))
            {
                // Console.WriteLine("index: " + index);
                for (var i = 1; i < x.Length; i++)
                {
                    if (bag.ContainsKey(x[i].Substring(1)) && x[i] != "noother")
                    {
                        bag[x[i].Substring(1)] += Int32.Parse(x[i].Substring(0, 1)) * bag[x[0]];
                        count += Int32.Parse(x[i].Substring(0, 1)) * bag[x[0]];
                    }
                    else if (x[i] != "noother")
                    {
                        bag.Add(x[i].Substring(1), bag[x[0]] * Int32.Parse(x[i].Substring(0, 1)));
                        count += bag[x[0]] * Int32.Parse(x[i].Substring(0, 1));
                        Console.WriteLine(count);
                    }
                }

                bag.Remove(x[0]);
            }
        }
        if (bag.Count() == 0)
            return;
        else
            getGoldBag(ruleList, bag);
    }

    public static void getMatchingColour(List<string[]> ruleList, HashSet<string> SSet)
    {
        foreach (var rule in ruleList)
            for (var i = 1; i < rule.Length; i++)
                if (SSet.Contains(rule[i]))
                    SSet.Add(rule[0]);

        if (count == SSet.Count())
            return;
        else
        {
            count = SSet.Count();
            getMatchingColour(ruleList, SSet);
        }
    }



}
