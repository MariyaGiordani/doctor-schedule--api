using Microsoft.AspNetCore.Mvc;
using APICore.Models;

namespace APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityController : ControllerBase
    {
        [HttpGet]
        public string GetSpecialities() {
            Speciality specialities = new Speciality();
            return specialities.GetSpecialitiesSerialized();
        }
    }
}