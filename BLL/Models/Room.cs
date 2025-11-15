namespace BLL.Models;

public class Room
{
    public int Id { get; set; }
    public List<Student> Students { get; set; } = new();
    public int CountStudents => Students.Count;
    
    public Room() {}

    public Room(int id)
    {
        Id = id;
    }

    public void AddStudent(Student student)
    {
        Students.Add(student);
        student.RoomId = Id;
    }

    public void RemoveStudent(Student student)
    {
        Students.Remove(student);
        student.RoomId = 0;
    }
}