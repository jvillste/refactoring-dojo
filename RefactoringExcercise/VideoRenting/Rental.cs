namespace VideoRenting
{
	public class Rental
	{
		private int daysRented;
		private Movie movie;

		public Rental(Movie movie, int daysRented)
		{
			this.movie = movie;
			this.daysRented = daysRented;
		}

		public double GetAmount()
		{
			return movie.GetPrice(daysRented);
		}

		public int GetFrequentRenterPoints()
		{
			return movie.GetRenterPoints(daysRented);
		}

		public string GetTitle()
		{
			return movie.GetTitle();
		}
	}
}