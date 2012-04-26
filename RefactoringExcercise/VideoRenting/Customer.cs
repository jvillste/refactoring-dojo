using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace VideoRenting
{
    /// <summary>
    /// Customer class
    /// </summary>
    public class Customer
    {
        private string _name;
        private ArrayList _rentals = new ArrayList();

        // Constructor
        public Customer(string _name)
        {
            this._name = _name;
        }

        public void AddRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public string Statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            IEnumerator rentals = _rentals.GetEnumerator();
            string result = "Rental Record for: " + GetName() + "\n";
            while (rentals.MoveNext())
            {
                double thisAmount = 0;
                Rental each = (Rental)rentals.Current;

                // determine amounts for each line
                switch (each.GetMovie().GetPriceCode())
                {
                    case Movie.REGULAR:
                        thisAmount += 2;
                        if (each.GetDaysRented() > 2)
                            thisAmount += (each.GetDaysRented() - 2) * 1.5;
                        break;
                    case Movie.NEW_RELEASE:
                        thisAmount += each.GetDaysRented() * 3;
                        //double discountvalue = GetDiscountValue();
                        //thisAmount += each.GetDaysRented() * 3
                        //    - _discount;
                        break;
                    case Movie.CHILDRENS: // Lisätty uusi lastenelokuva kategoria
                        thisAmount += 1.5;
                        // lastenelokuvien vuokrahinta on kaksi ensimmäistä päivää sama.
                        // mivuorin, TASK# 1487, 12.07.2009
                        if (each.GetDaysRented() > 3)
                            thisAmount += (each.GetDaysRented() - 3) * 1.5;
                        break;
                }

                // add frequent renter points
                frequentRenterPoints++;
                // add bonus for a two day new release rental
                if ((each.GetMovie().GetPriceCode() == Movie.NEW_RELEASE) &&
                        each.GetDaysRented() > 1) frequentRenterPoints++;

                //show figures for this rental
                result += "\t" + each.GetMovie().GetTitle() + "\t" +
                        thisAmount.ToString("0.0")+ "\n";
                totalAmount += thisAmount;
            }

            // add footer lines
            result += "Amount owed is " + totalAmount.ToString("0.0") + "\n";
            result += "You earned " + frequentRenterPoints +
                    " frequent renter points.";
            return result;
        }

        public string GetName()
        {
            return _name;
        }
    }
}
