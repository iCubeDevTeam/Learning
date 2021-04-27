using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DBContext;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api")] // 5001/api
    public class LearningController : ControllerBase
    {
        private readonly ILogger<LearningController> _logger;
        private readonly ServerContext _serverContext;

        public LearningController(ILogger<LearningController> logger, ServerContext serverContext) //constructor
        {
            _serverContext = serverContext;
            _logger = logger;
        }

        [HttpGet] // https://localhost:5001/api
        public IActionResult GetUsers()
        {
            var users = _serverContext.Users.ToList();
            return StatusCode(200 ,new {result = users, message = "success"});
        }

        [HttpGet("{id}")] // https://localhost:5001/api/1
        public IActionResult GetUsers(int id)
        {
            var users = _serverContext.Users.SingleOrDefault(o => o.Id == id);
            return StatusCode(200 ,new {result = users, message = "success"});
        }

        [HttpPost] // https://localhost:5001/api
        public IActionResult CreateUsers(User _user)
        {
            _serverContext.Users.Add(_user);
            _serverContext.SaveChanges(); // commit to database
            return StatusCode(200 ,new {message = "success"});
        }

        [HttpPut] // https://localhost:5001/api
        public IActionResult UpdateUsers(User _user)
        {
            var user = _serverContext.Users.SingleOrDefault(o => o.Id == _user.Id);

            if(user != null)
            {
                user.Username = _user.Username;
                user.Password = _user.Password;
            }

            _serverContext.Users.Update(user);
            _serverContext.SaveChanges(); // commit to database
            return StatusCode(200 ,new {message = "success"});
        }

        [HttpDelete("{id}")] // https://localhost:5001/api
        public IActionResult DeleteUsers(int id)
        {
            var user = _serverContext.Users.SingleOrDefault(o => o.Id == id);

            if(user != null)
            {
                _serverContext.Users.Remove(user);
                _serverContext.SaveChanges(); // commit to database
                return StatusCode(200 ,new {message = "success"});
            }
            else
            {
                return StatusCode(400 ,new {message = "error"});
            }

        }

    }
}
