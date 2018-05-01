using System;
using System.Collections.Generic;
using System.Text;

namespace Tecwi.BusinessLogic.Staff
{
    public class SalaryBuilder
    {
        private decimal salary;
        private int numTimesYearRateApplied = 0;
        private int numTimesSubordinatorsRateApplied = 0;

        public decimal Salary { get => salary; }

        public SalaryBuilder(decimal sBaseRate)
        {
            salary = sBaseRate;
        }

        private bool IsValidRateArgument(decimal rate, string argNameToCheck, out string outArgName)
        {
            outArgName = argNameToCheck;
            return rate * 100 < 100;
        }

        public void ApplyYearsRate(int numberOfYears, decimal rate, decimal premiumLimitRate)
        {
            if(numTimesYearRateApplied == 0)
            {
                if (!IsValidRateArgument(rate, "rate", out string outArgName) ||
                    !IsValidRateArgument(premiumLimitRate, "premiumLimitRate", out outArgName))
                {
                    throw new ArgumentException(message: "Invalid agrument format - should be in decimal form, not in percent",
                                    paramName: outArgName);
                }

                numTimesYearRateApplied++;
                int maxNumYears = (int)(premiumLimitRate / rate);
                if (numberOfYears <= maxNumYears)
                    salary = salary + salary * rate * numberOfYears;
                else
                    salary = salary + salary * rate * maxNumYears;


            }
           
        }

        public void ApplySubordinatorsRate(DateTime salaryDate, decimal rate, IEnumerable<Worker> subordinators)
        {
            if(numTimesSubordinatorsRateApplied == 0)
            {
                if (!IsValidRateArgument(rate, "rate", out string outArgName))
                {
                    throw new ArgumentException(message: "Invalid agrument format - should be in decimal form, not in percent",
                                    paramName: outArgName);
                }

                numTimesSubordinatorsRateApplied++;
                decimal premium = 0;
                foreach (var worker in subordinators)
                {
                    
                    premium = premium + worker.CalculateSalary(salaryDate) * rate;
                }
                salary = salary + premium;
            }
            
        }
    }
}
