namespace BLL.MappersBLLDAL;
using DAL.Entities;
using Models;

public static class DormitoryBLLDAL
{
    public static DormitoryEntity ToDAL(this Dormitory bll)
    {
        return new DormitoryEntity
        {
            Id = bll.Id,
            Rooms = bll.Rooms.Select(r => r.ToDAL()).ToList()
        };
    }

    public static Dormitory ToBLL(this DormitoryEntity dal)
    {
        return new Dormitory
        {
            Id = dal.Id,
            Rooms = dal.Rooms.Select(r => r.ToBLL()).ToList()
        };
    }
}