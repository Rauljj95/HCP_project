using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PsicoteXt
{
    class SinMarcarException : Exception
    {
        string mensaje;

        public SinMarcarException(string message)
        {
            mensaje = message;
        }

        public string getMensaje()
        {
            return mensaje;
        }
    }
}
