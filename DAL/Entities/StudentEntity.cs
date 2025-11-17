namespace DAL.Entities;

public class StudentEntity
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Course { get; set; }
    public string StudentId { get; set; }
    public GroupEntity Group { get; set; }
    public DormitoryEntity Dormitory { get; set; }
    
}