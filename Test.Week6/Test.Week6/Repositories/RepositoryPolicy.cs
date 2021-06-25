using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Week6
{
    public class RepositoryPolicy : IRepositoryPolicy
    {
        public Policy Create(Policy item)
        {
            using (var ctx = new Context())
            {
                if (item != null)
                {
                    try
                    {
                        ctx.Entry<Policy>(item).State = EntityState.Added;
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

        public ICollection<Policy> GetAll()
        {
            using (var ctx = new Context())
            {
                return ctx.Policies.ToList();
            }
        }
    }
}
