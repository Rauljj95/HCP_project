using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PsicoteXt
{
    public partial class FormRespuesta : Form
    {
        //private int[] ejeXPos;
        //private int[] ejeXNeg;
        //private int[] ejeYPos;
        //private int[] ejeYNeg;
        //private int dim = 20;
        private int estiloApren; // 1.divergente, 2.adaptador, 3.convergente, 4.asimilador

        private int EC; //Experiencia Concreta
        private int OR; //Observación Reflexiva
        private int CA; //Conceptualización Abstracta
        private int EA; //Experimentación Activa

        private int x;
        private int y;

        enum estilo {Divergente,Adaptador,Convergente,Asimilador};

        

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
        private string GetEstiloNombre(int aux)
        {
            switch (aux)
            {
                case (int)estilo.Divergente: return "Divergente";
                case (int)estilo.Convergente: return "Convergente";
                case (int)estilo.Asimilador: return "Asimilador";
                case (int)estilo.Adaptador: return "Adaptador";
            }
            return "";
        }
        private string GetEstiloDescripcion(int aux)
        {
            switch (aux)
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
            int estiloAprend = CalcularEstilo();
            this.label1.Text = GetEstiloNombre(estiloAprend);
        }
        private String TextoEstilo()
        {
            switch (estiloApren)
            {
                case 1:
                    return " ";
                case 2:
                    return " ";
                case 3:
                    return " ";
                case 4:
                    return " ";
                default:
                    return " ";
            }
        }
        //-------------------------------------------------------


        //No se necesita, se ha sustituido por el enum

        //private String NombreEstilo()
        //{
        //    switch (estiloApren)
        //    {
        //        case 1:
        //            return "Divergente";
        //        case 2:
        //            return "Adaptador";
        //        case 3:
        //            return "Convergente";
        //        case 4:
        //            return "Asimilador";
        //        default:
        //            return " ";
        //    }
        //}

        //Código Anterior para calcular los ejes

        //private void InitEjes()
        //{
        //    ejeXPos = new int[dim];
        //    int xPosi = 5; //Valor inicial del eje (5, 4, 3, 2....)
        //    ejeXNeg = new int[dim];
        //    int xNegi = 6; //Valor inicial del eje (6, 7, 8, 9....)

        //    ejeYPos = new int[dim];
        //    int yPosi = 3; //Valor inicial del eje (3, 2, 1, 0....)
        //    ejeYNeg = new int[dim];
        //    int yNegi = 4; //Valor inicial del eje (4, 5, 6, 7....)

        //    for (int i = 0; i < dim; i++)
        //    {
        //        ejeXPos[i] = xPosi--;
        //        ejeXNeg[i] = xNegi++;
        //        ejeYPos[i] = yPosi--;
        //        ejeYNeg[i] = yNegi++;
        //    }
        //}
        //private void ObtEstilo()
        //{
        //    int X = EA-OR;
        //    int Y = CA-EC;
        //    bool[] eje = { true, false, false, false };

        //    for (int i= 0; i<dim; i++){
        //        if (ejeXPos[i] == X)
        //        {
        //            eje[0] = true;
        //            break;
        //        }
        //    }
        //    for (int i=0; i<dim; i++){
        //        if (ejeYPos[i] == X)
        //        {
        //            eje[1] = true;
        //            break;
        //        }
        //    }
        //    for (int i=0; i<dim; i++){
        //        if (ejeXNeg[i] == X)
        //        {
        //            eje[2] = true;
        //            break;
        //        }
        //    }
        //    for (int i=0; i<dim; i++){
        //        if (ejeYNeg[i] == X)
        //        {
        //            eje[3] = true;
        //            break;
        //        }
        //    }

        //    if (eje[0] && eje[1])
        //        estiloApren = 1;
        //    else if (eje[1] && eje[2])
        //        estiloApren = 2;
        //    else if (eje[2] && eje[3])
        //        estiloApren = 3;
        //    else
        //        estiloApren = 4;
        //}


        //Inicialización del Form------------------------
        public FormRespuesta()
        {
            InitializeComponent();
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
