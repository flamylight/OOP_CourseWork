using BLL.MappersBLLDAL;
using BLL.Models;
using DAL;
namespace BLL.Services;

public class DormitoryService
{
    private readonly EntityContext _context;

    public DormitoryService(EntityContext context)
    {
        _context = context;
    }

    public void AddDormitory(Dormitory dormitory)
    {
        if (dormitory.Rooms.Count < 1)
        {
            throw new Exception("Dormitory needs at least one room");
        }
        
        var dalDormitory = _context.GetDormitoryById(dormitory.Id);
        if (dalDormitory != null)
        {
            throw new Exception("Dormitory already exists");
        }
        
        _context.AddDormitory(dormitory.ToDAL());
    }

    public void RemoveDormitory(int dormitoryId)
    {
        var dalDormitory = _context.GetDormitoryById(dormitoryId) ??
                           throw new Exception("Dormitory not found");

        var students = _context.AllStudents().Select(s => s.ToBLL());
        foreach (var student in students)
        {
            student.MoveOut();
        }
        _context.RemoveDormitory(dalDormitory);
    }

    public List<Dormitory> AllDormitories()
    {
        return _context.GetDormitories.Select(d => d.ToBLL()).ToList();
    }

    public Dormitory GetDormitory(int dormitoryId)
    {
        var dormitory = _context.GetDormitoryById(dormitoryId) ??
                        throw new Exception("Dormitory not found");
        return dormitory.ToBLL();
    }
}