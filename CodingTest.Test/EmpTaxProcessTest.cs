using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MYOBCodingTest;
using System.Collections.Generic;
using System.Configuration;

namespace CSVProcessTest
{
    [TestClass]
    public class EmpTaxProcessTest
    {    
               
        [TestMethod]
        public void CSVProcess_WithNoData()
        {
           
            var output = new Mock<IOutput<EmployeePaySlip>>();

            output.Setup(o => o.Output(It.IsAny<List<EmployeePaySlip>>()));

            var taxCalculator = new Mock<ITaxRateCalculator>();
            
            var csvProcess = new EmpTaxProcess(taxCalculator.Object);

            var empList = new List<Employee>();

            empList.Add(new Employee());
            empList.Add(new Employee());            
                      
           
            var empPayslipList = csvProcess.Process(empList);

            Assert.IsTrue(empPayslipList.Count == 2);
            Assert.IsTrue(empPayslipList[0].GrossIncome == 0);
                   
         }

        [TestMethod]
        public void CSVProcess_WithEmpData()
        {
            var taxCalculator = new Mock<ITaxRateCalculator>();

            var csvProcess = new EmpTaxProcess(taxCalculator.Object);

            var empList = new List<Employee>();

            var emp = new Employee {
                FirstName = "David",
                LastName = "Rudd",
                AnnualSalary = 60050,
                PaymentPeriod = "01 March – 31 March",
                SuperRate="9%"
            };


            empList.Add(emp);                   

           var result = csvProcess.Process(empList);

            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0].NetIncome == 5004);
            Assert.IsTrue(result[0].IncomeTax == 0);
            Assert.IsTrue(result[0].Super == 450);

            
        }

    }
}
