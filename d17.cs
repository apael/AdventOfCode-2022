using System;
using System.Linq;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;


public class d17
{
    public static int n = 32;

    public static string[,,,] input = new string[n, n, n, n];
    public static string[,,,] copyInput = new string[n, n, n, n];

    public static void dayfunc()
    {
        string line;
        var q = 0;
        System.IO.StreamReader file = new System.IO.StreamReader(@"I:\ftp_kansio\Arttu\AdventOfCode\17.txt");
        while ((line = file.ReadLine()) != null)
            for (int i = 0; i < line.Length; i++)
            {
                input[n / 2 + i, n / 2 + q, n / 2, n / 2] = line[i].ToString();
                copyInput[n / 2 + i, n / 2 + q, n / 2, n / 2] = line[i].ToString();
            }
        q++;

        file.Close();

        for (var x = 0; x < 6; x++)
        {
            lineParse();
            input = copyInput.Clone() as string[,,,];

        }
        var count = 0;
        foreach (var x in input)
            if (x == "#")
                count++;

        Console.WriteLine(count);
        return;
    }

    public static void lineParse()
    {
        for (int tAxis = 1; tAxis < n - 1; tAxis++)
            for (int zAxis = 1; zAxis < n - 1; zAxis++)
                for (int xAxis = 1; xAxis < n - 1; xAxis++)
                    for (var yAxis = 1; yAxis < n - 1; yAxis++)
                    {
                        var nb = countNeighbours(xAxis, yAxis, zAxis, tAxis);
                        if (input[xAxis, yAxis, zAxis, tAxis] == null)
                            copyInput[xAxis, yAxis, zAxis, tAxis] = ".";

                        if (input[xAxis, yAxis, zAxis, tAxis] == "#")
                        {
                            if (nb != 2 && nb != 3)
                                copyInput[xAxis, yAxis, zAxis, tAxis] = ".";
                        }
                        else
                            if (nb == 3)
                            copyInput[xAxis, yAxis, zAxis, tAxis] = "#";

                    }

    }

    public static int countNeighbours(int xAxis, int yAxis, int zAxis, int tAxis)
    {
        var activePieces = 0;
        int[] arr = new int[3] { -1, 0, 1 };
        foreach (var ti in arr)
            foreach (var xi in arr)
                foreach (var yi in arr)
                    foreach (var zi in arr)
                    {
                        if (xi == 0 && zi == 0 && yi == 0 && ti == 0)
                            continue;
                        if (input[xAxis + xi, yAxis + yi, zAxis + zi, tAxis + ti] == "#")
                            activePieces++;

                    }
        return activePieces;
    }
}





