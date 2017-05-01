using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PsicoteXt
{
    public class Respuesta
    {
        private string enunciado;
        private int valor;

        public Respuesta()
        { }

        public string Enunciado { get => enunciado; set => enunciado = value; }
        public int Valor { get => valor; set => valor = value; }

        public string DatosFichero()
        {
            string datos = enunciado + ": " + valor.ToString() + "  ";
            return datos;
        }


    }
}
