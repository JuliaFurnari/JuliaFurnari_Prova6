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
    class ADOCustomerRepository : ICustomerRepository
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                       "Initial Catalog = Insurance;" +
                                       "Integrated Security = true;";
        public bool Add(Customer customer)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;


                    command.CommandText = "insert into Customers values (@fiscalCode, @firstName, @lastName)";
                    command.Parameters.AddWithValue("@fiscalCode", customer.FiscalCode);
                    command.Parameters.AddWithValue("@firstName", customer.FirstName);
                    command.Parameters.AddWithValue("@lastName", customer.LastName);
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch
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
            throw new NotImplementedException();
        }

        public Customer GetByFiscalCode(string code)
        {
            Customer customer = new Customer();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Customers where FiscalCode = @fiscalCode";
                command.Parameters.AddWithValue("@fiscalCode", code);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var fiscalCode = (string)reader["FiscalCode"];
                    var firstName = (string)reader["FirstName"];
                    var lastName = (string)reader["LastName"];
                    var id = (int)reader["Id"];

                    customer = new Customer { FiscalCode= fiscalCode, FirstName=firstName, LastName = lastName, Id=id };              
                }
               
            }
            return customer;
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
