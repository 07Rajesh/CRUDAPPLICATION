using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAPPLICATION.Controllers
{
    public class EmployeeController : Controller
    {
        
        public IActionResult ShowEmployees()
        {
            return View();
        }
        public IActionResult AddEmployees()
        {
            return View();
        }
    }
}
