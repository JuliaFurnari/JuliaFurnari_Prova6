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
    class CustomerRepository : ICustomerRepository
    {
        private readonly InsuranceContext ctx;

        public CustomerRepository()
        {
            ctx = new InsuranceContext();
        }
        public bool Add(Customer customer)
        {
            if (customer == null)
                return false;
            try
            {
                ctx.Customers.Add(new Customer
                {
                    FiscalCode = customer.FiscalCode,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,                  
                });

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Customer item)
        {
            throw new NotImplementedException();
        }

        public List<Customer> Fetch()
        {
            throw new NotImplementedException();
        }

        public List<Customer> FetchCustomerByLifePol()
        {
             
            try
            {
                var customersWithLifePolicy = ctx.Customers.Include(c => c.Policies)
                   .Where(c => c.Policies.Any (p => p.Type == (TypePolicy)2)).ToList();
                return customersWithLifePolicy;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Customer GetByFiscalCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                return null;

            try
            {
                var customer = ctx.Customers.Where(c => c.FiscalCode == code).FirstOrDefault();

                return customer;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
