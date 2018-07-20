using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYOBCodingTest
{
    public interface IOutput<T>
    {
        void Output(List<T> data);
    }
}
