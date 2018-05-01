using System;
using Tecwi.BusinessLogic.Helpers;
using NUnit.Framework;


namespace Tecwi.UnitTests.BusinessLogic.HelpersTests.DateTimeHelperTests
{
    [TestFixture]
    public class GetDifferenceInYearsTests
    {
        
        [Test]
        [TestCase("2010-01-01", "2015-01-01", ExpectedResult = 5)]
        // Same year but less then full year.
        [TestCase("2010-01-01", "2010-12-01", ExpectedResult = 0)]
        // Next year but less then full year.
        [TestCase("2010-02-12", "2011-02-05", ExpectedResult = 0)]
        // Plus some years but not full year
        [TestCase("2010-04-17", "2012-02-05", ExpectedResult = 1)]
        // Plus some years
        [TestCase("2010-04-17", "2012-05-19", ExpectedResult = 2)]
        public int GetDifferenceInYears_NormalCase(string startDate, string endDate)
        {
            return DateTimeHelper.GetDifferenceInYears(DateTime.Parse(startDate), DateTime.Parse(endDate));
        }

        [Test]
        [TestCase("2012-01-01", "2010-01-01")]
        [TestCase("2010-12-01", "2010-01-01")]
        [TestCase("2010-01-10", "2010-01-09")]
        [TestCase("2010-05-24", "2010-03-12")]
        public void GetDifferenceInYears_ArgExceptionCase(string startDate, string endDate)
        {
            Assert.That(() => DateTimeHelper.GetDifferenceInYears(DateTime.Parse(startDate), DateTime.Parse(endDate)), Throws.ArgumentException);
        }
    }
}
