namespace BLL.Models;

public class Group
{
    public string GroupName { get; set; }
    public List<string> StudentsId { get; set; } = new();
    public int CountStudents => StudentsId.Count;
    
    public void AddStudent(Student student)
    {
        student.Validate();
        StudentsId.Add(student.StudentId);
    }

    public void RemoveStudent(Student student)
    {
        if (!StudentsId.Contains(student.StudentId))
        {
            throw new ArgumentException("Student not found");
        }
        student.GroupId = null;
        StudentsId.Remove(student.StudentId);
    }
}