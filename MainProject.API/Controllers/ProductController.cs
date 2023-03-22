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

    public class ProductController : ControllerBase //I should call product controller
    {
        private readonly IProductService _productService; //service 

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Create a product
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ProductVM>> Create([FromBody] ProductAddVM data)
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
        public async Task<ActionResult<List<ProductVM>>> GetAll()
        {

            // Get the Game entities from the service
            var results = await _productService.GetAll();

            // Return a 200 response with the GameVMs
            return Ok(results);

        }

        /// <summary>
        /// Get a specific product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVM>> Get([FromRoute] Guid id)
        {
            // Get the requested product entity from the service
            var result = await _productService.GetById(id);

            
            return Ok(result);

        }

        /// <summary>
        ///  Update a product
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<ProductVM>> Update([FromBody] ProductUpdateVM data)
        {

            
            var result = await _productService.Update(data);

            // Return a 200 response with the ProductVM
            return Ok(result);

        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            // Tell the repository to delete the requested Product entity
            await _productService.Delete(id);

            // Return a 200 response
            return Ok();

        }

        /// <summary>
        /// search for a product using the title field
        /// </summary>
        /// <param name="searchItem"></param>
        /// <returns></returns>
        [HttpGet("search/{searchItem}")] //TODO ?question  
        public async Task<ActionResult<ProductVM>> Search([FromRoute] string searchItem)
        {
            
            var result = await _productService.GetBySearch();

            // 
            return Ok(result);

        }
    }
}
