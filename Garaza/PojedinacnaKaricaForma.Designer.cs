namespace Garaza
{
    partial class PojedinacnaKaricaForma
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbTipC = new System.Windows.Forms.RadioButton();
            this.rbTipB = new System.Windows.Forms.RadioButton();
            this.rbTipA = new System.Windows.Forms.RadioButton();
            this.btnCheck = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.tbTablica = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbTipC);
            this.groupBox1.Controls.Add(this.rbTipB);
            this.groupBox1.Controls.Add(this.rbTipA);
            this.groupBox1.Location = new System.Drawing.Point(12, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 54);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tip vozila";
            // 
            // rbTipC
            // 
            this.rbTipC.AutoSize = true;
            this.rbTipC.Location = new System.Drawing.Point(83, 20);
            this.rbTipC.Name = "rbTipC";
            this.rbTipC.Size = new System.Drawing.Size(32, 17);
            this.rbTipC.TabIndex = 2;
            this.rbTipC.Text = "C";
            this.rbTipC.UseVisualStyleBackColor = true;
            // 
            // rbTipB
            // 
            this.rbTipB.AutoSize = true;
            this.rbTipB.Checked = true;
            this.rbTipB.Location = new System.Drawing.Point(45, 19);
            this.rbTipB.Name = "rbTipB";
            this.rbTipB.Size = new System.Drawing.Size(32, 17);
            this.rbTipB.TabIndex = 1;
            this.rbTipB.TabStop = true;
            this.rbTipB.Text = "B";
            this.rbTipB.UseVisualStyleBackColor = true;
            // 
            // rbTipA
            // 
            this.rbTipA.AutoSize = true;
            this.rbTipA.Location = new System.Drawing.Point(7, 20);
            this.rbTipA.Name = "rbTipA";
            this.rbTipA.Size = new System.Drawing.Size(32, 17);
            this.rbTipA.TabIndex = 0;
            this.rbTipA.Text = "A";
            this.rbTipA.UseVisualStyleBackColor = true;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(202, 180);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(102, 23);
            this.btnCheck.TabIndex = 11;
            this.btnCheck.Text = "Pronđi parking";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Do";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(202, 209);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Sacuvaj";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(12, 209);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(102, 23);
            this.btnCancle.TabIndex = 16;
            this.btnCancle.Text = "Otkaži";
            this.btnCancle.UseVisualStyleBackColor = true;
            // 
            // tbTablica
            // 
            this.tbTablica.Location = new System.Drawing.Point(101, 136);
            this.tbTablica.MaxLength = 10;
            this.tbTablica.Name = "tbTablica";
            this.tbTablica.Size = new System.Drawing.Size(201, 20);
            this.tbTablica.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Registarski broj";
            // 
            // dtpDatum
            // 
            this.dtpDatum.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatum.Location = new System.Drawing.Point(59, 9);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(245, 20);
            this.dtpDatum.TabIndex = 19;
            // 
            // PojedinacnaKaricaForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 242);
            this.Controls.Add(this.dtpDatum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbTablica);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCheck);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PojedinacnaKaricaForma";
            this.Text = "PojedinacnaKaricaForma";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PojedinacnaKaricaForma_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbTipC;
        private System.Windows.Forms.RadioButton rbTipB;
        private System.Windows.Forms.RadioButton rbTipA;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.TextBox tbTablica;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDatum;
    }
}