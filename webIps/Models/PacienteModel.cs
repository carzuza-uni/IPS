using Entity;

namespace webIps.Models
{
    public class PacienteInputModel
    {
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public decimal ValorServicio { get; set; }
        public decimal Salario { get; set; }
    }

    public class PacienteViewModel : PacienteInputModel
    {
        public PacienteViewModel()
        {

        }
        public PacienteViewModel(Paciente paciente)
        {
            Identificacion = paciente.Identificacion;
            Nombre = paciente.Nombre;
            ValorServicio = paciente.ValorServicio;
            Salario = paciente.Salario;
            Copago = paciente.Copago;
        }
        public decimal Copago { get; set; }
    }
}