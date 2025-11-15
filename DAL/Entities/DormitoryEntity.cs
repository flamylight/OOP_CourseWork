namespace DAL.Entities;

public class DormitoryEntity
{
    public int Id { get; set; }
    public List<RoomEntity> Rooms { get; set; } = new();
    public int CountRooms => Rooms.Count;

    // public DormitoryEntity(int id)
    // {
    //     Id = id;
    // }
}