using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Data;
using MoreLinq;
using System.Linq;

public class d13
{
    public static long res = 0;
    public static Dictionary<int, int> dict = new Dictionary<int, int>();
    public static Dictionary<int, long> dict2 = new Dictionary<int, long>();
    public static List<long> paired = new List<long>();
    public static List<int> todo = new List<int>();

    public static List<int> diff = new List<int>();
    public static void dayfunc()
    {
        string line;
        string[] data = { };


        System.IO.StreamReader file = new System.IO.StreamReader(@"I:\ftp_kansio\Arttu\AdventOfCode\13.txt");
        while ((line = file.ReadLine()) != null)
            data = line.Split(",");
        file.Close();

        int i = 0; int z = 0;
        foreach (var x in data)
        {
            if (x != "x")
            {
                dict.Add(Int32.Parse(x), Int32.Parse(x));
                dict2.Add(Int32.Parse(x), Int64.Parse(x));

                diff.Add(i - z);
                z = i;
            }
            i++;
        }

        foreach (var y in dict)
            todo.Add(y.Key);

        foreach (var y in diff)
            Console.Write(y + " ");

        increment();
        // increment();

        foreach (var y in dict2)
            Console.WriteLine(y);

        return;
    }


    public static void increment()
    {

        for (int v = 0; v < todo.Count - 1; v++)
        {
            int c = diff[v + 1];
            int key1 = dict[todo[v]];
            int key2 = dict[todo[v + 1]];

            long val1 = dict2[key1];
            long val2 = dict2[key2];

            while (val2 - val1 != c)
            {
                if (val2 - val1 < c)
                    val2 += dict2[key2];
                else
                    val1 += dict2[key1];

            }
            paired.Add(val1);

            if (v + 2 == todo.Count)
                paired.Add(val2);

        }

        for (int q = 0; q < todo.Count; q++)
        {
            dict2[todo[q]] = paired[q];
        }

        paired.Clear();

    }

    public static void increment2(int a, int b, int c)
    {

        var inc1 = a;
        var inc2 = b;

        while (b - a != c)
        {
            if (b - a < c)
                b += inc2;
            else
                a += inc1;

        }
        Console.WriteLine(a + "  " + b + " " + lcm(inc1, inc2));
        //euraavassa siten etta ratkaisu voi olla ainoastaan hetkilla 335, 469 + 365, 2 * 469 + 365, 3 * 469 + 365 jne

        ;

    }


    static long gcf(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    static long lcm(long a, long b)
    {
        return (a / gcf(a, b)) * b;
    }
}


