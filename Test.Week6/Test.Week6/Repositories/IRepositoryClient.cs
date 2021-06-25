using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Week6
{
    public interface IRepositoryClient : IRepository<Client>
    {
        public bool AddClient(string clientCF, Policy policy);
    }
}
