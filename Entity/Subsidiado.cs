using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Subsidiado : LiquidacionCuotaModeradora
    {
        public override void CalcularTarifa()
        {
            Tarifa = 0.05;
        }

        public override void ValidarTope()
        {
            TopeMaximo = 200000;
        }
    }
}
