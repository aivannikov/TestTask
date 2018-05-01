using System;
using System.Collections.Generic;
using System.Text;
using Tecwi.BusinessLogic.Helpers;

namespace Tecwi.BusinessLogic.Staff
{
    public class Employee : Worker
    {
        public Employee(string wName, DateTime wStartDate) : base(wName, wStartDate)
        {
        }

        protected override decimal CalculateSalary(DateTime salaryDate, SalaryBuilder builder)
        {
            int periodInMonthes = DateTimeHelper.GetDifferenceInMonthes(jobStartDate, salaryDate);
            int numYears = periodInMonthes / 12;
            builder.ApplyYearsRate(numYears, 0.03m, 0.3m);
            return periodInMonthes * builder.Salary;
        }
    }
}
