using BLL.Exceptions;
using BLL.MappersBLLDAL;
using BLL.Models;
using DAL;
using DAL.DataProvider;


namespace BLL.Services;

public class StudentService
{
    private readonly IEntityContext _context;

    public StudentService(IEntityContext context)
    {
        _context = context;
    }

    public void AddStudent(string name, string lastName, int course, string studentId)
    {
        var student = new Student(name, lastName, course, studentId);
        student.Validate();
        var dalStudent = _context.GetById(student.StudentId);
        if (dalStudent != null)
        {
           throw new StudentAlreadyExistsException("Student already exists");
        }
        _context.AddStudent(student.ToDAL());
    }

    public void RemoveStudent(string studentId)
    {
        var dalStudent = _context.GetById(studentId) ?? throw new StudentNotFoundException("Student not found");
        var student = dalStudent.ToBLL();

        if (student.Dormitory != null)
        {
            student.Dormitory.RemoveStudent(student);
            _context.UpdateDormitory(student.Dormitory.ToDAL());
            student.LeaveDormitory();
        }

        if (student.Group != null)
        {
            student.Group.RemoveStudent(student);
            _context.UpdateGroup(student.Group.ToDAL());
            student.LeaveGroup();
        }
        _context.RemoveStudent(student.ToDAL());
    }

    public List<Student> AllStudents()
    {
        return _context.GetStudents.Select(s => s.ToBLL()).ToList();
    }

    public Student GetStudent(string studentId)
    {
        return _context.GetById(studentId)?.ToBLL() ??
               throw new StudentNotFoundException("Student not found");;
    }
    
}