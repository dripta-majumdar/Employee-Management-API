using EmployeeAPI.Models;
using EmployeeAPI.Services.Interfaces;
using EmployeeAPI.Logger;

namespace EmployeeAPI.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private static readonly List<Employee> _employees = new();
        private readonly IAppLogger _logger;

        public EmployeeServices(IAppLogger logger)
        {
            _logger = logger;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            try
            {
                return await Task.FromResult(_employees);
            }
            catch (Exception ex)
            {
                _logger.Info("Fetching all employees.");
                //_logger.Error("Error fetching employees.", ex);
                throw;
            }
        }
        public async Task<Employee?> GetByIdAsync(int id)
        {
            try
            {
                var employee = _employees.FirstOrDefault(e => e.Id == id);
                return await Task.FromResult(employee);
            }
            catch (Exception ex)
            {
                _logger.Info($"Fetching employee by id: {id}");
                throw;

            }

        }


        public Task<Employee> CreateAsync(Employee employee)
        {
            try
            {
                employee.Id = _employees.Count + 1;
                _employees.Add(employee);
                //return CreatedAction(nameof(GetAllAsync), new { id = employee.Id }, employee);
                return Task.FromResult(employee);
            }
            catch (Exception ex)
            {
                _logger.Info($"Created employee id: {employee.Id}");
                throw;

            }
        }

        public Task<Employee?> UpdateAsync(int id, Employee employee)
        {
            try
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
            catch (Exception ex)
            {
                _logger.Error(ex, "Error updating employee.");
                throw;
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            try
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
            catch (Exception ex)
            {
                _logger.Error(ex, "Error deleting employee.");
                throw;
            }


        }
    }
}
