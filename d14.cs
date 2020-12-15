using System;
using System.Linq;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;


public class d14
{
    public static List<string[]> input = new List<string[]>();
    public static Dictionary<string, long> mem = new Dictionary<string, long>();

    public static void dayfunc()
    {
        string line;
        string[] data = { };

        System.IO.StreamReader file = new System.IO.StreamReader(@"I:\ftp_kansio\Arttu\AdventOfCode\14.txt");
        while ((line = file.ReadLine()) != null)
        {
            data = line.Split(" = ");
            if (data[0] != "mask")
            {
                // mem.Add(Regex.Match(data[0], @"[0-9]*").Value, Int32.Parse(data[1]));
                data[1] = ToBinary(Int32.Parse(data[1].Trim()));

            }
            input.Add(data);

        }
        file.Close();


        string mask = "";
        foreach (var y in input)
        {
            if (y[0].Trim() == "mask")
            {
                mask = y[1];

            }
            else
            {

                // foreach (var y in input)

                var id = y[0];

                char[] buff = new char[36];

                long count = 0;
                for (int i = 35; i >= 0; i--)
                {

                    if (mask[35 - i] == 'X')
                        buff[35 - i] = y[1][35 - i];
                    if (mask[35 - i] == '0')
                        buff[35 - i] = '0';
                    if (mask[35 - i] == '1')
                        buff[35 - i] = '1';

                    count += (long)Math.Pow(2 * (buff[35 - i] - '0'), i);
                    Console.WriteLine(2 * (buff[35 - i] - '0') + " pow " + i + " res " + (long)Math.Pow(2 * (buff[35 - i] - '0'), i));

                }
                // Console.WriteLine(count);
                // Console.WriteLine(y[1]);



                if (buff[0] == '0')
                    count--;

                if (buff[0] == '1')
                    count++;

                if (mem.ContainsKey(id))
                    mem[id] = count;
                else
                    mem.Add(id, count);
            }

        }
        // foreach (var y in mem)
        //  Console.WriteLine(y);

        var total = mem.Sum(v => v.Value);
        Console.WriteLine(total + " total " + mem.Count);
    }

    public static string ToBinary(int myValue)
    {
        string binVal = Convert.ToString(myValue, 2);
        int bits = 0;
        int bitblock = 36;

        for (int i = 0; i < binVal.Length; i = i + bitblock)
        { bits += bitblock; }

        return binVal.PadLeft(bits, '0');
    }
}


