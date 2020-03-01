namespace Garaza
{
    partial class ParkiranjePretplatneKartice
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
            this.numId = new System.Windows.Forms.NumericUpDown();
            this.btnLoadCard = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numId)).BeginInit();
            this.SuspendLayout();
            // 
            // numId
            // 
            this.numId.Location = new System.Drawing.Point(13, 13);
            this.numId.Maximum = new decimal(new int[] {
            -1294967296,
            0,
            0,
            0});
            this.numId.Name = "numId";
            this.numId.Size = new System.Drawing.Size(217, 20);
            this.numId.TabIndex = 0;
            // 
            // btnLoadCard
            // 
            this.btnLoadCard.Location = new System.Drawing.Point(237, 9);
            this.btnLoadCard.Name = "btnLoadCard";
            this.btnLoadCard.Size = new System.Drawing.Size(141, 23);
            this.btnLoadCard.TabIndex = 1;
            this.btnLoadCard.Text = "Izaberi";
            this.btnLoadCard.UseVisualStyleBackColor = true;
            this.btnLoadCard.Click += new System.EventHandler(this.btnLoadCard_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(13, 168);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(141, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Sačuvaj";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 54);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(366, 95);
            this.listBox1.TabIndex = 4;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // ParkiranjePretplatneKartice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 204);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoadCard);
            this.Controls.Add(this.numId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ParkiranjePretplatneKartice";
            this.Text = "ParkiranjePretplatneKartice";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ParkiranjePretplatneKartice_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numId)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numId;
        private System.Windows.Forms.Button btnLoadCard;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListBox listBox1;
    }
}