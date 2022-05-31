using TrainingPrep.collections;

static internal class CriteriaExtensions
{
    public static Alternative<Movie> Or(this ICriteria<Movie> criteria1, ICriteria<Movie> criteria2)
    {
        return new Alternative<Movie>(criteria1,
            criteria2);
    }

    public static Conjunction<Movie> And(this ICriteria<Movie> criteria1, ICriteria<Movie> criteria2)
    {
        return new Conjunction<Movie>(criteria1, criteria2);
    }
}