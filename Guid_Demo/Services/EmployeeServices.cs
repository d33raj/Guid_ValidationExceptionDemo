using Guid_Demo.Exceptions;
using Guid_Demo.Models;
using Guid_Demo.Repositories;

namespace Guid_Demo.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IRepository<Employee> _repository;

        public EmployeeServices(IRepository<Employee> repository)
        {
            _repository = repository;
        }
        public int AddEmployee(Employee employee)
        {
            _repository.Add(employee);
            return 1;
        }

        public List<Employee> GetAllEmployees()
        {
            var employees=_repository.GetAll().ToList();
            return employees;
        }

        public Employee GetEmployee(Guid id)
        {
            var employee=_repository.GetById(id);
            if (employee != null)
            {
                return employee;
            }
            throw new EmployeeNotFoundException("No Such Employee Exists");
        }
    }
}
