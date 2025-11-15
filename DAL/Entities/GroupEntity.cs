namespace DAL.Entities;

public class GroupEntity
{
    public string GroupName { get; set; }
    public List<string> StudentsId { get; set; } = new();
    public int CountStudents => StudentsId.Count;

    // public GroupEntity(string groupName)
    // {
    //     GroupName = groupName;
    // }
    
}