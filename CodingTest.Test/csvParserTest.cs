using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MYOBCodingTest;
using System.IO;

namespace CSVProcessTest
{
    /// <summary>
    /// Summary description for csvParserTest
    /// </summary>
    [TestClass]
    public class csvParserTest
    {
        const string filePath = "..\\..\\CSV\\Input.csv";
        [TestMethod]
        public void CsvParserTest_Positive()
        {
            var csvParser = new CSVParser();
            var empList =  csvParser.ParseFile(filePath);

            Assert.IsTrue(empList.Count == 2);
            Assert.IsTrue(empList[0].FirstName.ToLower() == "david");            
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException), "file Path is wrong")]
        public void CsvParserTest_Negative()
        {
            var csvParser = new CSVParser();
            string missingFile = "..\\..\\..\\Input.csv";
            var empList = csvParser.ParseFile(missingFile);

            Assert.IsTrue(empList.Count == 2);
            Assert.IsTrue(empList[0].FirstName.ToLower() == "david");
        }
    }
}
