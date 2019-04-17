using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ListExtension
{
    public static void Shuffle<T>(this IList<T> list)
    {
        for (var i = 0; i < list.Count - 1; i++)
            list.Swap(i, Random.Range(i, list.Count));
    }

    public static void Swap<T>(this IList<T> list, int i, int j)
    {
        var temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }
}
