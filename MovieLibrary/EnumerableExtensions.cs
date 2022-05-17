using System.Collections.Generic;
using TrainingPrep.collections;

public static class EnumerableExtensions
{
    public static IEnumerable<T> OneAtATime<T>(this IEnumerable<T> colection)
    {
        foreach (var item in colection)
        {
            yield return item;
        }
    }
}