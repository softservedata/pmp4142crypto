namespace Caesar_cipher
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.textBox_main = new System.Windows.Forms.TextBox();
            this.button_load = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_eng = new System.Windows.Forms.RadioButton();
            this.radioButton_ukr = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_encrypt = new System.Windows.Forms.Button();
            this.textBox_encrypt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_decrypt = new System.Windows.Forms.Button();
            this.textBox_decrypt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_main
            // 
            this.textBox_main.Location = new System.Drawing.Point(22, 23);
            this.textBox_main.Multiline = true;
            this.textBox_main.Name = "textBox_main";
            this.textBox_main.Size = new System.Drawing.Size(237, 196);
            this.textBox_main.TabIndex = 0;
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(22, 237);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(75, 23);
            this.button_load.TabIndex = 1;
            this.button_load.Text = "Завантажити";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(103, 237);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 23);
            this.button_clear.TabIndex = 2;
            this.button_clear.Text = "Очистити";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(184, 237);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 3;
            this.button_save.Text = "Зберегти";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_eng);
            this.groupBox1.Controls.Add(this.radioButton_ukr);
            this.groupBox1.Location = new System.Drawing.Point(284, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 47);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Мова";
            // 
            // radioButton_eng
            // 
            this.radioButton_eng.AutoSize = true;
            this.radioButton_eng.Location = new System.Drawing.Point(113, 19);
            this.radioButton_eng.Name = "radioButton_eng";
            this.radioButton_eng.Size = new System.Drawing.Size(81, 17);
            this.radioButton_eng.TabIndex = 1;
            this.radioButton_eng.TabStop = true;
            this.radioButton_eng.Text = "Англійська";
            this.radioButton_eng.UseVisualStyleBackColor = true;
            this.radioButton_eng.CheckedChanged += new System.EventHandler(this.radioButton_eng_CheckedChanged);
            // 
            // radioButton_ukr
            // 
            this.radioButton_ukr.AutoSize = true;
            this.radioButton_ukr.Location = new System.Drawing.Point(15, 19);
            this.radioButton_ukr.Name = "radioButton_ukr";
            this.radioButton_ukr.Size = new System.Drawing.Size(84, 17);
            this.radioButton_ukr.TabIndex = 0;
            this.radioButton_ukr.TabStop = true;
            this.radioButton_ukr.Text = "Українська";
            this.radioButton_ukr.UseVisualStyleBackColor = true;
            this.radioButton_ukr.CheckedChanged += new System.EventHandler(this.radioButton_ukr_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_encrypt);
            this.groupBox2.Controls.Add(this.textBox_encrypt);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(284, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(209, 76);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Шифрування";
            // 
            // button_encrypt
            // 
            this.button_encrypt.Location = new System.Drawing.Point(66, 47);
            this.button_encrypt.Name = "button_encrypt";
            this.button_encrypt.Size = new System.Drawing.Size(75, 23);
            this.button_encrypt.TabIndex = 2;
            this.button_encrypt.Text = "ОК";
            this.button_encrypt.UseVisualStyleBackColor = true;
            this.button_encrypt.Click += new System.EventHandler(this.button_encrypt_Click);
            // 
            // textBox_encrypt
            // 
            this.textBox_encrypt.Location = new System.Drawing.Point(176, 23);
            this.textBox_encrypt.Name = "textBox_encrypt";
            this.textBox_encrypt.Size = new System.Drawing.Size(25, 20);
            this.textBox_encrypt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Зашифрувати текст за ключем";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_decrypt);
            this.groupBox3.Controls.Add(this.textBox_decrypt);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(284, 184);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(209, 76);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Дешифрування";
            // 
            // button_decrypt
            // 
            this.button_decrypt.Location = new System.Drawing.Point(66, 47);
            this.button_decrypt.Name = "button_decrypt";
            this.button_decrypt.Size = new System.Drawing.Size(75, 23);
            this.button_decrypt.TabIndex = 2;
            this.button_decrypt.Text = "ОК";
            this.button_decrypt.UseVisualStyleBackColor = true;
            this.button_decrypt.Click += new System.EventHandler(this.button_decrypt_Click);
            // 
            // textBox_decrypt
            // 
            this.textBox_decrypt.Location = new System.Drawing.Point(176, 19);
            this.textBox_decrypt.Name = "textBox_decrypt";
            this.textBox_decrypt.Size = new System.Drawing.Size(25, 20);
            this.textBox_decrypt.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Дешифрувати текст за ключем";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 282);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.textBox_main);
            this.Name = "Form1";
            this.Text = "Шифр цезаря";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox textBox_main;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_eng;
        private System.Windows.Forms.RadioButton radioButton_ukr;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_encrypt;
        private System.Windows.Forms.TextBox textBox_encrypt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_decrypt;
        private System.Windows.Forms.TextBox textBox_decrypt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.BindingSource bindingSource2;
    }
}

