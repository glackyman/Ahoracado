namespace Juego
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
            this.lblVidas = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ahorcado1 = new ComponenteJuego.ComponenteAhorcado();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configuracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conexionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.juegoNuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaPalabraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTryWord = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblVidas
            // 
            this.lblVidas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVidas.AutoSize = true;
            this.lblVidas.Location = new System.Drawing.Point(10, 24);
            this.lblVidas.Name = "lblVidas";
            this.lblVidas.Size = new System.Drawing.Size(48, 13);
            this.lblVidas.TabIndex = 2;
            this.lblVidas.Text = "Vidas:  6";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 470);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // ahorcado1
            // 
            this.ahorcado1.Location = new System.Drawing.Point(32, 41);
            this.ahorcado1.Margin = new System.Windows.Forms.Padding(4);
            this.ahorcado1.Name = "ahorcado1";
            this.ahorcado1.NumErrores = 0;
            this.ahorcado1.Size = new System.Drawing.Size(421, 288);
            this.ahorcado1.TabIndex = 3;
            this.ahorcado1.Text = "componenteAhorcado1";
            this.ahorcado1.Ahorcado += new System.EventHandler(this.ahorcado_Ahorcado);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(71, 435);
            this.textBox1.MaxLength = 1;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuracionToolStripMenuItem,
            this.juegoNuevoToolStripMenuItem,
            this.verRecordsToolStripMenuItem,
            this.nuevaPalabraToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configuracionToolStripMenuItem
            // 
            this.configuracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conexionToolStripMenuItem});
            this.configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            this.configuracionToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.configuracionToolStripMenuItem.Text = "Configuracion";
            // 
            // conexionToolStripMenuItem
            // 
            this.conexionToolStripMenuItem.Name = "conexionToolStripMenuItem";
            this.conexionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.conexionToolStripMenuItem.Text = "Conexion";
            this.conexionToolStripMenuItem.Click += new System.EventHandler(this.ConexionConfig);
            // 
            // juegoNuevoToolStripMenuItem
            // 
            this.juegoNuevoToolStripMenuItem.Name = "juegoNuevoToolStripMenuItem";
            this.juegoNuevoToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.juegoNuevoToolStripMenuItem.Text = "Juego Nuevo";
            this.juegoNuevoToolStripMenuItem.Click += new System.EventHandler(this.juegoNuevoToolStripMenuItem_Click);
            // 
            // verRecordsToolStripMenuItem
            // 
            this.verRecordsToolStripMenuItem.Name = "verRecordsToolStripMenuItem";
            this.verRecordsToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.verRecordsToolStripMenuItem.Text = "Ver Records";
            this.verRecordsToolStripMenuItem.Click += new System.EventHandler(this.verRecordsToolStripMenuItem_Click);
            // 
            // nuevaPalabraToolStripMenuItem
            // 
            this.nuevaPalabraToolStripMenuItem.Name = "nuevaPalabraToolStripMenuItem";
            this.nuevaPalabraToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.nuevaPalabraToolStripMenuItem.Text = "Nueva Palabra";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(56, 497);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(221, 20);
            this.textBox2.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 500);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Fallos";
            // 
            // btnTryWord
            // 
            this.btnTryWord.Location = new System.Drawing.Point(10, 434);
            this.btnTryWord.Margin = new System.Windows.Forms.Padding(2);
            this.btnTryWord.Name = "btnTryWord";
            this.btnTryWord.Size = new System.Drawing.Size(56, 19);
            this.btnTryWord.TabIndex = 11;
            this.btnTryWord.Text = "Jugar";
            this.btnTryWord.UseVisualStyleBackColor = true;
            this.btnTryWord.Click += new System.EventHandler(this.btnTryWord_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnTryWord;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 528);
            this.Controls.Add(this.btnTryWord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ahorcado1);
            this.Controls.Add(this.lblVidas);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblVidas;
        private ComponenteJuego.ComponenteAhorcado ahorcado1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem juegoNuevoToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem verRecordsToolStripMenuItem;
        private System.Windows.Forms.Button btnTryWord;
        private System.Windows.Forms.ToolStripMenuItem nuevaPalabraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conexionToolStripMenuItem;
    }
}