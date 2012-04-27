namespace VideoRenting
{
	public class NewReleasePrice : Price
	{
		public override double GetPrice(int daysRented)
		{
			return daysRented * 3;
		}

		public override int GetRenterPoints(int daysRented)
		{
			if (daysRented > 1)
			{
				return 2;
			}
			
			return base.GetRenterPoints(daysRented);
		}
	}
}