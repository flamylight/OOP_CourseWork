namespace BLL.Exceptions;

public class InvalidStudentIdFormatException: Exception
{
    public InvalidStudentIdFormatException() { }
    public InvalidStudentIdFormatException(string message) : base(message) { }
    public InvalidStudentIdFormatException(string message, Exception inner) : base(message, inner) { }
}

public class StudentNotFoundException: Exception
{
    public StudentNotFoundException() { }
    public StudentNotFoundException(string message) : base(message) { }
    public StudentNotFoundException(string message, Exception inner) : base(message, inner) { }
}

public class StudentAlreadyExistsException: Exception
{
    public StudentAlreadyExistsException() { }
    public StudentAlreadyExistsException(string message) : base(message) { }
    public StudentAlreadyExistsException(string message, Exception inner) : base(message, inner) { }
}