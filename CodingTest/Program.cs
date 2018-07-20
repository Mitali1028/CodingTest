using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYOBCodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Parse the CSV
                var inputFilePath = Helper.getConfigProperty<string>("InputFile");
                var csvParser = new CSVParser();
                var inputData = csvParser.ParseFile(inputFilePath);

                //Process the CSV                
                var taxRateOptions = TaxRateConfig.GetTaxRateOptions();
                var taxRateCal = new TaxRateCalculator(taxRateOptions);
                var empTaxProcess = new EmpTaxProcess(taxRateCal);
                var empPayslipList = empTaxProcess.Process(inputData);

                //Output the result
                var outputFilePath = Helper.getConfigProperty<string>("OutPutFile");
                IOutput<EmployeePaySlip> payslipOutput = new PayslipOutput(outputFilePath);
                payslipOutput.Output(empPayslipList);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }
    }
}
