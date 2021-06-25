using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Week6
{
    public class Client
    {
        public string CF { get; set; } //PK 
        public string Name { get; set; } 
        public string Surname { get; set; } 
        public string Address { get; set; } 
        public ICollection<Policy> Policies = new List<Policy>();
        public override string ToString()
        {
            return $"CF: {CF}\nName: {Name}\nSurname: {Surname}\nAddress: {Address}\n";
        }
    }
}
