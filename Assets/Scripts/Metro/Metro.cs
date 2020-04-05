using System;
using System.Collections.Generic;
using UnityEngine;

public class Metro
{
    private readonly List<Station> points;
    private readonly Dictionary<Station, List<Tuple<Station, Line>>> edges;
    public const int MAX = 2147483647;

    public Metro(List<Station> points, Dictionary<Station, List<Tuple<Station, Line>>> edges)
    {
        this.points = points;
        this.edges = edges;
    }

    public (List<Tuple<Station, Line>>, int) Find(Station start, Station finish)
    {
        Queue<Station> queue = new Queue<Station>();
        Dictionary<Station, List<Tuple<Station, Line>>> paths = new Dictionary<Station, List<Tuple<Station, Line>>>();
        int minTransfers = MAX;
        Station current = start;

        queue.Enqueue(current);
        paths[current] = new List<Tuple<Station, Line>>();

        while (queue.Count != 0)
        {
            current = queue.Dequeue();
            if (paths.ContainsKey(finish))
            {
                if (paths[finish].Count == paths[current].Count)
                {
                    return (paths[finish], minTransfers);
                }
            }

            foreach (var edge in edges[current])
            {
                var path = new List<Tuple<Station, Line>>(paths[current]); path.Add(edge);
                if (edge.Item1 == finish) 
                {
                    if (!paths.ContainsKey(finish))
                    {
                        paths.Add(edge.Item1, path);
                        minTransfers = CountTransfers(path);
                        continue;
                    }
                    else 
                    {
                        if (minTransfers > CountTransfers(path))
                        { 
                            paths[edge.Item1] = path;
                            minTransfers = CountTransfers(path);
                            continue;
                        }
                    }
                }
                if (!paths.ContainsKey(edge.Item1))
                {
                    paths.Add(edge.Item1, path);
                    queue.Enqueue(edge.Item1);
                }
            }
        }

        return (paths[finish], minTransfers);
    }

    public static int CountTransfers(List<Tuple<Station, Line>> path)
    {
        if (path.Count < 2)
            return 0;

        int number = 0;
        for (int i = 1; i < path.Count; i++)
        {
            if (path[i - 1].Item2 != path[i].Item2)
            {
                number++;
            }
        }
        return number;
    }

    public enum Line
    {
        Red = 0,
        Blue = 1,
        Green = 2,
        Black = 3,
        White = 3,
        Pink = 3,
        Yellow = 3,
    }

    public enum Station
    {
        A = 0,
        B = 1,
        C = 2,
        D = 3,
        E = 4,
        F = 5,
        G = 6,
        H = 7,
        I = 8,
        J = 9,
        K = 10,
        L = 11,
        M = 12,
        N = 13,
        O = 14,
        P = 15,
        Q = 16,
        R = 17,
        S = 18,
        T = 19,
        U = 20,
        V = 21,
        W = 22,
        X = 23,
        Y = 24,
        Z = 25,
    }
}

