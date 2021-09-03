using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6Day6.Core.Models;

namespace Week6Day6.Core.InterfacesRepositories
{
    interface IPolicyRepository : IRepository<Policy>
    {
        List<Policy> FetchPoliciesByCustomerCode(string fiscalCode);
    }
}
