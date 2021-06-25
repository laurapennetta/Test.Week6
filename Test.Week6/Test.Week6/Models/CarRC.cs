using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Week6
{
    public class CarRC : Policy
    {
        public string Plate { get; set; } 
        public int Displacement { get; set; }
        public override string ToString()
        {
            return $"Plate: {Plate}\nDisplacement: {Displacement}\n";
        }
    }
}
