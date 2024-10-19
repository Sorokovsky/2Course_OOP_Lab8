namespace Lab_8.Commands;

public class ShowAllCommand : Command
{
    public override string Title { get; } = "Show all.";
    public override void GetResult(PatientsBook book)
    {
        for (int i = 0; i < book.Count; i++)
        {
            Console.WriteLine($"#{i + 1}");
            Console.WriteLine(book[i]);
        }
    }
}