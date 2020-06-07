using Microsoft.AspNetCore.Mvc;
using APICore.Repositories;
using APICore.Models;
using System;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;
using System.Linq;

namespace APICore.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ITimeSheetRepository _timeSheetRepository;
        private readonly IDaysOfTheWeekRepository _daysOfTheWeekRepository;

        public AddressesController(IDoctorRepository doctorRepository, IAddressRepository addressRepository,
            ITimeSheetRepository timeSheetRepository, IDaysOfTheWeekRepository daysOfTheWeekRepository)
        {
            _doctorRepository = doctorRepository;
            _addressRepository = addressRepository;
            _timeSheetRepository = timeSheetRepository;
            _daysOfTheWeekRepository = daysOfTheWeekRepository;
        }

        [HttpPut("{cpf}")]
        public IActionResult Update(string cpf, [FromBody]Address address)
        {
            if ((address == null) || (address.Cpf != cpf))
            {
                return BadRequest();
            }

            string message = "";

            if (!address.AddressIsValid(ref message))
            {
                RetornoWS retornoWS = new RetornoWS
                {
                    Mensagem = $"Não foi possível atualizar o endereço. Necessário informar os campos: {message}.",
                    Sucesso = false
                };

                return BadRequest(retornoWS);
            }

            Doctor _doctor = _doctorRepository.Find(address.Cpf);

            if (_doctor == null)
            {
                RetornoWS retornoWS = new RetornoWS
                {
                    Mensagem = "CPF não cadastrado, não será possível prosseguir com a atualização do endereço.",
                    Sucesso = false
                };

                return NotFound(retornoWS);
            }

            try
            {
                if (_addressRepository.AddressExists(address))
                {
                    Address _address = _addressRepository.Find(address.AddressId, address.Cpf);

                    _address.RoadType = address.RoadType;
                    _address.Street = address.Street;
                    _address.Number = address.Number;
                    _address.Neighborhood = address.Neighborhood;
                    _address.Complement = address.Complement;
                    _address.PostalCode = address.PostalCode;
                    _address.City = address.City;
                    _address.UF = address.UF;
                    _address.Information = address.Information;
                    _address.Telephone = address.Telephone;
                    _address.HealthCare = address.HealthCare;
                    _address.Status = address.Status;
                                           
                    TimeSheet _timeSheet = _timeSheetRepository.Find(address.TimeSheet.TimeSheetId, address.Cpf, address.AddressId);
                    _timeSheet.StartDate = address.TimeSheet.StartDate;
                    _timeSheet.EndDate = address.TimeSheet.EndDate;
                    _timeSheet.LunchStartDate = address.TimeSheet.LunchStartDate;
                    _timeSheet.LunchEndDate = address.TimeSheet.LunchEndDate;
                    _timeSheet.AppointmentDuration = address.TimeSheet.AppointmentDuration;
                    _timeSheet.AppointmentCancelTime = address.TimeSheet.AppointmentCancelTime;

                    _addressRepository.Update(_address);
                    _timeSheetRepository.Update(_timeSheet);

                    foreach (DaysOfTheWeek day in address.TimeSheet.DaysOfTheWeeks)
                    {
                        DaysOfTheWeek _daysOfTheWeek = _daysOfTheWeekRepository.Find(day.Id, day.TimeSheetId);
                        _daysOfTheWeek.Name = day.Name;
                        _daysOfTheWeekRepository.Update(_daysOfTheWeek);                        
                    }
                    

                    RetornoWS retorno = new RetornoWS
                    {
                        Mensagem = $"Endereço atualizado com sucesso.",
                        Sucesso = true
                    };

                    return Ok(retorno);
                }
                else
                {
                    RetornoWS retornoWS = new RetornoWS
                    {
                        Mensagem = "Endereço não encontrado, não será possível atualizar.",
                        Sucesso = false
                    };

                    return NotFound(retornoWS);
                }
            }
            catch (Exception e)
            {
                RetornoWS retorno = new RetornoWS
                {
                    Mensagem = $"Não foi possível atualizar o endereço.Motivo: {e.Message} : {e.InnerException}",
                    Sucesso = false
                };

                return StatusCode(500, retorno);
            }
        }

        [HttpPost]
        public IActionResult Create(Address address)
        {
            if (address == null)
            {
                return BadRequest();
            }
            else
            {               
                try
                {
                    string message = "";

                    if (!address.AddressIsValid(ref message))
                    {
                        RetornoWS retornoWS = new RetornoWS
                        {
                            Mensagem = $"Não foi possível cadastrar o endereço. Necessário informar os campos: {message}.",
                            Sucesso = false
                        };

                        return BadRequest(retornoWS);
                    }

                    Doctor _doctor = _doctorRepository.Find(address.Cpf);

                    if (_doctor == null)
                    {
                        RetornoWS retornoWS = new RetornoWS
                        {
                            Mensagem = "CPF não cadastrado, não será possível prosseguir com o cadastro do endereço.",
                            Sucesso = false
                        };

                        return NotFound(retornoWS);
                    }

                    if (_addressRepository.AddressExists(address))
                    {
                        RetornoWS retornoWS = new RetornoWS
                        {
                            Mensagem = "Endereço já cadastrado, não será possível adicionar.",
                            Sucesso = false
                        };

                        return BadRequest(retornoWS);
                    }
                    else {
                        address.Status = AddressStatus.Active;
                        _addressRepository.Add(address);

                        RetornoWS retorno = new RetornoWS
                        {
                            Mensagem = $"Endereço cadastrado com sucesso.",
                            Sucesso = true
                        };

                        return Ok(retorno);
                    }                 
                }
                catch (Exception e)
                {
                    RetornoWS retorno = new RetornoWS
                    {
                        Mensagem = $"Não foi possível cadastrar os endereço(s).Motivo: {e.Message} : {e.InnerException}",
                        Sucesso = false
                    };

                    return StatusCode(500, retorno);
                }
            }            
        }

        [HttpGet("GetAddresses")]
        public IEnumerable<Address> GetAddresses(string cpf, bool listarEnderecosDesativados = false)
        {
            if (!listarEnderecosDesativados) { 
                return _addressRepository.GetAddress(cpf);
            }
            else
            {
                return _addressRepository.GetAddress(cpf).ToList()
                    .Where(a => a.Status == AddressStatus.Active);
            }
        }

        [HttpGet("GetAddress")]
        public Address GetAddress(int addressId, string cpf, bool listarEnderecosDesativados = false)
        {            
            return _addressRepository.Find(addressId, cpf, listarEnderecosDesativados);
        }
    }
}