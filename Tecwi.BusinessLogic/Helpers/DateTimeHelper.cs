using System;
using System.Collections.Generic;
using System.Text;

namespace Tecwi.BusinessLogic.Helpers
{
    public static class DateTimeHelper
    {
        

        public static int GetDifferenceInMonthes(DateTime startDate, DateTime endDate)
        {
            if (RoundTimePart(startDate) > RoundTimePart(endDate))
                throw new ArgumentException("Start date can not be greater then end date");
            int yearDiff = endDate.Year - startDate.Year;
            int monthDiff = endDate.Month - startDate.Month;
            int dayDiff = endDate.Day - startDate.Day;

            if (yearDiff == 0)
            {
                return monthDiff;
            }
            else
            {
                if (monthDiff < 0)
                {                    
                    return (yearDiff - 1) * 12 + (12 - Math.Abs(monthDiff));
                }
                
                else
                {
                    return 12 * yearDiff;
                }
                    
            }
        }
       
        public static DateTime RoundTimePart(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
        }
        
    }
}
