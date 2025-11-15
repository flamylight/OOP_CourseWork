using BLL.MappersBLLDAL;
using BLL.Models;
using DAL;


namespace BLL.Services;

public class StudentService
{
    private readonly EntityContext _context;

    public StudentService(EntityContext context)
    {
        _context = context;
    }

    public void AddStudent(Student student)
    {
        student.Validate();
        var dalStudent = _context.GetById(student.StudentId);
        if (dalStudent != null)
        {
           throw new Exception("Student already exists");
        }
        _context.AddStudent(student.ToDAL());
    }

    public void RemoveStudent(string studentId)
    {
        var allStudents = _context.AllStudents()?.Select(s => s.ToBLL());
        var student = allStudents.FirstOrDefault(s => s.StudentId == studentId) ??
                      throw new Exception("Student not found");

        if (student.DormitoryId != null)
        {
            student.DormitoryId.RemoveStudent(student);
        }

        if (student.GroupId != null)
        {
            student.GroupId.RemoveStudent(student);
        }
        _context.SaveStudents(allStudents.Select(s => s.ToDAL()).ToList());
    }

    public List<Student> AllStudents()
    {
        return _context.AllStudents()?.Select(s => s.ToBLL()).ToList();
    }

    public Student GetStudent(string studentId)
    {
        return _context.GetById(studentId).ToBLL() ??
               throw new Exception("Student not found");;
    }
    
}