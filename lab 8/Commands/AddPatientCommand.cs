namespace Lab_8.Commands;

public class AddPatientCommand : Command
{
    public override string Title { get; } = "Add patient.";
    public override void GetResult(PatientsBook book)
    {
        Patient patient = Patient.Enter();
        var candidates = book.Find(
            x => patient.Date.Equals(x.Date) && patient.Hour == x.Hour);
        if (candidates.Any())
        {
            throw new Exception("Sorry but doctor has patient for this time.");
        }
        book.Append(patient);
    }
}