using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class Extensions
{
    private static System.Random rng = new System.Random();
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
public class Recursive : ProceduralGeneratedMaze
{
    public override void Generate()
    {
        Generate(5, 5);
    }

    public virtual void Generate(int x, int y)
    {
        if (Count4WayNeighbours(x, y) >= 2) return;
        m_Map[x, y] = 0;

        dir.Shuffle();

        Generate(x + dir[0].x, y + dir[0].y);
        Generate(x + dir[1].x, y + dir[1].y);
        Generate(x + dir[2].x, y + dir[2].y);
        Generate(x + dir[3].x, y + dir[3].y);
    }
}
