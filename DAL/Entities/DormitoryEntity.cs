namespace DAL.Entities;

public class DormitoryEntity
{
    public int Id { get; set; }
    public List<string> StudentsId { get; set; } = new();
    public int FreeSeats { get; set; }
}