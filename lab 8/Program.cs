//Variant 12(4)

using Utils;

namespace Lab_8;
public static class Program
{
    public static void Main()
    {
        var fileUtil = new FileUtils("patients.dat");
        LinkedList<Patient> patients = new();
    }

    private static int ChooseOperation()
    {
        Console.WriteLine("Choose operation");
        Console.WriteLine("0-Exit.");
        Console.WriteLine("1-Read from file.");
        Console.WriteLine("2-Write to file.");
        Console.WriteLine("4-Add patient.");
        Console.WriteLine("5-Show by day.");
        Console.WriteLine("6-Delete by surname.");
        Console.Write(">> ");
        return Convert.ToInt32(Console.ReadLine());
    }
    
    
}