using System;
using System.Linq;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;


public class d15
{
    public static List<string[]> input = new List<string[]>();
    public static Dictionary<int, int> dict = new Dictionary<int, int>();
    public static List<int> numbers = new List<int>();

    public static void dayfunc()
    {
        string line;
        string[] data = { };

        System.IO.StreamReader file = new System.IO.StreamReader(@"I:\ftp_kansio\Arttu\AdventOfCode\15.txt");
        while ((line = file.ReadLine()) != null)
        {
            data = line.Split(",");
            input.Add(data);
        }
        file.Close();
        int i = 0;

        foreach (var y in input[0])
        {
            i++;
            numbers.Add(Int32.Parse(y));
        }
        dict.Add(0, 1);
        dict.Add(14, 2);
        dict.Add(1, 3);
        dict.Add(3, 4);
        dict.Add(7, 5);
        //dict.Add(9, 6);
        //0,14,1,3,7,9
        int n = 30000000;
        for (int turn = 5; turn < n; turn++)
        {
            if (dict.ContainsKey(numbers[turn]))
            {
                numbers.Add(turn + 1 - dict[numbers[turn]]);
                dict[numbers[turn]] = turn + 1;
            }
            else
            {
                numbers.Add(0);
                dict.Add(numbers[turn], turn + 1);
            }
        }
        Console.WriteLine(numbers[n - 1]);

    }


}


