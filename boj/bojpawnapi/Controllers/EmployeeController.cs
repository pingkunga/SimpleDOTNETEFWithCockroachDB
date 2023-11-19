using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using bojpawnapi.Service;
using bojpawnapi.DTO;
using Microsoft.AspNetCore.Mvc;

namespace bojpawnapi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService pEmployeeService)
        {
            _employeeService = pEmployeeService;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            var employeeList = await _employeeService.GetEmployeesAsync();
            if (employeeList != null)
            {
                return Ok(employeeList);
            }
            else
            {
                return NoContent();
            }
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, EmployeeDTO employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            var result = await _employeeService.UpdateEmployeeAsync(employee);
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> PostEmployee(EmployeeDTO employee)
        {
            var result = await _employeeService.AddEmployeeAsync(employee);
            if (result != null)
            {
                return CreatedAtAction(nameof(GetEmployee), new { id = result.EmployeeId }, result);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _employeeService.DeleteEmployeeAsync(id);
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}