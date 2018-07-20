# Employee Monthly Payslip

This is the solution for Employee Monthly Payslip as requested in task description.

## Design consideration.

During design of the solution I have considered future change requests like. 
 1. Requirement of processing payslip from different version of input file.
 2. Requirement to change monthly payslip to other duration.
 3. Requirement to set Tax criteria from custom config section.
 4. Requirement to use different output format.

## Solution

1. Following is the Structure of the code :
   * All interfaces are generic so they are extensible for other types.
   * IParser - interface to Parse input data (can be implemented for any other format)
   * csvParser -  implements the parser and read file and create dataObject. 
   * Employee model to store parsed data of each employee.
   * IProcess - interface to process the records and return output dataObject.
   * EmpTaxProcess : implements the IProcess which accepts Employee record and return EmpPayslip object for the output.
   * IOutput - interface for output.
   * PayslipOutput - class to create employee payslip CSV File.
   * ITaxRateCalculator - interface to calculate incomeTax based on annual salary.
   * TaxRateCalculator - implements	ITaxRateCalculator to calculate Tax.
   * TaxIncomeConfig - custom config for Tax Criteria given.
   * Helper - static functions to get duration for the payslip and appsettings values.
   
	         
2. Unit test project added to test functionality. Not all functions have been tested but enough code coverage has been added to demonstrate the intent.


## Things considered but not taken care right now.

1. Currently working for only monthly payslips.
2. CSV file need to have headers for CSVReader mapping. Without headers in CSV there won't be any output. i can avoid headers mapping by giving mapping files.
3. Any kind of exceptions currently writing to console.
4. Files have not been organized in proper package structure. 
5. Input file path needs to be configured in settings. Default is under Release\CSV or Debug\CSV folder. This can be accepted as command line arguments.



## How to execute.

1) Repository has Debug and Release folder with CodingTest.exe
2) Input file is already present under Debug\CSV or Release\CSV folder.
3) When you run the exe it will generate ouput.csv file under Debug\CSV or release\CSV folder.

## Feedback
It would be great if you can review the code and provide any feedback on architecture and coding based on your experience. 



  
   