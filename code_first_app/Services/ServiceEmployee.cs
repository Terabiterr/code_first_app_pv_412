using code_first_app.Models;
using Microsoft.EntityFrameworkCore;

/*
 USE PV_412
-- CEO
INSERT INTO Employees (FirstName, LastName, ManagerId)
VALUES ('Ivan', 'Ivanov', NULL); -- CEO --1

-- Рівень 2 - менеджери під CEO
INSERT INTO Employees (FirstName, LastName, ManagerId)
VALUES 
('Petro', 'Petrov', 1), --2
('Olena', 'Olenina', 1), --3
('Mykola', 'Mykolenko', 1); --4

-- Рівень 3 - менеджери під менеджерами
INSERT INTO Employees (FirstName, LastName, ManagerId)
VALUES 
('Sergiy', 'Serhienko', 2),
('Iryna', 'Irynchuk', 2),

('Dmytro', 'Dmytriv', 3),
('Nadiya', 'Nadiyenko', 3),

('Oleh', 'Olehiv', 4),
('Tamara', 'Tamarova', 4);

-- Рівень 4 - звичайні працівники
-- Під 5
INSERT INTO Employees (FirstName, LastName, ManagerId)
VALUES 
('Marta', 'Martynenko', 5),
('Bogdan', 'Bohdanov', 5),
('Andriy', 'Andriyenko', 5);

-- Під 6
INSERT INTO Employees (FirstName, LastName, ManagerId)
VALUES 
('Kateryna', 'Koval', 6),
('Pavlo', 'Pavlenko', 6),
('Oksana', 'Oksanenko', 6);

-- Під 7
INSERT INTO Employees (FirstName, LastName, ManagerId)
VALUES 
('Yuriy', 'Yurchenko', 7),
('Natalia', 'Natashenko', 7),
('Roman', 'Romaniv', 7);
 */

namespace code_first_app.Services
{
    public interface IEmployeeService
    {
        public Employee? GetEmployeeById(int id);
        public IEnumerable<Employee> GetAll();
        public IEnumerable<Employee> GetManagers();
        public IEnumerable<Employee> GetSubordinates(int managerId);
        public void AddEmployee(Employee employee);
        public void UpdateEmployee(int id, Employee employee);
        public void DeleteEmployee(int id);
    }
    public class ServiceEmployee : IEmployeeService, IDisposable
    {
        private readonly Shop_pv412 _context;
        public ServiceEmployee(Shop_pv412 context)
        {
            _context = context;
        }

        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var employee = GetEmployeeById(id);
            if(employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<Employee> GetAll() => _context.Employees;

        public Employee? GetEmployeeById(int id) => _context.Employees.Find(id);

        public IEnumerable<Employee> GetManagers() => _context.Employees.Where(e => e.ManagerId == null)
            .Include(e => e.Subordinates);

        public IEnumerable<Employee> GetSubordinates(int managerId) => _context.Employees.Where(e => e.ManagerId == managerId)
            .Include(m => m.Subordinates);

        public void UpdateEmployee(int id, Employee? employee)
        {
            Employee? emp_update = GetEmployeeById(id);
            if(emp_update != null)
            {
                emp_update.EmployeeId = employee.EmployeeId;
                emp_update.FirstName = employee.FirstName;
                emp_update.LastName = employee.LastName;
                emp_update.ManagerId = employee.ManagerId;
                _context.SaveChanges();
            }
        }
    }
}
