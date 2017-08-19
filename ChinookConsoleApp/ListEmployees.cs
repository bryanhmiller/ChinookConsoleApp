using System;
using System.Data.SqlClient;
using Dapper;

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

            using (var connection = new SqlConnection("Server = (local)\\SqlExpress; Database=chinook;Trusted_Connection=True;"))
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
                    return int.Parse(Console.ReadLine());
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
