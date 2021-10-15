using AcademyG.Week6Test.Core.Interfaces;
using AcademyG.Week6Test.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyG.Week6Test.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly IManagementBL managementBL;

        public CustomersController(IManagementBL manageBL)
        {
            this.managementBL = manageBL;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var results = this.managementBL.FetchCustomers();

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Id Customer");

            var customer = this.managementBL.FetchCustomerById(id);

            if (customer == null)
                return NotFound($"Order not found with Id = {id}");

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult CreaNewCustomer(Customer customer)
        {
            if (customer == null)
                return BadRequest("Invalid data recived");

            if (!this.managementBL.CreateCustomer(customer))
                return BadRequest("Cannot complete the operation");

            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, Customer customer)
        {
            if (id <= 0)
                return BadRequest("Invalid Id Customer");

            if (customer.Id != id)
                return BadRequest("Invalid data recived");

            if (!this.managementBL.EditCustomer(customer))
                return BadRequest("Cannot complete the operation");

            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomerById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Id Customer");

            var customerDelete = this.managementBL.DeleteCustomerById(id);

            if (!customerDelete)
                return StatusCode(500, "Cannot complete the operation.");

            return Ok();
        }
    }
}
