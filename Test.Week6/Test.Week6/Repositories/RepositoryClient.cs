using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Week6
{
    public class RepositoryClient : IRepositoryClient
    {
        public bool AddClient(string clientCF, Policy policy)
        {
            bool result = false;
            using (var ctx = new Context())
            {
                var client = ctx.Clients.Include(x => x.Policies)
                                         .FirstOrDefault(n => n.CF == clientCF);
                if (client != null)
                {
                    try
                    {
                        client.Policies.Add(policy);
                        policy.Client = client;
                        ctx.SaveChanges();
                        result = true;
                    }
                    catch (Exception)
                    {
                        return result;
                    }
                }
            }
            return result;
        }

        public Client Create(Client item)
        {
            using (var ctx = new Context())
            {
                if (item != null)
                {
                    try
                    {
                        ctx.Entry<Client>(item).State = EntityState.Added;
                        ctx.SaveChanges();
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
            return item;
        }

        public ICollection<Client> GetAll()
        {
            using (var ctx = new Context())
            {
                return ctx.Clients.ToList();
            }
        }
    }
}
