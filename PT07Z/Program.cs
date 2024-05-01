using System;
using System.Collections.Generic;

class Program
{
    static void BFS(int[] d, List<int>[] g, int n, int s)
    {
        for (int i = 0; i < n; i++)
        {
            d[i] = -1;
        }
        d[s] = 0;
        Queue<int> q = new Queue<int>();
        q.Enqueue(s);
        int v, u;
        while (q.Count > 0)
        {
            u = q.Dequeue();
            foreach (var it in g[u])
            {
                v = it;
                if (d[v] == -1)
                {
                    q.Enqueue(v);
                    d[v] = d[u] + 1;
                }
            }
        }
    }

    static void Main(string[] args)
    {
        int n, a, b;
        n = int.Parse(Console.ReadLine());
        List<int>[] g = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            g[i] = new List<int>();
        }
        for (int i = 0; i < n - 1; i++)
        {
            string[] input = Console.ReadLine().Split();
            a = int.Parse(input[0]);
            b = int.Parse(input[1]);
            g[a - 1].Add(b - 1);
            g[b - 1].Add(a - 1);
        }

        int[] d = new int[1000000];
        BFS(d, g, n, 0);
        int maxdis = -1, index = 0;
        for (int i = 0; i < n; i++)
        {
            if (d[i] > maxdis)
            {
                maxdis = d[i];
                index = i;
            }
        }
        BFS(d, g, n, index);
        maxdis = -1;
        for (int i = 0; i < n; i++)
        {
            if (d[i] > maxdis)
            {
                maxdis = d[i];
            }
        }
        Console.WriteLine(maxdis);
    }
}