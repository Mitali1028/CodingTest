using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYOBCodingTest
{
    public class EmployeePaySlip
    {
        public string Name { get; set; }
        public string PaymentPeriod { get; set; }
        public int GrossIncome { get; set; }
        public int IncomeTax { get; set; }
        public int NetIncome => GrossIncome - IncomeTax;
        public int Super { get; set; }
    }
}
