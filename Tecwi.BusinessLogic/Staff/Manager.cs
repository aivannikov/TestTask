using System;
using System.Collections.Generic;
using System.Linq;
using Tecwi.BusinessLogic.Helpers;

namespace Tecwi.BusinessLogic.Staff
{
    public class Manager : SupervisorWorker
    {
        public Manager(string wName, DateTime wStartDate) : base(wName, wStartDate)
        {
        }

        protected override decimal CalculateSalary(DateTime salaryDate, SalaryBuilder builder)
        {
            int periodInMonthes = DateTimeHelper.GetDifferenceInMonthes(jobStartDate, salaryDate);
            int numYears = periodInMonthes / 12;
            IEnumerable<Worker> subordinates = Subordinates.Where(s => s.Level == SubordinationLevel.Direct)
                .Select(s => s.Worker);
            builder.ApplyYearsRate(numYears, 0.05m, 0.4m);
            builder.ApplySubordinatorsRate(salaryDate, 0.05m, subordinates);
            return periodInMonthes * builder.Salary;
        }

        
    }
}
