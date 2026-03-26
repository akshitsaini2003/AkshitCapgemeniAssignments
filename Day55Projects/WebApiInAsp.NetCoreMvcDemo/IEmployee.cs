using Microsoft.AspNetCore.Mvc;
using WebApiInAsp.NetCoreMvcDemo.Models;

namespace WebApiInAsp.NetCoreMvcDemo
{
    public interface IEmployee
    {
        Task<List<Employee>> GetAllEmployeesAsync(int pageNumber,int pageSize);
        Task<Employee?> GetEmployeesByIdAsync(int id);
        Task<Employee> AddEmployeeAsync(Employee emp,IFormFile image);
        Task<Employee?> UpdateEmployeeAsync(Employee updatedEmp,IFormFile? image);
        Task<Employee?> DeleteEmployeeAsync(int id);
    }
}
