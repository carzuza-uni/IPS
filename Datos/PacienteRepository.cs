using System.Data.SqlClient;
using System.Collections.Generic;
using Entity;
using System;

namespace Datos
{
    public class PacienteRepository
    {
        private readonly SqlConnection _connection;

        public PacienteRepository(ConnectionManager connection)
        {
            _connection = connection.conexion;
        }

        public void Guardar(Paciente paciente){
            using(var command = _connection.CreateCommand()){
                command.CommandText = @"Insert Into Paciente (Identificacion,Nombre,ValorServicio,Salario,Copago) 
                                        values (@Identificacion,@Nombre,@ValorServicio,@Salario,@Copago)";
                command.Parameters.AddWithValue("@Identificacion", paciente.Identificacion);
                command.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                command.Parameters.AddWithValue("@ValorServicio", paciente.ValorServicio);
                command.Parameters.AddWithValue("@Salario", paciente.Salario);
                command.Parameters.AddWithValue("@Copago", paciente.Copago);
                var filas = command.ExecuteNonQuery();
            }
        }

        public List<Paciente> ConsultarTodos(){
            SqlDataReader reader;
            List<Paciente> pacientes = new List<Paciente>();

            using(var command = _connection.CreateCommand()){
                command.CommandText = "select * from Paciente";
                reader = command.ExecuteReader();
                if(reader.HasRows){
                    while(reader.Read()){
                        Paciente paciente = MapToPerson(reader);
                        pacientes.Add(paciente);
                    }
                }
            }
            return pacientes;
        }
        public Paciente MapToPerson(SqlDataReader reader){
            if(!reader.HasRows)
                return null;
            
            Paciente paciente = new Paciente();
            paciente.Identificacion = (string)reader["Identificacion"];
            paciente.Nombre = (string)reader["Nombre"];
            paciente.ValorServicio = (decimal)reader["ValorServicio"];
            paciente.Salario = (decimal)reader["Salario"];
            paciente.Copago = (decimal)reader["Copago"];
            return paciente;
        }
    }
}
