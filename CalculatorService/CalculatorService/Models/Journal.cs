using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorService.Models
{
    public class Journal
    {
        public string Operation { get; set; }
        public string Calculation { get; set; }
        public string Date { get; set; }
    }
}
