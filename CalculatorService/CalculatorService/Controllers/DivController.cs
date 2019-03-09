using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorService.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CalculatorService.Controllers
{
    [Route("calculator/div")]
    [ApiController]
    public class DivController : Controller
    {
        [HttpPost]
        public DivRes Post([FromBody] DivReq value)
        {
            DivRes result = new DivRes();
            try
            {
                /*  Realiza la division entre el Dividend y el Divisor obtenidos de la peticion,
                 *  cuando el encabezado no contiene el identificador "X-Evi-Tracking-Id"
                 */
                if (String.IsNullOrEmpty(Request.Headers["X-Evi-Tracking-Id"]))
                {
                    result.Quotient = value.Dividend / value.Divisor;
                    result.Remainder = value.Dividend % value.Divisor;
                }
                /* Si el encabezado contiene el "X-Evi-Tracking-Id" se efectua la operacion 
                 * y se crea un archivo con el nombre del id del usuario y los datos de la 
                 * operacion realizada
                 */
                else
                {
                    result.Quotient = value.Dividend / value.Divisor;
                    result.Remainder = value.Dividend % value.Divisor;
                    LogJournal logJournal = new LogJournal(Request.Headers["X-Evi-Tracking-Id"]);
                    logJournal.Add("{" + "\"" + "Operation" + "\"" + ": " + "\"" + "Div" + "\"" + ", " + "\"" + "Calculation" + "\"" + ": " + "\"" + value.Dividend + " / " + value.Divisor + " result: Quotient = " + result.Quotient + " Remainder = " + result.Remainder + "\"" + ", " + "\"" + "Date" + "\"" + ": " + "\"" + DateTime.Now.ToString("u") + "\"" + "}");


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
