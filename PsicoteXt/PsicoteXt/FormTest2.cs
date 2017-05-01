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
    public partial class FormTest2 : Form
    {
        private Preguntas preguntasTest;
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
                    bool[] valoresSinUsar = { true, true, true, true };

                    foreach (Control posiblesGroupBox in posiblesPaneles.Controls) //Recorriendo los 4 GroupBox de cada Panel
                    {
                        GroupBox grupo;
                        if (posiblesGroupBox is GroupBox)
                        {
                            grupo = (GroupBox)posiblesGroupBox;
                            grupoActual++;
                            int aux = ObtenerNumMarcado(grupo, grupoActual);
                            if (grupoActual <= 4 && filaActual <= 6)
                                preguntasTest.ListaPreguntas[filaActual+5].Respuestas[grupoActual-1].Valor = aux;
                            if (valoresSinUsar[aux - 1])
                                valoresSinUsar[aux - 1] = false;
                            else
                            {
                                MPEx = new MismaPrioridadException("Exiten en la pregunta " + filaActual + ", respuestas marcadas con la misma prioridad");
                                throw MPEx;
                            }

                        }
                    }
                }
            }
        }

        public FormTest2(Preguntas preguntasLeidas)
        {
            InitializeComponent();
            preguntasTest = new Preguntas();
            preguntasTest = preguntasLeidas;
        }



        private void buttonExitTest2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ObtenerValoresEstilos();
                FormCicloApren cicloApren = new FormCicloApren(preguntasTest);
                this.Hide();
                cicloApren.SetEC(EC);
                cicloApren.SetEA(EA);
                cicloApren.SetOR(OR);
                cicloApren.SetCA(CA);
                cicloApren.Prepare();
                cicloApren.Show();
            }
            catch (MismaPrioridadException ex)
            {
                MessageBox.Show(ex.getMensaje(), "Incorrecto", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
            catch (SinMarcarException ex)
            {
                MessageBox.Show(ex.getMensaje(), "Incorrecto", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
        }

        private void FormTest2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
