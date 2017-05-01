using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PsicoteXt
{
    public class Preguntas
    {
        private List<Pregunta> listaPreguntas;

        public Preguntas()
        {
            ListaPreguntas = new List<Pregunta>(12);
        }

        public List<Pregunta> ListaPreguntas { get => listaPreguntas; set => listaPreguntas = value; }

        public void LeerFichero(string nombre)
        {
            string path = Directory.GetCurrentDirectory();
            try
            {
                FileStream fichero = new FileStream(@path + "\\" + nombre, FileMode.Open, FileAccess.Read);

                char separador = ';';

                int restantes = 2000;
                int numeroPreguntas = 0;
                int i = 0;
                byte[] nbytes = new byte[restantes];
                fichero.Read(nbytes, 0, restantes);
                StringReader strReader = new StringReader(Encoding.UTF8.GetString(nbytes));

                string linea;

                linea = strReader.ReadLine();

                while (linea != null && numeroPreguntas != 12)
                {

                    String[] substrings = linea.Split(separador);

                    Pregunta preguntaAux = new Pregunta();
                    preguntaAux.Enunciado = substrings[0];
                    i = 0;
                    while (i != 4)
                    {
                        preguntaAux.Respuestas[i] = new Respuesta();
                        preguntaAux.Respuestas[i].Enunciado = substrings[i+1];
                        preguntaAux.Respuestas[i].Valor = 0;
                        i++;
                    }

                    listaPreguntas.Add(preguntaAux);
                    linea = strReader.ReadLine();

                    numeroPreguntas++;
                }
                fichero.Close();
            }
            catch
            {
             
            }
            return;
        }

        public void EscribirFichero(string nombre, string estilo)
        {
            string path = Directory.GetCurrentDirectory();
            try
            {
                StreamWriter fichero = new StreamWriter(@path + "\\" + nombre);

                fichero.WriteLine("Estilo: " + estilo + "\n");
                foreach(Pregunta aux in listaPreguntas)
                {
                    fichero.WriteLine(aux.DatosFichero());
                }
                fichero.Close();
            }
            catch
            {
                
            }
            return;
        }
    }
}
