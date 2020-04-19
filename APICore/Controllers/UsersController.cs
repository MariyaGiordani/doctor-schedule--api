using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using APICore.Repositories;
using APICore.Models;

namespace APICore.Controllers
{
    [Route("api/[Controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;        

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;            
        }

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        [HttpGet("id", Name = "GetProduct")]
        public IActionResult GetById(long id)
        {
            var user = _userRepository.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            _userRepository.Add(user);            

            return CreatedAtRoute("GetProduct", new {id = user.Id}, user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] User user)
        {
            if (user == null || user.Id != id)
            {
                return BadRequest();
            }

            var _user = _userRepository.Find(id);

            if (_user == null)
            {
                return NotFound();
            }

            _user.UserName = user.UserName;
            _user.Password = user.Password;            

            _userRepository.Update(_user);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var user = _userRepository.Find(id);

            if (user == null)
            {
                return NotFound();
            }
            _userRepository.Remove(id);
            return new NoContentResult();
        }
    }
}
