using Microsoft.AspNetCore.Mvc;
using APICore.Repositories;
using APICore.Models;
using System;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;

namespace APICore.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IAddressRepository _addressRepository;

        public AddressesController(IDoctorRepository doctorRepository, IAddressRepository addressRepository) {
            _doctorRepository = doctorRepository;
            _addressRepository = addressRepository;
        }

        [HttpPost]
        public IActionResult Create(List<Address> addresses)
        {
            if (addresses == null)
            {
                return BadRequest();
            }
            else
            {               
                try
                {
                    foreach (Address address in addresses)
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

                        if (address.AddressAction == AddressAction.Add)
                        {
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
                                _addressRepository.Add(address);
                            }
                        }
                        else if (address.AddressAction == AddressAction.Remove)
                        {
                            if (_addressRepository.AddressExists(address))
                            {
                                _addressRepository.Remove(address.AddressId, address.Cpf);
                            }
                            else
                            {
                                RetornoWS retornoWS = new RetornoWS
                                {
                                    Mensagem = "Endereço não encontrado, não será possível remover.",
                                    Sucesso = false
                                };
                                return NotFound(retornoWS);
                            }
                        }
                        else if (address.AddressAction == AddressAction.Update)
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

                                _addressRepository.Update(_address);
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
                        else
                        {
                            RetornoWS retornoWS = new RetornoWS
                            {
                                Mensagem = "Ação inválida, utilize: 1 - Add, 2 - Update, 3 - Remove.",
                                Sucesso = false
                            };
                            return StatusCode(400, retornoWS);
                        }
                    }

                    RetornoWS retorno = new RetornoWS
                    {
                        Mensagem = $"Endereço(s) processados com sucesso.",
                        Sucesso = true
                    };

                    return Ok(retorno);
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
    }
}