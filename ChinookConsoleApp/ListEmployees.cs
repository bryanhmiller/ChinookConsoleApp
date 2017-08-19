using System;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;

namespace ChinookConsoleApp
{
    public class EmployeeListResult
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class ListEmployees
    {
        public int List(string prompt)
        {

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString))
            {


                try
                {
                    connection.Open();

                    var result = connection.Query<EmployeeListResult>(  "select * " +
                                                                        "from Employee");
                    foreach( var employee in result)
                    {
                        Console.WriteLine($"{employee.EmployeeId}.) {employee.FirstName} {employee.LastName}");
                    }

                    Console.WriteLine(prompt);

                    var wasInt = int.TryParse(Console.ReadLine(), out var entry);

                    return wasInt ? entry: 0;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }

                return 0;
            }
        }
    }
}
