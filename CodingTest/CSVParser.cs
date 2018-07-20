using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace MYOBCodingTest
{
   public class CSVParser :IParser<Employee>
    {
        /// <summary>
        /// Reading input csv and converting into Employee object for taxProcess.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<Employee> ParseFile(string filePath)
        {
            IEnumerable<Employee> employees = null;
            if (!File.Exists(filePath))
                throw new FileNotFoundException();

            using (var fileReader = File.OpenText(filePath))
            {
                var file = new CsvReader(fileReader);                               
                employees = file.GetRecords<Employee>();
                
                return employees.ToList();
            }
        }
    }
}
