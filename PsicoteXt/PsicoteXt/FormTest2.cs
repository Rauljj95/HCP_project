﻿using System;
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

        public FormTest2()
        {
            InitializeComponent();
        }

        private void buttonExitTest2_Click(object sender, EventArgs e)
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