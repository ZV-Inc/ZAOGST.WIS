using System.Globalization;

namespace ZAOGST.WIS.Tests;

public class ZaogstWisTests
{
	[Fact]
	public void DateTimeConverter_12H_24Hreturned()
	{
		// Arrange
		DateTime date12H = DateTime.ParseExact("4/14/2013 5:07:04 PM", "M/dd/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
		DateTime expected = DateTime.ParseExact("14.04.2013 17:07:04", "dd.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture);

		// Act
		DateTime actual = DateTimeConverter.GetConvertedGPT5(date12H);

		// Assert
		Assert.Equal(expected, actual);
	}
}