using System;
using System.Linq;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;


public class d10
{
    public static int count;
    public static Dictionary<int, long> dict = new Dictionary<int, long>();

    public static void dayfunc()
    {
        string line;
        long[] data = { };
        List<long> input = new List<long>();

        System.IO.StreamReader file = new System.IO.StreamReader(@"I:\ftp_kansio\Arttu\AdventOfCode\10.txt");
        while ((line = file.ReadLine()) != null)
            input.Add(Int64.Parse(line));
        file.Close();
        input.Add(input.Max() + 3);
        input.Add(0);

        input.Sort();
        count = input.Count();
        Console.WriteLine(recursiveFind(input, 0));

    }

    public static long recursiveFind(List<long> input, int i)
    {

        if (dict.ContainsKey(i))
            return dict[i];

        long res = 0;
        if (input.Max() == input[i])
            return 1;

        if (Regex.IsMatch((input[i + 1] - input[i]).ToString(), @"[123]"))
            res += recursiveFind(input, i + 1);

        if (count > i + 2)
            if (Regex.IsMatch((input[i + 2] - input[i]).ToString(), @"[123]"))
                res += recursiveFind(input, i + 2);

        if (count > i + 3)
            if (Regex.IsMatch((input[i + 3] - input[i]).ToString(), @"[123]"))
                res += recursiveFind(input, i + 3);
        dict[i] = res;
        return res;
    }


}


