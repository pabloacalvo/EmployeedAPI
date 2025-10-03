using EmployeedAPI.Data;
using EmployeedAPI.entities;
using EmployeedAPI.Models;

namespace EmployeedAPI
{
    public static class Seed
    {
        public static void SeedData(DataContext context)
        {
            // asegurarse de que la BD existe
            context.Database.EnsureCreated();

            // cargar departamentos
            if (!context.Departaments.Any())
            {
                context.Departaments.AddRange(
                    new Departament { DepartamentName = "IT" },
                    new Departament { DepartamentName = "HR" },
                    new Departament { DepartamentName = "Finance" }
                );
                context.SaveChanges();
            }

            // cargar estados
            if (!context.States.Any())
            {
                context.States.AddRange(
                    new State { NameState = "Active" },
                    new State { NameState = "On Leave" },
                    new State { NameState = "Inactive" }
                );
                context.SaveChanges();
            }

            // cargar empleados
            if (!context.Employees.Any())
            {
                var itDept = context.Departaments.First(d => d.DepartamentName == "IT");
                var hrDept = context.Departaments.First(d => d.DepartamentName == "HR");
                var active = context.States.First(s => s.NameState == "Active");

                context.Employees.AddRange(
                    new Employee
                    {
                        LastName = "Pérez",
                        FirstName = "Juan",
                        DepartamentId = itDept.Id,
                        Range = "Senior",
                        HireDate = new DateOnly(2020, 5, 1),
                        BusinessId = 1,
                        StateId = active.IdState,
                        Email = "juan.perez@example.com",
                        Phone = "123456789",
                    },
                    new Employee
                    {
                        LastName = "Gómez",
                        FirstName = "Ana",
                        DepartamentId = hrDept.Id,
                        Range = "Junior",
                        HireDate = new DateOnly(2022, 8, 10),
                        BusinessId = 1,
                        StateId = active.IdState,
                        Email = "ana.gomez@example.com",
                        Phone = "987654321",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

