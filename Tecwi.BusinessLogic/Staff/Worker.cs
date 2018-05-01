using System;
using System.Collections.Generic;
using System.Text;
using Tecwi.BusinessLogic.Helpers;

namespace Tecwi.BusinessLogic.Staff
{
    public abstract class Worker
    {
        protected string name;
        protected DateTime jobStartDate;
        private static readonly decimal baseSalary = 200;



        public string Name { get => name;  }
        public DateTime JobStartDate { get => jobStartDate; }
        
        public SupervisorWorker Supervisor { get; set; }

        public static decimal BaseSalary => baseSalary;

 

        public Worker(string wName, DateTime wStartDate)
        {
            name = wName;
            jobStartDate = wStartDate;
        }

        public decimal CalculateSalary(DateTime salaryDate)
        {
            if (DateTimeHelper.RoundTimePart(salaryDate) < DateTimeHelper.RoundTimePart(jobStartDate))
                throw new ArgumentException("JobStartDate can not be more then salary date");
            SalaryBuilder builder = new SalaryBuilder(baseSalary);
            return CalculateSalary(salaryDate, builder);
        }
        


        protected abstract decimal CalculateSalary(DateTime salaryDate, SalaryBuilder builder);

    }
}
