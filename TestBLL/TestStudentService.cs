using DAL.DataProvider;
using Moq;
namespace TestBLL;
using BLL.Services;
using DAL.Entities;
using BLL.Exceptions;
using BLL.Models;
using BLL.MappersBLLDAL;

[TestFixture]
public class StudentServiceTest
{
    private Mock<IEntityContext> _mockContext;
    private StudentService _studentService;
    
    [SetUp]
    public void Setup()
    {
        _mockContext = new Mock<IEntityContext>();
        _studentService = new StudentService(_mockContext.Object);
    }

    //Add student
    [Test]
    public void AddStudent_StudentExists()
    {
        _mockContext
            .Setup(c => c.GetById("KB15280786"))
            .Returns(new StudentEntity { StudentId = "KB15280786" });
        
        Assert.Throws<StudentAlreadyExistsException>(() =>
            _studentService.AddStudent("John", "Doe", 1, "KB15280786"));
        
    }

    [Test]
    public void AddStudent_Validate()
    {
        var student1 = new Student(null, "Pupkin", 2, "KB15280786");
        var student2 = new Student("Vasya", null, 2, "KB15280786");
        var student3 = new Student("Vasya", "Pupkin", 2, "KB1528078");
        
        Assert.Throws<ArgumentException>(() => 
                student1.Validate());
        
        Assert.Throws<ArgumentException>(() => 
            student2.Validate());
        
        Assert.Throws<InvalidStudentIdFormatException>(() => 
            student3.Validate());
    }
    
    [Test]
    public void AddStudent_NewStudent()
    {
        
        _studentService.AddStudent("Alice", "Brown", 1, "KB15280786");
        
        _mockContext.Verify(
            c => c.AddStudent(It.Is<StudentEntity>(s => s.StudentId == "KB15280786")),
            Times.Once
        );
    }
    
    //Delete student
    [Test]
    public void RemoveStudent_StudentNotFound()
    {
        _mockContext.Setup(c => c.GetById("KB15280786")).Returns((StudentEntity?)null);
        
        Assert.Throws<StudentNotFoundException>(() =>
            _studentService.RemoveStudent("X1"));
    }
    
    [Test]
    public void RemoveStudent_NoGroupNoDormitory_RemovesStudent()
    {
        
        var dal = new StudentEntity { StudentId = "KB15280786" };
        _mockContext.Setup(c => c.GetById("KB15280786")).Returns(dal);
        
        _studentService.RemoveStudent("KB15280786");
        
        _mockContext.Verify(c => c.RemoveStudent(It.Is<StudentEntity>(
            s => s.StudentId == "KB15280786")), Times.Once);
    }
    
    [Test]
    public void RemoveStudent_WithDormitory_UpdatesDormitory()
    {
        
        var dormitoryBLL = new Dormitory(1, 10);
        var studentBLL = new Student("Vasya", "Pupkin", 1, "KB15280786");
        studentBLL.AssignDormitory(dormitoryBLL);
        dormitoryBLL.AddStudent(studentBLL);

        _mockContext.Setup(c => c.GetById("KB15280786")).Returns(studentBLL.ToDAL());
        
        _studentService.RemoveStudent("KB15280786");
        
        _mockContext.Verify(c => c.UpdateDormitory(It.IsAny<DormitoryEntity>()), Times.Once);
        
        _mockContext.Verify(c => c.RemoveStudent(It.Is<StudentEntity>(
            s => s.StudentId == "KB15280786")), Times.Once);
    }
    
    [Test]
    public void RemoveStudent_WithGroup_UpdatesGroup()
    {
        var groupBLL = new Group("B-121-24-2-PI");
        var studentBLL = new Student("Vasya", "Pupkin", 1, "KB15280786");
        studentBLL.AssignGroup(groupBLL);
        groupBLL.AddStudent(studentBLL);

        _mockContext.Setup(c => c.GetById("KB15280786")).Returns(studentBLL.ToDAL());

        var service = new StudentService(_mockContext.Object);
        
        service.RemoveStudent("KB15280786");
        
        _mockContext.Verify(c => c.UpdateGroup(It.IsAny<GroupEntity>()), Times.Once);
        _mockContext.Verify(c => c.RemoveStudent(
            It.Is<StudentEntity>(s => s.StudentId == "KB15280786")), Times.Once);
    }
    
    //Return all
    [Test]
    public void AllStudents_ReturnsAllStudents()
    {
        var dalStudents = new List<StudentEntity>
        {
            new StudentEntity { StudentId = "KB15280786", Name = "Alice", LastName = "Smith", Course = 1 },
            new StudentEntity { StudentId = "KB87408378", Name = "Bob", LastName = "Brown", Course = 2 }
        };
        _mockContext.Setup(c => c.GetStudents).Returns(dalStudents);
        
        var result = _studentService.AllStudents();
        
        Assert.That(result.Count, Is.EqualTo(2));
        Assert.That(result.Any(s => s.StudentId == "KB15280786" && s.Name == "Alice"), Is.True);
        Assert.That(result.Any(s => s.StudentId == "KB87408378" && s.Name == "Bob"), Is.True);
        
        _mockContext.Verify(c => c.GetStudents, Times.Once);
    }
    
    //Search student
    [Test]
    public void GetStudent_ExistingId_ReturnsStudent()
    {
        var dalStudent = new StudentEntity { StudentId = "KB15280786", Name = "Alice" };
        _mockContext.Setup(c => c.GetById("KB15280786")).Returns(dalStudent);

        var result = _studentService.GetStudent("KB15280786");

        Assert.That(result.StudentId, Is.EqualTo("KB15280786"));
        Assert.That(result.Name, Is.EqualTo("Alice"));
        _mockContext.Verify(c => c.GetById("KB15280786"), Times.Once);
    }
    
    [Test]
    public void GetStudent_NonExistingId_ThrowsStudentNotFoundException()
    {
        _mockContext.Setup(c => c.GetById("KB15280786")).Returns((StudentEntity)null);

        Assert.Throws<StudentNotFoundException>(() => 
            _studentService.GetStudent("KB15280786"));

        _mockContext.Verify(c => c.GetById("KB15280786"), Times.Once);
    }
}