using System;
using System.Collections.Generic;
using Tecwi.BusinessLogic.Staff;

namespace Tecwi.Run
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal salaryOfAllWorkers = 0;
            List<Worker> workers = new List<Worker>()
            {
                new Manager("John", DateTime.Parse("01-01-2010")),
                new Sales("Peter", DateTime.Parse("01-01-2012")),
                new Employee("Ted", DateTime.Parse("01-01-2018")),
                new Employee("Bill", DateTime.Parse("01-01-2017"))
            };
            DateTime salaryDate = DateTime.Now;
            foreach(Worker worker in workers)
            {
                salaryOfAllWorkers += worker.CalculateSalary(salaryDate);
            }
            Console.WriteLine("Salary of all workers: {0}", salaryOfAllWorkers);
            Console.ReadKey();

        }
    }
}
