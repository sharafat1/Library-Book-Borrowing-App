using System;
using System.Collections.Generic;
using System.Text;

namespace assign_cab301
{
    public class Movie
    {
        /**
         * This class is a public class and will display or model a movies object or blueprint.
         * Which will be used in this console application to allow the users view movie details etc.
         * 
         * This class will use the below class members/fields/methods.
         */

        //Some of the members of this class
        private int movieAvailableCopies;
        private int movieDuration;
        private int movieTimesRented;
        private int movieReleaseDate;

        private string movieTitle;
        private string movieClassification;
        private string movieGenre;
        private string movieDirectors;
        private string movieStars;

        
        /// <summary>
        /// This is an object declaration for this class. Or this object has the blueprint for this class.
        /// </summary>
        /// <param name="movieAvailableCopies"></param>
        /// <param name="movieDuration"></param>
        /// <param name="movieTimesRented"></param>
        /// <param name="movieReleaseDate"></param>
        /// <param name="movieTitle"></param>
        /// <param name="movieClassification"></param>
        /// <param name="movieGenre"></param>
        /// <param name="movieDirectors"></param>
        /// <param name="movieStars"></param>
        public Movie (int movieAvailableCopies, int movieDuration, int movieTimesRented, int movieReleaseDate, 
            string movieTitle, string movieClassification, string movieGenre,  string movieDirectors, 
            string movieStars)
        {
            this.movieAvailableCopies = movieAvailableCopies;
            this.movieDuration = movieDuration;
            this.movieTimesRented = movieTimesRented;
            this.movieReleaseDate = movieReleaseDate;
            this.movieTitle = movieTitle;
            this.movieClassification = movieClassification;
            this.movieGenre = movieGenre;
            this.movieDirectors = movieDirectors;
            this.movieStars = movieStars;
        }

        /// <summary>
        /// This is an object declaration of the Movie class
        /// </summary>
        /// <param name="movieTitle"></param>
        /// <param name="star"></param>
        /// <param name="directorNames"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="duration"></param>
        /// <param name="releaseDate"></param>
        /// <param name="copiesAvailable"></param>
        /// <param name="v"></param>
        public Movie(string movieTitle, string star, string directorNames, object p1, object p2, int duration, int releaseDate, int copiesAvailable, int v)
        {
            this.movieTitle = movieTitle;
        }

        /// <summary>
        /// Returns a string that represents the current object. Or convert the movie objec to a string for a use.
        /// When printing the movies details to the members.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Title: " + movieTitle + "\n" +
                    "Starring: " + movieStars + "\n" +
                    "Director: " + movieDirectors + "\n" +
                    "Genre: " + movieGenre + "\n" +
                    "Classification: " + movieClassification + "\n" +
                    "Duration: " + movieDuration + "\n" +
                    "Release Date: " + movieReleaseDate + "\n" +
                    "Copies Available: " + movieAvailableCopies + "\n" +
                    "Times Rented: " + movieTimesRented + "\n";
        }



        /// <summary>
        /// When someone returns their movie, this function will increase the available copies of the movies by 1
        /// 
        /// </summary>
        public void movieRturned()
        {
            movieAvailableCopies = movieAvailableCopies + 1;
        }


        /// <summary>
        /// This function is a helper function and helps the functionality of how many times a movie is rented.
        /// </summary>
        public void howManyTimesRented()
        {
            movieTimesRented = movieTimesRented + 1; //each time movie is rented incrase it by 1.
            movieAvailableCopies = movieAvailableCopies - 1; //and decrease the available copies by 1.
        }

        public int MovieAvailableCopies { get => movieAvailableCopies; set => movieAvailableCopies = value; }
        public int MovieDuration { get => movieDuration; set => movieDuration = value; }
        public int MovieTimesRented { get => movieTimesRented; set => movieTimesRented = value; }
        public int MovieReleaseDate { get => movieReleaseDate; set => movieReleaseDate = value; }
        public string MovieTitle { get => movieTitle; set => movieTitle = value; }
        public string MovieClassification { get => movieClassification; set => movieClassification = value; }
        public string MovieGenre { get => movieGenre; set => movieGenre = value; }
        public string MovieDirectors { get => movieDirectors; set => movieDirectors = value; }
        public string MovieStars { get => movieStars; set => movieStars = value; }
    }
}
