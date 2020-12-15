using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;


public class day6
{
    public static void dayfunc()
    {
        int count = 0;
        string line;
        bool flag = false;
        HashSet<char> yesSet = new HashSet<char>();
        System.IO.StreamReader file = new System.IO.StreamReader(@"I:\ftp_kansio\Arttu\AdventOfCode\input6.txt");
        while ((line = file.ReadLine()) != null)
        {

            if (line != "")
            {
                HashSet<char> ndSet = new HashSet<char>();
                for (var i = 0; i < line.Length; i++)
                    ndSet.Add(line[i]);

                if (!flag)
                    for (var i = 0; i < line.Length; i++)
                        yesSet.Add(line[i]);

                flag = true;
                yesSet.IntersectWith(ndSet);
            }
            else
            {
                count += yesSet.Count();
                yesSet.Clear();
                flag = false;
            }
        }
        file.Close();
        Console.WriteLine("Total: " + count);
    }

}
