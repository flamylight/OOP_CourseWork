namespace DAL.Entities;

public class RoomEntity
{
    public int Id { get; set; }
    public List<StudentEntity> Students { get; set; } = new();
    public int CountStudents => Students.Count;

    // public RoomEntity(int id)
    // {
    //     Id = id;
    // }
    
}