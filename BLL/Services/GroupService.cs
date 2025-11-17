using BLL.Exceptions;
using BLL.MappersBLLDAL;
using DAL;
namespace BLL.Services;
using Models;

public class GroupService
{
    private readonly EntityContext _context;

    public GroupService(EntityContext context)
    {
        _context = context;
    }

    public void AddGroup(string groupName)
    {
        Group newGroup = new Group(groupName);
        newGroup.Validate();
        var dalGroup = _context.GetGroupById(newGroup.GroupName);
        if (dalGroup != null)
        {
            throw new GroupAlreadyExistsException("Group is already exists");
        }
        _context.AddGroup(newGroup.ToDAL());
    }

    public void RemoveGroup(string groupName)
    {
        var group = _context.GetGroupById(groupName)?.ToBLL() ?? 
                       throw new GroupNotFoundException("Group not found");
        
        
        var students = _context.GetStudents.Select(s => s.ToBLL()).ToList();
        foreach (var student in students)
        {
            if (student.Group != null && student.Group.GroupName == group.GroupName)
            {
                student.LeaveGroup();
            }
        }
        _context.SaveStudents(students.Select(s => s.ToDAL()).ToList());
        _context.RemoveGroup(group.ToDAL());
    }

    public List<Group> AllGroups()
    {
        return _context.AllGroups().Select(g => g.ToBLL()).ToList();
    }

    public Group GetGroup(string groupName)
    {
        var group = _context.GetGroupById(groupName);
        if (group == null)
        {
            throw new GroupNotFoundException("Group not found");
        }

        return group.ToBLL();
    }

    public void AddStudent(string groupName, string studentID)
    {
        var group = _context.GetGroupById(groupName);
        if (group == null)
        {
            throw new GroupNotFoundException("Group not found");
        }
        var student = _context.GetById(studentID);
        if (student == null)
        {
            throw new StudentNotFoundException("Student not found");
        }

        var groupBLL = group.ToBLL();
        var studentBLL = student.ToBLL();
        groupBLL.AddStudent(studentBLL);
        studentBLL.AssignGroup(groupBLL);
        
        _context.UpdateGroup(groupBLL.ToDAL());
        _context.UpdateStudent(studentBLL.ToDAL());
    }

    public void RemoveStudent(string groupName, string studentID)
    {
        var group = _context.GetGroupById(groupName);
        if (group == null)
        {
            throw new GroupNotFoundException("Group not found");
        }
        var student = _context.GetById(studentID);
        if (student == null)
        {
            throw new StudentNotFoundException("Student not found");
        }

        var groupBLL = group.ToBLL();
        var studentBLL = student.ToBLL();
        groupBLL.RemoveStudent(studentBLL);
        studentBLL.LeaveGroup();
        
        _context.UpdateGroup(groupBLL.ToDAL());
        _context.UpdateStudent(studentBLL.ToDAL());
    }

    public Student GetStudent(string groupName, string studentID)
    {
        var student = _context.GetById(studentID);
        if (student != null && student.Group.GroupName == groupName)
        {
            return student.ToBLL();
        }
        throw new StudentNotFoundException("Student not found");
    }
    
}