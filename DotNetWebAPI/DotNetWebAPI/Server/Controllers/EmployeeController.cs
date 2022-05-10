using DotNetWebAPI.Server.Models;
using DotNetWebAPI.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWebAPI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            /* 
             Level 200 : 200-> ok, 201-> created, 204-> no content
             Level 400 : 400 -> Bad Request, 401 -> Unauthorized, 404-> Not Found
             Level 500 : 500-> Internal Server Error, 501-> Not Implemented, 503-> Service Unavailable
             */
            try
            {
                return Ok(await employeeRepository.GetEmployees());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                          "Error retrieving data from the database");
            }
            
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployees(int id)
        {
            try
            {
                var result =  await employeeRepository.GetEmployee(id);
                if(result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                          "Error retrieving data from the database");
            }
            return null;
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
               if(employee == null) return BadRequest();
               var createdEmployee = await employeeRepository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployees),
                      new { id = createdEmployee.EmployeeId }, createdEmployee);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                          "Error creating new employee record");
            }
        }
    }
}
