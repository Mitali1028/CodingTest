using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using MYOBCodingTest;

namespace CSVProcessTest
{
    /// <summary>
    /// Summary description for TaxCalculatorTest
    /// </summary>
    [TestClass]
    public class TaxCalculatorTest
    {
       
        [TestMethod]
        public void GetIncomeTaxTest()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = "App.config";
            Configuration config
              = ConfigurationManager.OpenMappedExeConfiguration(fileMap,
                ConfigurationUserLevel.None);
            TaxRateSection section
              = config.GetSection("taxIncomeSettings") as TaxRateSection;

            var taxCalculator = new TaxRateCalculator(section.TaxRates);

            var result = taxCalculator.GetTaxIncome(60050);

            int tax = (int)Math.Round(result / 12);

            Assert.IsTrue(tax == 922);
        }
    }
}
