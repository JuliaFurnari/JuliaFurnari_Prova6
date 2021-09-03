using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6Day6.Core.InterfacesRepositories;
using Week6Day6.Core.Models;
using Week6Day6.ADO.Repositories;

namespace Week6Day6
{
    class MainBL
    {
        private ICustomerRepository _customerRepo;
        private IPolicyRepository _policyRepo;
       

        public MainBL(ICustomerRepository customerRepository, IPolicyRepository policyRepository)
        {
            _customerRepo = customerRepository;
            _policyRepo = policyRepository;
        }




        internal bool AddCustomer(Customer customer)
        {
            //validazione
            if (customer == null) throw new ArgumentNullException();

            bool isAdded = _customerRepo.Add(customer);
            return isAdded; 
        }

        internal bool AddPolicy(Policy policy)
        {
            //validazione
            if (policy == null) throw new ArgumentNullException();

            bool isAdded = _policyRepo.Add(policy);
            return isAdded;
        }

        internal Customer GetCustomerByFiscalCode(string code)
        {
            //validazione 
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException();

            Customer customer = _customerRepo.GetByFiscalCode(code);
            return customer;
        }

        internal List<Policy> FetchPoliciesByCustomer(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException();

            return _policyRepo.FetchPoliciesByCustomerCode(customer.FiscalCode);
        }

        internal bool UpdatePolicy(Policy policyUpdate)
        {
            
            if (policyUpdate == null) throw new ArgumentNullException();

            bool isUpdate=_policyRepo.Update(policyUpdate);
          
            return isUpdate;
        }

        internal List<Customer> FetchCustomerByLifePolicy()
        {           

            return _customerRepo.FetchCustomerByLifePol();
        }
    }
}
