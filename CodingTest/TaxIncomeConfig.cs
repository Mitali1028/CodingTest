using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MYOBCodingTest
{
    /// <summary>
    /// Custom config class for each tax criteria.
    /// </summary>
     public class TaxRate : ConfigurationElement
        {
            [ConfigurationProperty("name", IsRequired = true)]
            public string Name
            {
                get { return (string)this["name"]; }
                set { this["name"] = value; }
            }
            [ConfigurationProperty("min", IsRequired = true)]
            public int Min
            {
                get { return (int)this["min"]; }
                set { this["min"] = value; }
            }

            [ConfigurationProperty("max", IsRequired = true)]
            public int Max
            {
                get { return (int)this["max"]; }
                set { this["max"] = value; }
            }

            [ConfigurationProperty("Rate", IsRequired = true)]
            public int Rate
            {
                get { return (int)this["Rate"]; }
                set { this["Rate"] = value; }
            }

            [ConfigurationProperty("Cents", IsRequired = true)]
            public decimal Cents
            {
                get { return (decimal)this["Cents"]; }
                set { this["Cents"] = value; }
            }
        }

    public class TaxRateSection : ConfigurationSection
    {        
        [ConfigurationProperty("taxRates")]
        public TaxRates TaxRates
        {
            get { return (TaxRates)this["taxRates"]; }
        }
    }
   
    public class TaxRates : ConfigurationElementCollection
        {
            public TaxRate this[int index]
            {
                get
                {
                    return base.BaseGet(index) as TaxRate;
                }
                set
                {
                    if (base.BaseGet(index) != null)
                    {
                        base.BaseRemoveAt(index);
                    }
                    this.BaseAdd(index, value);
                }
            }

            public new TaxRate this[string responseString]
            {
                get { return (TaxRate)BaseGet(responseString); }
                set
                {
                    if (BaseGet(responseString) != null)
                    {
                        BaseRemoveAt(BaseIndexOf(BaseGet(responseString)));
                    }
                    BaseAdd(value);
                }
            }


            protected override ConfigurationElement CreateNewElement()
            {
                return new TaxRate();
            }

            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((TaxRate)element).Name;
            }
        
        }

        public class TaxRateConfig : ConfigurationSection
        {

        public static TaxRateSection Config = ConfigurationManager.GetSection("taxIncomeSettings") as TaxRateSection;

        public static TaxRates GetTaxRateOptions()
        {
            return Config.TaxRates;
        }

    }
}

