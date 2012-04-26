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

        public int FrequentRenterPoints()
        {
            return ((GetMovie().GetPriceCode() == Movie.NEW_RELEASE) && GetDaysRented() > 1) ? 2 : 1;
        }

        public Movie GetMovie()
        {
            return aMovie;
        }
        public double GetAmount()
        {
            double thisAmount = 0;
            // determine amounts for each line
            switch (GetMovie().GetPriceCode())
            {
                case Movie.REGULAR:
                    thisAmount += 2;
                    if (GetDaysRented() > 2)
                        thisAmount += (GetDaysRented() - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    thisAmount += GetDaysRented() * 3;
                    break;
                case Movie.CHILDRENS: // Lisätty uusi lastenelokuva kategoria
                    thisAmount += 1.5;
                    if (GetDaysRented() > 3)
                        thisAmount += (GetDaysRented() - 3) * 1.5;
                    break;
            }
            return thisAmount;
        }

    }

}
