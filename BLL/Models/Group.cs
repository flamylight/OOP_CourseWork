namespace BLL.Models;
using System.Text.RegularExpressions;

public class Group
{
    public string GroupName { get; set; }
    public List<string> StudentsId { get; set; } = new();
    public int CountStudents => StudentsId.Count;
    
    public void AddStudent(Student student)
    {
        student.Validate();
        StudentsId.Add(student.StudentId);
    }

    public void RemoveStudent(Student student)
    {
        if (!StudentsId.Contains(student.StudentId))
        {
            throw new ArgumentException("Student not found");
        }
        student.GroupId = null;
        StudentsId.Remove(student.StudentId);
    }

    public void Validate()
    {
        if (!Regex.IsMatch(GroupName, @"^[А-Я]{1}-\d{3}-\d{2}-\d{1}-[А-Я]{2}$"))
        {
            throw new ArgumentException("Group id must be the format \"Б-121-24-2-ПІ\"");
        }
    }
}