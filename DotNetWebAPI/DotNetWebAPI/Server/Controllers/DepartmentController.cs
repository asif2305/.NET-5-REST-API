using DotNetWebAPI.Server.Models;
using DotNetWebAPI.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWebAPI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetDepartments()
        {
            /* 
             Level 200 : 200-> ok, 201-> created, 204-> no content
             Level 400 : 400 -> Bad Request, 401 -> Unauthorized, 404-> Not Found
             Level 500 : 500-> Internal Server Error, 501-> Not Implemented, 503-> Service Unavailable
             */
            try
            {
                return Ok(await departmentRepository.GetDepartments());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                          "Error retrieving data from the database");
            }

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Department>> GetDepartments(int id)
        {
            try
            {
                var result = await departmentRepository.GetDepartmentById(id);
                if (result == null)
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

    }
}
