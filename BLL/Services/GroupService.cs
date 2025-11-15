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

    public void AddGroup(Group group)
    {
        group.Validate();
        var dalGroup = _context.GetGroupById(group.GroupName);
        if (dalGroup != null)
        {
            throw new Exception("Group is already exists");
        }
        _context.AddGroup(group.ToDAL());
    }

    public void RemoveGroup(string groupName)
    {
        var groups = _context.AllGroups().Select(g => g.ToBLL()).ToList();
        var group = groups.FirstOrDefault(g => g.GroupName == groupName);
        if (group == null)
        {
            throw new Exception("Group not found");
        }
        var students = _context.AllStudents().Select(s => s.ToBLL()).ToList();
        foreach (var student in students)
        {
            if (student.GroupId != null && student.GroupId.GroupName == group.GroupName)
            {
                group.RemoveStudent(student);
            }
        }
        groups.Remove(group);
        _context.SaveGroups(groups.Select(g => g.ToDAL()).ToList());
    }

    public List<Group> GetGroups()
    {
        return _context.AllGroups().Select(g => g.ToBLL()).ToList();
    }

    public Group GetGroup(string groupName)
    {
        var group = _context.GetGroupById(groupName);
        if (group == null)
        {
            throw new Exception("Group not found");
        }

        return group.ToBLL();
    }
}