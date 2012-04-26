using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoRenting
{
    /**
     *
     * @author mikkovu
     * @version 1.0.12
     *
     * Muutoshistoria:
     *  - Lisätty lastenelokuvat constant
     */
    public class Movie
    {

        public const int CHILDRENS = 2; // Uudet lastenelokuvat
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;

        private string _title;
        private int _priceCode;

        // Movie class Constructor
        public Movie(string _title, int _priceCode)
        {
            this._title = _title;
            this._priceCode = _priceCode;
        }

        /// <summary>
        /// getPriceCode
        /// </summary>
        /// <returns>priceCode</returns>
        public int GetPriceCode()
        {
            return _priceCode;
        }

        /// <summary>
        /// sets pricecode
        /// </summary>
        /// <param name="_priceCode">priceciode</param>
        public void SetPriceCode(int _priceCode)
        {
            this._priceCode = _priceCode;
        }

        /// <summary>
        /// title
        /// </summary>
        /// <returns>movie tittle</returns>
        public string GetTitle()
        {
            return _title;
        }
    }
}
