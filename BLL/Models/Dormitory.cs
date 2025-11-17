namespace BLL.Models;

public class Dormitory
{
    public int Id { get; set; }
    public List<string> StudentsIds { get; set; } = new();
    public int FreeSeats { get; set; }

    public Dormitory(){}
    
    public Dormitory(int id, int rooms)
    {
        Id = id;
        FreeSeats = rooms;
    }

    public void AddStudent(Student student)
    {
        if (FreeSeats == 0)
        {
            throw new Exception("No seats available");
        }

        if (StudentsIds.Contains(student.StudentId))
        {
            throw new Exception("Student already exists");
        }
        StudentsIds.Add(student.StudentId);
        student.AssignDormitory(this);
        FreeSeats--;
    }

    public void RemoveStudent(Student student)
    {
        if (!StudentsIds.Contains(student.StudentId))
        {
            throw new Exception("No student found in dormitory");
        }
        StudentsIds.Remove(student.StudentId);
        FreeSeats++;
    }
}