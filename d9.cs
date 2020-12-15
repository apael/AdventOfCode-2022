using System;
using System.Linq;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;


public class d9
{
    static long count = 0;

    public static void dayfunc()
    {
        bool found = false;
        string line;
        long[] data = { };
        List<long> input = new List<long>();

        System.IO.StreamReader file = new System.IO.StreamReader(@"I:\ftp_kansio\Arttu\AdventOfCode\9.txt");
        while ((line = file.ReadLine()) != null)
            input.Add(Int64.Parse(line));
        file.Close();

        for (int i = 0; i < input.Count(); i++)
        {
            found = false;
            var range = input.GetRange(i, input.Count() - i);

            foreach (var x in range)
                foreach (var y in range)
                    if (x + y == input[i + 25])
                    {
                        found = true;
                        break;
                    }
            if (!found)
                Console.WriteLine(input[i + 25] + " part1");

            int z = 0;
            count = 0;
            foreach (var x in range)
            {
                count += x; z++;
                if (count > 41682220)
                    break;
                if (count == 41682220)
                    Console.WriteLine(input.GetRange(i, z).Max() + input.GetRange(i, z).Min() + " part2");

            }
        }
    }
}


