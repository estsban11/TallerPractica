using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BLL
{
    public class LiquidacionCuotaService
    {

        private LiquidacionRepository repository = new LiquidacionRepository();

        public string Guardar(LiquidacionCuotaModeradora liquidacion)
        {
            try
            {
                
                liquidacion.CalcularTarifa();
                liquidacion.CalcularCuota();
                repository.Guardar(liquidacion);
                return "Se registro con exito";

            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
                
            }
        }

        public Respuesta Consulta ()
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta.liquidaciones = repository.Consultar();
                respuesta.Error = false;
                respuesta.Mensaje = "Consulta exitosa";
                return respuesta;
            }
            catch (Exception e) 
            {

                respuesta.Error = true;
                respuesta.Mensaje = $"Error: {e.Message}";
                return respuesta;
            }
        }

        }

     public class Respuesta
{
   public List<LiquidacionCuotaModeradora> liquidaciones { get; set; }
   public  bool Error { get; set;}
    public string Mensaje { get; set; }
}
}
