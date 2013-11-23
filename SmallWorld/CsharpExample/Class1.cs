using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Wrapper;

namespace CsharpExample
{
    public class TestWrapper
    {
        private ExampleWrapper csExample;
        private int csInt;

        public TestWrapper(int c)
        {
            csExample = new ExampleWrapper(2);
            csInt = c;
        }

        public int multiplier()
        {
            return csExample.wrapperGetA() * csInt;
        }

        

    }
}
