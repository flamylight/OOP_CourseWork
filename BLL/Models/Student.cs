using System.Text.RegularExpressions;

namespace BLL.Models;

public class Student
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Course { get; set; }
    public string StudentId { get; set; }
    public Group Group { get; set; }
    public Dormitory Dormitory { get; set; }

    public Student(){}
    
    public Student(string name, string lastName, int course, string studentId)
    {
        Name = name;
        LastName = lastName;
        Course = course;
        StudentId = studentId;
    }

    public void Validate()
    {
        if (string.IsNullOrEmpty(Name))
        {
            throw new ArgumentException("Student name is required");
        }

        if (string.IsNullOrEmpty(LastName))
        {
            throw new ArgumentException("Student last name is required");
        }

        if (Course <= 0 || Course > 6)
        {
            throw new ArgumentException("Course must be between 0 and 6");
        }
        if (!Regex.IsMatch(StudentId, @"^[A-Z]{2}\d{8}$"))
        {
            throw new ArgumentException("Student id must be the format \"KB15280786\"");
        }
        
    }

    public void AssignGroup(Group group)
    {
        Group = group;
    }
    
    public void LeaveGroup()
    {
        Group = null;
    }

    public void LeaveDormitory()
    {
        Dormitory = null;
    }

    public void AssignDormitory(Dormitory dormitory)
    {
        Dormitory = dormitory;
    }
}