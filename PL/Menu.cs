namespace PL;
using ModelsMenu;

public class Menu
{
    private bool _isRunning = true;


    private StudentMenu _studentMenu;


    public Menu(StudentMenu sm)
    {
        _studentMenu = sm;

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
    
}