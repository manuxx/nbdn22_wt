using System.Collections.Generic;
using TrainingPrep.collections;

public static class EnumerableExtensions
{
    public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> colection)
    {
        foreach (var item in colection)
        {
            yield return item;
        }
    }
}