using System;
using System.Collections;
using System.Linq;

namespace TrainingPrep.collections
{
    public class Movie : IEquatable<Movie>
    {
        public bool Equals(Movie other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return title == other.title;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Movie)obj);
        }

        public override int GetHashCode()
        {
            return (title != null ? title.GetHashCode() : 0);
        }

        public static bool operator ==(Movie left, Movie right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Movie left, Movie right)
        {
            return !Equals(left, right);
        }

        public string title { get; set; }
        public ProductionStudio production_studio { get; set; }
        public Genre genre { get; set; }
        public int rating { get; set; }
        public DateTime date_published { get; set; }

        public static ICriteria<Movie> IsPublishedBy(ProductionStudio productionStudio)
        {
            return new PublishedCriteria(productionStudio);
        }


        public static ICriteria<Movie> IsPublishedAfter(int year)
        {
            return new PublishedAfterCriteria(year);
        }

        public static ICriteria<Movie> IsPublishedBetween(int yearFrom, int YearTo)
        {
            return new PublishedBetweenCriteria(yearFrom,YearTo);
        }

        public static Predicate<Movie> IsNotPublishedBy(ProductionStudio productionStudio)
        {
            return movie => movie.production_studio != productionStudio;
        }

        public static ICriteria<Movie> IsAnyOfGenre(params Genre[] genres)
        {
            return new GenreCriteria(genres);
        }

    }

    public class GenreCriteria : ICriteria<Movie>
    {
        private readonly Genre[] _genres;

        public GenreCriteria(Genre[] genres)
        {
            _genres = genres;
        }

        public bool IsSatisfiedBy(Movie movie)
        {
            return ((IList)_genres).Contains(movie.genre);
        }
    }

    public class PublishedBetweenCriteria : ICriteria<Movie>
    {
        private readonly int _yearFrom;
        private readonly int _yearTo;

        public PublishedBetweenCriteria(int yearFrom, int yearTo)
        {
            _yearFrom = yearFrom;
            _yearTo = yearTo;
        }

        public bool IsSatisfiedBy(Movie item)
        {
            return item.date_published.Year >= _yearFrom && item.date_published.Year <= _yearTo;
        }
    }

    public class PublishedAfterCriteria : ICriteria<Movie>
    {
        private readonly int _year;

        public PublishedAfterCriteria(int year)
        {
            _year = year;
        }

        public bool IsSatisfiedBy(Movie movie)
        {
            return movie.date_published.Year > _year;
        }
    }

    public class PublishedCriteria : ICriteria<Movie>
    {
        private readonly ProductionStudio _productionStudio;

        public PublishedCriteria(ProductionStudio productionStudio)
        {
            _productionStudio = productionStudio;
        }

        public bool IsSatisfiedBy(Movie movie)
        {
            return movie.production_studio == _productionStudio;

        }
    }
}