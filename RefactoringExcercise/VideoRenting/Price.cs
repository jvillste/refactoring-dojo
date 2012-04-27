namespace VideoRenting
{
	public abstract class Price
	{
		public abstract double GetPrice(int daysRented);

		public virtual int GetRenterPoints(int daysRented)
		{
			return 1;
		}
	}
}