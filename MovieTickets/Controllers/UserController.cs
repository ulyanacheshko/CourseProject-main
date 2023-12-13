﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTickets.Entities;
using MovieTickets.DataAccess;
using MovieTickets.Services.Contracts;
using MovieTickets.OrderDTO;

namespace MovieTickets.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            return await _userService.GetById(id);
        }

        [HttpPost("register")]
        public async Task<ActionResult<int>> Create([FromBody] CreateUserDto user)
        {
            return await _userService.Create(new UserDto
            {
                Password = user.Password,
                Username = user.Username
            });
        }

        [HttpGet("Users")]
        public async Task<ActionResult<List<UserDto>>> GetUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserDto userDto)
        {
            var updatedUserDto = await _userService.Update(userDto);

            if (updatedUserDto == null)
            {
                return NotFound();
            }

            return Ok(updatedUserDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
