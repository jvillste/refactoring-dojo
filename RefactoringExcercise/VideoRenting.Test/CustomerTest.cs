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
			return "Rental Record for: Test Customer\n" + 
				"\tRegularMovie\t2.0\n" +
				"\tChildMovie\t1.5\n" +
				"\tNewRelease\t3.0\n" +
			    "\tNewRelease\t9.0\n" +
				"\tClassic\t4.0\n" +
				"Amount owed is 19.5\n" + "You earned 7 frequent renter points.";
		}

		private string GetExpectedXml()
		{
			return "<?xml version=\"1.0\" encoding=\"utf-8\"?><Rentals customer=\"Test Customer\"><Rental name=\"RegularMovie\" price=\"2.0\" /><Rental name=\"ChildMovie\" price=\"1.5\" /><Rental name=\"NewRelease\" price=\"3.0\" /><Rental name=\"NewRelease\" price=\"9.0\" /><Total>15.5</Total><Points>5</Points></Rentals>";
		}

		[TestMethod]
		public void StatementTest()
		{
			var customer = new Customer("Test Customer");

			var regularMovie = new Movie("RegularMovie", new RegularPrice());
			var childMovie = new Movie("ChildMovie", new ChildrenPrice());
			var newReleaseMovie = new Movie("NewRelease", new NewReleasePrice());
			var classicMovie = new Movie("Classic", new ClassicPrice());

			customer.AddRental(new Rental(regularMovie, 2));
			customer.AddRental(new Rental(childMovie, 3));
			customer.AddRental(new Rental(newReleaseMovie, 1));
			customer.AddRental(new Rental(newReleaseMovie, 3));
			customer.AddRental(new Rental(classicMovie, 2));

			Assert.AreEqual(GetExpectedStatement(), customer.Statement());
		}

		[TestMethod]
		public void XmlStatementTest()
		{
			var customer = new Customer("Test Customer");

			var regularMovie = new Movie("RegularMovie",new RegularPrice());
			var childMovie = new Movie("ChildMovie", new ChildrenPrice());
			var newReleaseMovie = new Movie("NewRelease", new NewReleasePrice());

			customer.AddRental(new Rental(regularMovie, 2));
			customer.AddRental(new Rental(childMovie, 3));
			customer.AddRental(new Rental(newReleaseMovie, 1));
			customer.AddRental(new Rental(newReleaseMovie, 3));

			Assert.AreEqual(GetExpectedXml(), customer.StatementXml());
		}
	}
}