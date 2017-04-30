using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PsicoteXt
{
    class MismaPrioridadException : Exception
    {
        string mensaje;

        public MismaPrioridadException(string message)
        {
            mensaje = message;
        }

        public string getMensaje()
        {
            return mensaje;
        }
    }
}
