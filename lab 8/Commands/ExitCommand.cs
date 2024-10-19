namespace Lab_8.Commands;

public class ExitCommand : Command
{
    public override string Title { get; } = "Exit.";
    public override void GetResult(PatientsBook book)
    {
        Environment.Exit(0);
    }
}