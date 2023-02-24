using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryClass.Models.ViewModels;
using LibraryClass.Services.Services.Interfaces;
using MainProject.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MainProject.API.Controllers
{
   
        [Route("api/[controller]")]
        [Authorize]
        [ApiController]

        public class HomeController : ControllerBase
        {
            private readonly IProductService _productService; //service 

            public HomeController(IProductService productService)
            {
            _productService = productService;
            }

            // Create a endpoint
            [HttpPost]
            public async Task<ActionResult<ProjectVM>> Create([FromBody] ProjectAddVM data)
            {
            try
            {

                //get the userid
                    var userId = User.GetId();
                     if (userId == null)
                         return BadRequest("Invalid user");

                    // Have the service create the new game
                    var result = await _productService.Create(data, userId);

                    // Return a 200 response with the GameVM
                    return Ok(result);
                }
                catch (DbUpdateException)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Unable to contact the database" });
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            
           // comments are not working
            /// <summary>
            /// Get all.
            /// </summary>
            /// <returns>array of products</returns>
            [HttpGet]
            public async Task<ActionResult<List<ProjectVM>>> GetAll()
            {
                try  
                {    //  
                    // Get the Game entities from the service
                    var results = await _productService.GetAll();

                    // Return a 200 response with the GameVMs
                    return Ok(results);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
                }
            }
        

            // Get a specific game by Id
            [HttpGet("{id}")]
            public async Task<ActionResult<ProjectVM>> Get([FromRoute] Guid id)
            {
                try
                {
                    // Get the requested Game entity from the service
                    var result = await _productService.GetById(id);

                    // Return a 200 response with the GameVM
                    return Ok(result);
                }
                catch
                {
                    return BadRequest(new { message = "Unable to retrieve the requested item" });
                }
            }

            // Update a game
            [HttpPut]
            public async Task<ActionResult<ProjectVM>> Update([FromBody] ProjectUpdateVM data)
            {
                try
                {
                    // Update Game entity from the service
                    var result = await _productService.Update(data);

                    // Return a 200 response with the GameVM
                    return Ok(result);
                }
                catch (DbUpdateException)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Unable to contact the database" });
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            // Delete a game
            [HttpDelete("{id}")]
            public async Task<ActionResult> Delete([FromRoute] Guid id)
            {
                try
                {
                    // Tell the repository to delete the requested Game entity
                    await _productService.Delete(id);

                    // Return a 200 response
                    return Ok();
                }
                catch (DbUpdateException)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Unable to contact the database" });
                }
                catch
                {
                    return BadRequest(new { message = "Unable to delete the requested game" });
                }
            }
        }
    }

