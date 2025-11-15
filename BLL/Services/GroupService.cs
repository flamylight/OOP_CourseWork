using BLL.MappersBLLDAL;
using DAL;
namespace BLL.Services;
using System.Text.RegularExpressions;
using GroupModel = Models.Group;

public class GroupService
{
    private readonly List<GroupModel> _groups;
    private readonly EntityContext _context;

    public GroupService(EntityContext context)
    {
        _context = context;
    }

    public void AddGroup(GroupModel group)
    {
        if (_groups.Any(g => g.GroupName == group.GroupName))
        {
            throw new Exception("Group with the same name already exists");
        }
        if (!Regex.IsMatch(group.GroupName, @"^[А-Я]{1}-\d{3}-\d{2}-\d{1}-[А-Я]{2}$"))
        {
            throw new ArgumentException("Group id must be the format \"Б-121-24-2-ПІ\"");
        }
        _groups.Add(group);
        _context.Groups.Add(group.ToDAL());
        _context.SaveChanges();
    }

    public void RemoveGroup(string groupName)
    {
        var removeGroup = _groups.FirstOrDefault(g => g.GroupName == groupName);
        var students = removeGroup?.Students;

        if (students != null)
        {
            foreach (var student in students)
            {
                student.GroupId = null;
            }
            
            
        }
    }
}