namespace Lab_8.Commands;

public class DeleteBySurnameCommand : Command
{
    public override string Title { get; } = "Delete by surname.";
    public override void GetResult(PatientsBook book)
    {
        Console.Write("Enter a surname: ");
        string surname = Console.ReadLine() ?? string.Empty;
        book.Delete(x => !surname.Equals(x.Surname));
    }
}