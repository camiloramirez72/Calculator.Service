using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CalculatorService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CalculatorService.Controllers
{
    [Route("calculator/add")]
    [ApiController]
    public class AddController : Controller
    {
        
        [HttpPost]
        public AddRes Post([FromBody] AddReq value)
        {
            //Retorna BadRequest si la cantidad de operandos es menor a 2
            if (value.Addends.Length < 1) {
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            AddRes result = new AddRes();
            result.Sum = 0;
            try
            {
                AddReq numbers = value;
                /*  Realiza la suma para cada uno de los numeros dentro de la peticion,
                 *  cuando el encabezado no contiene el identificador "X-Evi-Tracking-Id"
                 */
                if (String.IsNullOrEmpty(Request.Headers["X-Evi-Tracking-Id"])) {
                    foreach (float number in numbers.Addends)
                    {
                        result.Sum += number;
                    }
                }
                /* Si el encabezado contiene el "X-Evi-Tracking-Id" se efectua la operacion 
                 * y se crea un archivo con el nombre del id del usuario y los datos de la 
                 * operacion realizada
                 */
                else
                {
                    string operation = "";
                    foreach (float number in numbers.Addends)
                    {
                        result.Sum += number;
                        operation += number + " + ";
                    }
                    LogJournal logJournal = new LogJournal(Request.Headers["X-Evi-Tracking-Id"]);
                    logJournal.Add("{"+ "\"" + "Operation" + "\"" + ": " + "\"" + "Sum" + "\"" + ", " + "\"" + "Calculation" + "\"" + ": " + "\"" + operation.Substring(0, operation.Length-3) + " = " + result.Sum + "\"" + ", " + "\"" + "Date" + "\"" + ": " + "\"" + DateTime.Now.ToString("u") + "\"" + "}");
                }
                
            }
            catch(Exception ex) {
                Log log = new Log();
                log.Add("Error en AddController.cs " + ex.Message);
            }

            return result;


        }
    }
}
