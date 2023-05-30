using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaTravel.Utilidades
{
    public class UResult
    {
    }

    public class Result
    {
        public int Error { get; set; }
        public string Message { get; set; }
        public object Values { get; set; }
    }
}
