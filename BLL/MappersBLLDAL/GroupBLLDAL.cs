using BLL.Models;
using DAL.Entities;
namespace BLL.MappersBLLDAL;

public static class GroupBLLDAL
{
    public static GroupEntity ToDAL(this Group bll)
    {
        return new GroupEntity
        {
            GroupName = bll.GroupName,
            StudentsId = bll.StudentsId
        };
    }

    public static Group ToBLL(this GroupEntity dal)
    {
        return new Group
        {
            GroupName = dal.GroupName,
            StudentsId = dal.StudentsId
        };
    }
}