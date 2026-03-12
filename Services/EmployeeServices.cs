using EmployeeAPI.Models;
using EmployeeAPI.Services.Interfaces;
using EmployeeAPI.Logger;

namespace EmployeeAPI.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly List<Employee> _employees = new();
        private readonly IAppLogger _logger;

        public EmployeeServices(IAppLogger logger)
        {
            _logger = logger;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            _logger.Info("Fetching all employees.");
            return await Task.FromResult(_employees);
        }
        public async Task<Employee?> GetByIdAsync(int id)
        {
            _logger.Info($"Fetching employee by id: {id}");
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            return await Task.FromResult(employee);
        }


        public Task<Employee> CreateAsync(Employee employee)
        {
            employee.Id = _employees.Count + 1;
            _employees.Add(employee);
            _logger.Info($"Created employee id: {employee.Id}");
            //return CreatedAction(nameof(GetAllAsync), new { id = employee.Id }, employee);
            return Task.FromResult(employee);
        }

        public Task<Employee?> UpdateAsync(int id, Employee employee)
        {
            _logger.Info($"Updating employee id: {id}");
            var emp = _employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
            {
                _logger.Warn($"Employee not found for update. Id: {id}");
                return Task.FromResult<Employee?>(null);
            }
            emp.Name = employee.Name;
            emp.Department = employee.Department; 
            emp.Email = employee.Email;
            emp.Phone = employee.Phone;
            emp.Designation = employee.Designation;
            emp.IsActive = employee.IsActive;
            emp.Exp = employee.Exp;
            return Task.FromResult<Employee?>(emp);
        }

        public Task<bool> DeleteAsync(int id)
        {
            _logger.Info($"Deleting employee id: {id}");
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                _logger.Warn($"Employee not found for delete. Id: {id}");
                return Task.FromResult(false);
            }
            _employees.Remove(employee);
            return Task.FromResult(true);
        }


    }
}
