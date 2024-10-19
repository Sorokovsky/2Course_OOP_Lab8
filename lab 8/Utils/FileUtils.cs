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
        stream.Close();
    }

    public void Rewrite(LinkedList<Patient> patients)
    {
        using var stream = new FileStream(Path, FileMode.OpenOrCreate);
        using var writer = new StreamWriter(stream);
        writer.WriteLine($"Count: {patients.Count}");
        foreach (var patient in patients)
        {
            Append(patient);
        }
        writer.Close();
        stream.Close();
    }

    public LinkedList<Patient> Read()
    {
        LinkedList<Patient> patients = new();
        using var stream = new FileStream(Path, FileMode.Open);
        using var reader = new StreamReader(stream);
        var count = Convert.ToInt32((reader.ReadLine() ?? string.Empty).Trim(' ').Split(":")[1]);
        for (var i = 0; i < count; i++)
        {
            var lines = string.Empty;
            for (var j = 0; j < 3; j++)
            {
                lines += $"{reader.ReadLine()}\n";
            }
            patients.AddLast(Patient.ParseFromString(lines));
        }
        reader.Close();
        stream.Close();
        return patients;
    }
}