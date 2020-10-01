using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BLL;

namespace TallerPractica
{
    class Program
    {
        static void Main(string[] args)
        {
             LiquidacionCuotaService service = new LiquidacionCuotaService();
        
                LiquidacionCuotaModeradora liquidacion = new Contributivo();

               
                
            if (liquidacion.TipoDeAfiliacion == "Contributivo")
            {
                liquidacion = new Contributivo();
            }
            else
            {
                liquidacion = new Subsidiado();
            }
            Console.WriteLine("Tipo de afiliacion");
            liquidacion.TipoDeAfiliacion = Console.ReadLine();
            Console.WriteLine("Digite numero de liquidacion: ");
                liquidacion.NumeroDeLiquidacion = Console.ReadLine();
                Console.WriteLine("Digite la fecha: (DD/MM/AA)");
                liquidacion.FechaDeLiquidacion = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Identificacion");
                liquidacion.Identificacion = Console.ReadLine();
                Console.WriteLine("Salario devengado");
                liquidacion.SalarioDevengado = double.Parse(Console.ReadLine());
                Console.WriteLine("Valor servicio");
                liquidacion.ValorServicio = double.Parse(Console.ReadLine());
                service.Guardar(liquidacion);
                 
           

            Console.Clear();
            Consultar(service);
            Console.ReadKey();

        }

        public static void Consultar(LiquidacionCuotaService service)
        {
            Respuesta respuesta = service.Consulta();
           /* foreach (var item in respuesta.liquidaciones)
            {
                Console.WriteLine("Lista");
                Console.WriteLine(item.ToString());
            }
           */
        }
            
        
    }
}
