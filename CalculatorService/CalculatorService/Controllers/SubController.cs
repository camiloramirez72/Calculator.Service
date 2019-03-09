using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorService.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CalculatorService.Controllers
{
    [Route("calculator/sub")]
    [ApiController]
    public class SubController : Controller
    {
        [HttpPost]
        public SubRes Post([FromBody] SubReq value)
        {
            SubRes result = new SubRes();
            try
            {
                SubReq numbers = value;
                if (String.IsNullOrEmpty(Request.Headers["X-Evi-Tracking-Id"]))
                {
                    result.Difference = value.Minuend - value.Subtrahend;
                }
                else
                {
                    result.Difference = value.Minuend - value.Subtrahend;
                    Log log = new Log("journal_");
                    log.Add(Request.Headers["X-Evi-Tracking-Id"] + " operation subtraction numbers: " + value.Minuend + " - " + value.Subtrahend + " result: " + result.Difference);
                    
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
