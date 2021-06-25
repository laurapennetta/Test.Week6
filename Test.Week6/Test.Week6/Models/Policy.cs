using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Week6
{
    public abstract class Policy
    {
        public int Number { get; set; } //PK
        public DateTime StartDate { get; set; }
        public decimal Price { get; set; }
        public decimal Instalment { get; set; }
        public string ClientCF { get; set; }
        public Client Client { get; set; }
        public override string ToString()
        {
            return $"Number: {Number}\nStart Date: {StartDate}\nPrice: {Price}\nInstalment: {Instalment}\n";
        }
    }
}
