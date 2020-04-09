using System;

namespace Entity
{
    public class Paciente
    {
        const decimal SALARIOMAXIMO = 2500000;
        const decimal TARIFAMIN = 0.10m;
        const decimal TARIFAMAX = 0.20m;

        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public decimal ValorServicio { get; set; }
        public decimal Salario { get; set; }
        public decimal Copago { get; set; }

        public void CalcularCopago(){
            if(Salario > SALARIOMAXIMO){
                Copago = ValorServicio * TARIFAMAX;
            }else{
                Copago = ValorServicio * TARIFAMIN;
            }
        }
    }
}
