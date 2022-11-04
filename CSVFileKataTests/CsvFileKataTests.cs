using Castle.Core.Resource;

using CSVFileKata;
using NSubstitute;
using NUnit.Framework;

namespace CSVFileKataTests
{
    [TestFixture]
    public class CsvFileKataTests
    {
        private static Customer CreateCustomer(string name, string contactNumber)
        {
            return new Customer
            {
                Name = name,
                ContactNumber = contactNumber
            };
        }

        [Test]
        public void Write_GivenOneCustomer_ShouldWriteCustomerDataAsCsvLineToProvidedFile()
        {
            // Arrange
            var customer = CreateCustomer("Brandon Page", "1234555678");
            var fileSystem = Substitute.For<IFileSystem>();
            var sut = new CustomerCsvFileWriter(fileSystem);

            // Act
            sut.Write("customer.csv", new List<Customer> { customer });

            // Assert
            fileSystem.Received(1).WriteLine("customer.csv", "Brandon Page,1234555678");
        }

        [Test]
        public void Write_GivenTwoCustomers_ShouldWriteBothCustomersDataAsCsvLinesToProvidedFile()
        {
            // Arrange
            var customer1 = CreateCustomer("Jayd Page", "23456789");
            var customer2 = CreateCustomer("Peter Wiles", "98765432");
            
            var fileSystem = Substitute.For<IFileSystem>();
            var sut = new CustomerCsvFileWriter(fileSystem);

            // Act
            sut.Write("cust.csv", new List<Customer>{customer1, customer2});

            // Assert
            fileSystem.Received(1).WriteLine("cust.csv", "Jayd Page,23456789");
            fileSystem.Received(1).WriteLine("cust.csv", "Peter Wiles,98765432");
        }

        [Test]
        public void Write_GivenThreeCustomers_ShouldWriteAllCustomersDataAsCsvLinesToProvidedFile()
        {
            // Arrange
            var customer1 = CreateCustomer("Mark Pearl", "1234567890");
            var customer2 = CreateCustomer("Sylvain", "0987654321");
            var customer3 = CreateCustomer("Bob", "5432167890");

            var fileSystem = Substitute.For<IFileSystem>();
            var sut = new CustomerCsvFileWriter(fileSystem);

            // Act
            sut.Write("cust1.csv", new List<Customer> { customer1, customer2, customer3 });

            // Assert
            fileSystem.Received(1).WriteLine("cust1.csv", "Mark Pearl,1234567890");
            fileSystem.Received(1).WriteLine("cust1.csv", "Sylvain,0987654321");
            fileSystem.Received(1).WriteLine("cust1.csv", "Bob,5432167890");
        }
    }
}
