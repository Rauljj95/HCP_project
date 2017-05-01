using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PsicoteXt
{
    public class Pregunta
    {

        private Respuesta[] respuestas;
        private string enunciado;

        public Respuesta[] Respuestas { get => respuestas; set => respuestas = value; }
        public string Enunciado { get => enunciado; set => enunciado = value; }

        public Pregunta()
        {
            Respuestas = new Respuesta[4];

        }

        public string DatosFichero()
        {
            string datos = "\n"+ enunciado + "\n\n";
      
            datos += respuestas[0].DatosFichero() + "\n";
            datos += respuestas[1].DatosFichero() + "\n";
            datos += respuestas[2].DatosFichero() + "\n";
            datos += respuestas[3].DatosFichero() + "\n\n";

            return datos;
        }

    }
}
