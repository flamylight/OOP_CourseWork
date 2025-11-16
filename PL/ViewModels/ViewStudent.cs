namespace PL.ViewModels;

public class ViewStudent
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Course { get; set; }
    public string StudentId { get; set; }
    public ViewGroup GroupId { get; set; }


    public ViewStudent(){}

    public override string ToString()
    {
        return $"Student: {Name}, {LastName}, {Course}, {StudentId}";
    }
}