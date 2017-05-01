using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PsicoteXt
{
    public partial class FormRespuesta : Form
    {
        private int estiloApren; // 1.divergente, 2.adaptador, 3.convergente, 4.asimilador
        private Preguntas listaPreguntas;
        private int EC; //Experiencia Concreta
        private int OR; //Observación Reflexiva
        private int CA; //Conceptualización Abstracta
        private int EA; //Experimentación Activa

        private int x;
        private int y;

        enum estilo {Divergente = 1,Adaptador,Convergente,Asimilador};

        //Métodos Set-------------------------------------------
        public void SetEC(int EC)
        {
            this.EC = EC;
        }
        public void SetOR(int OR)
        {
            this.OR = OR;
        }
        public void SetCA(int CA)
        {
            this.CA = CA;
        }
        public void SetEA(int EA)
        {
            this.EA = EA;
        }
        //------------------------------------------------------

        //Métodos para Determinación de Estilo de Aprendizaje-------------------------
        public int CalcularEstilo()
        {
            if (x <= 5 && y <= 3)
                return (int)estilo.Divergente;
            else if (x >= 6 && y <= 3)
                return (int)estilo.Adaptador;
            else if (x >= 6 && y >= 4)
                return (int)estilo.Convergente;
            else
                return (int)estilo.Asimilador;
        }
        private string GetEstiloNombre()
        {
            switch (estiloApren)
            {
                case (int)estilo.Divergente: return "Divergente";
                case (int)estilo.Convergente: return "Convergente";
                case (int)estilo.Asimilador: return "Asimilador";
                case (int)estilo.Adaptador: return "Adaptador";
            }
            return "";
        }
        
        //----------------------------------------------------------------------------

        //Métodos Que Escriben en Pantalla----------------------
        private void ImprimirEstilo()
        {
            x = EA - OR;
            y = CA - EC;
            estiloApren = CalcularEstilo();
            this.label1.Text = GetEstiloNombre();

            string path = Directory.GetCurrentDirectory();
            try
            {
                FileStream fichero = new FileStream(@path + "\\" + GetEstiloNombre() +".txt", FileMode.Open, FileAccess.Read);

                
                int restantes = (int)fichero.Length;
               
                byte[] nbytes = new byte[restantes];
                fichero.Read(nbytes, 0, restantes);
                

                
                label2.Text = Encoding.UTF8.GetString(nbytes);
                fichero.Close();
                listaPreguntas.EscribirFichero("respuestas.txt", GetEstiloNombre());
            }
            catch
            {

            }
        }
        
        //-------------------------------------------------------


        //Inicialización del Form------------------------
        public FormRespuesta(Preguntas preguntasTest)
        {
            InitializeComponent();
            listaPreguntas = new Preguntas();
            listaPreguntas = preguntasTest;
        }
        //------------------------------------------------

        //Eventos--------------------------------

        private void buttonExitRespuesta_Click(object sender, EventArgs e)
        {
           
            
         
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImprimirEstilo();
        }

        private void FormRespuesta_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
