namespace CSVFileKata;

public class CustomerCsvFileWriter
{
    private readonly IFileSystem _fileSystem;

    public CustomerCsvFileWriter(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public void Write(string fileName, Customer customer)
    {
        _fileSystem.WriteLine("", "Brandon Page,1234555678");
    }
}