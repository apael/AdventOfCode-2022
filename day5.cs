
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;

public class day5
{
    public static void dayfunc()
    {
        string line;
        int row, column, highestSeat = 0, backSeat = 0;
        List<int> allSeats = new List<int>();
        System.IO.StreamReader file = new System.IO.StreamReader(@"I:\ftp_kansio\Arttu\AdventOfCode\input5.txt");
        while ((line = file.ReadLine()) != null)
        {
            row = findSeat(line.Substring(0, 7), 127, 0, 'F');
            column = findSeat(line.Substring(7, 3), 7, 0, 'L');
            allSeats.Add(row * 8 + column);
            if (row * 8 + column > highestSeat)
                highestSeat = row * 8 + column;
        }
        file.Close();

        allSeats.Sort();
        foreach (var x in allSeats)
        {
            if (x - 2 == backSeat)
                Console.WriteLine(x - 1 + " is my seat ");
            backSeat = x;
        }
        Console.WriteLine(highestSeat + "is last id");

        static int findSeat(string path, int max, int min, char a)
        {
            if (path.Length > 1)
                if (path[0] == a)
                    max = (max + min) / 2;
                else
                    min = (max + min) / 2 + 1;
            else
                return (path[0] == a) ? min : max;
            return findSeat(path.Substring(1), max, min, a);
        }
    }



}