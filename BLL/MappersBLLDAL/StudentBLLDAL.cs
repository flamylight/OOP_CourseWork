namespace BLL.MappersBLLDAL;
using DAL.Entities;
using Models;

public static class StudentBLLDAL
{
    public static StudentEntity ToDAL(this Student bll)
    {
        return new StudentEntity
        {
            Name = bll.Name,
            LastName = bll.LastName,
            StudentId = bll.StudentId,
            Course = bll.Course,
            Dormitory = bll.Dormitory?.ToDAL(),
            Group = bll.Group?.ToDAL()
        };
    }

    public static Student ToBLL(this StudentEntity dal)
    {
        return new Student
        {
            Name = dal.Name,
            LastName = dal.LastName,
            StudentId = dal.StudentId,
            Course = dal.Course,
            Dormitory = dal.Dormitory?.ToBLL(),
            Group = dal.Group?.ToBLL()
        };
    }
}