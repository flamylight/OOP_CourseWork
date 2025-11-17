namespace PL.MappersBLLPL;
using BLL.Models;
using ViewModels;

public static class DormitoryBLLPL
{
    public static ViewDormitory ToPL(this Dormitory bll)
    {
        return new ViewDormitory
        {
            Id = bll.Id,
            FreeSeats = bll.FreeSeats
        };
    }
}