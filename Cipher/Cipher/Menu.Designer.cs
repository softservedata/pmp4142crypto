
namespace Cipher
{
    partial class Menu
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
            this.buttonRSA = new System.Windows.Forms.Button();
            this.buttonCardano = new System.Windows.Forms.Button();
            this.buttonWiegener = new System.Windows.Forms.Button();
            this.buttonChastokola = new System.Windows.Forms.Button();
            this.buttonAthenian = new System.Windows.Forms.Button();
            this.buttonCaesar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonRSA
            // 
            this.buttonRSA.Location = new System.Drawing.Point(545, 125);
            this.buttonRSA.Name = "buttonRSA";
            this.buttonRSA.Size = new System.Drawing.Size(180, 43);
            this.buttonRSA.TabIndex = 1;
            this.buttonRSA.Text = "Шифр RSA";
            this.buttonRSA.UseVisualStyleBackColor = true;
            this.buttonRSA.Click += new System.EventHandler(this.buttonRSA_Click);
            // 
            // buttonCardano
            // 
            this.buttonCardano.Location = new System.Drawing.Point(545, 40);
            this.buttonCardano.Name = "buttonCardano";
            this.buttonCardano.Size = new System.Drawing.Size(180, 43);
            this.buttonCardano.TabIndex = 2;
            this.buttonCardano.Text = "Шифр Кардано";
            this.buttonCardano.UseVisualStyleBackColor = true;
            this.buttonCardano.Click += new System.EventHandler(this.buttonCardano_Click);
            // 
            // buttonWiegener
            // 
            this.buttonWiegener.Location = new System.Drawing.Point(310, 125);
            this.buttonWiegener.Name = "buttonWiegener";
            this.buttonWiegener.Size = new System.Drawing.Size(180, 43);
            this.buttonWiegener.TabIndex = 3;
            this.buttonWiegener.Text = "Шифр Віженера";
            this.buttonWiegener.UseVisualStyleBackColor = true;
            this.buttonWiegener.Click += new System.EventHandler(this.buttonWiegener_Click);
            // 
            // buttonChastokola
            // 
            this.buttonChastokola.Location = new System.Drawing.Point(72, 125);
            this.buttonChastokola.Name = "buttonChastokola";
            this.buttonChastokola.Size = new System.Drawing.Size(180, 43);
            this.buttonChastokola.TabIndex = 4;
            this.buttonChastokola.Text = "Шифр Частокола";
            this.buttonChastokola.UseVisualStyleBackColor = true;
            this.buttonChastokola.Click += new System.EventHandler(this.buttonChastokola_Click);
            // 
            // buttonAthenian
            // 
            this.buttonAthenian.Location = new System.Drawing.Point(310, 40);
            this.buttonAthenian.Name = "buttonAthenian";
            this.buttonAthenian.Size = new System.Drawing.Size(180, 43);
            this.buttonAthenian.TabIndex = 5;
            this.buttonAthenian.Text = "Афінний Шифр";
            this.buttonAthenian.UseVisualStyleBackColor = true;
            this.buttonAthenian.Click += new System.EventHandler(this.buttonAthenian_Click);
            // 
            // buttonCaesar
            // 
            this.buttonCaesar.Location = new System.Drawing.Point(72, 40);
            this.buttonCaesar.Name = "buttonCaesar";
            this.buttonCaesar.Size = new System.Drawing.Size(180, 43);
            this.buttonCaesar.TabIndex = 6;
            this.buttonCaesar.Text = "Шифр Цезаря";
            this.buttonCaesar.UseVisualStyleBackColor = true;
            this.buttonCaesar.Click += new System.EventHandler(this.buttonCaesar_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 216);
            this.Controls.Add(this.buttonRSA);
            this.Controls.Add(this.buttonCardano);
            this.Controls.Add(this.buttonWiegener);
            this.Controls.Add(this.buttonChastokola);
            this.Controls.Add(this.buttonAthenian);
            this.Controls.Add(this.buttonCaesar);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonRSA;
        private System.Windows.Forms.Button buttonCardano;
        private System.Windows.Forms.Button buttonWiegener;
        private System.Windows.Forms.Button buttonChastokola;
        private System.Windows.Forms.Button buttonAthenian;
        private System.Windows.Forms.Button buttonCaesar;
    }
}