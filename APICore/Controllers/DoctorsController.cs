﻿using Microsoft.AspNetCore.Mvc;
using APICore.Repositories;
using APICore.Models;
using System;
using Microsoft.AspNetCore.Cors;

namespace APICore.Controllers
{
    [EnableCors("AllowMyOrigin")]
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

        [HttpPut("{cpf}")]
        public IActionResult Update(string cpf, [FromBody] Doctor doctor) {
            if (doctor == null || doctor.Cpf != cpf) {
                return BadRequest();
            }

            string message = "";

            if (!doctor.DoctorIsValid(ref message)) {
                RetornoWS retorno = new RetornoWS {
                    Mensagem = $"Não foi possível atualizar o cadastro do médico. Necessário informar os campos: {message}.",
                    Sucesso = false
                };

                return BadRequest(retorno);
            }

            var _doctor = _doctorRepository.Find(cpf);

            if (_doctor == null) {
                RetornoWS retorno = new RetornoWS {
                    Mensagem = "Médico não encontrado, verifique os dados informados.",
                    Sucesso = false
                };
                return NotFound(retorno);
            }

            try {
                _doctor.FirstName = doctor.FirstName;
                _doctor.LastName = doctor.LastName;
                _doctor.Crm = doctor.Crm;
                _doctor.Speciality = doctor.Speciality;

                _doctorRepository.Update(_doctor);

                RetornoWS retorno = new RetornoWS {
                    Mensagem = "Médico atualizado com sucesso.",
                    Sucesso = true
                };
                return Ok(retorno);
            }
            catch (Exception e) {
                RetornoWS retorno = new RetornoWS {
                    Mensagem = $"Erro ao atualizar médico.Motivo: {e.InnerException}",
                    Sucesso = false
                };

                return StatusCode(500, retorno);
            }
        }

        [HttpGet("exists")]
        public IActionResult DoctorExists(string cpf) {
            if (cpf == "") {
                return BadRequest();
            }

            try {
                var _doctor = _doctorRepository.Find(cpf);

                if (_doctor == null) {
                    RetornoWS retorno = new RetornoWS {
                        Mensagem = "CPF não cadastrado, pode prosseguir com o cadastro do médico.",
                        Sucesso = true
                    };
                    return NotFound(retorno);
                }
                else {
                    RetornoWS retorno = new RetornoWS {
                        Mensagem = "CPF já cadastrado, não é possível prosseguir com o cadastro.",
                        Sucesso = false
                    };
                    return Ok(retorno);
                }
            }
            catch (Exception e) {
                RetornoWS retorno = new RetornoWS {
                    Mensagem = $"Erro ao buscar médico.Motivo: {e.InnerException}",
                    Sucesso = false
                };

                return StatusCode(500, retorno);
            }
        }
    }
}