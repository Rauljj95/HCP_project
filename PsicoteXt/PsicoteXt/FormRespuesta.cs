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
        private int[] ejeXPos;
        private int[] ejeXNeg;
        private int[] ejeYPos;
        private int[] ejeYNeg;
        private int dim = 20;
        private int estiloApren; // 1.divergente, 2.adaptador, 3.convergente, 4.asimilador

        private int EC; //Experiencia Concreta
        private int OR; //Observación Reflexiva
        private int CA; //Conceptualización Abstracta
        private int EA; //Experimentación Activa

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

        private void ImprimirEstilo()
        {
            InitEjes();
            ObtEstilo();
            this.label1.Text = NombreEstilo();
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
        private String NombreEstilo()
        {
            switch (estiloApren)
            {
                case 1:
                    return "Divergente";
                case 2:
                    return "Adaptador";
                case 3:
                    return "Convergente";
                case 4:
                    return "Asimilador";
                default:
                    return " ";
            }
        }

        private void InitEjes()
        {
            ejeXPos = new int[dim];
            int xPosi = 5; //Valor inicial del eje (5, 4, 3, 2....)
            ejeXNeg = new int[dim];
            int xNegi = 6; //Valor inicial del eje (6, 7, 8, 9....)

            ejeYPos = new int[dim];
            int yPosi = 3; //Valor inicial del eje (3, 2, 1, 0....)
            ejeYNeg = new int[dim];
            int yNegi = 4; //Valor inicial del eje (4, 5, 6, 7....)

            for (int i = 0; i < dim; i++)
            {
                ejeXPos[i] = xPosi--;
                ejeXNeg[i] = xNegi++;
                ejeYPos[i] = yPosi--;
                ejeYNeg[i] = yNegi++;
            }
        }
        private void ObtEstilo()
        {
            int X = EA-OR;
            int Y = CA-EC;
            bool[] eje = { true, false, false, false };

            for (int i= 0; i<dim; i++){
                if (ejeXPos[i] == X)
                {
                    eje[0] = true;
                    break;
                }
            }
            for (int i=0; i<dim; i++){
                if (ejeYPos[i] == X)
                {
                    eje[1] = true;
                    break;
                }
            }
            for (int i=0; i<dim; i++){
                if (ejeXNeg[i] == X)
                {
                    eje[2] = true;
                    break;
                }
            }
            for (int i=0; i<dim; i++){
                if (ejeYNeg[i] == X)
                {
                    eje[3] = true;
                    break;
                }
            }

            if (eje[0] && eje[1])
                estiloApren = 1;
            else if (eje[1] && eje[2])
                estiloApren = 2;
            else if (eje[2] && eje[3])
                estiloApren = 3;
            else
                estiloApren = 4;
        }

        public FormRespuesta()
        {
            InitializeComponent();
            
        }

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
    }
}
