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
    public class OrdersController : ControllerBase
    {
        private readonly IManagementBL managementBL;

        public OrdersController(IManagementBL manageBL)
        {
            this.managementBL = manageBL;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var results = this.managementBL.FetchOrders();

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Id Order");

            var order = this.managementBL.FetchOrderById(id);

            if (order == null)
                return NotFound($"Order not found with Id = {id}");

            return Ok(order);
        }

        [HttpPost]
        public IActionResult CreaNewOrder(Order order)
        {
            if (order == null)
                return BadRequest("Invalid data recived");

            if (!this.managementBL.CreateOrder(order))
                return BadRequest("Cannot complete the operation");

            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id}, order);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, Order order)
        {
            if(id <= 0)
                return BadRequest("Invalid Id Order");
            if(order.Id != id)
                return BadRequest("Invalid data recived");

            if(!this.managementBL.EditOrder(order))
                return BadRequest("Cannot complete the operation");

            return Ok(order);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrderById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Id Order");

            var orderDelete = this.managementBL.DeleteOrderById(id);

            if(!orderDelete)
                return StatusCode(500, "Cannot complete the operation.");

            return Ok();
        }
    }
}
