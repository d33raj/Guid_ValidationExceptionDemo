using Guid_Demo.Models;

namespace Guid_Demo.Services
{
    public interface IEmployeeServices
    {
        public List<Employee> GetAllEmployees();

        public Employee GetEmployee(Guid id);

        public int AddEmployee(Employee employee);
    }
}
