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
    public class UpdateEmployee
    {
        public void Update()
        {
            var employeeList = new ListEmployees();
            var employeeUpdate = employeeList.List("Pick an employee to change their name");

            Console.WriteLine("Enter first name:");
            var firstName = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            var lastName = Console.ReadLine();

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString))
            {
                try
                {
                    var rowsAffected = connection.Execute(  "Update Employee " + 
                                                            "Set FirstName = @firstName, LastName = @lastName " + 
                                                            "Where EmployeeId = @employeeUpdate ",
                                                            new {   EmployeeUpdate = employeeUpdate,
                                                                    FirstName = firstName,
                                                                    LastName = lastName});
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }

                Console.WriteLine("Press enter to return to the menu.");
                Console.ReadLine();

//          Previously written code
/*
                var employeeListCommand = connection.CreateCommand();

                employeeListCommand.CommandText = "select * from Employee";

                try
                {
                    connection.Open();
                    var reader = employeeListCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["EmployeeId"]}.) {reader["FirstName"]} {reader["LastName"]}");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
             
                Console.WriteLine("Please enter the number of the entry you want to change");
                var selection = Console.ReadLine();

                var employeeUpdate = connection.CreateCommand();
                employeeUpdate.CommandText =    "Update Employee" +
                                                "Set(@firstName,@lastName)" +
                                                "Where EmployeeId = @selection";

                var selectionparameter = employeeUpdate.Parameters.Add("@selection", SqlDbType.VarChar);
                selectionparameter.Value = selection;

                var firstNameparameter = employeeUpdate.Parameters.Add("@firstName", SqlDbType.VarChar);
                firstNameparameter.Value = firstName;

                var lastNameparameter = employeeUpdate.Parameters.Add("@lastName", SqlDbType.VarChar);
                lastNameparameter.Value = lastName;
*/
            }
        }
    }
}
