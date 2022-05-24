using System;
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

    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> items, Predicate<TItem> condition)
    {
        return items.ThatSatisfy(new AnonymousCriteria<TItem>(condition));
    }

    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> items, ICriteria<TItem> criteria)
    {
        foreach (var item in items)
        {
            if (criteria.IsSatisfiedBy(item))
            {
                yield return item;
            }
        }
    }
}