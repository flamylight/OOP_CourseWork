namespace DAL.Entities;

public class StudentEntity
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Course { get; set; }
    public string StudentId { get; set; }
    public GroupEntity GroupId { get; set; }
    public DormitoryEntity DormitoryId { get; set; }
    public int RoomId { get; set; }

    // public StudentEntity(string name, string lastName, int course, string studentId)
    // {
    //     Name = name;
    //     LastName = lastName;
    //     Course = course;
    //     StudentId = studentId;
    // }
}