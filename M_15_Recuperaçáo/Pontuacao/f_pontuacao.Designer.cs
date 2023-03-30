namespace M_15_Recuperaçáo.Pontuacao
{
    partial class f_pontuacao
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtdata_pontuacao = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cbcacador = new System.Windows.Forms.ComboBox();
            this.cbarma = new System.Windows.Forms.ComboBox();
            this.tbNpontuacao = new System.Windows.Forms.TextBox();
            this.dgpontuacao = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgpontuacao)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nº Pontuação";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nº Caçador";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nº Arma";
            // 
            // dtdata_pontuacao
            // 
            this.dtdata_pontuacao.Location = new System.Drawing.Point(51, 239);
            this.dtdata_pontuacao.Name = "dtdata_pontuacao";
            this.dtdata_pontuacao.Size = new System.Drawing.Size(158, 20);
            this.dtdata_pontuacao.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Data Pontucação";
            // 
            // cbcacador
            // 
            this.cbcacador.FormattingEnabled = true;
            this.cbcacador.Location = new System.Drawing.Point(51, 115);
            this.cbcacador.Name = "cbcacador";
            this.cbcacador.Size = new System.Drawing.Size(121, 21);
            this.cbcacador.TabIndex = 6;
            // 
            // cbarma
            // 
            this.cbarma.FormattingEnabled = true;
            this.cbarma.Location = new System.Drawing.Point(51, 168);
            this.cbarma.Name = "cbarma";
            this.cbarma.Size = new System.Drawing.Size(121, 21);
            this.cbarma.TabIndex = 7;
            // 
            // tbNpontuacao
            // 
            this.tbNpontuacao.Location = new System.Drawing.Point(51, 58);
            this.tbNpontuacao.Name = "tbNpontuacao";
            this.tbNpontuacao.Size = new System.Drawing.Size(121, 20);
            this.tbNpontuacao.TabIndex = 8;
            // 
            // dgpontuacao
            // 
            this.dgpontuacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgpontuacao.Location = new System.Drawing.Point(306, 58);
            this.dgpontuacao.Name = "dgpontuacao";
            this.dgpontuacao.Size = new System.Drawing.Size(465, 201);
            this.dgpontuacao.TabIndex = 9;
            this.dgpontuacao.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(306, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(396, 280);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Apagar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(615, 280);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "Cancelar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(696, 280);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "Atualizar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // f_pontuacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgpontuacao);
            this.Controls.Add(this.tbNpontuacao);
            this.Controls.Add(this.cbarma);
            this.Controls.Add(this.cbcacador);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtdata_pontuacao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "f_pontuacao";
            this.Text = "f_pontuacao";
            ((System.ComponentModel.ISupportInitialize)(this.dgpontuacao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtdata_pontuacao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbcacador;
        private System.Windows.Forms.ComboBox cbarma;
        private System.Windows.Forms.TextBox tbNpontuacao;
        private System.Windows.Forms.DataGridView dgpontuacao;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}