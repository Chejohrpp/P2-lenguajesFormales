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
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtEditor = new System.Windows.Forms.RichTextBox();
            this.btnCompilar = new System.Windows.Forms.Button();
            this.listaResult = new System.Windows.Forms.ListBox();
            this.lblFila = new System.Windows.Forms.Label();
            this.lblColumna = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archioToolStripMenuItem,
            this.editarToolStripMenuItem});
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
            this.cerrarToolStripMenuItem});
            this.archioToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.archioToolStripMenuItem.Name = "archioToolStripMenuItem";
            this.archioToolStripMenuItem.Size = new System.Drawing.Size(90, 29);
            this.archioToolStripMenuItem.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(167, 30);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(167, 30);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(167, 30);
            this.cerrarToolStripMenuItem.Text = "Cerrar";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(75, 29);
            this.editarToolStripMenuItem.Text = "Editar";
            // 
            // txtEditor
            // 
            this.txtEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // btnCompilar
            // 
            this.btnCompilar.Location = new System.Drawing.Point(31, 497);
            this.btnCompilar.Name = "btnCompilar";
            this.btnCompilar.Size = new System.Drawing.Size(170, 46);
            this.btnCompilar.TabIndex = 2;
            this.btnCompilar.Text = "Compilar";
            this.btnCompilar.UseVisualStyleBackColor = true;
            this.btnCompilar.Click += new System.EventHandler(this.btnCompilar_Click);
            // 
            // listaResult
            // 
            this.listaResult.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.listaResult.FormattingEnabled = true;
            this.listaResult.ItemHeight = 16;
            this.listaResult.Location = new System.Drawing.Point(16, 566);
            this.listaResult.Name = "listaResult";
            this.listaResult.Size = new System.Drawing.Size(1238, 180);
            this.listaResult.TabIndex = 3;
            // 
            // lblFila
            // 
            this.lblFila.AutoSize = true;
            this.lblFila.Location = new System.Drawing.Point(994, 508);
            this.lblFila.Name = "lblFila";
            this.lblFila.Size = new System.Drawing.Size(34, 17);
            this.lblFila.TabIndex = 4;
            this.lblFila.Text = "Fila:";
            // 
            // lblColumna
            // 
            this.lblColumna.AutoSize = true;
            this.lblColumna.Location = new System.Drawing.Point(1176, 508);
            this.lblColumna.Name = "lblColumna";
            this.lblColumna.Size = new System.Drawing.Size(67, 17);
            this.lblColumna.TabIndex = 5;
            this.lblColumna.Text = "Columna:";
            this.lblColumna.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 764);
            this.Controls.Add(this.lblColumna);
            this.Controls.Add(this.lblFila);
            this.Controls.Add(this.listaResult);
            this.Controls.Add(this.btnCompilar);
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
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.RichTextBox txtEditor;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.Button btnCompilar;
        private System.Windows.Forms.ListBox listaResult;
        private System.Windows.Forms.Label lblFila;
        private System.Windows.Forms.Label lblColumna;
    }
}

