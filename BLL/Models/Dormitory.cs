namespace BLL.Models;

public class Dormitory
{
    public int Id { get; set; }
    public List<Room> Rooms { get; set; } = new();
    public int CountPlaces => Rooms.Count * 4;

    public Dormitory(){}
    
    public Dormitory(int id, int rooms)
    {
        Id = id;

        for (int i = 0; i < rooms; i++)
        {
            Rooms.Add(new Room(i));
        }
    }

    public void AddStudent(Student student)
    {
        if (CountPlaces == 0)
        {
            throw new Exception("No seats available");
        }
        foreach (var room in Rooms)
        {
            if (room.CountStudents < 4)
            {
                room.AddStudent(student);
                student.DormitoryId = this;
            }
        }
    }

    public void RemoveStudent(Student student)
    {
        foreach (var room in Rooms)
        {
            if (room.Students.Contains(student))
            {
                room.RemoveStudent(student);
                student.DormitoryId = null;
                return;
            }
        }
        throw new Exception("No student found in dormitory");
    }
}