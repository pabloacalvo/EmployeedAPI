using EmployeedAPI.Data;
using EmployeedAPI.Dto;
using EmployeedAPI.entities;
using EmployeedAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeedAPI.Repository
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<EmployeeDto> GetEmployees()
        {
            return _context.Employees
                .Include(e => e.State)
                .Include(e => e.Departament)
                .Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    EmployeeCode = e.EmployeeCode,
                    LastName = e.LastName,
                    FirstName = e.FirstName,
                    Range = e.Range,
                    HireDate = e.HireDate,
                    BusinessId = e.BusinessId,
                    Email = e.Email,
                    Phone = e.Phone,
                    StateName = e.State != null ? e.State.NameState : string.Empty,
                    DepartamentName = e.Departament != null ? e.Departament.DepartamentName : string.Empty
                })
                .ToList();
        }


        public bool AddEmployee(Employee employee) {
            _context.Employees.Add(employee);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0; // retorna true si guarda
        }

        public ICollection<Employee> GetEmployeesIdBusiness(int idBusiness)
        {
            return _context.Employees.Where(e=>e.BusinessId == idBusiness).ToList();
        }

        public Employee GetEmployeeById(int id) { 
        
            return _context.Employees.Where(p=>p.Id == id).FirstOrDefault();
        }
    }
}
