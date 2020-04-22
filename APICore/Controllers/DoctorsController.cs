using Microsoft.AspNetCore.Mvc;
using APICore.Repositories;
using System.Collections.Generic;
using APICore.Models;

namespace APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorsController(IDoctorRepository doctorRepository) {
            _doctorRepository = doctorRepository;
        }

        [HttpGet("search")]
        public IActionResult SearchDoctors(string speciality, string firstName, string lastName) {
            if ((speciality == null) && (firstName == null) && (lastName == null)){
                RetornoWS retorno = new RetornoWS {
                    Mensagem = "Necessário informar pelo menos um filtro.",
                    Sucesso = false
                };

                return BadRequest(retorno);
            }            

            return Ok(_doctorRepository.GetDoctor(speciality, firstName, lastName));
        }
    }
}