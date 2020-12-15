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
            dict.Add(Int32.Parse(y), i);
        }
        int turn = 0;
        while (turn != 2020)
        {


            if (dict.ContainsKey(numbers[turn]))
            {
                numbers.Add(numbers[turn] - dict[numbers[turn]]);
            }
            else
            {
                numbers.Add(0);

                dict[0] = turn + 1;
            }


        }


    }


}


