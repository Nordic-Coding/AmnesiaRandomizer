namespace Amnesia_Randomizer_UI
{
    partial class randConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.randLevel = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.textureLevel = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.soundLevel = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.randLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textureLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Randomization level";
            // 
            // randLevel
            // 
            this.randLevel.Location = new System.Drawing.Point(13, 30);
            this.randLevel.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.randLevel.Name = "randLevel";
            this.randLevel.Size = new System.Drawing.Size(102, 20);
            this.randLevel.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "User textures blend";
            // 
            // textureLevel
            // 
            this.textureLevel.Location = new System.Drawing.Point(124, 29);
            this.textureLevel.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.textureLevel.Name = "textureLevel";
            this.textureLevel.Size = new System.Drawing.Size(95, 20);
            this.textureLevel.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "User sounds blend";
            // 
            // soundLevel
            // 
            this.soundLevel.Location = new System.Drawing.Point(229, 28);
            this.soundLevel.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.soundLevel.Name = "soundLevel";
            this.soundLevel.Size = new System.Drawing.Size(92, 20);
            this.soundLevel.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(317, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Save and close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // randConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 85);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.soundLevel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textureLevel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.randLevel);
            this.Controls.Add(this.label1);
            this.Name = "randConfig";
            this.Text = "randConfig";
            this.Load += new System.EventHandler(this.randConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.randLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textureLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown randLevel;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown textureLevel;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.NumericUpDown soundLevel;
        private System.Windows.Forms.Button button1;
    }
}