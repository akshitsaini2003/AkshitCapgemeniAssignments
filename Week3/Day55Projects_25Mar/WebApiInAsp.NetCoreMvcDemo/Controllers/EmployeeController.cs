using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiInAsp.NetCoreMvcDemo.Models;

namespace WebApiInAsp.NetCoreMvcDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employeeService;

        public EmployeeController(IEmployee employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAll(int pageNumber=1, int pageSize=3)
        {
            return Ok(await _employeeService.GetAllEmployeesAsync(pageNumber,pageSize));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            var employee=await _employeeService.GetEmployeesByIdAsync(id);
            if(employee == null)
            {
                return BadRequest("Employee Not Found");
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Create([FromForm]Employee emp,IFormFile image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _employeeService.AddEmployeeAsync(emp,image));
        }

        //[HttpPut("{id}")]
        //public async Task<ActionResult<Employee>> Update(int id,[FromForm]Employee updatedEmp,IFormFile? image)
        //{
        //    if (id != updatedEmp.Id)
        //    {
        //        return BadRequest("ID Mismatch");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var updated=await _employeeService.UpdateEmployeeAsync(updatedEmp,image);
        //    if(updated == null)
        //    {
        //        return NotFound("Employee not found for update");
        //    }
        //    return Ok(updated);
        //}

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> Update(
        int id, [FromForm] EmployeeUpdateDto employeeDto, IFormFile? image)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // map dto to entity
            var employee = new Employee
            {
                Id = id, // take from route only
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                Age = employeeDto.Age,
                ImagePath = employeeDto.ImagePath
            };

            var updated = await _employeeService.UpdateEmployeeAsync(employee, image);
            if (updated == null)
                return NotFound("Employee not found to update");

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            var deleted = await _employeeService.DeleteEmployeeAsync(id);
            if(deleted == null)
            {
                return NotFound("No Employee is there to Delete");
            }
            return Ok(deleted);
        }


    }
}
