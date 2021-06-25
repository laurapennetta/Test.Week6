using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Week6
{
    public class Theft : Policy 
    {
        public int Coverage { get; set; }
        public override string ToString()
        {
            return $"Coverage: {Coverage}\n";
        }
    }
}
