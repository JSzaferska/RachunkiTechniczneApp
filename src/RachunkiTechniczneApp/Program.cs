using System.Data.SqlClient;
using RachunkiTechniczneApp.DTOs;
using Dapper;
using Microsoft.VisualBasic;

namespace RachunkiTechniczneApp
{
    internal class Program
    {
        private const string ConnectionString =
            "Persist Security Info=False;Integrated Security=True;TrustServerCertificate=True;Initial Catalog=RachunkiTechniczne;Server=NITRO-WIATRY\\SQLEXPRESS";


        static async Task Main(string[] args)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            /*
            Console.WriteLine("Podaj nazwę firmy, której faktury chciałbyś wyświetlić:");
            string companyName = Console.ReadLine();

            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = $"SELECT i.Id, i.TotalNet, i.TotalGross, i.IssueDate, i.DueDate, i.Paid, i.Description FROM Invoices AS i LEFT JOIN Companies AS c ON i.CompanyId = c.Id WHERE c.Name = '{companyName}'";
                var result =
                    await connection.QueryAsync<InvoiceDto>(sql);

                foreach (var item in result)
                {
                    Console.WriteLine($"Id: {item.Id}, TotalNet: {item.TotalNet}, TotalGross: {item.TotalGross}, IssueDate: {item.IssueDate}, DueDate: {item.DueDate}, Paid: {item.Paid}, Description: {item.Description}");
                }
            }
            */
        }
    }
}
