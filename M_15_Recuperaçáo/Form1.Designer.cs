namespace M_15_Recuperaçáo
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ficheiroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caçadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.armasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pontuaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ficheiroToolStripMenuItem,
            this.editarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ficheiroToolStripMenuItem
            // 
            this.ficheiroToolStripMenuItem.Name = "ficheiroToolStripMenuItem";
            this.ficheiroToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.ficheiroToolStripMenuItem.Text = "Ficheiro";
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.caçadoresToolStripMenuItem,
            this.armasToolStripMenuItem,
            this.pontuaçãoToolStripMenuItem});
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.editarToolStripMenuItem.Text = "Editar";
            // 
            // caçadoresToolStripMenuItem
            // 
            this.caçadoresToolStripMenuItem.Name = "caçadoresToolStripMenuItem";
            this.caçadoresToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.caçadoresToolStripMenuItem.Text = "Caçadores";
            this.caçadoresToolStripMenuItem.Click += new System.EventHandler(this.caçadoresToolStripMenuItem_Click);
            // 
            // armasToolStripMenuItem
            // 
            this.armasToolStripMenuItem.Name = "armasToolStripMenuItem";
            this.armasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.armasToolStripMenuItem.Text = "Armas";
            this.armasToolStripMenuItem.Click += new System.EventHandler(this.armasToolStripMenuItem_Click);
            // 
            // pontuaçãoToolStripMenuItem
            // 
            this.pontuaçãoToolStripMenuItem.Name = "pontuaçãoToolStripMenuItem";
            this.pontuaçãoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pontuaçãoToolStripMenuItem.Text = "Pontuação";
            this.pontuaçãoToolStripMenuItem.Click += new System.EventHandler(this.pontuaçãoToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ficheiroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caçadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem armasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pontuaçãoToolStripMenuItem;
    }
}

