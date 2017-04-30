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
        

        private int ObtenerNumMarcado(GroupBox g, int caso)
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
                            EC += num; return num;
                        case 2:
                            OR += num; return num;
                        case 3:
                            CA += num; return num;
                        case 4:
                            EA += num; return num;
                    }
                }
            }
            if (!hayMarcado)
            {
                SinMarcarException SMEx = new SinMarcarException("Existen respuestas sin marcar");
                throw SMEx;
            }
                
            return 0;
        }


        private void ObtenerValoresEstilos()
        {
            MismaPrioridadException MPEx;
            int filaActual = 0;
            foreach (Control posiblesPaneles in this.flowLayoutPanel1.Controls) //Recorriendo los 6 paneles Principales
            {
                if (posiblesPaneles is Panel)
                {
                    filaActual++;
                    int grupoActual = 0;
                    bool[] valoresSinUsar = {true, true, true, true};

                    foreach (Control posiblesGroupBox in posiblesPaneles.Controls) //Recorriendo los 4 GroupBox de cada Panel
                    {
                        GroupBox grupo;
                        if (posiblesGroupBox is GroupBox)
                        {
                            grupo = (GroupBox)posiblesGroupBox;
                            grupoActual++;
                            int aux = ObtenerNumMarcado(grupo, grupoActual);
                            if (valoresSinUsar[aux - 1])
                                valoresSinUsar[aux - 1] = false;
                            else
                            {
                                MPEx = new MismaPrioridadException("Exiten en la pregunta "+filaActual+", respuestas marcadas con la misma prioridad");
                                throw MPEx;
                            }
                                
                        }
                    }
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
            try
            {
                ObtenerValoresEstilos();
                FormTest2 test2 = new FormTest2();
                this.Hide();
                test2.Show();
                test2.SetEC(EC);
                test2.SetEA(EA);
                test2.SetOR(OR);
                test2.SetCA(CA);
            }
            catch (MismaPrioridadException ex)
            {
                MessageBox.Show(ex.getMensaje(), "Incorrecto",MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
            catch (SinMarcarException ex)
            {
                MessageBox.Show(ex.getMensaje(), "Incorrecto", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
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

        private void groupBox14_Enter(object sender, EventArgs e)
        {

        }
    }
}
