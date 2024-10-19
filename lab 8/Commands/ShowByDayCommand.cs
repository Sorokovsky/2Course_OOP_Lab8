namespace Lab_8.Commands;

public class ShowByDayCommand : Command
{
    public override string Title { get; } = "Show by day.";
    public override void GetResult(PatientsBook book)
    {
        Console.Write("Enter a year: ");
        int year = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter a month: ");
        int month = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter a day: ");
        int day = Convert.ToInt32(Console.ReadLine());
        DateOnly date = new(year, month, day);
        var found = book.Find(x => x.Date.Equals(date));
        if (!found.Any())
        {
            Console.WriteLine("Sorry but doctor do not has a patients for this day.");
        }
        else
        {
            for (int i = 0; i < found.Count(); i++)
            {
                Console.WriteLine($"#{i + 1}");
                Console.WriteLine(found.ElementAt(i));
            }
        }
    }
}