using System;
using Tecwi.BusinessLogic.Helpers;
using NUnit.Framework;

namespace Tecwi.UnitTests.BusinessLogic.HelpersTests.DateTimeHelperTests
{
    [TestFixture]
    public class GetDifferenceInMonthesTests
    {

        [Test]
        [TestCase("2010-01-15", "2010-02-03", ExpectedResult = 1)]
        // same year
        [TestCase("2010-01-01", "2010-05-01", ExpectedResult = 4)]
        // 2 years equally
        [TestCase("2010-01-01", "2012-01-01", ExpectedResult = 24)]
        // 2 years and 4 monthes
        [TestCase("2010-02-01", "2012-06-01", ExpectedResult = 28)]
        // 1 years and 10 monthes
        [TestCase("2010-03-10", "2012-01-12", ExpectedResult = 22)]        
        public int GetDifferenceInMonthes_NormalCase(string startDate, string endDate)
        {
            return DateTimeHelper.GetDifferenceInMonthes(DateTime.Parse(startDate), DateTime.Parse(endDate));
        }


        [Test]
        [TestCase("2012-01-01", "2010-01-01")]
        [TestCase("2010-12-01", "2010-01-01")]
        [TestCase("2010-01-10", "2010-01-09")]
        [TestCase("2010-05-24", "2010-03-12")]
        public void GetDifferenceInMonthes_ArgExceptionCase(string startDate, string endDate)
        {
            Assert.That(() => DateTimeHelper.GetDifferenceInMonthes(DateTime.Parse(startDate), DateTime.Parse(endDate)), Throws.ArgumentException);
        }
    }
}
