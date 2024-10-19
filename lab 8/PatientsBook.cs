namespace Lab_8;
using Utils;

public class PatientsBook
{
    public delegate bool IsNeed(Patient patient);
    
    private LinkedList<Patient> _list = new();

    private FileUtils _fileUtils;

    public int Count => _list.Count;

    public Patient this[int index]
    {
        get
        {
            ValidateIndex(index);
            return _list.ElementAt(index);
        }
    }

    public PatientsBook(string filePath)
    {
        _fileUtils = new(filePath);
    }

    public void Append(Patient patient)
    {
        _list.AddLast(patient);
    }

    public void Delete(IsNeed isNeed)
    {
        _list = new(_list.Where(isNeed.Invoke).ToArray());
    }

    public IEnumerable<Patient> Find(IsNeed isNeed)
    {
        return _list.Where(isNeed.Invoke);
    }

    public void Save()
    {
        _fileUtils.Rewrite(_list);
    }

    public void Read()
    {
        _list = _fileUtils.Read();
    }
    
    public void SetFilePath(string filePath)
    {
        _fileUtils.Path = filePath;
    }

    private void ValidateIndex(int index)
    {
        if (index < 0 || index >= Count)
            throw new IndexOutOfRangeException();
    }
}