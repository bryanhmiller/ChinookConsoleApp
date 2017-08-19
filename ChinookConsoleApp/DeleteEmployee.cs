using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookConsoleApp
{
    public class DeleteEmployee
    {
        public void Delete()
        {
            var employeeList = new ListEmployees();
            var firedEmployee = employeeList.List("Pick an employee to fire");

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString))
            {
                connection.Open();

                try
                {

                    var affectedRows = connection.Execute(  "delete from Employee where EmployeeId = @EmployeeId",
                                                            new {EmployeeId = firedEmployee });
                    if (affectedRows == 1)
                    {
                        Console.WriteLine("Success");
                    }
                    else if (affectedRows > 1)
                    {
                        Console.WriteLine("AAAAHHHHH");
                    }
                    else
                    {
                        Console.WriteLine("Failed to find a matching Id");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Press enter to return to the menu");
                Console.ReadLine();
            }


        }
    }
}
