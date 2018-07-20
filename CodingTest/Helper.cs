using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYOBCodingTest
{
   public static class Helper
    {
        public static T getConfigProperty<T>(string propertyName)
        {
            string propertyValue = ConfigurationManager.AppSettings.Get(propertyName);
            if (propertyValue == null)
            {
                throw new Exception("Property " + propertyName + " is not configured");
            }
            T value = (T)Convert.ChangeType(propertyValue, typeof(T));
            return value;
        }   
        /// <summary>
        /// Get Duration based on payment period.still need to extend for other period.Currently just working for monthly period.
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public static int GetDuration(Employee emp)
        {
            if (emp == null || string.IsNullOrEmpty(emp.PaymentPeriod)) return 12;

            DateTime[] dates = emp.PaymentPeriod.Split(new char[] { '-', '–' }).Select(c => DateTime.Parse(c, new System.Globalization.CultureInfo("en-NZ"))).ToArray();
            var startDate = dates[0];
            var endDate = dates[1];

            var firstDayOfMonth = new DateTime(startDate.Year, startDate.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            if(startDate.Day == firstDayOfMonth.Day && endDate.Day == lastDayOfMonth.Day)
            {
                return 12;
            }
            return 12;
        }
    }
}
