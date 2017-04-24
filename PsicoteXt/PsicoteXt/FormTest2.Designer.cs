namespace PsicoteXt
{
    partial class FormTest2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTest2));
            this.buttonExitTest2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonExitTest2
            // 
            this.buttonExitTest2.Location = new System.Drawing.Point(961, 12);
            this.buttonExitTest2.Name = "buttonExitTest2";
            this.buttonExitTest2.Size = new System.Drawing.Size(89, 47);
            this.buttonExitTest2.TabIndex = 0;
            this.buttonExitTest2.Text = "Salir";
            this.buttonExitTest2.UseVisualStyleBackColor = true;
            this.buttonExitTest2.Click += new System.EventHandler(this.buttonExitTest2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(919, 613);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ver Resultado";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormTest2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1062, 673);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonExitTest2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTest2";
            this.Text = "psicoteXt";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonExitTest2;
        private System.Windows.Forms.Button button1;
    }
}