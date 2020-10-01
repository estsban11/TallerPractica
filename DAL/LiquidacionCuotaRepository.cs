using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DAL
{
    public class LiquidacionRepository
    {
        private string Ruta = "Liquidaciones.txt";

        public void Guardar(LiquidacionCuotaModeradora liquidacion)
        {
            FileStream file = new FileStream(Ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{liquidacion.NumeroDeLiquidacion};{liquidacion.FechaDeLiquidacion};{liquidacion.Identificacion};{liquidacion.TipoDeAfiliacion};{liquidacion.SalarioDevengado};+" +
            $"{liquidacion.ValorServicio};{liquidacion.TotalPago};{liquidacion.Tarifa};{liquidacion.TopeMaximo};{liquidacion.AplicacionTope};{liquidacion.CuotaModeradora}");
            escritor.Close();
            file.Close();
        }

        public List<LiquidacionCuotaModeradora> Consultar()
        {
            List<LiquidacionCuotaModeradora> liquidaciones = new List<LiquidacionCuotaModeradora>();
            FileStream file = new FileStream(Ruta, FileMode.OpenOrCreate);
            StreamReader lector = new StreamReader(file);
            string linea = string.Empty;
            while ((linea = lector.ReadLine())!=null)
            {
                LiquidacionCuotaModeradora liquidacion = Mapear(linea);
                liquidaciones.Add(liquidacion);
            }
            lector.Close();
            file.Close();
            return liquidaciones;

        }

        private LiquidacionCuotaModeradora Mapear(string linea)
        {
            LiquidacionCuotaModeradora liquidacion = new Contributivo(); new Subsidiado();
            char delimitador = ';';
            string[] registro = linea.Split(delimitador);
            liquidacion.Identificacion = registro[0];
            liquidacion.TipoDeAfiliacion = registro[1];
            liquidacion.SalarioDevengado = double.Parse(registro[2]);
            liquidacion.ValorServicio = double.Parse(registro[3]);
            liquidacion.TopeMaximo = double.Parse(registro[4]);
            liquidacion.TotalPago = double.Parse(registro[5]);
            liquidacion.AplicacionTope = registro[6];
            liquidacion.CuotaModeradora = double.Parse(registro[7]);
            return liquidacion;

        }



    }
}
