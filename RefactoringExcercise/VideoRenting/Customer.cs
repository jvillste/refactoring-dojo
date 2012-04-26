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
        private readonly string _name;
        private List<Rental> _rentals = new List<Rental>();

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
        
            string result = "Rental Record for: " + GetName() + "\n";
            foreach(var rental in _rentals)
            {

                result += "\t" + rental.GetMovie().GetTitle() + "\t" +
                        rental.GetAmount().ToString("0.0")+ "\n";
            
            }
            // add footer lines
            result += "Amount owed is " + Amount().ToString("0.0") + "\n";
            result += "You earned " + FrequentUserPoints().ToString("0") +
                    " frequent renter points.";
            return result;
        }

        public double Amount()
        {
            return _rentals.Sum(rental => rental.GetAmount());
        }

        public int FrequentUserPoints()
        {
            return _rentals.Sum(rental => rental.FrequentRenterPoints());
        }

        public string GetName()
        {
            return _name;
        }

        public string XmlStatement()
        {

            var movieStatement = "";
            foreach (var rental in _rentals)
            {
                movieStatement += "<" + rental.GetMovie().GetTitle() + ">" + rental.GetAmount().ToString("0.0") + "</" + rental.GetMovie().GetTitle() + ">";
            }


            return "<RentalRecord>"
                    +"<CustomerName>" + GetName() + "</CustomerName>"
                    + "<TotalAmount>" + Amount().ToString("0.0") + "</TotalAmount>"
                    + "<FrequentUserPoints>" + FrequentUserPoints().ToString("0") + "</FrequentUserPoints>"
                    +"<Movies>"
                    + movieStatement
                    +"</Movies>"
                    +"</RentalRecord>";

          
            }
        }
    }

