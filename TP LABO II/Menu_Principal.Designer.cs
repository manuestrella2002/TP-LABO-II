
namespace TP_LABO_II
{
    partial class Menu_Principal
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
            this.button_Comenzar = new System.Windows.Forms.Button();
            this.button_Salir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Comenzar
            // 
            this.button_Comenzar.Location = new System.Drawing.Point(64, 169);
            this.button_Comenzar.Name = "button_Comenzar";
            this.button_Comenzar.Size = new System.Drawing.Size(75, 23);
            this.button_Comenzar.TabIndex = 0;
            this.button_Comenzar.Text = "Comenzar";
            this.button_Comenzar.UseVisualStyleBackColor = true;
            this.button_Comenzar.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_Salir
            // 
            this.button_Salir.Location = new System.Drawing.Point(284, 169);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(75, 23);
            this.button_Salir.TabIndex = 1;
            this.button_Salir.Text = "Salir";
            this.button_Salir.UseVisualStyleBackColor = true;
            this.button_Salir.Click += new System.EventHandler(this.button_Salir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "Posicionar Piezas de Ajedrez";
            // 
            // Menu_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 237);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Salir);
            this.Controls.Add(this.button_Comenzar);
            this.Name = "Menu_Principal";
            this.Text = "Menu_Principal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Comenzar;
        private System.Windows.Forms.Button button_Salir;
        private System.Windows.Forms.Label label1;
    }
}