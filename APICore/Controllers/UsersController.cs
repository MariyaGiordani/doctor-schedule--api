using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using APICore.Repositories;
using APICore.Models;
using System;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;

namespace APICore.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api/[Controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISecurityRepository _securityRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;

        public UsersController(IUserRepository userRepository, ISecurityRepository securityRepository,
            IDoctorRepository doctorRepository, IPatientRepository patientRepository)
        {
            _userRepository = userRepository;
            _securityRepository = securityRepository;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
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
                User _user = _userRepository.FindByUser(user);
                bool cpfExists = false;

                if (user.Doctor != null) {
                    cpfExists = _doctorRepository.Find(user.Doctor.Cpf) == null;
                }
                else {
                    cpfExists = _patientRepository.Find(user.Patient.Cpf) == null;
                }

                if ((_user == null) && (cpfExists == true)){
                    _userRepository.Add(user);

                    RetornoWS retorno = new RetornoWS {
                        Mensagem = "Usuário cadastrado com sucesso.",
                        Sucesso = true
                    };

                    return StatusCode(201, retorno);
                }
                else {
                    RetornoWS retorno = new RetornoWS {
                        Mensagem = "Usuário ou CPF já existente.Não será possível cadastrar.",
                        Sucesso = false
                    };

                    return Ok(retorno);
                }
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

            string message = "";

            if (!user.UserIsValid(ref message)) {
                RetornoWS retorno = new RetornoWS {
                    Mensagem = $"Não foi possível atualizar o usuário. Necessário informar os campos: {message}.",
                    Sucesso = false
                };

                return BadRequest(retorno);
            }

            User _user = _userRepository.Find(id);

            if (_user == null)
            {
                RetornoWS retorno = new RetornoWS {
                    Mensagem = "Usuário não encontrado, verifique os dados informados.",
                    Sucesso = false
                };
                return NotFound(retorno);
            }

            try {
                _user.UserName = user.UserName;
                _user.Password = user.Password;

                _userRepository.Update(_user);

                RetornoWS retorno = new RetornoWS {
                    Mensagem = "Usuário atualizado com sucesso.",
                    Sucesso = true
                };
                return Ok(retorno);
            }
            catch (Exception e) {
                RetornoWS retorno = new RetornoWS {
                    Mensagem = $"Erro ao atualizar usuário.Motivo: {e.InnerException}",
                    Sucesso = false
                };

                return StatusCode(500, retorno);
            }            
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] User user) {

            long idUser = _userRepository.FindByUserLong(user);

            if (idUser == 0) {
                RetornoWS retorno = new RetornoWS {
                    Mensagem = "Usuário inválido.",
                    Sucesso = false
                };

                return Unauthorized(retorno);
            }
            else {
                byte[] salt = _securityRepository.Find(idUser);
                string pass = user.HashString(user.Password, salt);

                User User = _userRepository.Login(user.UserName, pass);

                if (User != null) {
                    RetornoWS retorno = new RetornoWS {
                        Mensagem = "Login efetuado com sucesso.",
                        Sucesso = true,
                        Objeto = User
                    };

                    var serializerSettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };

                    string json = JsonConvert.SerializeObject(retorno, Formatting.Indented, serializerSettings);

                    return Content(json, "application/json");
                }
                else {
                    RetornoWS retorno = new RetornoWS {
                        Mensagem = "Senha inválida.",
                        Sucesso = false
                    };

                    return Unauthorized(retorno);
                }
            }
        }
    }
}
