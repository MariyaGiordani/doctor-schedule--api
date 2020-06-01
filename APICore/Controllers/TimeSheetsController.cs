using Microsoft.AspNetCore.Mvc;
using APICore.Repositories;
using APICore.Models;
using System;
using Microsoft.AspNetCore.Cors;

namespace APICore.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSheetsController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ITimeSheetRepository _timeSheetRepository;

        public TimeSheetsController(IDoctorRepository doctorRepository, IAddressRepository addressRepository,
            ITimeSheetRepository timeSheetRepository) {
            _doctorRepository = doctorRepository;
            _addressRepository = addressRepository;
            _timeSheetRepository = timeSheetRepository;
        }

        [HttpPost]
        public IActionResult Create(TimeSheet timeSheet)
        {
            if (timeSheet == null)
            {
                return BadRequest();
            }

            try
            {
                if (_doctorRepository.DoctorExists(timeSheet.Cpf))
                {
                    if (_addressRepository.AddressExists(timeSheet.AddressId))
                    {
                        if (!_timeSheetRepository.TimeSheetExists(timeSheet))
                        {

                            _timeSheetRepository.Add(timeSheet);

                            RetornoWS retornoWS = new RetornoWS
                            {
                                Mensagem = "Expediente cadastrado com sucesso.",
                                Sucesso = true
                            };

                            return NotFound(retornoWS);
                        }
                        else
                        {
                            RetornoWS retornoWS = new RetornoWS
                            {
                                Mensagem = "Expediente já existe. Não será possível cadastrar.",
                                Sucesso = false
                            };

                            return BadRequest(retornoWS);
                        }
                    }
                    else
                    {
                        RetornoWS retornoWS = new RetornoWS
                        {
                            Mensagem = "Endereço não existe. Expediente não será cadastrado.",
                            Sucesso = false
                        };

                        return NotFound(retornoWS);
                    }
                }
                else
                {
                    RetornoWS retornoWS = new RetornoWS
                    {
                        Mensagem = "Médico não existe. Expediente não será cadastrado.",
                        Sucesso = false
                    };

                    return NotFound(retornoWS);
                }
            }
            catch (Exception e)
            {
                RetornoWS retornoWS = new RetornoWS
                {
                    Mensagem = $"Erro ao cadastrar expediente. Motivo: {e.Message} : {e.InnerException}",
                    Sucesso = false
                };
                return StatusCode(500, retornoWS);
            }           
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TimeSheet timeSheet) {
            if (timeSheet == null || timeSheet.TimeSheetId != id) {
                return BadRequest();
            }

            string message = "";

            if (!timeSheet.TimeSheetIsValid(ref message)) {
                RetornoWS retorno = new RetornoWS {
                    Mensagem = $"Não foi possível atualizar o expediente. Necessário informar os campos: {message}.",
                    Sucesso = false
                };

                return BadRequest(retorno);
            }

            try
            {
                if (_timeSheetRepository.TimeSheetExists(timeSheet))
                {
                    _timeSheetRepository.Update(timeSheet);

                    RetornoWS retornoWS = new RetornoWS
                    {
                        Mensagem = "Expediente atualizado com sucesso.",
                        Sucesso = true
                    };

                    return Ok(retornoWS);
                }
                else
                {
                    RetornoWS retornoWS = new RetornoWS
                    {
                        Mensagem = "Expediente não existe. Não será possível atualizar.",
                        Sucesso = false
                    };

                    return BadRequest(retornoWS);
                }
            }
            catch (Exception e)
            {
                RetornoWS retornoWS = new RetornoWS
                {
                    Mensagem = $"Erro ao atualizar expediente. Motivo: {e.Message} : {e.InnerException}",
                    Sucesso = false
                };
                return StatusCode(500, retornoWS);
            }
        }
        
        [HttpDelete("{id}")]
        public IActionResult Remove(int id, [FromBody] TimeSheet timeSheet)
        {
            if (timeSheet == null || timeSheet.TimeSheetId != id)
            {
                return BadRequest();
            }

            string message = "";

            if (!timeSheet.TimeSheetIsValid(ref message))
            {
                RetornoWS retorno = new RetornoWS
                {
                    Mensagem = $"Não foi possível remover o expediente. Necessário informar os campos: {message}.",
                    Sucesso = false
                };

                return BadRequest(retorno);
            }

            try
            {
                if (_timeSheetRepository.TimeSheetExists(timeSheet))
                {
                    _timeSheetRepository.Remove(timeSheet.TimeSheetId, timeSheet.AddressId, timeSheet.Cpf);

                    RetornoWS retornoWS = new RetornoWS
                    {
                        Mensagem = "Expediente removido com sucesso.",
                        Sucesso = true
                    };

                    return Ok(retornoWS);
                }
                else
                {
                    RetornoWS retornoWS = new RetornoWS
                    {
                        Mensagem = "Expediente não existe. Não será possível remover.",
                        Sucesso = false
                    };

                    return NotFound(retornoWS);
                }
            }
            catch (Exception e)
            {
                RetornoWS retornoWS = new RetornoWS
                {
                    Mensagem = $"Erro ao remover expediente. Motivo: {e.Message} : {e.InnerException}",
                    Sucesso = false
                };
                return StatusCode(500, retornoWS);
            }
        }

        //[HttpGet]
        //public IEnumerable<TimeSheet> GetTimeSheet(int addressId, string cpf)
        //{
        //    return _timeSheetRepository.GetTimeSheets(addressId, cpf);
        //}
    }
}