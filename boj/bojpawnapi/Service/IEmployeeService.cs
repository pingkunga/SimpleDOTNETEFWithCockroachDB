using System.Collections.Generic;
using bojpawnapi.DTO;
namespace bojpawnapi.Service
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetEmployeesAsync();
        Task<EmployeeDTO> GetEmployeeByIdAsync(int employeeId);
        Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO employee);
        Task<bool> UpdateEmployeeAsync(EmployeeDTO employee);
        Task<bool> DeleteEmployeeAsync(int employeeId);
    }
}