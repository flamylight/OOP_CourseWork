namespace PL.MappersBLLPL;
using BLL.Models;
using ViewModels;

public static class StudentBLLPL
{
    
    public static ViewStudent ToPL(this Student bll)
    {
        return new ViewStudent
        {
            Name = bll.Name,
            LastName = bll.LastName,
            StudentId = bll.StudentId,
            Course = bll.Course
        };
    }
}