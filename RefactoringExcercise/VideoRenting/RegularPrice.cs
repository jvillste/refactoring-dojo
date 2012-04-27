namespace VideoRenting
{
	public class RegularPrice : Price
	{
		public override double GetPrice(int daysRented)
		{
			double amount = 2;
			if (daysRented > 2)
			{
				amount += (daysRented - 2) * 1.5;
			}
			return amount;
		}
	}
}