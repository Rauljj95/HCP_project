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
    public partial class FormTest : Form
    {
        private int EC; //Experiencia Concreta
        private int OR; //Observación Reflexiva
        private int CA; //Conceptualización Abstracta
        private int EA; //Experimentación Activa
        
        private void ObtenerValores()
        {
            EC = 0;
            OR = 0;
            CA = 0;
            EA = 0;
            ObtenerEC();
        }

        private void ObtenerNumMarcado(GroupBox g, int caso)
        {
            bool hayMarcado = false; //Si es falso al final, lanzar exepción, de que no hay marcado
            foreach (RadioButton radioB in g.Controls) //Recorriendo los 4 GroupBox de cada Panel
            {
                if (radioB.Checked)
                {
                    hayMarcado = true;
                    String s = radioB.Text;
                    int num = Int32.Parse(s);
                    switch (caso)
                    {
                        case 1:
                            EC += num; break;
                        case 2:
                            OR += num; break;
                        case 3:
                            CA += num; break;
                        case 4:
                            EA += num; break;
                    }
                }
            }
        }


        private void ObtenerEC()
        {
            foreach (Control posPaneles in this.flowLayoutPanel1.Controls) //Recorriendo los 6 paneles Principales
            {
                if (posPaneles is Panel)
                {
                    int grupoActual = 0;

                    foreach (Control posGroupBox in posPaneles.Controls) //Recorriendo los 4 GroupBox de cada Panel
                    {
                        GroupBox grupo;
                        if (posGroupBox is GroupBox)
                        {
                            grupo = (GroupBox)posGroupBox;
                            grupoActual++;
                            ObtenerNumMarcado(grupo, grupoActual);
                        }

                        //if (radioB.Checked)
                        //{
                        //    String num = radioB.Text;
                        //    EC += Int32.Parse(num);
                        //}
                    }
                    //foreach(Control gr in this.flowLayoutPanel1.Controls)

                    //elemento.GetChildAtPoint(1)

                    //if (elemento is GroupBox)
                    //{ 
                    //}
                    //foreach (RadioButton radioB in elemento.Controls)
                    //{
                    //    
                    //}
                }
            }
        }

        public FormTest()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void buttonExitTest_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonNextTest_Click(object sender, EventArgs e)
        {
            FormTest2 test2 = new FormTest2();
            this.Hide();
            ObtenerEC();
            test2.Show();
            test2.SetEC(EC);
            test2.SetEA(EA);
            test2.SetOR(OR);
            test2.SetCA(CA);
            
        }

        private void FormTest_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void FormTest_Load(object sender, EventArgs e)
        {

        }

        private void FormTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
