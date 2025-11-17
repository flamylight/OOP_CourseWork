namespace BLL.Models;
using System.Text.RegularExpressions;

public class Group
{
    public string GroupName { get; set; }
    public List<string> StudentsId { get; set; } = new();
    public int CountStudents => StudentsId.Count;

    public Group() {}
    
    public Group(string groupName)
    {
        GroupName = groupName;
    }
    
    public void AddStudent(Student student)
    {
        if (StudentsId.Contains(student.StudentId))
        {
            throw new Exception("Student already exists");
        }
        StudentsId.Add(student.StudentId);
    }

    public void RemoveStudent(Student student)
    {
        if (!StudentsId.Contains(student.StudentId))
        {
            throw new ArgumentException("Student not found");
        }
        StudentsId.Remove(student.StudentId);
    }

    public void Validate()
    {
        if (!Regex.IsMatch(GroupName, @"^[A-Z]{1}-\d{3}-\d{2}-\d{1}-[A-Z]{2}$"))
        {
            throw new ArgumentException("Group id must be the format \"B-121-24-2-PI\"");
        }
    }
}