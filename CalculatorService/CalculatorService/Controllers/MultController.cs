using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorService.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CalculatorService.Controllers
{
    [Route("calculator/mult")]
    [ApiController]
    public class MultController : Controller
    {
        [HttpPost]
        public MultRes Post([FromBody] MultReq value)
        {
            MultRes result = new MultRes();
            result.Product = 1;
            try
            {
                MultReq numbers = value;
                /*  Realiza la multiplicacion cada uno de los numeros dentro de la peticion,
                 *  cuando el encabezado no contiene el identificador "X-Evi-Tracking-Id"
                 */
                if (String.IsNullOrEmpty(Request.Headers["X-Evi-Tracking-Id"]))
                {
                    foreach (float number in numbers.Factors)
                    {
                        result.Product *= number;
                    }
                }
                /* Si el encabezado contiene el "X-Evi-Tracking-Id" se efectua la operacion 
                 * y se crea un archivo con el nombre del id del usuario y los datos de la 
                 * operacion realizada
                 */
                else
                {
                    string operation = "";
                    foreach (float number in numbers.Factors)
                    {
                        result.Product *= number;
                        operation += number + " x ";
                    }
                    LogJournal logJournal = new LogJournal(Request.Headers["X-Evi-Tracking-Id"]);
                    logJournal.Add("{" + "\"" + "Operation" + "\"" + ": " + "\"" + "Mult" + "\"" + ", " + "\"" + "Calculation" + "\"" + ": " + "\"" + operation.Substring(0, operation.Length - 3) + " = " + result.Product + "\"" + ", " + "\"" + "Date" + "\"" + ": " + "\"" + DateTime.Now.ToString("u") + "\"" + "}");
                }

            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.Add("Error en AddController.cs " + ex.Message);
            }

            return result;


        }
    }
}
