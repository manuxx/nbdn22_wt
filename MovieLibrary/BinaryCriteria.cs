namespace TrainingPrep.collections
{
    public abstract class BinaryCriteria<TItem> : ICriteria<TItem>
    {
        protected ICriteria<TItem> _criteria1;
        protected ICriteria<TItem> _criteria2;

        public BinaryCriteria(ICriteria<TItem> criteria1, ICriteria<TItem> criteria2)
        {
            _criteria1 = criteria1;
            _criteria2 = criteria2;
        }

        public abstract bool IsSatisfiedBy(TItem item);
    }
}