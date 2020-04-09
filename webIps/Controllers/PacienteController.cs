using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using webIps.Models;
using Entity;
using Logica;

namespace webIps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController: ControllerBase
    {
        private readonly PacienteService _pacienteService;
        public IConfiguration Configuration { get; }

        public PacienteController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _pacienteService = new PacienteService(connectionString);
        }

        [HttpPost]
        public ActionResult<PacienteViewModel> post(PacienteInputModel pacienteInput){
            Paciente paciente = MapearPaciente(pacienteInput);
            var response = _pacienteService.Guardar(paciente);
            if(response.Error){
                return BadRequest(response.Mensaje);
            }
            return Ok(response.paciente);
        }
        private Paciente MapearPaciente(PacienteInputModel pacienteInput)
        {
            var paciente = new Paciente
            {
                Identificacion = pacienteInput.Identificacion,
                Nombre = pacienteInput.Nombre,
                ValorServicio = pacienteInput.ValorServicio,
                Salario = pacienteInput.Salario
            };
            return paciente;
        }

        [HttpGet]
        public IEnumerable<PacienteViewModel> gets(){
            var pacientes = _pacienteService.ConsultarTodos().Select(p=> new PacienteViewModel(p));
            return pacientes;
        }
    }
}