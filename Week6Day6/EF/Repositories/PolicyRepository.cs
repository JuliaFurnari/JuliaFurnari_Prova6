using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6Day6.Core.InterfacesRepositories;
using Week6Day6.Core.Models;

namespace Week6Day6.EF.Repositories
{
    class PolicyRepository : IPolicyRepository
    {
        private readonly InsuranceContext ctx;

        public PolicyRepository()
        {
            ctx = new InsuranceContext();
        }
        public bool Add(Policy policy)
        {
            if (policy == null)
                return false;
            try
            {
                ctx.Policies.Add(new Policy
                {
                    PolicyNumber = policy.PolicyNumber,
                    ExpirationDate=policy.ExpirationDate,
                    MonthlyPayment=policy.MonthlyPayment,
                    Type=policy.Type,
                    CustomerId=policy.CustomerId,                 
                }); 

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Policy item)
        {
            throw new NotImplementedException();
        }

        public List<Policy> Fetch()
        {
            throw new NotImplementedException();
        }

        public List<Policy> FetchPoliciesByCustomerCode(string fiscalCode)
        {
            if (string.IsNullOrEmpty(fiscalCode))
                return null;

            try
            {
                var policies = ctx.Policies.Include(p => p.Customer)
                   .Where(p => p.Customer.FiscalCode == fiscalCode).ToList();

                return policies;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Policy GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Policy updatePolicy)
        {
            if (updatePolicy == null)
                return false;

            try
            {
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
