﻿using BlogApiDemo.DataAccessLayer;
using BlogApiDemo.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using (var c = new Context())
            {
                var values = c.Employees.ToList();
                return Ok(values);
            }
        }
        [HttpPost]
        public IActionResult EmployeeAdd(Employee employee)
        {
            using (var c = new Context())
            {
                c.Add(employee);
                c.SaveChanges();
            }
            return Ok();    
        }
        [HttpGet("{id}")]
        public IActionResult EmployeeGet(int id) 
        { 
            using var c = new Context();
            var employee = c.Employees.Find(id);
            if(employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public IActionResult EmployeeeDelete(int id)
        {
            using var c = new Context();
            var employee = c.Employees.Find(id);
            if (employee == null) 
            {
                return NotFound();
            }
            c.Remove(employee);
            c.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult EmployeeUpdate(Employee employee)
        {
            using var c = new Context();
            var value = c.Find<Employee>(employee.ID);
            if (value == null)
            {
                return NotFound();
            }
            value.Name = employee.Name;
            c.Update(value);
            c.SaveChanges();
            return Ok();
        }
        
    }
}
