using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using CsvHelper;

namespace MYOBCodingTest
{
    public class PayslipOutput : IOutput<EmployeePaySlip>
    {
        private string _outputFileName;
        public PayslipOutput(string outPutFileName)
        {
            this._outputFileName = outPutFileName;
        }
        /// <summary>
        /// Output employee's payslip to CSV.
        /// </summary>
        /// <param name="data"></param>
                 
        public void Output(List<EmployeePaySlip> data)
        {
            using (var writer = new StreamWriter(_outputFileName))
            {
                var output = new CsvWriter(writer);                
                output.WriteRecords(data);
            }
        }
    }
}
