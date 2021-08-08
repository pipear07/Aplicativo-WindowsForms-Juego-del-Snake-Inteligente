namespace Proyecto_de_Progra_ll
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.palabras_de_inicio = new System.Windows.Forms.Label();
            this.puntos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // palabras_de_inicio
            // 
            this.palabras_de_inicio.AutoSize = true;
            this.palabras_de_inicio.Location = new System.Drawing.Point(242, 179);
            this.palabras_de_inicio.Name = "palabras_de_inicio";
            this.palabras_de_inicio.Size = new System.Drawing.Size(0, 13);
            this.palabras_de_inicio.TabIndex = 0;
            // 
            // puntos
            // 
            this.puntos.AutoSize = true;
            this.puntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.puntos.Location = new System.Drawing.Point(144, 9);
            this.puntos.Name = "puntos";
            this.puntos.Size = new System.Drawing.Size(30, 31);
            this.puntos.TabIndex = 1;
            this.puntos.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "Puntaje";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Proyecto_de_Progra_ll.Properties.Resources.paredes;
            this.ClientSize = new System.Drawing.Size(794, 427);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.puntos);
            this.Controls.Add(this.palabras_de_inicio);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Dibujar_todo_en_formulario_en_forma_paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Presionar_cualquier_tecla_del_computador);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Presiona_click_en_el_mause);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label palabras_de_inicio;
        private System.Windows.Forms.Label puntos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
    }
}

