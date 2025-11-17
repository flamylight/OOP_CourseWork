namespace PL;
using ModelsMenu;

public class Menu
{
    private bool _isRunning = true;


    private StudentMenu _studentMenu;
    private GroupMenu _groupMenu;
    private DormitoryMenu _dormitoryMenu;


    public Menu(StudentMenu sm, GroupMenu gm, DormitoryMenu dm)
    {
        _studentMenu = sm;
        _groupMenu = gm;
        _dormitoryMenu = dm;
    }

    public void Run()
    {
        while (_isRunning)
        {
            ShowMenu();
            switch (Console.ReadLine())
            {
                case "1":
                    ShowStudentMenu();
                    break;
                case "2":
                    ShowGroupMenu();
                    break;
                case "3":
                    ShowDormitoryMenu();
                    break;
            }
        }
    }

    private void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Students");
        Console.WriteLine("2. Groups");
        Console.WriteLine("3. Dormitory");
        Console.WriteLine("0. Exit");
        Console.Write("Your choice: ");
    }

    private void ShowStudentMenu()
    {
        Console.Clear();

        Console.WriteLine("1. Add Student");
        Console.WriteLine("2. Delete Student");
        Console.WriteLine("3. Show all students");
        Console.WriteLine("4. Search by student ID");
        Console.WriteLine("0. Back");
        Console.Write("Your choice: ");

        switch (Console.ReadLine())
        {
            case "1":
                _studentMenu.AddStudentFlow();
                break;

            case "2":
                _studentMenu.RemoveStudentFlow();
                break;

            case "3":
                _studentMenu.ShowAllStudents();
                break;

            case "4":
                _studentMenu.SearchByStudentID();
                break;

            case "0":
                return;

            default:
                Console.WriteLine("Invalid input!");
                break;
        }
    }

    private void ShowGroupMenu()
    {
        Console.Clear();

        Console.WriteLine("1. Add group");
        Console.WriteLine("2. Delete group");
        Console.WriteLine("3. Show all groups");
        Console.WriteLine("4. Search by ID");
        Console.WriteLine("5. Add student");
        Console.WriteLine("6. Delete student");
        Console.WriteLine("0. Back");
        Console.Write("Your choice: ");
        
        switch (Console.ReadLine())
        {
            case "1":
                _groupMenu.CreateGroup();
                break;
            case "2":
                _groupMenu.DeleteGroup();
                break;
            case "3":
                _groupMenu.ShowAllGroups();
                break;
            case "4":
                _groupMenu.SearchByStudentID();
                break;
            case "5":
                _groupMenu.AddStudent();
                break;
            case "6":
                _groupMenu.RemoveStudent();
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Invalid input!");
                break;
        }
    }
    
    private void ShowDormitoryMenu()
    {
        Console.Clear();

        Console.WriteLine("1. Add dormitory");
        Console.WriteLine("2. Delete dormitory");
        Console.WriteLine("3. Show all dormitories");
        Console.WriteLine("4. Search by ID");
        Console.WriteLine("5. Add student");
        Console.WriteLine("6. Delete student");
        Console.WriteLine("0. Back");
        Console.Write("Your choice: ");
        
        switch (Console.ReadLine())
        {
            case "1":
                _dormitoryMenu.CreateDormitory();
                break;
            case "2":
                _dormitoryMenu.DeleteDormitory();
                break;
            case "3":
                _dormitoryMenu.ShowAllDormitory();
                break;
            case "4":
                _groupMenu.SearchByStudentID();
                break;
            case "5":
                _dormitoryMenu.AddStudent();
                break;
            case "6":
                _dormitoryMenu.RemoveStudent();
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Invalid input!");
                break;
        }
    }
    
}