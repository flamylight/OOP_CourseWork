namespace DAL.DataProvider;
using Entities;

public interface IEntityContext
{
    List<StudentEntity> GetStudents { get; }
    List<GroupEntity> GetGroups { get; }
    List<DormitoryEntity> GetDormitories { get; }

    void SaveStudents(List<StudentEntity> students);
    void SaveGroups(List<GroupEntity> groups);
    void SaveDormitory(List<DormitoryEntity> dormitory);

    void AddStudent(StudentEntity student);
    StudentEntity? GetById(string studentId);
    
    void AddGroup(GroupEntity group);
    GroupEntity? GetGroupById(string groupName);

    void AddDormitory(DormitoryEntity dormitory);
    DormitoryEntity? GetDormitoryById(int dormitoriesId);

    void RemoveDormitory(DormitoryEntity dormitory);
    void RemoveStudent(StudentEntity student);
    void RemoveGroup(GroupEntity group);

    void UpdateStudent(StudentEntity student);
    void UpdateGroup(GroupEntity group);
    void UpdateDormitory(DormitoryEntity dormitory);
}