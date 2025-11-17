using BLL.Exceptions;

namespace PL.ModelsMenu;
using BLL.Services;
using ViewModels;
using MappersBLLPL;

public class GroupMenu
{
    private GroupService _groupService;

    public GroupMenu(GroupService groupService)
    {
        _groupService = groupService;
    }

    public void CreateGroup()
    {
        Console.Clear();
        
        Console.Write("Name group: ");
        try
        {
            _groupService.AddGroup(Console.ReadLine());
            Console.WriteLine("Group created");
        }
        catch (InvalidGroupIdFormatException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (GroupAlreadyExistsException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    public void DeleteGroup()
    {
        Console.Clear();
        Console.Write("Name group: ");
        try
        {
            _groupService.RemoveGroup(Console.ReadLine());
            Console.WriteLine("Group deleted");
        }
        catch (GroupNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    public void AddStudent()
    {
        Console.Clear();
        
        Console.Write("Name group: ");
        string groupName = Console.ReadLine();
        Console.Write("student ID: ");
        string studentID = Console.ReadLine();
        try
        {
            _groupService.AddStudent(groupName, studentID);
            Console.WriteLine("Student added");
        }
        catch (GroupNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (StudentAlreadyExistsException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (StudentNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    public void RemoveStudent()
    {
        Console.Clear();
        
        Console.Write("Name group: ");
        string groupName = Console.ReadLine();
        Console.Write("student ID: ");
        string studentID = Console.ReadLine();
        try
        {
            _groupService.RemoveStudent(groupName, studentID);
            Console.WriteLine("Student deleted");
        }
        catch (StudentNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (GroupNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    public void ShowAllGroups()
    {
        Console.Clear();

        List<ViewGroup> groups = _groupService.AllGroups().Select(g => g.ToPL()).ToList();
        if (groups.Count == 0)
        {
            Console.WriteLine("No groups found!");
        }
        else
        {
            for (int i = 0; i < groups.Count; i++)
            {
                Console.WriteLine($"{i+1}. {groups[i]}");
            }
        }
        
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
    
    public void SearchById()
    {
        Console.Clear();
        
        Console.Write("Group ID: ");
        try
        {
            var group = _groupService.GetGroup(Console.ReadLine());
            Console.WriteLine("Found!");
            Console.WriteLine(group.ToPL());
            
        }
        catch (GroupNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    public void SearchStudent()
    {
        Console.Clear();
        
        Console.Write("Group ID: ");
        string groupName = Console.ReadLine();
        Console.Write("student ID: ");
        string studentID = Console.ReadLine();

        try
        {
            var student = _groupService.GetStudent(groupName, studentID);
            Console.WriteLine("Found!");
            Console.WriteLine(student.ToPL());
        }
        catch (StudentNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}