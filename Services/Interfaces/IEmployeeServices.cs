using EmployeeAPI.Models;

namespace EmployeeAPI.Services.Interfaces

{
    public interface IEmployeeServices
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
        Task<Employee> CreateAsync(Employee employee);
        Task<Employee> UpdateAsync(int id, Employee employee);
        Task<bool> DeleteAsync(int id);
    }
}
