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

        [Test]
        public void WhenEmployeeExists_ReturnsAll()
        {
            using (var context = new RepositoryContext(options))
            {
                SetupTestData(options);

                var repository = new EmployeesRepository(context);

                var employees = repository.GetAllEmployees().ToList();

                Assert.That(3 == employees.Count(), Is.True, "Should contain 3 employees");

                Employee firstReturnedEmployee = employees[0];
                Assert.True(firstReturnedEmployee.Id == EmployeesTestData.SeedData()[0].Id);
                Assert.True(firstReturnedEmployee.Name.Equals(EmployeesTestData.SeedData()[0].Name));
                Assert.True(firstReturnedEmployee.Age == EmployeesTestData.SeedData()[0].Age);

                Employee secondReturnedEmployee = employees[1];
                Assert.True(secondReturnedEmployee.Id == EmployeesTestData.SeedData()[1].Id);
                Assert.True(secondReturnedEmployee.Name.Equals(EmployeesTestData.SeedData()[1].Name));
                Assert.True(secondReturnedEmployee.Age == EmployeesTestData.SeedData()[1].Age);

                Employee thirdReturnedEmployee = employees[2];
                Assert.True(thirdReturnedEmployee.Id == EmployeesTestData.SeedData()[2].Id);
                Assert.True(thirdReturnedEmployee.Name.Equals(EmployeesTestData.SeedData()[2].Name));
                Assert.True(thirdReturnedEmployee.Age == EmployeesTestData.SeedData()[2].Age);
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
        private static void SetupTestData(DbContextOptions<RepositoryContext> options)
        {
            using (var context = new RepositoryContext(options))
            {
                context.Employees.AddRange(EmployeesTestData.SeedData());

                context.SaveChanges();
            }
        }
    }
}
