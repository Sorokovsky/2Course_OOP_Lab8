namespace Lab_8.Commands;

public abstract class Command
{
    private static int _number = 0;

    public int Number { get; } = CurrentNumber;
    public abstract string Title { get; }
    public abstract void GetResult(PatientsBook book);

    private static int CurrentNumber => _number++;

    public override string ToString()
    {
        return $"{Number}-{Title}";
    }
}