using System;
using System.Linq;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;


public class d11
{
    public static List<string> input2 = new List<string>();
    public static void dayfunc()
    {
        string line;

        System.IO.StreamReader file = new System.IO.StreamReader(@"I:\ftp_kansio\Arttu\AdventOfCode\11.txt");
        while ((line = file.ReadLine()) != null)
        {
            input2.Add(line);
            Console.WriteLine(line);
        }
        file.Close();

        List<string> copy = new List<string>();
        copy = lineParse(input2);
        for (int i = 0; i < 140; i++)
        {
            if (copy == lineParse(copy))
                break;
            copy = lineParse(copy);
        }


        var count = 0;
        foreach (var z in copy)
        {
            Console.WriteLine(z);
            count += z.Count(x => x == '#');
        }
        Console.WriteLine(count);
    }

    public static List<string> lineParse(List<string> input)
    {
        List<string> copy = new List<string>();
        for (int i = 0; i < input.Count(); i++)
        {
            string block = "";


            for (var x = 0; x < input[i].Length; x++)
            {
                List<int[]> nbList = new List<int[]>();
                var neighbours = from z in Enumerable.Range(i - 1, 3)
                                 from y in Enumerable.Range(x - 1, 3)
                                 where z >= 0 && y >= 0 && z < input.Count() && y < input[0].Length
                                 select new { z, y };
                var count = 0;
                foreach (var u in neighbours.ToList())
                    if (input[u.z][u.y] == '#')
                        count++;
                char res = 'q';
                var o = i;
                var p = x;
                int[] arr = new int[3] { -1, 0, 1 };
                foreach (var di in arr)
                    foreach (var dj in arr)
                    {
                        while (res != '#')
                        {
                            if (o == 0 || o == input[0].Count() || p != 0 || p != input[0].Count())
                                o += di;
                            //if ()
                            p += dj;

                            res = input[o][p];

                            if (res == '#')
                                count++;

                        }
                    }


                if (input[i][x] == '#')
                    block += (count >= 5) ? "L" : "#";

                if (input[i][x] == '.')
                    block += ".";

                if (input[i][x] == 'L')
                    block += (count == 0) ? "#" : "L";
            }
            copy.Add(block);
            // Console.WriteLine(block);
        }
        return copy;
    }




}


