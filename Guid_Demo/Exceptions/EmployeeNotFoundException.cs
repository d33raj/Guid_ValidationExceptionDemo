namespace Guid_Demo.Exceptions
{
    public class EmployeeNotFoundException: Exception
    {
        public EmployeeNotFoundException(string message): base(message) { }
    }
}
