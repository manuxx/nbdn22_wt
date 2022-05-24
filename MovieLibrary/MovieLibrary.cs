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
            foreach (var movie in movies)
            {
                if (movie.production_studio == ProductionStudio.Pixar)
                {
                    yield return movie;
                }
            }
        }



        public IEnumerable<Movie> all_kid_movies()
        {
            return   OnlyThatSatisfy(movie => movie.genre == Genre.kids);
                
        }

        private IEnumerable<Movie> OnlyThatSatisfy(Predicate<Movie> condition)
        {
            foreach (var movie in movies)
            {
                if (condition(movie))
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> all_action_movies()
        {
            return OnlyThatSatisfy(movie => movie.genre == Genre.action);
        }

        public IEnumerable<Movie> all_movies_published_after(int i)
        {
            return OnlyThatSatisfy(movie => movie.date_published.Year > i);
        }

        public IEnumerable<Movie> all_movies_published_between_years(int i, int i1)
        {
            return OnlyThatSatisfy(movie => movie.date_published.Year >= i && movie.date_published.Year <= i1);
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            return OnlyThatSatisfy(movie =>
                movie.production_studio == ProductionStudio.Pixar ||
                movie.production_studio == ProductionStudio.Disney);
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            return OnlyThatSatisfy(movie => movie.production_studio != ProductionStudio.Pixar);
        }

        public IEnumerable<Movie> all_kid_movies_published_after(int i)
        {
            return OnlyThatSatisfy(movie => movie.genre == Genre.kids && movie.date_published.Year > i);
        }

        public IEnumerable<Movie> all_horror_or_action()
        {
            return OnlyThatSatisfy(movie => movie.genre == Genre.horror || movie.genre == Genre.action);
        }
    }
}