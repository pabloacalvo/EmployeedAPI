using EmployeedAPI.entities;
using System.ComponentModel.DataAnnotations;

namespace EmployeedAPI.Models
{
    public class Departament
    {
        [Key]

        public int Id { get; set; }
        public string DepartamentName { get; set; } = string.Empty;

        public ICollection<Employee> Employees { get; set; }

    }
}
