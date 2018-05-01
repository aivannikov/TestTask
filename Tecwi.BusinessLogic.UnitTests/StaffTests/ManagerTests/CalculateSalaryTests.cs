using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Tecwi.BusinessLogic.Staff;

namespace Tecwi.UnitTests.BusinessLogic.StaffTests.ManagerTests
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
        public decimal CalculateSalaryTests_WithoutSubordinates(string startDate, string salaryDate)
        {
            Manager manager = new Manager("John", DateTime.Parse(startDate));
            return manager.CalculateSalary(DateTime.Parse(salaryDate));
        }

        [Test]
        [TestCase("02-01-2010", "04-01-2010", ExpectedResult = 480)]
        [TestCase("02-01-2010", "02-01-2011", ExpectedResult = 5515.2)] 
        public decimal CalculateSalaryTests_WithSubordinates(string startDate, string salaryDate)
        {
            Manager manager = new Manager("John", DateTime.Parse(startDate));
            manager.AddSubordinate(new Subordinate(SubordinationLevel.Direct, new Employee("John", DateTime.Parse(startDate))));
            manager.AddSubordinate(new Subordinate(SubordinationLevel.Direct, new Manager("Ben", DateTime.Parse(startDate))));
            manager.AddSubordinate(new Subordinate(SubordinationLevel.InDirect, new Sales("Ben", DateTime.Parse(startDate))));
            return manager.CalculateSalary(DateTime.Parse(salaryDate));
        }
    }
}
