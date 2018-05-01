using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Tecwi.BusinessLogic.Staff;

namespace Tecwi.UnitTests.BusinessLogic.StaffTests.EmployeeTests
{
    [TestFixture]
    public class CalculateSalaryTests
    {
        [Test]
        [TestCase("02-01-2010", "04-01-2010", ExpectedResult = 400)]
        // apply 1 year rate
        [TestCase("02-01-2010", "02-01-2011", ExpectedResult = 2472)]
        //apply 3 years
        [TestCase("02-01-2010", "02-01-2013", ExpectedResult = 7848)]
        // number of years equal to summary limit rate
        [TestCase("02-01-2001", "02-01-2011", ExpectedResult = 31200)]
        // number of years more then summary limit rate
        [TestCase("02-01-2001", "02-01-2015", ExpectedResult = 43680)]
        public decimal CalculateSalary_NormalCase(string jobStartDate, string salaryDate)
        {
            var employee = new Employee("John", DateTime.Parse(jobStartDate));
            return employee.CalculateSalary(DateTime.Parse(salaryDate));
        }

    }
}
