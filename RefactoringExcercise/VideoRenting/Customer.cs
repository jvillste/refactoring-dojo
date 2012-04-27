using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace VideoRenting
{
	public class Customer
	{
		private string name;
		private ICollection<Rental> rentals = new List<Rental>();

		public Customer(string name)
		{
			this.name = name;
		}

		public void AddRental(Rental arg)
		{
			rentals.Add(arg);
		}

		public string Statement()
		{
			string result = "Rental Record for: " + GetName() + "\n";
			foreach (Rental rental in rentals)
			{
				result += "\t" + rental.GetTitle() + "\t" + rental.GetAmount().ToString("0.0", CultureInfo.InvariantCulture) + "\n";
			}
			result += "Amount owed is " + GetTotalAmount().ToString("0.0", CultureInfo.InvariantCulture) + "\n";
			result += "You earned " + GetTotalFrequentRenterPoints() + " frequent renter points.";
			return result;
		}

		private int GetTotalFrequentRenterPoints()
		{
			return rentals.Sum(rental => rental.GetFrequentRenterPoints());
		}

		private double GetTotalAmount()
		{
			return rentals.Sum(rental => rental.GetAmount());
		}

		public string GetName()
		{
			return name;
		}

		public string StatementXml()
		{
			string result = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
			result += "<Rentals customer=\"" + GetName() + "\">";
			foreach (Rental rental in rentals)
			{
				result += "<Rental name=\"" + rental.GetTitle() + "\" price=\"" + rental.GetAmount().ToString("0.0", CultureInfo.InvariantCulture) + "\" />";
			}
			result += "<Total>" + GetTotalAmount().ToString("0.0", CultureInfo.InvariantCulture) + "</Total>";
			result += "<Points>" + GetTotalFrequentRenterPoints() + "</Points>";
			result += "</Rentals>";
			return result;
		}
	}
}