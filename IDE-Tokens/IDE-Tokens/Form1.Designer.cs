namespace IDE_Tokens
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarElLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarArbolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtEditor = new System.Windows.Forms.RichTextBox();
            this.listaResult = new System.Windows.Forms.ListBox();
            this.listSintactico = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1300, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archioToolStripMenuItem
            // 
            this.archioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.exportarElLogToolStripMenuItem,
            this.generarArbolToolStripMenuItem,
            this.cerrarToolStripMenuItem});
            this.archioToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.archioToolStripMenuItem.Name = "archioToolStripMenuItem";
            this.archioToolStripMenuItem.Size = new System.Drawing.Size(90, 29);
            this.archioToolStripMenuItem.Text = "Archivo";
            this.archioToolStripMenuItem.Click += new System.EventHandler(this.archioToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(266, 30);
            this.abrirToolStripMenuItem.Text = "Abrir un proyecto";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(266, 30);
            this.guardarToolStripMenuItem.Text = "Guardar el proyecto";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // exportarElLogToolStripMenuItem
            // 
            this.exportarElLogToolStripMenuItem.Name = "exportarElLogToolStripMenuItem";
            this.exportarElLogToolStripMenuItem.Size = new System.Drawing.Size(266, 30);
            this.exportarElLogToolStripMenuItem.Text = "Exportar el Log";
            this.exportarElLogToolStripMenuItem.Click += new System.EventHandler(this.exportarElLogToolStripMenuItem_Click);
            // 
            // generarArbolToolStripMenuItem
            // 
            this.generarArbolToolStripMenuItem.Name = "generarArbolToolStripMenuItem";
            this.generarArbolToolStripMenuItem.Size = new System.Drawing.Size(266, 30);
            this.generarArbolToolStripMenuItem.Text = "Generar Arbol";
            this.generarArbolToolStripMenuItem.Click += new System.EventHandler(this.generarArbolToolStripMenuItem_Click);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(266, 30);
            this.cerrarToolStripMenuItem.Text = "Cerrar el programa";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // txtEditor
            // 
            this.txtEditor.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditor.Location = new System.Drawing.Point(31, 37);
            this.txtEditor.Margin = new System.Windows.Forms.Padding(4);
            this.txtEditor.Name = "txtEditor";
            this.txtEditor.Size = new System.Drawing.Size(1238, 453);
            this.txtEditor.TabIndex = 1;
            this.txtEditor.Text = "";
            this.txtEditor.TextChanged += new System.EventHandler(this.txtEditor_TextChanged);
            this.txtEditor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEditor_KeyDown);
            this.txtEditor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEditor_KeyPress);
            this.txtEditor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtEditor_MouseDown);
            this.txtEditor.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtEditor_PreviewKeyDown);
            // 
            // listaResult
            // 
            this.listaResult.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.listaResult.FormattingEnabled = true;
            this.listaResult.ItemHeight = 16;
            this.listaResult.Location = new System.Drawing.Point(31, 514);
            this.listaResult.Name = "listaResult";
            this.listaResult.Size = new System.Drawing.Size(1238, 84);
            this.listaResult.TabIndex = 3;
            // 
            // listSintactico
            // 
            this.listSintactico.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.listSintactico.FormattingEnabled = true;
            this.listSintactico.ItemHeight = 16;
            this.listSintactico.Location = new System.Drawing.Point(31, 621);
            this.listSintactico.Name = "listSintactico";
            this.listSintactico.Size = new System.Drawing.Size(1238, 180);
            this.listSintactico.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 601);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Errores sintacticos";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 494);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Errores Lexicos";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 818);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listSintactico);
            this.Controls.Add(this.listaResult);
            this.Controls.Add(this.txtEditor);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.RichTextBox txtEditor;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.ListBox listaResult;
        private System.Windows.Forms.ToolStripMenuItem exportarElLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarArbolToolStripMenuItem;
        private System.Windows.Forms.ListBox listSintactico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

