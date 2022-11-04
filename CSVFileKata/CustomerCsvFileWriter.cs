namespace CSVFileKata;

public class CustomerCsvFileWriter
{
    private readonly IFileSystem _fileSystem;

    public CustomerCsvFileWriter(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public void Write(string fileName, List<Customer> customers)
    {
        foreach (Customer customer in customers)
        {
            _fileSystem.WriteLine(fileName, customer.ToString());
        }
    }
}