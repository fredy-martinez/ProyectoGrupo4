﻿
namespace ProyectoGrupo4.Vistas
{
    partial class BoletoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoletoView));
            this.Destino2GridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Cliente2DataGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Destino2GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cliente2DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Destino2GridView
            // 
            this.Destino2GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Destino2GridView.Location = new System.Drawing.Point(33, 63);
            this.Destino2GridView.Name = "Destino2GridView";
            this.Destino2GridView.Size = new System.Drawing.Size(397, 395);
            this.Destino2GridView.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(186, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Destino";
            // 
            // Cliente2DataGridView
            // 
            this.Cliente2DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Cliente2DataGridView.Location = new System.Drawing.Point(436, 63);
            this.Cliente2DataGridView.Name = "Cliente2DataGridView";
            this.Cliente2DataGridView.Size = new System.Drawing.Size(397, 395);
            this.Cliente2DataGridView.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(571, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cliente";
            // 
            // BoletoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 558);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Cliente2DataGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Destino2GridView);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BoletoView";
            this.Text = "Información del viaje ";
            ((System.ComponentModel.ISupportInitialize)(this.Destino2GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cliente2DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView Destino2GridView;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView Cliente2DataGridView;
    }
}