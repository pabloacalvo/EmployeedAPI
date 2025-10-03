using EmployeedAPI.Dto;
using EmployeedAPI.entities;

namespace EmployeedAPI.Interfaces
{
    public interface IEmployeeRepository
    {
        ICollection<EmployeeDto> GetEmployees();

        Employee GetEmployeeById(int id);
        ICollection<Employee> GetEmployeesIdBusiness(int idBusiness);
        bool AddEmployee(Employee employee);
        bool Save();

    }
}
