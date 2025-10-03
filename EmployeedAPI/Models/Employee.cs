using EmployeedAPI.Models;
using System.ComponentModel.DataAnnotations;
namespace EmployeedAPI.entities
{
    public class Employee
    {
        [Key] // se debe colocar para la migracion 
        public int Id {  get; set; }
        public string EmployeeCode { get; private set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;

        // Relacion con departamento
        public int DepartamentId {  get; set; }
        public Departament? Departament { get; set; }
        public string Range { get; set; } = string.Empty;
        public DateOnly HireDate { get; set; }
        public int BusinessId { get; set; }

        public int StateId { get; set; }
        public State? State { get; set; }

        // Adicional data
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;


        private void SetEmployeeNumber(string code)
        {
            if (DepartamentId == 1) {
                EmployeeCode = "99" + code;
            }
            else
            {
                EmployeeCode = code;
            }
        }
    }
}
