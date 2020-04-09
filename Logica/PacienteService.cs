using System;
using System.Collections.Generic;
using Datos;
using Entity;

namespace Logica
{
    public class PacienteService
    {
        private readonly ConnectionManager conexion;
        private readonly PacienteRepository repository;

        public PacienteService(string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            repository = new PacienteRepository(conexion);
        }

        public GuardarPersonaResponse Guardar(Paciente paciente){
            try{
                paciente.CalcularCopago();
                conexion.Open();
                repository.Guardar(paciente);
                conexion.Close();
                return new GuardarPersonaResponse(paciente);
            }catch(Exception e){ 
                return new GuardarPersonaResponse($"Error de la aplicacion: {e.Message}");
            }finally{
               conexion.Close(); 
            }
        }

        public List<Paciente> ConsultarTodos(){
            try{
                conexion.Open();
                var pacientes = repository.ConsultarTodos();
                conexion.Close();
                return pacientes;
            }catch(Exception e){
                
            }
            return null;
        }
    }

    public class GuardarPersonaResponse 
    {
        public GuardarPersonaResponse(Paciente paciente)
        {
            Error = false;
            Paciente paciente1 = paciente;
        }
        public GuardarPersonaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Paciente paciente { get; set; }
    }
}
