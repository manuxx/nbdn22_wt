using System;
using System.Collections.Generic;

namespace TrainingPrep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return new ReadOnlySet<Movie>(movies);
        }

        public void add(Movie movie)
        {
            foreach (var m in movies)
            {
                if (m.title==movie.title)
                {
                    return;
                }
            }
            movies.Add(movie);
        }
        public IEnumerable<Movie> sort_all_movies_by_title_descending()
        {
            var ret = new List<Movie>(movies);
            ret.Sort((m1, m2) => (-1) * m1.title.CompareTo(m2.title));
            return ret;
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            return movies.ThatSatisfy(IsPublishedBy(ProductionStudio.Pixar));
        }

        private static Predicate<Movie> IsPublishedBy(ProductionStudio productionStudio)
        {
            return movie => movie.production_studio == productionStudio;
        }


        public IEnumerable<Movie> all_kid_movies()
        {
            return movies.ThatSatisfy(IsOfGenre(Genre.kids));
                
        }

        private static Predicate<Movie> IsOfGenre(Genre genre)
        {
            return movie => movie.genre == genre;
        }

        public IEnumerable<Movie> all_action_movies()
        {
            return movies.ThatSatisfy(IsOfGenre( Genre.action));
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            return movies.ThatSatisfy(IsPublishedAfter(year));
        }

        private static Predicate<Movie> IsPublishedAfter(int year)
        {
            return movie => movie.date_published.Year > year;
        }

        public IEnumerable<Movie> all_movies_published_between_years(int yearFrom, int YearTo)
        {
            return movies.ThatSatisfy(IsPublishedBetween(yearFrom, YearTo));
        }

        private static Predicate<Movie> IsPublishedBetween(int yearFrom, int YearTo)
        {
            return movie => movie.date_published.Year >= yearFrom && movie.date_published.Year <= YearTo;
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            return movies.ThatSatisfy(movie =>
                movie.production_studio == ProductionStudio.Pixar ||
                movie.production_studio == ProductionStudio.Disney);
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            return movies.ThatSatisfy(IsNotPublishedBy(ProductionStudio.Pixar));
        }

        private static Predicate<Movie> IsNotPublishedBy(ProductionStudio productionStudio)
        {
            return movie => movie.production_studio != productionStudio;
        }

        public IEnumerable<Movie> all_kid_movies_published_after(int year)
        {
            return movies.ThatSatisfy(movie => movie.genre == Genre.kids && movie.date_published.Year > year);
        }

        public IEnumerable<Movie> all_horror_or_action()
        {
            return movies.ThatSatisfy(movie => movie.genre == Genre.horror || movie.genre == Genre.action);
        }
    }
}