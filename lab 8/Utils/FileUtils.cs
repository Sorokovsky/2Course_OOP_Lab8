namespace Lab_8.Utils;
public class FileUtils
{
    public string Path { get; set; }

    public FileUtils(string path)
    {
        Path = path;
    }

    private void Append(Patient patient)
    {
        var text = patient.ToString();
        using var stream = new FileStream(Path, FileMode.Append);
        var bytes = text.Select(symbol => Convert.ToByte(symbol));
        var span = new ReadOnlySpan<byte>(bytes.ToArray());
        stream.Write(span);
    }

    public void Rewrite(IEnumerable<Patient> patients)
    {
        using var stream = new FileStream(Path, FileMode.OpenOrCreate);
        using var writer = new StreamWriter(stream);
        writer.WriteLine($"Count: {patients.Count()}");
        foreach (var patient in patients)
        {
            Append(patient);
        }
    }

    public LinkedList<Patient> Read()
    {
        LinkedList<Patient> patients = new();
        try
        {
            using var stream = new FileStream(Path, FileMode.Open);
            using var reader = new StreamReader(stream);
            int count = Convert.ToInt32(reader.ReadLine().Trim(' ').Split(":")[1]);
            for (int i = 0; i < count; i++)
            {
                var lines = string.Empty;
                for (int j = 0; j < 3; j++)
                {
                    lines += $"{reader.ReadLine()}\n";
                }

                patients.AddLast(Patient.ParseFromString(lines));
            }

            return patients;
        }
        catch (FileNotFoundException exception)
        {
            Console.WriteLine(exception.Message);
            return patients;
        }
    }
}