//Variant 12(4)
namespace Lab_8;
using Commands;
public static class Program
{
    private static int _operation;
    private static PatientsBook _book = new("patients.data");
    public static void Main()
    {
        List<Command> commands = new() { 
                new ExitCommand(), 
                new ReadFromFileCommand(),
                new ShowAllCommand(),
                new SaveCommand(),
                new AddPatientCommand(),
                new ShowByDayCommand(),
                new DeleteBySurnameCommand()
            };
        while (true)
        {
            try
            {
                _operation = ChooseOperation(commands);
                ProcessCommand(commands);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
        }
    }

    private static int ChooseOperation(List<Command> commands)
    {
        Console.WriteLine("Choose operation");
        foreach (var command in commands)
        {
            Console.WriteLine($"{command}");
        }
        Console.Write(">> ");
        return Convert.ToInt32(Console.ReadLine());
    }

    private static void ProcessCommand(List<Command> commands)
    {
        bool founded = false;
        foreach (var command in commands)
        {
            if (command.Number == _operation)
            {
                command.GetResult(_book);
                founded = true;
                break;
            }
        }

        if (founded == false)
        {
            throw new ArgumentException("Unknown operation. Try again.");
        }
    }
}