using System;
using APICore.Models;
using APICore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientsController(IPatientRepository patientRepository) {
            _patientRepository = patientRepository;
        }

        [HttpPut("{cpf}")]
        public IActionResult Update(long cpf, [FromBody] Patient patient) {
            if (patient == null || patient.Cpf != cpf) {
                return BadRequest();
            }

            string message = "";

            if (!patient.PatientIsValid(ref message)) {
                RetornoWS retorno = new RetornoWS {
                    Mensagem = $"Não foi possível atualizar o cadastro do paciente. Necessário informar os campos: {message}.",
                    Sucesso = false
                };

                return BadRequest(retorno);
            }

            var _patient = _patientRepository.Find(cpf);

            if (_patient == null) {
                RetornoWS retorno = new RetornoWS {
                    Mensagem = "Paciente não encontrado, verifique os dados informados.",
                    Sucesso = false
                };
                return NotFound(retorno);
            }

            try {
                _patient.FirstName = patient.FirstName;
                _patient.LastName = patient.LastName;
                _patient.Email = patient.Email;

                _patientRepository.Update(_patient);

                RetornoWS retorno = new RetornoWS {
                    Mensagem = "Paciente atualizado com sucesso.",
                    Sucesso = true
                };
                return Ok(retorno);
            }
            catch (Exception e) {
                RetornoWS retorno = new RetornoWS {
                    Mensagem = $"Erro ao atualizar paciente.Motivo: {e.InnerException}",
                    Sucesso = false
                };

                return StatusCode(500, retorno);
            }
        }
    }
}