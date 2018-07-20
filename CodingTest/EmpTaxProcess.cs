using System;
using System.Collections.Generic;

namespace MYOBCodingTest
{
    public class EmpTaxProcess : IProcess<Employee,EmployeePaySlip>
    {  
        private ITaxRateCalculator _taxRateCalculator;
    

        public EmpTaxProcess(ITaxRateCalculator taxRateCalculator)
        {
            this._taxRateCalculator = taxRateCalculator;           
        }
        /// <summary>
        /// get the list of Employees and return their payslips after calculating their monthly salary ,tax and super.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<EmployeePaySlip> Process(List<Employee> data)
        {           

            var empPayslipList = new List<EmployeePaySlip>();
            foreach (var employee in data)
            {
                var empPayslip = CreateEmpPaySlip(employee);
                empPayslipList.Add(empPayslip);
            }
            return empPayslipList;
        }
       
        /// <summary>
        /// create employee payslip object.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        private EmployeePaySlip CreateEmpPaySlip(Employee employee)
        {
            int duration = Helper.GetDuration(employee);
            var empPayslip = new EmployeePaySlip
            {
                Name = employee.FirstName + ' ' + employee.LastName,
                PaymentPeriod = employee.PaymentPeriod,
                GrossIncome = employee.AnnualSalary / duration,
                IncomeTax = (int)Math.Round(_taxRateCalculator.GetTaxIncome(employee.AnnualSalary) / duration)
            };

            decimal super = 0;

            if (employee.SuperRate != null)
            {
                Decimal.TryParse(employee.SuperRate.TrimEnd(new char[] { '%', ' ' }), out super);
            }
            empPayslip.Super = (int)Math.Round((empPayslip.GrossIncome * super) / 100);

            return empPayslip;
        }

       
    }
}
