using System;
using System.Collections.Generic;
using TrainingPrep.collections;
using Machine.Specifications;
using TrainingPrep.specs.MovieLibrarySpecs;


/* The following set of Contexts (TestFixture) are in place to specify the functionality that you need to complete for the MovieLibrary class.
 * MovieLibrary is an aggregate root for the Movie class. it exposes the ability to search,sort, and iterate over all of the movies that it aggregates.
 */

namespace TrainingPrep.specs
{
    namespace MovieLibrarySpecs
    {
        public abstract class movie_library_concern 
        {
            protected static IList<Movie> movie_collection;
            protected static MovieLibrary subject;

            private Establish context = () =>
            {
                movie_collection = new List<Movie>();

                subject = new MovieLibrary(movie_collection);
            };
        } ;

        [Subject(typeof(MovieLibrary))]
        public class when_counting_the_number_of_movies : movie_library_concern
        {
            static int number_of_movies;

            Establish context = () =>
                movie_collection.add_all(new Movie(), new Movie());

            Because of = () =>
                number_of_movies = subject.all_movies().CountAll();

            It should_return_the_number_of_all_movies_in_the_library = () =>
                number_of_movies.ShouldEqual(2);
        }

        [Subject(typeof(MovieLibrary))]
        public class when_asked_for_all_of_the_movies : movie_library_concern
        {
            static Movie first_movie;
            static Movie second_movie;
            static IEnumerable<Movie> all_movies;

            Establish context = () =>
            {
                first_movie = new Movie();
                second_movie = new Movie();

                movie_collection.add_all(first_movie, second_movie);
            };

            Because of = () => { all_movies = subject.all_movies(); };

            It should_receive_a_set_containing_each_movie_in_the_library = () =>
                all_movies.ShouldContainOnly(first_movie, second_movie);
        }
        
        [Subject(typeof(MovieLibrary))]
        public class when_adding_a_movie_to_the_library : movie_library_concern
        {
            static Movie movie;

            Establish context = () => movie = new Movie();

            Because of = () =>
                subject.add(movie);

            It should_store_it_in_the_movie_collection = () =>
            {
                subject.all_movies().ShouldContainOnly(movie);
            };
        }

        [Ignore("Will be implemented next")]
        [Subject(typeof(MovieLibrary))]
        public class when_adding_an_existing_movie_in_the_collection_again : movie_library_concern
        {
            static Movie movie;

            Establish context = () =>
            {
                movie = new Movie();
                movie_collection.Add(movie);
            };

            Because of = () =>
                subject.add(movie);

            It should_not_restore_the_movie_in_the_collection = () =>
                subject.all_movies().CountAll().ShouldEqual(1);
        }

        [Ignore("Will be implemented next")]
        [Subject(typeof(MovieLibrary))]
        public class when_adding_two_different_copies_of_the_same_movie : movie_library_concern
        {
            static Movie another_copy_of_speed_racer;
            static Movie speed_racer;

            Establish context = () =>
            {
                speed_racer = new Movie { title = "Speed Racer" };
                another_copy_of_speed_racer = new Movie { title = "Speed Racer" };
                movie_collection.Add(speed_racer);
            };

            Because of = () =>
                subject.add(another_copy_of_speed_racer);

            It should_store_only_1_copy_in_the_collection = () =>
                subject.all_movies().CountAll().ShouldEqual(1);
        }
    }
}