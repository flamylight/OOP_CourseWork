namespace PL.ViewModels;

public class ViewGroup
{
    public string GroupName { get; set; }
    public List<string> StudentsId { get; set; } = new();
    public int CountStudents => StudentsId.Count;

    public override string ToString()
    {
        return $"{GroupName}: {CountStudents}";
    }
}