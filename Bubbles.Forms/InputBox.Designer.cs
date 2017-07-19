namespace Bubbles.Forms
{
    partial class InputBox
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
            this.btn = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.ipt_qtd = new System.Windows.Forms.TextBox();
            this.ipt_use_area = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(210, 111);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(75, 23);
            this.btn.TabIndex = 0;
            this.btn.Text = "Enviar";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(12, 9);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(35, 13);
            this.lbl.TabIndex = 1;
            this.lbl.Text = "label1";
            // 
            // ipt_qtd
            // 
            this.ipt_qtd.Location = new System.Drawing.Point(176, 59);
            this.ipt_qtd.Name = "ipt_qtd";
            this.ipt_qtd.Size = new System.Drawing.Size(109, 20);
            this.ipt_qtd.TabIndex = 2;
            this.ipt_qtd.TextChanged += new System.EventHandler(this.Ipt_QtdChanged);
            // 
            // ipt_use_area
            // 
            this.ipt_use_area.Location = new System.Drawing.Point(176, 85);
            this.ipt_use_area.Name = "ipt_use_area";
            this.ipt_use_area.Size = new System.Drawing.Size(109, 20);
            this.ipt_use_area.TabIndex = 3;
            this.ipt_use_area.TextChanged += new System.EventHandler(this.Ipt_UseAreaChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "QUANTIDADE DE BOLHAS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "AREA DE USO";
            // 
            // InputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 156);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ipt_use_area);
            this.Controls.Add(this.ipt_qtd);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.btn);
            this.Name = "InputBox";
            this.Text = "InputBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.TextBox ipt_qtd;
        private System.Windows.Forms.TextBox ipt_use_area;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}