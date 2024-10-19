namespace Lab_8;
public class Patient
{
    private int _hour;
    
    public DateOnly Date { get; set; }

    public int Hour
    {
        get
        {
            return _hour;
        }
        set
        {
            if (value < 0) _hour = 0;
            else if (value > 24) _hour = 24;
            else _hour = value;
        }
    }

    public string Surname { get; set; }

    public Patient(DateOnly date, int hour, string surname)
    {
        Date = date;
        Hour = hour;
        Surname = surname;
    }

    public static Patient Enter()
    {
        Console.Write("Enter a year: ");
        var year = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter a number of month: ");
        var month = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter a number of day: ");
        var day = Convert.ToInt32(Console.ReadLine());
        var date = new DateOnly(year, month, day);
        Console.Write("Enter a hour: ");
        var hour = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter a surname: ");
        var surname = Console.ReadLine() ?? string.Empty;
        return new Patient(date, hour, surname);
    }

    public override string ToString()
    {
        return $"Date: {Date.Day}.{Date.Month}.{Date.Year}\n" +
               $"Time: {Hour}:00\n" +
               $"Surname: {Surname}\n";
    }

    public static Patient ParseFromString(string lines)
    {
        var parameters = lines.Split("\n");
        var date = DateOnly.Parse(parameters[0].Trim(' ').Split(":")[1]);
        var time = Convert.ToInt32(parameters[1].Replace(":00", "").Trim(' ').Split(":")[1]);
        var surname = parameters[2].Split(":")[1].Trim(' ');
        return new Patient(date, time, surname);
    }
}