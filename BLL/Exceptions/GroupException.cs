namespace BLL.Exceptions;

public class InvalidGroupIdFormatException: Exception
{
    public InvalidGroupIdFormatException() { }
    public InvalidGroupIdFormatException(string message) : base(message) { }
    public InvalidGroupIdFormatException(string message, Exception inner) : base(message, inner) { }
}


public class GroupNotFoundException: Exception
{
    public GroupNotFoundException() { }
    public GroupNotFoundException(string message) : base(message) { }
    public GroupNotFoundException(string message, Exception inner) : base(message, inner) { }
}

public class GroupAlreadyExistsException: Exception
{
    public GroupAlreadyExistsException() { }
    public GroupAlreadyExistsException(string message) : base(message) { }
    public GroupAlreadyExistsException(string message, Exception inner) : base(message, inner) { }
}