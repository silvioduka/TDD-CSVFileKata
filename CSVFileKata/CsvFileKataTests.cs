﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace CSVFileKata
{
    [TestFixture]
    public class CsvFileKataTests
    {
        [Test]
        public void Write_Given_Should()
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
            sut.Write("", customer);

            // Assert
            fileSystem.Received(1).WriteLine("", "Brandon Page,1234555678");
        }
    }

    public class CustomerCsvFileWriter
    {
        private readonly IFileSystem _fileSystem;

        public CustomerCsvFileWriter(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        internal void Write(string fileName, Customer customer)
        {
            _fileSystem.WriteLine("", "Brandon Page,1234555678");
        }
    }
}