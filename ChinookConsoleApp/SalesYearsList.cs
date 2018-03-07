using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookConsoleApp
{
    public class SalesYearsListResult
    {
        public int Year { get; set; }
    }

    public class SalesYearsList
    {
        public int ListYear()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString))
            {


                try
                {
                    connection.Open();

                    var result = connection.Query<SalesYearsListResult>(    "select Year(Invoice.InvoiceDate) 'Year' " +
                                                                            "from Invoice " +
                                                                            "group by Year");

                    foreach (var Invoice in result)
                    {
                        Console.WriteLine($"{Invoice.Year}");
                    }

                    Console.WriteLine();

                    var wasInt = int.TryParse(Console.ReadLine(), out var entry);

                    return wasInt ? entry : 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }

                return 0;
            }
        }
    }
}
