using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo_Flujo_Async
{
    public class CalculadoraHipotecaAsync
    {
        public static async Task<int> ObtenerAniosDeVidaLaboral()
        {
            Console.WriteLine("\nObteniendo años de vida laboral...");
            await Task.Delay(5000); //esperamos 5 segundos
            return new Random().Next(1, 35); //devolvemos un valor random entre 1 y 35
        }

        public static async Task<bool> EsContratoIndefinido()
        {
            Console.WriteLine("\nVerificando si el tipo de contrato es infinido...");
            await Task.Delay(5000); //esperamos 5 segundos
            return (new Random().Next(0,10)) % 2 == 0;

        }

        public static async Task<int> ObtenerSueldoNeto()
        {
            Console.WriteLine("\nObteniendo sueldo neto...");
            await Task.Delay(5000); //esperamos 5 segundos
            return new Random().Next(800, 6000);

        }

        public static async Task<int> ObtenerGastosMensuales()
        {
            Console.WriteLine("\nObteniendo gastos mensuales...");
            await Task.Delay(5000); //esperamos 5 segundos
            return new Random().Next(200, 1000);

        }

        public static bool SeConedeHipoteca(
            int aniosVidaLaboral,
            bool tipoContrato,
            int sueldoNeto,
            int gastosMensuales,
            int cantidadSolicitada,
            int aniosPagar)
        {
            Console.WriteLine("\nAnalizando informacion para conceder hipoteca...");
            if(aniosVidaLaboral < 2)
            {
                return false;
            }

            //obtener cuota mensual a pagar
            var cuota = (cantidadSolicitada / aniosPagar) / 12;

            if(cuota >= sueldoNeto || cuota > (sueldoNeto / 2))
            {
                return false;
            }

            //obtener porcentaje sobre gastos
            var porcentajeGastosSobreSueldo = (gastosMensuales * 100) / sueldoNeto;

            if(porcentajeGastosSobreSueldo > 30)
            {
                return false;
            }

            if(cuota + gastosMensuales >= sueldoNeto)
            {
                return false;
            }

            if (!tipoContrato)
            {
                if((cuota + gastosMensuales) > sueldoNeto / 3)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
