namespace PL.MappersBLLPL;
using BLL.Models;
using ViewModels;

public static class GroupBLLPL
{
    public static ViewGroup ToPL(this Group bll)
    {
        return new ViewGroup
        {
            GroupName = bll.GroupName,
            StudentsId = bll.StudentsId
        };
    }
}