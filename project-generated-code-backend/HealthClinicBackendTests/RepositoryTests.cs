using System;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using NUnit.Framework;
using Xunit;
using Xunit.Abstractions;

namespace HealthClinicBackendTests
{
    public class RepositoryTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public RepositoryTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void TestMedicineRepository_GetsAll()
        {
            // GIVEN
            var subject = new MedicineDatabaseSql();

            // WHEN
            var result = subject.GetAll();

            foreach (var medicine in result)
            {
                _testOutputHelper.WriteLine(medicine.ToString());
            }

            // THEN
            Assert.IsNotEmpty(result);
        }
    }
}