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
    public partial class FormCicloApren : Form
    {
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

        //Método que prepara la ventana--------
        public void Prepare()
        {
            DibujarBarras();
        }
        //------------------------------------

        private void DibujarBarras()
        {
            //Porcentajes que representa cada 
            float pEC = 120 * EC / 100;
            float pOR = 120 * OR / 100;
            float pCA = 120 * CA / 100;
            float pEA = 120 * EA / 100;
            porcientoEC.Text = pEC.ToString()+" %";
            barraEC.Width = 666*(int)pEC/100;
            porcientoCA.Text = pCA.ToString()+" %";
            barraCA.Width = 666 * (int)pCA / 100;
            porcientoOR.Text = pOR.ToString()+" %";
            barraOR.Width = 666 * (int)pOR / 100;
            porcientoEA.Text = pEA.ToString()+" %";
            barraEA.Width = 666 * (int)pEA / 100;
        }

        public FormCicloApren()
        {
            InitializeComponent();
        }

        private void FormCicloApren_Load(object sender, EventArgs e)
        {
            
        }

        private void FormCicloApren_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormRespuesta respuesta = new FormRespuesta();
            respuesta.Show();
            this.Hide();
            respuesta.SetEC(EC);
            respuesta.SetEA(EA);
            respuesta.SetOR(OR);
            respuesta.SetCA(CA);
        }
    }
}
