using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Contributivo : LiquidacionCuotaModeradora
    {

        public override void CalcularTarifa()
        {
            if(SalarioDevengado< 1755606)
            {
                Tarifa = 0.15;
            }else if((SalarioDevengado>= 1755606) && (SalarioDevengado<= 4389015))
            {
                Tarifa = 0.20;
            }else if(SalarioDevengado > 4389015)
            {
                Tarifa = 0.50;
            }
            
        }

        public override void ValidarTope()
        {
            if (SalarioDevengado < 1755606)
            {
                TopeMaximo = 200000;
            }
            else if ((SalarioDevengado >= 1755606) && (SalarioDevengado <= 4389015))
            {
                TopeMaximo = 900000;
            }
            else if (SalarioDevengado > 4389015)
            {
                TopeMaximo = 1500000;
            }
        }
        
    }
}
