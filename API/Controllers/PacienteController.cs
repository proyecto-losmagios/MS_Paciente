using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Domain.DTOs;
using Domain.Entities;


namespace API.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase {
        private readonly IPacienteServices _service;

        public PacienteController(IPacienteServices service) {
            _service = service;
        }

        [HttpPost]
        public ActionResult<Paciente> Post(PacienteDto paciente) {
            return StatusCode(201, _service.CreatePaciente(paciente));
        }

        [HttpGet]
        public IActionResult GetPaciente([FromQuery] string q) {
            try {
                return new JsonResult(_service.SearchPaciente(q)) { StatusCode = 200 };
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("Info")]
        public IActionResult GetPacienteInfo([FromQuery] string email) {
            try {
                return new JsonResult(_service.GetPacienteByEmail(email)) { StatusCode = 200 };
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}