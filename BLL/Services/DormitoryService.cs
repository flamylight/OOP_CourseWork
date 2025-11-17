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

    public void AddDormitory(int id, int countRooms)
    {
        var dormitory = new Dormitory(id, countRooms*4);
        if (dormitory.FreeSeats < 4)
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

        var students = _context.GetStudents.Select(s => s.ToBLL()).ToList();
        if (dalDormitory.StudentsId.Count != 0)
        {
            foreach (var student in students)
            {
                if (dalDormitory.StudentsId.Contains(student.StudentId))
                {
                    student.LeaveDormitory();
                    _context.UpdateStudent(student.ToDAL());
                }
            }
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
    
    public void AddStudent(int id, string studentID)
    {
        var dormitory = _context.GetDormitoryById(id);
        if (dormitory == null)
        {
            throw new Exception("Dormitory not found");
        }
        var student = _context.GetById(studentID);
        if (student == null)
        {
            throw new Exception("Student not found");
        }

        var dormitoryBLL = dormitory.ToBLL();
        var studentBLL = student.ToBLL();
        dormitoryBLL.AddStudent(studentBLL);
        
        _context.UpdateDormitory(dormitoryBLL.ToDAL());
        _context.UpdateStudent(studentBLL.ToDAL());
    }
    
    public void RemoveStudent(int id, string studentID)
    {
        var dormitory = _context.GetDormitoryById(id);
        if (dormitory == null)
        {
            throw new Exception("Dormitory not found");
        }
        var student = _context.GetById(studentID);
        if (student == null)
        {
            throw new Exception("Student not found");
        }

        var dormitoryBLL = dormitory.ToBLL();
        var studentBLL = student.ToBLL();
        dormitoryBLL.RemoveStudent(studentBLL);
        
        _context.UpdateDormitory(dormitoryBLL.ToDAL());
        studentBLL.LeaveDormitory();
        _context.UpdateStudent(studentBLL.ToDAL());
    }
}