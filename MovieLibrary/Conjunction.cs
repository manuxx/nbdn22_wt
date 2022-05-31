namespace TrainingPrep.collections
{
    public class Conjunction<TItem> : BinaryCriteria<TItem>
    {
        public Conjunction(ICriteria<TItem> criteria1, ICriteria<TItem> criteria2) : base(criteria1, criteria2)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return _criteria1.IsSatisfiedBy(item) && _criteria2.IsSatisfiedBy(item);
        }
    }
}