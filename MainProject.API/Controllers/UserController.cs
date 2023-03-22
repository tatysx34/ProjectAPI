﻿using System;
using LibraryClass.Models.ViewModels.User;
using LibraryClass.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MainProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Create/register a new user
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<ActionResult<UserVM>> Create([FromBody] UserAddVM data)
        {
            try
            {
                // Have the service create the new user
                var result = await _userService.Create(data);

                // Return a 200 response with the UserVM
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

        /// <summary>
        /// Get a specific user by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserVM>> Get([FromRoute] string id)
        {
            try
            {
                // Get the requested User entity from the service
                var result = await _userService.GetById(id);

                // Return a 200 response with the UserVM
                return Ok(result);
            }
            catch
            {
                return BadRequest(new { message = "Unable to retrieve the requested user" });
            }
        }

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<UserVM>> Update([FromBody] UserUpdateVM data)
        {
            try
            {
                // Update User entity from the service
                var result = await _userService.Update(data);

                // Return a 200 response with the UserVM
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

        //api/user/contactus endpoint 
    }
}


