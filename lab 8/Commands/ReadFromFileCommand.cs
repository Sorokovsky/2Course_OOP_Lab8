namespace Lab_8.Commands;

public class ReadFromFileCommand : Command
{
    public override string Title { get; } = "Read from file.";
    public override void GetResult(PatientsBook book)
    {
        book.Read();
    }
}