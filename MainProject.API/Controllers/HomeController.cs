using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryClass.Models.ViewModels;
using LibraryClass.Services.Services.Interfaces;
using MainProject.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MainProject.API.Controllers
{
   
        [Route("api/[controller]")]
        [Authorize]
        [ApiController]

        public class HomeController : ControllerBase //I should call product controller
        {
            private readonly IProductService _productService; //service 

            public HomeController(IProductService productService)
            {
            _productService = productService;
            }

        // Create a endpoint
        // Create a new game
        [HttpPost]
        public async Task<ActionResult<ProjectVM>> Create([FromBody] ProjectAddVM data)
        {

            // Get the user ID
            var userId = User.GetId();
            if (userId == null)
                return BadRequest("Invalid user");

            // Have the service create the new game
            var result = await _productService.Create(data, userId);

            // Return a 200 response with the GameVM
            return Ok(result);
        }


        /// <summary>
        /// Gets all produts.
        /// </summary>
        /// <returns>Array of Games</returns>
        /// <response code="200">Game Found</response>
        /// <response code="401">Not Currently Logged In</response>
        /// <response code="500">Internal Server Problem. E.g. connectivity, database, etc.</response>
        [HttpGet]
        public async Task<ActionResult<List<ProjectVM>>> GetAll()
        {

            // Get the Game entities from the service
            var results = await _productService.GetAll();

            // Return a 200 response with the GameVMs
            return Ok(results);

        }

        // Get a specific product by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectVM>> Get([FromRoute] Guid id)
        {
            // Get the requested Game entity from the service
            var result = await _productService.GetById(id);

            // Return a 200 response with the GameVM
            return Ok(result);

        }

        // Update a product
        [HttpPut]
        public async Task<ActionResult<ProjectVM>> Update([FromBody] ProjectUpdateVM data)
        {

            // Update Game entity from the service
            var result = await _productService.Update(data);

            // Return a 200 response with the GameVM
            return Ok(result);

        }

        // Delete a product
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            // Tell the repository to delete the requested Product entity
            await _productService.Delete(id);

            // Return a 200 response
            return Ok();

        }
    }
}
