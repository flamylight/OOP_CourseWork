namespace PL.ModelsMenu;
using BLL.Services;
using ViewModels;
using MappersBLLPL;

public class DormitoryMenu
{
    private DormitoryService _dormitoryService;
    
    public DormitoryMenu(DormitoryService dormitoryService)
    {
        _dormitoryService = dormitoryService;
    }
    
    public void CreateDormitory()
    {
        Console.Clear();
        
        Console.Write("ID dormitory: ");
        int id;
        int CountRooms;
        
        var checkId = int.TryParse(Console.ReadLine(), out id);
        if (checkId == false)
        {
            throw new Exception("ID dormitory must be an integer");
        }
        
        Console.Write("Rooms count: ");
        var checkRooms = int.TryParse(Console.ReadLine(), out CountRooms);
        if (checkRooms == false)
        {
            throw new Exception("Count rooms must be an integer");
        }
        
        try
        {
            _dormitoryService.AddDormitory(id, CountRooms);
            Console.WriteLine("Dormitory created");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
    
    public void DeleteDormitory()
    {
        Console.Clear();
        Console.Write("ID dormitory: ");
        int id;
        var checkId = int.TryParse(Console.ReadLine(), out id);
        if (checkId == false)
        {
            throw new Exception("ID dormitory must be an integer");
        }
        
        try
        {
            _dormitoryService.RemoveDormitory(id);
            Console.WriteLine("Dormitory deleted");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }


    public void ShowAllDormitory()
    {
        Console.Clear();

        List<ViewDormitory> dormitories = _dormitoryService.AllDormitories().Select(g => g.ToPL()).ToList();
        if (dormitories.Count == 0)
        {
            Console.WriteLine("No dormitories found!");
        }
        else
        {
            for (int i = 0; i < dormitories.Count; i++)
            {
                Console.WriteLine($"{i+1}. {dormitories[i]}");
            }
        }
        
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
    
    public void AddStudent()
    {
        Console.Clear();
        Console.Write("ID dormitory: ");
        int id;
        var checkId = int.TryParse(Console.ReadLine(), out id);
        if (checkId == false)
        {
            throw new Exception("ID dormitory must be an integer");
        }
        Console.Write("Student ID: ");
        string studentID = Console.ReadLine();
        
        try
        {
            _dormitoryService.AddStudent(id, studentID);
            Console.WriteLine("Student added");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
    
    public void RemoveStudent()
    {
        Console.Clear();
        
        Console.Write("ID dormitory: ");
        int id;
        var checkId = int.TryParse(Console.ReadLine(), out id);
        if (checkId == false)
        {
            throw new Exception("ID dormitory must be an integer");
        }
        Console.Write("Student ID: ");
        string studentID = Console.ReadLine();
        
        try
        {
            _dormitoryService.RemoveStudent(id, studentID);
            Console.WriteLine("Student deleted");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}