namespace VideoRenting
{
	public class ChildrenPrice : Price
	{
		public override double GetPrice(int daysRented)
		{
			double thisAmount = 1.5;
			if (daysRented > 3)
			{
				thisAmount += (daysRented - 3) * 1.5;
			}
			return thisAmount;
		}
	}
}