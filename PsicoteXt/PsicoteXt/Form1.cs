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
    public partial class FormInicio : Form
    {
        private Preguntas preguntasTest;

        //public Preguntas PreguntasTest { get => preguntasTest; set => preguntasTest = value; }

        public FormInicio()
        {
            InitializeComponent();
            preguntasTest = new Preguntas();

            preguntasTest.LeerFichero("preguntas.txt");
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormTest test = new FormTest(preguntasTest);
            test.Show();
            this.Hide();
        }
    }
}
