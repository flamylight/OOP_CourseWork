using DAL.Entities;
using DAL.DataProvider;

namespace DAL;

public class EntityContext: IEntityContext
{
    private readonly IDataProvider<StudentEntity> _studentsProvider;
    private readonly IDataProvider<GroupEntity> _groupsProvider;
    private readonly IDataProvider<DormitoryEntity> _dormitoriesProvider;

    public EntityContext(IDataProvider<StudentEntity> students, IDataProvider<GroupEntity> groups,
        IDataProvider<DormitoryEntity> dormitories)
    {
        _studentsProvider = students;
        _groupsProvider = groups;
        _dormitoriesProvider = dormitories;
        
    }


    public List<StudentEntity> GetStudents => _studentsProvider.Load();
    public List<GroupEntity> GetGroups => _groupsProvider.Load();
    public List<DormitoryEntity> GetDormitories => _dormitoriesProvider.Load();
    
    public void SaveStudents(List<StudentEntity> students) => _studentsProvider.Save(students);
    public void SaveGroups(List<GroupEntity> groups) => _groupsProvider.Save(groups);
    public void SaveDormitory(List<DormitoryEntity> dormitory) => _dormitoriesProvider.Save(dormitory);

    public void AddStudent(StudentEntity student)
    {
        var students = GetStudents.ToList();
        students.Add(student);
        SaveStudents(students);
    }

    public StudentEntity? GetById(string studentId)
    {
        var students = GetStudents.ToList();
        return students.FirstOrDefault(s => s.StudentId == studentId);
    }

    
    public void AddGroup(GroupEntity group)
    {
        var groups = GetGroups.ToList();
        groups.Add(group);
        SaveGroups(groups);
    }

    public GroupEntity? GetGroupById(string groupName)
    {
        var groups = GetGroups.ToList();
        return groups.FirstOrDefault(g => g.GroupName == groupName);
    }

    public List<GroupEntity> AllGroups()
    {
        return GetGroups.ToList();;
    }

    public void AddDormitory(DormitoryEntity dormitory)
    {
        var dormitories = GetDormitories.ToList();
        dormitories.Add(dormitory);
        SaveDormitory(dormitories);
    }
    
    public DormitoryEntity? GetDormitoryById(int dormitoriesId)
    {
        var dormitories = GetDormitories.ToList();
        return dormitories.FirstOrDefault(d => d.Id == dormitoriesId);
    }

    public void RemoveDormitory(DormitoryEntity dormitory)
    {
        var dormitories = GetDormitories.ToList();
        foreach (var dor in dormitories)
        {
            if (dor.Id == dormitory.Id)
            {
                dormitories.Remove(dor);
                SaveDormitory(dormitories);
                break;
            }
        }
    }

    public void RemoveStudent(StudentEntity student)
    {
        var students = GetStudents.ToList();
        foreach (var stud in students)
        {
            if (stud.StudentId == student.StudentId)
            {
                students.Remove(stud);
                SaveStudents(students);
                break;
            }
        }
    }
    
    public void RemoveGroup(GroupEntity group)
    {
        var groups = GetGroups.ToList();
        foreach (var gr in groups)
        {
            if (gr.GroupName == group.GroupName)
            {
                groups.Remove(gr);
                SaveGroups(groups);
                break;
            }
        }
    }
    
    
    public void UpdateStudent(StudentEntity student)
    {
        var students = GetStudents.ToList();
        var index = students.FindIndex(s => s.StudentId == student.StudentId);
        students[index] = student; 
        SaveStudents(students);
    }
    
    public void UpdateGroup(GroupEntity group)
    {
        var groups = GetGroups.ToList();
        var index = groups.FindIndex(s => s.GroupName == group.GroupName);
        groups[index] = group; 
        SaveGroups(groups);
    }
    
    public void UpdateDormitory(DormitoryEntity dormitory)
    {
        var dormitories = GetDormitories.ToList();
        var index = dormitories.FindIndex(s => s.Id == dormitory.Id);
        dormitories[index] = dormitory; 
        SaveDormitory(dormitories);
    }
}