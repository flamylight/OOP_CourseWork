using System.Text.RegularExpressions;

namespace BLL.Models;

public class Student
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Course { get; set; }
    public string StudentId { get; set; }
    public Group GroupId { get; set; }
    public Dormitory DormitoryId { get; set; }
    public int RoomId { get; set; }

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
            throw new ArgumentException("Student id must be fthe ormat \"KB15280786\"");
        }
        
    }
}