using System;
using System.Linq;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;


public class d8
{
    static int count = 0;

    public static void dayfunc()
    {
        string line;
        string[] data = { };
        List<string[]> cmdList = new List<string[]>();

        HashSet<int> SSet = new HashSet<int>();


        System.IO.StreamReader file = new System.IO.StreamReader(@"I:\ftp_kansio\Arttu\AdventOfCode\8.txt");
        while ((line = file.ReadLine()) != null)
        {
            line += " false";
            data = line.Split(' ');
            cmdList.Add(data);
        }

        for (int i = 0; i < cmdList.Count(); i++)
        {
            count = 0;
            if (cmdList[i][0] == "jmp" || cmdList[i][0] == "nop")
            {
                var copy = new List<string[]>();
                cmdList.ForEach(delegate (string[] page)
                {
                    copy.Add((string[])page.Clone());
                });

                if (copy[i][0] == "jmp")
                    copy[i][0] = "nop";
                else
                    copy[i][0] = "jmp";

                for (var x = 0; x < copy.Count();)
                {
                    x = GiveNewIndex(copy, x);
                    if (x == -1)
                        break;

                    if (x == copy.Count())
                        Console.WriteLine(count);
                }
            }
        }


        file.Close();
        // Console.WriteLine("Total: " + count);
    }

    public static int GiveNewIndex(List<string[]> cmdList, int i)
    {
        if (cmdList[i][2] == "true")
            return -1;

        cmdList[i][2] = "true";

        if (cmdList[i][0] == "acc")
            count += Int32.Parse(cmdList[i][1]);

        if (cmdList[i][0] == "jmp")
            return i += Int32.Parse(cmdList[i][1]);

        if (cmdList[i][0] == "nop")
            return i + 1;

        return i + 1;
    }
}


