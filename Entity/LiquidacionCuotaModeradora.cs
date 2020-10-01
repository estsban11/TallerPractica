using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public abstract class LiquidacionCuotaModeradora
    {

        public string NumeroDeLiquidacion { get; set; }
        public DateTime FechaDeLiquidacion { get; set; }
        public string Identificacion { get; set; }
        public string TipoDeAfiliacion { get; set; }
        public string AplicacionTope { get; set; }
        public double SalarioDevengado { get; set; }
        public double ValorServicio { get; set; }
        public double TotalPago { get; set; }
        public double Tarifa { get; set; }
        public double TopeMaximo { get; set; }
        public double CuotaModeradora { get; set; }


        public void CalcularCuota()
        {
            CuotaModeradora = Tarifa * ValorServicio;
            ValidarTope();
            CalcularPagoFinal();


        }

        public abstract void ValidarTope();
        public abstract void CalcularTarifa();

        public void CalcularPagoFinal()
        {
            if (CuotaModeradora > TopeMaximo)
            {
                TotalPago = TopeMaximo;
                AplicacionTope = "Si";
            }
            else
            {
                TotalPago = CuotaModeradora;
                AplicacionTope = "No";
            }
        }
      
        
        
    }
}
