namespace TestBLL;
using DAL.DataProvider;
using Moq;
using BLL.Services;
using DAL.Entities;
using BLL.Exceptions;
using BLL.Models;

[TestFixture]
public class TestGroupService
{
    private Mock<IEntityContext> _mockContext;
    private GroupService _groupService;
    
    [SetUp]
    public void Setup()
    {
        _mockContext = new Mock<IEntityContext>();
        _groupService = new GroupService(_mockContext.Object);
    }
    
    //Add group
    [Test]
    public void AddGroup_NewGroup_AddsSuccessfully()
    {
        string groupName = "B-121-24-2-PI";
        _mockContext.Setup(c => c.GetGroupById(groupName)).Returns((GroupEntity)null);
        
        _groupService.AddGroup(groupName);
        
        _mockContext.Verify(c => c.AddGroup(It.Is<GroupEntity>(g => g.GroupName == groupName)), Times.Once);
    }
    
    [Test]
    public void AddGroup_ExistingGroup_ThrowsException()
    {
        string groupName = "B-121-24-2-PI";
        var existingGroup = new GroupEntity { GroupName = groupName };
        _mockContext.Setup(c => c.GetGroupById(groupName)).Returns(existingGroup);
        
        Assert.Throws<GroupAlreadyExistsException>(() => _groupService.AddGroup(groupName));
    }
    
    [Test]
    public void AddGroup_Validate()
    {
        var group = new Group(groupName:"B-121-24-2-P");
        
        Assert.Throws<InvalidGroupIdFormatException>(() => 
            group.Validate());
    }
    
    //Delete group
    [Test]
    public void RemoveGroup_GroupExists_RemovesGroupAndUpdatesStudents()
    {
        string groupName = "B-121-24-2-PI";
        var groupEntity = new GroupEntity { GroupName = groupName };

        var students = new List<StudentEntity>
        {
            new StudentEntity { StudentId = "KB15280786", Group = groupEntity },
            new StudentEntity { StudentId = "KB15280789", Group = null}
        };

        _mockContext.Setup(c => c.GetGroupById(groupName)).Returns(groupEntity);
        _mockContext.Setup(c => c.GetStudents).Returns(students);
        
        _groupService.RemoveGroup(groupName);
        
        _mockContext.Verify(c => c.SaveStudents(It.Is<List<StudentEntity>>(l =>
            l.First(s => s.StudentId == "KB15280786").Group == null
        )), Times.Once);

        _mockContext.Verify(c => c.RemoveGroup(It.Is<GroupEntity>(
            g => g.GroupName == groupName)), Times.Once);
    }
    
    [Test]
    public void RemoveGroup_GroupNotFound_ThrowsException()
    {
        string groupName = "B-121-24-2-PI";
        _mockContext.Setup(c => c.GetGroupById(groupName)).Returns((GroupEntity)null);
        
        Assert.Throws<GroupNotFoundException>(() => _groupService.RemoveGroup(groupName));
    }
    
    
    //Add student
    [Test]
    public void AddStudent_ValidGroupAndStudent_AddsStudent()
    {
        string groupName = "B-121-24-2-PI";
        string studentID = "KB15280786";

        var groupEntity = new GroupEntity { GroupName = groupName };
        var studentEntity = new StudentEntity { StudentId = studentID };

        _mockContext.Setup(c => c.GetGroupById(groupName)).Returns(groupEntity);
        _mockContext.Setup(c => c.GetById(studentID)).Returns(studentEntity);
        
        _groupService.AddStudent(groupName, studentID);
        
        _mockContext.Verify(c => c.UpdateGroup(It.Is<GroupEntity>(
            g => g.GroupName == groupName)), Times.Once);
        _mockContext.Verify(c => c.UpdateStudent(It.Is<StudentEntity>(
            s => s.StudentId == studentID)), Times.Once);
    }
    
    [Test]
    public void AddStudent_GroupDoesNotExist_ThrowsException()
    {
        string groupName = "B-121-24-2-PI";
        string studentID = "KB15280786";

        _mockContext.Setup(c => c.GetGroupById(groupName)).Returns((GroupEntity)null);

        Assert.Throws<GroupNotFoundException>(() => _groupService.AddStudent(groupName, studentID));
    }
    
    [Test]
    public void AddStudent_StudentDoesNotExist_ThrowsException()
    {
        string groupName = "B-121-24-2-PI";
        string studentID = "KB15280789";

        var groupEntity = new GroupEntity { GroupName = groupName };
        _mockContext.Setup(c => c.GetGroupById(groupName)).Returns(groupEntity);
        _mockContext.Setup(c => c.GetById(studentID)).Returns((StudentEntity)null);

        Assert.Throws<StudentNotFoundException>(() => _groupService.AddStudent(groupName, studentID));
    }
}