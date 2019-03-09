using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorService.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CalculatorService.Controllers
{
    [Route("calculator/query")]
    [ApiController]
    public class QueryController : Controller
    {
        
        [HttpPost]
        public OperationRes Post([FromBody] OperationReq value)
        {
            OperationRes result = new OperationRes();
            try
            {
                /*  Lee el archivo que pertenece al usuario que hace la peticion
                 *  y obtiene un objeto List Journal Con las operaciones efectuadas por el usuario
                 */
                LogJournal logJournal = new LogJournal(value.Id);
                result.Operations = logJournal.Read(value.Id);
                
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
