using EmployeeAPI.DTO;
using EmployeeAPI.Models;
using EmployeeAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _services;

        public EmployeeController(IEmployeeServices services)
        {
            _services = services;
        }

        //public IActionResult Index()
        //{
        //    //return View();

        //}

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetALl()
        {
            var employee = await _services.GetAllAsync();
            return Ok(employee);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            var employee = await _services.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateEmp([FromBody] EmployeeCreateDTO empCreatedto)
        {
            //var employee = await _services.CreateAsync(emp);
            var employee = new Employee
            {
                Name = empCreatedto.Name,
                Department = empCreatedto.Department,
                Email = empCreatedto.Email,
                Phone=empCreatedto.Phone,
                Designation=empCreatedto.Designation,
                Exp=empCreatedto.Exp,
                IsActive=true
            };
            var createdEmp= await _services.CreateAsync(employee);
            return CreatedAtAction(nameof(GetById), new { id = createdEmp.Id }, createdEmp);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateEmp([FromRoute] int id, [FromBody] EmployeeUpdateDTO empUpdateEmp)
        {
            var emp = new Employee
            {
                //Id = id,
                Name = empUpdateEmp.Name,
                Department = empUpdateEmp.Department,
                Email = empUpdateEmp.Email,
                Phone = empUpdateEmp.Phone,
                Designation = empUpdateEmp.Designation,
                IsActive = empUpdateEmp.IsActive
            };
            var updatedEmp = await _services.UpdateAsync(id, emp);
            return Ok(updatedEmp);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteEmp([FromRoute] int id)
        {
            var emp= await _services.DeleteAsync(id);
            if (!emp)
            {
                return NotFound();
            }

            return Ok("Employee Delete Successfully");

        }

    }
}
