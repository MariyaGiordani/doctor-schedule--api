using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using APICore.Repositories;
using APICore.Models;
using System;

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

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {            
            if ((user == null) || (user.Doctor == null && user.Patient == null)){
                return BadRequest();
            }

            string message = "";

            if (!user.UserIsValid(ref message)) {
                RetornoWS retorno = new RetornoWS {                    
                    Mensagem = $"Não foi possível cadastrar o usuário. Necessário informar os campos: {message}.",
                    Sucesso = false
                };

                return BadRequest(retorno);
            }

            try {
                _userRepository.Add(user);

                RetornoWS retorno = new RetornoWS {
                    Mensagem = "Usuário cadastrado com sucesso.",
                    Sucesso = true
                };

                return StatusCode(201, retorno);
            }
            catch (Exception e) {
                RetornoWS retorno = new RetornoWS {
                    Mensagem = $"Erro ao cadastrar usuário. Motivo: {e.InnerException}.",
                    Sucesso = false
                };

                return BadRequest(retorno);                
            }                        
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] User user)
        {
            if (user == null || user.Id == id)
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

        [HttpPost("Login")]
        public IActionResult Login([FromBody] User user) {            
            if (_userRepository.Login(user.UserName, user.Password)) {
                RetornoWS retorno = new RetornoWS {
                    Mensagem = "Login efetuado com sucesso.",
                    Sucesso = true
                };

                return Ok(retorno);
            } else {
                RetornoWS retorno = new RetornoWS {
                    Mensagem = "Usuário ou senha inválidos",
                    Sucesso = false
                };

                return Unauthorized(retorno);
            }
        }
    }
}
