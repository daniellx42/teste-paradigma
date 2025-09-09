using System;
using System.IO;
using System.Globalization;
using Microsoft.Data.Sqlite;

class Program
{
    static void Main()
    {
        // carrega SQL da pasta migrates
        var sqlScript = File.ReadAllText("../../migrates/09092025_DepartmentAndPerson.sql");

        using var connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();

        using (var cmd = connection.CreateCommand())
        {
            cmd.CommandText = sqlScript;
            cmd.ExecuteNonQuery();
        }

        var query = @"
            SELECT d.Name AS Department, p.Name AS Person, p.Salary
            FROM Person p
            JOIN Department d ON p.DepartmentId = d.Id
            WHERE p.Salary = (
                SELECT MAX(p2.Salary)
                FROM Person p2
                WHERE p2.DepartmentId = p.DepartmentId
            );";

        using (var cmd = connection.CreateCommand())
        {
            cmd.CommandText = query;
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string dept = reader["Department"].ToString() ?? "";
                string person = reader["Person"].ToString() ?? "";
                int salaryCents = Convert.ToInt32(reader["Salary"]);
                decimal salary = salaryCents / 100m;

                string salaryFormatted = salary.ToString("C", new CultureInfo("pt-BR"));

                Console.WriteLine($"{person} ganhou o maior salario {salaryFormatted} no departamento {dept}");
            }
        }
    }
}
