using EmployeeAPI.Models;
using EmployeeAPI.Services.Interfaces;

namespace EmployeeAPI.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly List<Employee> _employees=new();
        public async Task<List<Employee>> GetAllAsync()
        {
            return await Task.FromResult(_employees);
            throw new NotImplementedException();
        }
        public async Task<Employee> GetByIdAsync(int id)
        {
            //if (id==0) return BadRequest("Id cannot be zero");
            var employee= _employees.FirstOrDefault(e => e.Id == id);
            return await Task.FromResult(employee);
            throw new NotImplementedException();
        }


        public Task<Employee> CreateAsync(Employee employee)
        {
            employee.Id = _employees.Count + 1;
            _employees.Add(employee);
            //return CreatedAction(nameof(GetAllAsync), new { id = employee.Id }, employee);
            return Task.FromResult(employee);

            throw new NotImplementedException();                                                    
        }

        public Task<Employee> UpdateAsync(int id, Employee employee)
        {
            var emp= _employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
            {
                return Task.FromResult<Employee>(null);
            }
            emp.Name= employee.Name;
            emp.Department= employee.Department;
            emp.Email= employee.Email;
            emp.Phone= employee.Phone;
            emp.Designation= employee.Designation;
            emp.IsActive= employee.IsActive;
            emp.Exp= employee.Exp;
            return Task.FromResult(emp);

            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return Task.FromResult(false);
            }
            _employees.Remove(employee);
            throw new NotImplementedException();
        }


    }
}
