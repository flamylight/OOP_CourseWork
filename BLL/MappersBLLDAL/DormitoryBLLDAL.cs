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
            FreeSeats = bll.FreeSeats,
            StudentsId = bll.StudentsIds
        };
    }

    public static Dormitory ToBLL(this DormitoryEntity dal)
    {
        return new Dormitory
        {
            Id = dal.Id,
            FreeSeats = dal.FreeSeats,
            StudentsIds = dal.StudentsId
        };
    }
}