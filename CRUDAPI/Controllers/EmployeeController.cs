using CRUDAPI.DBAccess;
using CRUDAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        EmployeeDbAccess employeeDb = new EmployeeDbAccess();
        ApiResponse response = new ApiResponse();

        [Route("GetEmployees")]
        public IActionResult GetEmployees()
        {
            
            try
            {
                var emps = employeeDb.GetEmployees();
                response.Ok = true;
                response.Message = $"Total {emps.Count} Record fetch successfully..";
                response.Data = emps;
            }
            catch (Exception ex)
            {
                response.Ok = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
        [Route("PostEmployee")]
       [HttpPost]
        public IActionResult PostEmployee(Employee employee)
        {
            try
            {
                var res = employeeDb.CreateEmployee(employee);
                if (res == "ok")
                {
                    response.Ok = true;
                    response.Message = $"Employee Create Successfully";
                }
                else if (res == "fail")
                {
                    response.Ok = false;
                    response.Message = $"Employee email already exists";
                }
                else
                {
                    response.Ok = false;
                    response.Message = res;
                }
            }
            catch (Exception ex)
            {
                response.Ok = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [Route("DeleteEmployee")]
        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var res = employeeDb.DeleteEmployee(id);
                if (res == "ok")
                {
                    response.Ok = true;
                    response.Message = $"Employee deleted Successfully";
                }
                else if (res == "fail")
                {
                    response.Ok = false;
                    response.Message = $"Something went wrong";
                }
                else
                {
                    response.Ok = false;
                    response.Message = res;
                }
            }
            catch (Exception ex)
            {
                response.Ok = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
        [Route("UpdateEmployee")]
        public IActionResult UpdateEmployee(Employee employee)
        {
            try
            {
                var res = employeeDb.UpdateEmployee(employee);
                if (res == "ok")
                {
                    response.Ok = true;
                    response.Message = $"Employee updated Successfully";
                }
               /* else if (res == "fail")
                {
                    response.Ok = false;
                    response.Message = $"Employee email already exists";
                }*/
                else
                {
                    response.Ok = false;
                    response.Message = res;
                }
            }
            catch (Exception ex)
            {
                response.Ok = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

    }
}
