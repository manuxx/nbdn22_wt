using System;
using TrainingPrep.collections;

public interface ICriteria<TItem>
{
    bool IsSatisfiedBy(TItem item);

    ICriteria<TItem> And(ICriteria<TItem> second)
    {
        return new Conjunction<TItem>(this, second);
    }
}