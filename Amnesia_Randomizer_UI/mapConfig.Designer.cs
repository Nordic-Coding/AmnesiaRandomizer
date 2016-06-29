namespace Amnesia_Randomizer_UI
{
    partial class mapConfig
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
            this.scaleNumber = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.rotationNumber = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.translationNumber = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.scaleNumberE = new System.Windows.Forms.NumericUpDown();
            this.rotationNumberE = new System.Windows.Forms.NumericUpDown();
            this.translationNumberE = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scaleNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotationNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.translationNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleNumberE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotationNumberE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.translationNumberE)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scaling force";
            // 
            // scaleNumber
            // 
            this.scaleNumber.Location = new System.Drawing.Point(16, 30);
            this.scaleNumber.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.scaleNumber.Name = "scaleNumber";
            this.scaleNumber.Size = new System.Drawing.Size(66, 20);
            this.scaleNumber.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rotation force";
            // 
            // rotationNumber
            // 
            this.rotationNumber.Location = new System.Drawing.Point(88, 30);
            this.rotationNumber.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.rotationNumber.Name = "rotationNumber";
            this.rotationNumber.Size = new System.Drawing.Size(66, 20);
            this.rotationNumber.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(157, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Translation force";
            // 
            // translationNumber
            // 
            this.translationNumber.Location = new System.Drawing.Point(160, 30);
            this.translationNumber.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.translationNumber.Name = "translationNumber";
            this.translationNumber.Size = new System.Drawing.Size(66, 20);
            this.translationNumber.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Save and close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(232, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Statics";
            // 
            // scaleNumberE
            // 
            this.scaleNumberE.Location = new System.Drawing.Point(16, 57);
            this.scaleNumberE.Name = "scaleNumberE";
            this.scaleNumberE.Size = new System.Drawing.Size(66, 20);
            this.scaleNumberE.TabIndex = 8;
            // 
            // rotationNumberE
            // 
            this.rotationNumberE.Location = new System.Drawing.Point(89, 56);
            this.rotationNumberE.Name = "rotationNumberE";
            this.rotationNumberE.Size = new System.Drawing.Size(65, 20);
            this.rotationNumberE.TabIndex = 9;
            // 
            // translationNumberE
            // 
            this.translationNumberE.Location = new System.Drawing.Point(161, 56);
            this.translationNumberE.Name = "translationNumberE";
            this.translationNumberE.Size = new System.Drawing.Size(65, 20);
            this.translationNumberE.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(233, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Entities";
            // 
            // mapConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 115);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.translationNumberE);
            this.Controls.Add(this.rotationNumberE);
            this.Controls.Add(this.scaleNumberE);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.translationNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rotationNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.scaleNumber);
            this.Controls.Add(this.label1);
            this.Name = "mapConfig";
            this.Text = "mapConfig";
            ((System.ComponentModel.ISupportInitialize)(this.scaleNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotationNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.translationNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleNumberE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotationNumberE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.translationNumberE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown scaleNumber;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown rotationNumber;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.NumericUpDown translationNumber;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.NumericUpDown scaleNumberE;
        public System.Windows.Forms.NumericUpDown rotationNumberE;
        public System.Windows.Forms.NumericUpDown translationNumberE;
        private System.Windows.Forms.Label label5;
    }
}