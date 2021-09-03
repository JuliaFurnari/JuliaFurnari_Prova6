using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6Day6.Core.InterfacesRepositories;
using Week6Day6.Core.Models;

namespace Week6Day6.ADO.Repositories
{
    class ADOPolicyRepository : IPolicyRepository
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                      "Initial Catalog = Insurance;" +
                                      "Integrated Security = true;";
        public bool Add(Policy policy)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;


                    command.CommandText = "insert into Policies values (@policyNumber, @expirationDate, @monthlyPayment, @type, @customerId)";
                    command.Parameters.AddWithValue("@policyNumber", policy.PolicyNumber);
                    command.Parameters.AddWithValue("@expirationDate", policy.ExpirationDate);
                    command.Parameters.AddWithValue("@monthlyPayment", policy.MonthlyPayment);
                    command.Parameters.AddWithValue("@type", (int)policy.Type);
                    command.Parameters.AddWithValue("@customerId", policy.CustomerId);
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch
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
            throw new NotImplementedException();
        }

        public Policy GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Policy item)
        {
            throw new NotImplementedException();
        }
    }
}
