using BusinessLogicLayer.Abstracts;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace TestProjectAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        IEmployeeService employee;
        EmployeeModel employeeModel = new EmployeeModel();


        public EmployeeController(IEmployeeService employee)
        {
            this.employee = employee;

        }


        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee([FromRoute] int id, string employeeName, string employeeDescription)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                employeeModel.EmployeeID = id;
                employeeModel.EmployeeName = employeeName;
                employeeModel.EmployeeDescription = employeeDescription;

                employee.CreateEmployee(employeeModel);
                using var cn = new Context();
                await cn.SaveChangesAsync();


                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Errorr creating employees !");
            }


        }



        [HttpGet("GetEmployee")]
        public async Task<IActionResult> GetEmployee()
        {
            try
            {
                var val = employee.GetAllEmployee().ToArray();
                using var cn = new Context();
                await cn.SaveChangesAsync();


                return Ok(val);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Errorr can't get employees !");
            }
        }

        [HttpGet("GetEmployeeByID")]
        public async Task<IActionResult> GetEmployeeByID(int id)
        {
            try
            {
                var val = employee.GetEmployeeById(id).ToArray();

                using var cn = new Context();
                await cn.SaveChangesAsync();

                return Ok(val);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Errorr getting data by id !");
            }
        }


        [HttpPut("UpdateEmployee/{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee emp)
        {
            try
            {
                if (id != emp.EmployeeID)
                {
                    return BadRequest("Employee ID mismatch");
                }

                var upt = employee.GetEmployeeById(id);

                if (upt == null)
                {
                    return NotFound($"Employee with id={id} not found");

                }

                var uptemp = new Employee()
                {
                    EmployeeID = id,
                    EmployeeName = emp.EmployeeName,
                    EmployeeDescription = emp.EmployeeDescription,
                };


                using var cn = new Context();
                cn.Employees.Update(uptemp);
                await cn.SaveChangesAsync();

                return Ok();



            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }

        }

        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                

                var delemp = new Employee() { EmployeeID = id };


                using var cn = new Context();
                cn.Employees.Remove(delemp);
                await cn.SaveChangesAsync();

                return Ok();



            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }


        }


    }

}
