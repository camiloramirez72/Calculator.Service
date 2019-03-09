using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorService.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CalculatorService.Controllers
{
    [Route("sqrt")]
    [ApiController]
    public class SqrController : Controller
    {
        [HttpPost]
        public SqrtRes Post([FromBody] SqrtReq value)
        {
            SqrtRes result = new SqrtRes();
            try
            {
                /*  Obtiene la raiz cuadrada del numero dentro de la peticion,
                 *  cuando el encabezado no contiene el identificador "X-Evi-Tracking-Id"
                 */
                if (String.IsNullOrEmpty(Request.Headers["X-Evi-Tracking-Id"]))
                {
                    result.Square = Math.Sqrt(value.Number);
                }
                /* Si el encabezado contiene el "X-Evi-Tracking-Id" se efectua la operacion 
                 * y se crea un archivo con el nombre del id del usuario y los datos de la 
                 * operacion realizada
                 */
                else
                {
                    result.Square = Math.Sqrt(value.Number);
                    LogJournal logJournal = new LogJournal(Request.Headers["X-Evi-Tracking-Id"]);
                    logJournal.Add("{" + "\"" + "Operation" + "\"" + ": " + "\"" + "Sqrt" + "\"" + ", " + "\"" + "Calculation" + "\"" + ": " + "\"" + value.Number + " root  = " + result.Square + "\"" + ", " + "\"" + "Date" + "\"" + ": " + "\"" + DateTime.Now.ToString("u") + "\"" + "}");

                }

            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.Add("Error en SubController.cs " + ex.Message);
            }

            return result;


        }
    }
}
