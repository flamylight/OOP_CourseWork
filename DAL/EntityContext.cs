using DAL.Entities;
using DAL.DataProvider;

namespace DAL;

public class EntityContext
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
    

    private List<StudentEntity> GetStudents => _studentsProvider.Load();
    private List<GroupEntity> GetGroups => _groupsProvider.Load();
    public List<DormitoryEntity> GetDormitories => _dormitoriesProvider.Load();
    
    public void SaveStudents(List<StudentEntity> students) => _studentsProvider.Save(students);
    public void SaveGroups(List<GroupEntity> groups) => _groupsProvider.Save(groups);
    public void SaveDormitory(List<DormitoryEntity> dormitory) => _dormitoriesProvider.Save(dormitory);

    public void AddStudent(StudentEntity student)
    {
        var students = GetStudents.ToList();
        students.Add(student);
        _studentsProvider.Save(students);
    }

    public StudentEntity? GetById(string studentId)
    {
        var students = GetStudents.ToList();
        return students.FirstOrDefault(s => s.StudentId == studentId);
    }

    public List<StudentEntity> AllStudents()
    {
        return _studentsProvider.Load();
    }
    

    public void AddGroup(GroupEntity group)
    {
        var groups = GetGroups.ToList();
        groups.Add(group);
        _groupsProvider.Save(groups);
    }

    public GroupEntity? GetGroupById(string groupName)
    {
        var groups = GetGroups.ToList();
        return groups.FirstOrDefault(g => g.GroupName == groupName);
    }

    public List<GroupEntity> AllGroups()
    {
        return _groupsProvider.Load();
    }

    public void AddDormitory(DormitoryEntity dormitory)
    {
        var dormitories = GetDormitories.ToList();
        dormitories.Add(dormitory);
        _dormitoriesProvider.Save(dormitories);
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
                _dormitoriesProvider.Save(dormitories);
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
                _studentsProvider.Save(students);
                break;
            }
        }
    }
}