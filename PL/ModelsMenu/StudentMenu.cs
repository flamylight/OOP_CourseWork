using BLL.Models;
namespace PL.ModelsMenu;
using BLL.Services;
using ViewModels;
using MappersBLLPL;

public class StudentMenu
{
    private StudentService _studentService;

    public StudentMenu(StudentService studentService)
    {
        _studentService = studentService;
    }
    
    public void AddStudentFlow()
    {
        Console.Clear();
        Console.Write("Name: ");
        string name = Console.ReadLine();
    
        Console.Write("Last name: ");
        string lastName = Console.ReadLine();
    
        Console.Write("Course: ");
        if (!int.TryParse(Console.ReadLine(), out int course))
        {
            Console.WriteLine("Invalid course!");
            return;
        }
    
        Console.Write("Student ID: ");
        string id = Console.ReadLine();
    
        try
        {
            _studentService.AddStudent(name, lastName, course, id);
            Console.WriteLine("Student added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
    
    public void RemoveStudentFlow()
    {
        Console.Clear();
        
        Console.Write("Student ID: ");
        try
        {
            _studentService.RemoveStudent(Console.ReadLine());
            Console.WriteLine("Student removed successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    public void ShowAllStudents()
    {
        Console.Clear();

        List<ViewStudent> students = _studentService.AllStudents().Select(s => s.ToPL()).ToList();
        if (students.Count == 0)
        {
            Console.WriteLine("No students found!");
        }
        else
        {
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i+1}. {students[i]}");
            }
        }
        
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    public void SearchByStudentID()
    {
        Console.Clear();
        
        Console.Write("Student ID: ");
        try
        {
            var student = _studentService.GetStudent(Console.ReadLine());
            Console.WriteLine(student.ToPL());
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}