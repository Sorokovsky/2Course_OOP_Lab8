namespace Lab_8.Commands;

public class SaveCommand : Command
{
    public override string Title { get; } = "Write to file.";
    public override void GetResult(PatientsBook book)
    {
        book.Save();
    }
}