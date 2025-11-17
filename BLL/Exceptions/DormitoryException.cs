namespace BLL.Exceptions;

public class InvalidDormitoryIdFormatException: Exception
{
    public InvalidDormitoryIdFormatException() { }
    public InvalidDormitoryIdFormatException(string message) : base(message) { }
    public InvalidDormitoryIdFormatException(string message, Exception inner) : base(message, inner) { }
}

public class DormitoryNotFoundException: Exception
{
    public DormitoryNotFoundException() { }
    public DormitoryNotFoundException(string message) : base(message) { }
    public DormitoryNotFoundException(string message, Exception inner) : base(message, inner) { }
}

public class DormitoryAlreadyExistsException: Exception
{
    public DormitoryAlreadyExistsException() { }
    public DormitoryAlreadyExistsException(string message) : base(message) { }
    public DormitoryAlreadyExistsException(string message, Exception inner) : base(message, inner) { }
}

public class DormitoryFullException: Exception
{
    public DormitoryFullException() { }
    public DormitoryFullException(string message) : base(message) { }
    public DormitoryFullException(string message, Exception inner) : base(message, inner) { }
}