using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VideoRenting.Test
{
	[TestClass]
	public class CustomerTest
	{
		[ClassInitialize]
		public static void InitializeTest(TestContext testContext)
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
		}

		private string GetExpectedStatement()
		{
			return "Rental Record for: Test Customer\n" + "\tRegularMovie\t2.0\n" + "\tChildMovie\t1.5\n" + "\tNewRelease\t3.0\n" +
			       "\tNewRelease\t9.0\n" + "Amount owed is 15.5\n" + "You earned 5 frequent renter points.";
		}

		[TestMethod]
		public void StatementTest()
		{
			var customer = new Customer("Test Customer");

			var regularMovie = new Movie("RegularMovie", 0);
			var childMovie = new Movie("ChildMovie", 2);
			var newReleaseMovie = new Movie("NewRelease", 1);

			customer.AddRental(new Rental(regularMovie, 2));
			customer.AddRental(new Rental(childMovie, 3));
			customer.AddRental(new Rental(newReleaseMovie, 1));
			customer.AddRental(new Rental(newReleaseMovie, 3));

			string expected = GetExpectedStatement();
			string actual = customer.Statement();

			Assert.AreEqual(expected, actual);
		}
	}
}