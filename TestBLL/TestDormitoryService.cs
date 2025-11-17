namespace TestBLL;
using DAL.DataProvider;
using Moq;
using BLL.Services;
using DAL.Entities;
using BLL.Exceptions;

[TestFixture]
public class TestDormitoryService
{
    private Mock<IEntityContext> _mockContext;
    private DormitoryService _dormitoryService;
    
    [SetUp]
    public void Setup()
    {
        _mockContext = new Mock<IEntityContext>();
        _dormitoryService = new DormitoryService(_mockContext.Object);
    }
    
    //Add dormitory
    [Test]
    public void AddDormitory_ValidDormitory_AddsDormitory()
    {
        int dormId = 1;
        int countRooms = 5;
        _mockContext.Setup(c => c.GetDormitoryById(dormId)).Returns((DormitoryEntity)null);
        
        _dormitoryService.AddDormitory(dormId, countRooms);
        
        _mockContext.Verify(c => c.AddDormitory(It.Is<DormitoryEntity>(
            d => d.Id == dormId && d.FreeSeats == 20)), Times.Once);
    }
    
    [Test]
    public void AddDormitory_NotEnoughRooms_ThrowsArgumentException()
    {
        int dormId = 1;
        int countRooms = 0;

        Assert.Throws<ArgumentException>(() => _dormitoryService.AddDormitory(dormId, countRooms));
    }
    
    [Test]
    public void AddDormitory_AlreadyExists_ThrowsDormitoryAlreadyExistsException()
    {
        int dormId = 1;
        int countRooms = 5;
        var existingDorm = new DormitoryEntity { Id = dormId };
        _mockContext.Setup(c => c.GetDormitoryById(dormId)).Returns(existingDorm);

        Assert.Throws<DormitoryAlreadyExistsException>(() => _dormitoryService.AddDormitory(dormId, countRooms));
    }
    
    //Delete dormitory
    [Test]
    public void RemoveDormitory_DormitoryExistsWithStudents_UpdatesStudents()
    {
        int dormId = 1;
        var dormitoryEntity = new DormitoryEntity { Id = dormId, StudentsId = new List<string>
        {
            "KB15280786", "KB15280789"
        } };
        var students = new List<StudentEntity>
        {
            new StudentEntity { StudentId = "KB15280786" },
            new StudentEntity { StudentId = "KB15280789" },
            new StudentEntity { StudentId = "KB15280785" } 
        };

        _mockContext.Setup(c => c.GetDormitoryById(dormId)).Returns(dormitoryEntity);
        _mockContext.Setup(c => c.GetStudents).Returns(students);
        
        _dormitoryService.RemoveDormitory(dormId);
        
        _mockContext.Verify(c => c.UpdateStudent(It.Is<StudentEntity>(
            s => s.StudentId == "KB15280786")), Times.Once);
        _mockContext.Verify(c => c.UpdateStudent(It.Is<StudentEntity>(
            s => s.StudentId == "KB15280789")), Times.Once);
        _mockContext.Verify(c => c.UpdateStudent(It.Is<StudentEntity>(
            s => s.StudentId == "KB15280785")), Times.Never);
        _mockContext.Verify(c => c.RemoveDormitory(dormitoryEntity), Times.Once);
    }
    
    [Test]
    public void RemoveDormitory_DormitoryDoesNotExist_ThrowsDormitoryNotFoundException()
    {
        int dormId = 1;
        _mockContext.Setup(c => c.GetDormitoryById(dormId)).Returns((DormitoryEntity)null);

        Assert.Throws<DormitoryNotFoundException>(() => _dormitoryService.RemoveDormitory(dormId));
    }
    
    //Remove student
    [Test]
    public void RemoveStudent_StudentAndDormitoryExist_RemovesStudentFromDormitory()
    {
        int dormId = 1;
        string studentID = "KB15280786";

        var dormitoryEntity = new DormitoryEntity { Id = dormId, StudentsId = new List<string> { studentID } };
        var studentEntity = new StudentEntity { StudentId = studentID };

        _mockContext.Setup(c => c.GetDormitoryById(dormId)).Returns(dormitoryEntity);
        _mockContext.Setup(c => c.GetById(studentID)).Returns(studentEntity);
        
        _dormitoryService.RemoveStudent(dormId, studentID);
        
        _mockContext.Verify(c => c.UpdateDormitory(It.Is<DormitoryEntity>(
            d => !d.StudentsId.Contains(studentID))), Times.Once);
        _mockContext.Verify(c => c.UpdateStudent(It.Is<StudentEntity>(
            s => s.StudentId == studentID)), Times.Once);
    }
    
    [Test]
    public void RemoveStudent_DormitoryDoesNotExist_ThrowsDormitoryNotFoundException()
    {
        int dormId = 1;
        string studentID = "KB15280786";

        _mockContext.Setup(c => c.GetDormitoryById(dormId)).Returns((DormitoryEntity)null);

        Assert.Throws<DormitoryNotFoundException>(() => _dormitoryService.RemoveStudent(dormId, studentID));
    }

    [Test]
    public void RemoveStudent_StudentDoesNotExist_ThrowsStudentNotFoundException()
    {
        int dormId = 1;
        string studentID = "KB15280786";

        _mockContext.Setup(c => c.GetDormitoryById(dormId)).Returns(new DormitoryEntity { Id = dormId });
        _mockContext.Setup(c => c.GetById(studentID)).Returns((StudentEntity)null);

        Assert.Throws<StudentNotFoundException>(() => _dormitoryService.RemoveStudent(dormId, studentID));
    }
}