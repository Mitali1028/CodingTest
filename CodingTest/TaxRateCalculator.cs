using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYOBCodingTest
{
   public class TaxRateCalculator : ITaxRateCalculator
    {
        private TaxRates taxRateOptions;
        public TaxRateCalculator(TaxRates taxRates)
        {
            taxRateOptions = taxRates;
        }
        /// <summary>
        /// calculate Income Tax based on annual salary and Tax Rate options provided.
        /// </summary>
        /// <param name="annualSalary"></param>
        /// <returns></returns>
        public decimal GetTaxIncome(int annualSalary)
        {
            foreach (TaxRate taxRate in taxRateOptions)
            {
                if (annualSalary >= taxRate.Min && annualSalary <= taxRate.Max)
                {
                    return (taxRate.Rate + (taxRate.Cents * (annualSalary - (taxRate.Min - 1))));
                }
            }
            return 0;
        }
    }
}
