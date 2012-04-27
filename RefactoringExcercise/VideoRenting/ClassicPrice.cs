namespace VideoRenting
{
	public class ClassicPrice : Price
	{
		public override double GetPrice(int daysRented)
		{
			return daysRented * 2;
		}

		public override int GetRenterPoints(int daysRented)
		{
			return daysRented;
		}
	}
}