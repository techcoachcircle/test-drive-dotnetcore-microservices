using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using tdd_dotnetcore_microservices.Models;
using tdd_dotnetcore_microservices.Repository;

namespace tdd_dotnetcore_microservices.Test.Repository
{
    public class EmployeeRepositoryTest
    {
        private SqliteConnection connection;

        private DbContextOptions<RepositoryContext> options;

        [SetUp]
        public void Setup()
        {
            connection = GetSqliteConnection();

            options = GetSqliteContextOptions(connection);
        }

        [Test]
        public void shouldAutoGenerateId()
        {
            using (var context = new RepositoryContext(options))
            {
                context.Employees.Add(new Employee());

                context.SaveChanges();

                var repository = new EmployeesRepository(context);

                var employees = repository.GetAllEmployees().ToList();

                Assert.That(1 == employees[0].Id, Is.True, "Should be equal to 1");
            }
        }

        private static SqliteConnection GetSqliteConnection()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            return connection;
        }

        private static DbContextOptions<RepositoryContext> GetSqliteContextOptions(SqliteConnection connection)
        {
            var options = new DbContextOptionsBuilder<RepositoryContext>()
                   .UseSqlite(connection)
                   .Options;

            using (var context = new RepositoryContext(options))
            {
                context.Database.EnsureCreated();
            }

            return options;
        }
    }
}
