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
    public class AddEmployee
    {
        public void Add()
        {
            Console.WriteLine("Enter first name:");
            var firstName = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            var lastName = Console.ReadLine();
            
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString))
            {

                try
                {
                    connection.Open();

                    var rowsAffected = connection.Execute(  "Insert into Employee(Firstname, LastName) " +
                                                            "Values(@firstName,@lastName)", 
                                                            new {FirstName = firstName, LastName = lastName});
                    
                    Console.WriteLine(rowsAffected != 1 ? "Add Failed" : "Success!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }

                Console.WriteLine("Press enter to return to the menu.");
                Console.ReadLine();
            }
        }
    }
}
