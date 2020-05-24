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
    public class AppointmentsController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ITimeSheetRepository _timeSheetRepository;
        private readonly IDaysOfTheWeekRepository _daysOfTheWeekRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentsController(IDoctorRepository doctorRepository, IAddressRepository addressRepository,
            ITimeSheetRepository timeSheetRepository, IDaysOfTheWeekRepository daysOfTheWeekRepository,
            IPatientRepository patientRepository, IAppointmentRepository appointmentRepository)
        {
            _doctorRepository = doctorRepository;
            _addressRepository = addressRepository;
            _timeSheetRepository = timeSheetRepository;
            _daysOfTheWeekRepository = daysOfTheWeekRepository;
            _patientRepository = patientRepository;
            _appointmentRepository = appointmentRepository;
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Appointment appointment)
        {
            if ((appointment == null) || (appointment.AppointmentId != id))
            {
                return BadRequest();
            }

            string message = "";

            if (!appointment.AppointmentIsValid(ref message))
            {
                RetornoWS retornoWS = new RetornoWS
                {
                    Mensagem = $"Não foi possível atualizar a consulta. Necessário informar os campos: {message}.",
                    Sucesso = false
                };

                return BadRequest(retornoWS);
            }

            try
            {
                if (_appointmentRepository.AppointmentExists(appointment))
                {
                    Appointment _appointment = _appointmentRepository.Find(appointment.AppointmentId, appointment.AddressId,
                                                appointment.DoctorCpf, appointment.PatientCpf);                    

                    if (appointment.Status == AppointmentStatus.Canceled)
                    {
                        TimeSheet timeSheet = _timeSheetRepository.Find(appointment.DoctorCpf, appointment.AddressId);

                        DateTime CancelDate = _appointment.AppointmentTime.Subtract(TimeSpan.FromHours(timeSheet.AppointmentCancelTime.Hour));

                        if (DateTime.Compare(DateTime.Now, CancelDate) == -1)
                        {
                            _appointment.Status = appointment.Status;
                            _appointmentRepository.Update(_appointment);

                            RetornoWS retornoWS = new RetornoWS
                            {
                                Mensagem = "Consulta cancelada com sucesso.",
                                Sucesso = true
                            };

                            return Ok(retornoWS);
                        }
                        else { 
                            RetornoWS retornoWS = new RetornoWS
                            {
                                Mensagem = $"Não foi possível cancelar a consulta com menos de {timeSheet.AppointmentCancelTime.Hour} horas de antecedência.",
                                Sucesso = false
                            };

                            return BadRequest(retornoWS);
                        }
                    }

                    if (appointment.Status == AppointmentStatus.Rescheduled)
                    {
                        TimeSheet timeSheet = _timeSheetRepository.Find(appointment.DoctorCpf, appointment.AddressId);

                        DateTime CancelDate = _appointment.AppointmentTime.Subtract(TimeSpan.FromHours(timeSheet.AppointmentCancelTime.Hour));

                        if (DateTime.Compare(DateTime.Now, CancelDate) == -1)
                        {
                            Appointment appointmentRescheduled = new Appointment();

                            appointmentRescheduled.AppointmentTime = appointment.AppointmentTime;
                            appointmentRescheduled.Status = AppointmentStatus.Scheduled;
                            appointmentRescheduled.RescheludedAppointmentId = appointment.AppointmentId;
                            appointmentRescheduled.DoctorCpf = appointment.DoctorCpf;
                            appointmentRescheduled.PatientCpf = appointment.PatientCpf;
                            appointmentRescheduled.AddressId = appointment.AddressId;

                            _appointmentRepository.Add(appointmentRescheduled);
                        }
                        else
                        {
                            RetornoWS retornoWS = new RetornoWS
                            {
                                Mensagem = $"Não foi possível reagendar a consulta com menos de {timeSheet.AppointmentCancelTime} horas de antecedência.",
                                Sucesso = false
                            };

                            return BadRequest(retornoWS);
                        }
                    }

                    _appointment.AppointmentTime = appointment.AppointmentTime;
                    _appointment.Status = appointment.Status;

                    _appointmentRepository.Update(_appointment);

                    RetornoWS retorno = new RetornoWS
                    {
                        Mensagem = "Consulta atualizada com sucesso.",
                        Sucesso = true
                    };

                    return Ok(retorno);
                }
                else
                {
                    RetornoWS retornoWS = new RetornoWS
                    {
                        Mensagem = "Consulta não encontrada, não será possível atualizar.",
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
        public IActionResult Create(Appointment appointment)
        {
            if (appointment == null)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    string message = "";

                    if (!appointment.AppointmentIsValid(ref message))
                    {
                        RetornoWS retornoWS = new RetornoWS
                        {
                            Mensagem = $"Não foi possível cadastrar a consulta. Necessário informar os campos: {message}.",
                            Sucesso = false
                        };

                        return BadRequest(retornoWS);
                    }
                    

                    if (!_doctorRepository.DoctorExists(appointment.DoctorCpf))
                    {
                        RetornoWS retornoWS = new RetornoWS
                        {
                            Mensagem = "Médico não encontrado. Não será possível cadastrar a consulta.",
                            Sucesso = false
                        };

                        return NotFound(retornoWS);
                    }

                    if (!_patientRepository.PatientExists(appointment.PatientCpf))
                    {
                        RetornoWS retornoWS = new RetornoWS
                        {
                            Mensagem = "Paciente não encontrado. Não será possível cadastrar a consulta.",
                            Sucesso = false
                        };

                        return NotFound(retornoWS);
                    }

                    if (!_addressRepository.AddressExists(appointment.AddressId))
                    {
                        RetornoWS retornoWS = new RetornoWS
                        {
                            Mensagem = "Endereço não encontrado.Não será possível cadastrar a consulta.",
                            Sucesso = false
                        };

                        return BadRequest(retornoWS);
                    }

                    _appointmentRepository.Add(appointment);

                    RetornoWS retorno = new RetornoWS
                    {
                        Mensagem = "Consulta cadastrada com sucesso",
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

        [HttpGet("GetAppointments")]
        public IEnumerable<Appointment> GetAppointments(string cpf)
        {
            if (_doctorRepository.DoctorExists(cpf))
            {
                IEnumerable<Appointment> doctorAppointments = _appointmentRepository.GetDoctorAppointments(cpf);
                return doctorAppointments;
            }
            else
            {
                IEnumerable<Appointment> patientAppointments = _appointmentRepository.GetPatientAppointments(cpf);
                return patientAppointments;
            }                            
        }

        [HttpGet("")]
        public IEnumerable<Availability> GetAvailabilities(string cpf)
        {

        }
    }
}