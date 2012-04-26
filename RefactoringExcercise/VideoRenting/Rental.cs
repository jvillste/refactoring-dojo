using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoRenting
{
    /**
     * Rental class represenst a customer renting a movie.
     */
    public class Rental
    {
        private Movie aMovie;
        private int _daysRented;

        public Rental(Movie movie, int daysRented)
        {
            this.aMovie = movie;
            this._daysRented = daysRented;
        }

        public int GetDaysRented()
        {
            return _daysRented;
        }

        public Movie GetMovie()
        {
            return aMovie;
        }
    }

}
