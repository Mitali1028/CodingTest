using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYOBCodingTest
{
   public interface IProcess<T,R>
    {
        List<R> Process(List<T> data);
    }
}
