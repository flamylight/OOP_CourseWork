namespace BLL.MappersBLLDAL;
using DAL.Entities;
using Models;

public static class RoomBLLDAL
{
    public static RoomEntity ToDAL(this Room bll)
    {
        return new RoomEntity
        {
            Id = bll.Id,
            Students = bll.Students.Select(s => s.ToDAL()).ToList()
        };
    }

    public static Room ToBLL(this RoomEntity dal)
    {
        return new Room
        {
            Id = dal.Id,
            Students = dal.Students.Select(s => s.ToBLL()).ToList()
        };
    }
}