namespace TrainingPrep.collections
{
    public class Alternative<TItem> : ICriteria<TItem>
    {
        private readonly ICriteria<TItem> _criteria1;
        private readonly ICriteria<TItem> _criteria2;

        public Alternative(ICriteria<TItem> criteria1, ICriteria<TItem> criteria2)
        {
            _criteria1 = criteria1;
            _criteria2 = criteria2;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return _criteria1.IsSatisfiedBy(item) || _criteria2.IsSatisfiedBy(item);

        }
    }
}