using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICore.Repositories;
using APICore.Model;

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
            return CreatedAtRoute("GetProduct", new {id = user.ID}, user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] User user)
        {
            if (user == null || user.ID != id)
            {
                return BadRequest();
            }

            var _user = _userRepository.Find(id);

            if (_user == null)
            {
                return NotFound();
            }

            _user.FirstName = user.FirstName;
            _user.LastName = user.LastName;
            _user.Birthday = user.Birthday;
            _user.Address = user.Address;

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
