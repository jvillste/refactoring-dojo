using System;
using System.Collections.Generic;

namespace VideoRenting
{
	public class Movie
	{
		[Obsolete]
		public const int CHILDRENS = 2;
		
		[Obsolete]
		public const int REGULAR = 0;
		
		[Obsolete]
		public const int NEW_RELEASE = 1;

		private static IDictionary<int, Price> priceMap = new Dictionary<int, Price>
		{
			{REGULAR, new RegularPrice()},
			{NEW_RELEASE, new NewReleasePrice()},
			{CHILDRENS, new ChildrenPrice()}
		};

		private Price price;
		private string title;

		[Obsolete]
		public Movie(string title, int priceCode)
		{
			this.title = title;
			price = priceMap[priceCode];
		}

		public Movie(string title, Price price)
		{
			this.title = title;
			this.price = price;
		}

		public string GetTitle()
		{
			return title;
		}

		public double GetPrice(int daysRented)
		{
			return price.GetPrice(daysRented);
		}

		public int GetRenterPoints(int daysRented)
		{
			return price.GetRenterPoints(daysRented);
		}
	}
}