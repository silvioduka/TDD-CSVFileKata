using CSVFileKata;
using NSubstitute;
using NUnit.Framework;

namespace CSVFileKataTests
{
    [TestFixture]
    public class CsvFileKataTests
    {
        [Test]
        public void Write_GivenOneCustomer_ShouldWriteCustomerDataAsCsvLineToProvidedFile()
        {
            // Arrange
            var customer = new Customer
            {
                Name = "Brandon Page",
                ContactNumber = "1234555678"
            };
            var fileSystem = Substitute.For<IFileSystem>();
            var sut = new CustomerCsvFileWriter(fileSystem);

            // Act
            sut.Write("customer.csv", customer);

            // Assert
            fileSystem.Received(1).WriteLine("customer.csv", "Brandon Page,1234555678");
        }
    }
}
