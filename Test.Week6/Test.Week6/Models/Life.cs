using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Week6
{
    public class Life : Policy 
    {
        public int Age { get; set; }
        public override string ToString()
        {
            return $"Age: {Age}\n";
        }
    }
}
