using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Tecwi.BusinessLogic.Helpers;

namespace Tecwi.BusinessLogic.Staff
{
    public class Sales : SupervisorWorker
    {
        public Sales(string wName, DateTime wStartDate) : base(wName, wStartDate)
        {
        }

        protected override decimal CalculateSalary(DateTime salaryDate, SalaryBuilder builder)
        {
            int periodInMonthes = DateTimeHelper.GetDifferenceInMonthes(jobStartDate, salaryDate);
            int numYears = periodInMonthes / 12;
            IEnumerable<Worker> subordinates = Subordinates.Select(s => s.Worker);
            builder.ApplyYearsRate(numYears, 0.01m, 0.35m);
            builder.ApplySubordinatorsRate(salaryDate, 0.03m, subordinates);
            return periodInMonthes * builder.Salary;            
        }
        
    }
}
