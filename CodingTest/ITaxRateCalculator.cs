using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYOBCodingTest
{
   public interface ITaxRateCalculator
    {
        decimal GetTaxIncome(int annualSalary);
    }
}
