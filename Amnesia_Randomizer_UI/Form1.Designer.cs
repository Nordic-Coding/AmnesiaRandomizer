namespace Amnesia_Randomizer_UI
{
    partial class Form1
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
            this.incTextures = new System.Windows.Forms.CheckBox();
            this.normalsSpecs = new System.Windows.Forms.CheckBox();
            this.userImag = new System.Windows.Forms.CheckBox();
            this.incSounds = new System.Windows.Forms.CheckBox();
            this.userSounds = new System.Windows.Forms.CheckBox();
            this.soundSnts = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.userManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tLDRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pLZHALPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incDiaries = new System.Windows.Forms.CheckBox();
            this.doMusic = new System.Windows.Forms.CheckBox();
            this.mixEntStat = new System.Windows.Forms.CheckBox();
            this.incMapMan = new System.Windows.Forms.CheckBox();
            this.mapManConfig = new System.Windows.Forms.Button();
            this.randConf = new System.Windows.Forms.Button();
            this.staticSwap = new System.Windows.Forms.CheckBox();
            this.randomizeButton = new System.Windows.Forms.Button();
            this.feedbackWindow = new System.Windows.Forms.TextBox();
            this.unrand = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.helperWindow = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // incTextures
            // 
            this.incTextures.AutoSize = true;
            this.incTextures.Location = new System.Drawing.Point(13, 27);
            this.incTextures.Name = "incTextures";
            this.incTextures.Size = new System.Drawing.Size(67, 17);
            this.incTextures.TabIndex = 0;
            this.incTextures.Text = "Textures";
            this.incTextures.UseVisualStyleBackColor = true;
            this.incTextures.MouseEnter += new System.EventHandler(this.incTextures_MouseEnter);
            this.incTextures.MouseLeave += new System.EventHandler(this.incTextures_MouseLeave);
            // 
            // normalsSpecs
            // 
            this.normalsSpecs.AutoSize = true;
            this.normalsSpecs.Location = new System.Drawing.Point(36, 50);
            this.normalsSpecs.Name = "normalsSpecs";
            this.normalsSpecs.Size = new System.Drawing.Size(82, 17);
            this.normalsSpecs.TabIndex = 1;
            this.normalsSpecs.Text = "norm/specs";
            this.normalsSpecs.UseVisualStyleBackColor = true;
            this.normalsSpecs.MouseEnter += new System.EventHandler(this.normalsSpecs_MouseEnter);
            this.normalsSpecs.MouseLeave += new System.EventHandler(this.normalsSpecs_MouseLeave);
            // 
            // userImag
            // 
            this.userImag.AutoSize = true;
            this.userImag.Location = new System.Drawing.Point(36, 73);
            this.userImag.Name = "userImag";
            this.userImag.Size = new System.Drawing.Size(84, 17);
            this.userImag.TabIndex = 2;
            this.userImag.Text = "User images";
            this.userImag.UseVisualStyleBackColor = true;
            this.userImag.MouseEnter += new System.EventHandler(this.userImag_MouseEnter);
            this.userImag.MouseLeave += new System.EventHandler(this.userImag_MouseLeave);
            // 
            // incSounds
            // 
            this.incSounds.AutoSize = true;
            this.incSounds.Location = new System.Drawing.Point(12, 121);
            this.incSounds.Name = "incSounds";
            this.incSounds.Size = new System.Drawing.Size(62, 17);
            this.incSounds.TabIndex = 3;
            this.incSounds.Text = "Sounds";
            this.incSounds.UseVisualStyleBackColor = true;
            this.incSounds.MouseEnter += new System.EventHandler(this.incSounds_MouseEnter);
            this.incSounds.MouseLeave += new System.EventHandler(this.incSounds_MouseLeave);
            // 
            // userSounds
            // 
            this.userSounds.AutoSize = true;
            this.userSounds.Location = new System.Drawing.Point(36, 144);
            this.userSounds.Name = "userSounds";
            this.userSounds.Size = new System.Drawing.Size(85, 17);
            this.userSounds.TabIndex = 4;
            this.userSounds.Text = "User sounds";
            this.userSounds.UseVisualStyleBackColor = true;
            this.userSounds.MouseEnter += new System.EventHandler(this.userSounds_MouseEnter);
            this.userSounds.MouseLeave += new System.EventHandler(this.userSounds_MouseLeave);
            // 
            // soundSnts
            // 
            this.soundSnts.AutoSize = true;
            this.soundSnts.Location = new System.Drawing.Point(36, 167);
            this.soundSnts.Name = "soundSnts";
            this.soundSnts.Size = new System.Drawing.Size(102, 17);
            this.soundSnts.TabIndex = 5;
            this.soundSnts.Text = "Scramble SNT\'s";
            this.soundSnts.UseVisualStyleBackColor = true;
            this.soundSnts.MouseEnter += new System.EventHandler(this.soundSnts_MouseEnter);
            this.soundSnts.MouseLeave += new System.EventHandler(this.soundSnts_MouseLeave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userManualToolStripMenuItem,
            this.backupToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(416, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // userManualToolStripMenuItem
            // 
            this.userManualToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tLDRToolStripMenuItem,
            this.pLZHALPToolStripMenuItem});
            this.userManualToolStripMenuItem.Name = "userManualToolStripMenuItem";
            this.userManualToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.userManualToolStripMenuItem.Text = "Information";
            // 
            // tLDRToolStripMenuItem
            // 
            this.tLDRToolStripMenuItem.Name = "tLDRToolStripMenuItem";
            this.tLDRToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tLDRToolStripMenuItem.Text = "TL;DR";
            this.tLDRToolStripMenuItem.Click += new System.EventHandler(this.tLDRToolStripMenuItem_Click);
            // 
            // pLZHALPToolStripMenuItem
            // 
            this.pLZHALPToolStripMenuItem.Name = "pLZHALPToolStripMenuItem";
            this.pLZHALPToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.pLZHALPToolStripMenuItem.Text = "PLZHALP";
            this.pLZHALPToolStripMenuItem.Click += new System.EventHandler(this.pLZHALPToolStripMenuItem_Click);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupToolStripMenuItem1,
            this.removeBackupToolStripMenuItem});
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.backupToolStripMenuItem.Text = "Backup options";
            // 
            // backupToolStripMenuItem1
            // 
            this.backupToolStripMenuItem1.Name = "backupToolStripMenuItem1";
            this.backupToolStripMenuItem1.Size = new System.Drawing.Size(159, 22);
            this.backupToolStripMenuItem1.Text = "Backup";
            this.backupToolStripMenuItem1.Click += new System.EventHandler(this.backupToolStripMenuItem1_Click);
            // 
            // removeBackupToolStripMenuItem
            // 
            this.removeBackupToolStripMenuItem.Name = "removeBackupToolStripMenuItem";
            this.removeBackupToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.removeBackupToolStripMenuItem.Text = "Remove backup";
            this.removeBackupToolStripMenuItem.Click += new System.EventHandler(this.removeBackupToolStripMenuItem_Click);
            // 
            // incDiaries
            // 
            this.incDiaries.AutoSize = true;
            this.incDiaries.Location = new System.Drawing.Point(12, 190);
            this.incDiaries.Name = "incDiaries";
            this.incDiaries.Size = new System.Drawing.Size(58, 17);
            this.incDiaries.TabIndex = 7;
            this.incDiaries.Text = "Diaries";
            this.incDiaries.UseVisualStyleBackColor = true;
            this.incDiaries.MouseEnter += new System.EventHandler(this.incDiaries_MouseEnter);
            this.incDiaries.MouseLeave += new System.EventHandler(this.incDiaries_MouseLeave);
            // 
            // doMusic
            // 
            this.doMusic.AutoSize = true;
            this.doMusic.Location = new System.Drawing.Point(12, 213);
            this.doMusic.Name = "doMusic";
            this.doMusic.Size = new System.Drawing.Size(54, 17);
            this.doMusic.TabIndex = 8;
            this.doMusic.Text = "Music";
            this.doMusic.UseVisualStyleBackColor = true;
            this.doMusic.MouseEnter += new System.EventHandler(this.doMusic_MouseEnter);
            this.doMusic.MouseLeave += new System.EventHandler(this.doMusic_MouseLeave);
            // 
            // mixEntStat
            // 
            this.mixEntStat.AutoSize = true;
            this.mixEntStat.Location = new System.Drawing.Point(36, 96);
            this.mixEntStat.Name = "mixEntStat";
            this.mixEntStat.Size = new System.Drawing.Size(133, 17);
            this.mixEntStat.TabIndex = 9;
            this.mixEntStat.Text = "Mix entities with statics";
            this.mixEntStat.UseVisualStyleBackColor = true;
            this.mixEntStat.MouseEnter += new System.EventHandler(this.mixEntStat_MouseEnter);
            this.mixEntStat.MouseLeave += new System.EventHandler(this.mixEntStat_MouseLeave);
            // 
            // incMapMan
            // 
            this.incMapMan.AutoSize = true;
            this.incMapMan.Location = new System.Drawing.Point(13, 237);
            this.incMapMan.Name = "incMapMan";
            this.incMapMan.Size = new System.Drawing.Size(109, 17);
            this.incMapMan.TabIndex = 10;
            this.incMapMan.Text = "Map-manipulation";
            this.incMapMan.UseVisualStyleBackColor = true;
            this.incMapMan.MouseEnter += new System.EventHandler(this.incMapMan_MouseEnter);
            this.incMapMan.MouseLeave += new System.EventHandler(this.incMapMan_MouseLeave);
            // 
            // mapManConfig
            // 
            this.mapManConfig.Location = new System.Drawing.Point(12, 286);
            this.mapManConfig.Name = "mapManConfig";
            this.mapManConfig.Size = new System.Drawing.Size(157, 23);
            this.mapManConfig.TabIndex = 11;
            this.mapManConfig.Text = "Configure Map-Manipulator";
            this.mapManConfig.UseVisualStyleBackColor = true;
            this.mapManConfig.Click += new System.EventHandler(this.mapManConfig_Click);
            this.mapManConfig.MouseEnter += new System.EventHandler(this.mapManConfig_MouseEnter);
            this.mapManConfig.MouseLeave += new System.EventHandler(this.mapManConfig_MouseLeave);
            // 
            // randConf
            // 
            this.randConf.Location = new System.Drawing.Point(13, 315);
            this.randConf.Name = "randConf";
            this.randConf.Size = new System.Drawing.Size(156, 23);
            this.randConf.TabIndex = 12;
            this.randConf.Text = "Configure randomization";
            this.randConf.UseVisualStyleBackColor = true;
            this.randConf.Click += new System.EventHandler(this.randConf_Click);
            this.randConf.MouseEnter += new System.EventHandler(this.randConf_MouseEnter);
            this.randConf.MouseLeave += new System.EventHandler(this.randConf_MouseLeave);
            // 
            // staticSwap
            // 
            this.staticSwap.AutoSize = true;
            this.staticSwap.Location = new System.Drawing.Point(36, 261);
            this.staticSwap.Name = "staticSwap";
            this.staticSwap.Size = new System.Drawing.Size(117, 17);
            this.staticSwap.TabIndex = 13;
            this.staticSwap.Text = "Swap static models";
            this.staticSwap.UseVisualStyleBackColor = true;
            this.staticSwap.MouseEnter += new System.EventHandler(this.staticSwap_MouseEnter);
            this.staticSwap.MouseLeave += new System.EventHandler(this.staticSwap_MouseLeave);
            // 
            // randomizeButton
            // 
            this.randomizeButton.Location = new System.Drawing.Point(176, 285);
            this.randomizeButton.Name = "randomizeButton";
            this.randomizeButton.Size = new System.Drawing.Size(228, 53);
            this.randomizeButton.TabIndex = 14;
            this.randomizeButton.Text = "Randomize!";
            this.randomizeButton.UseVisualStyleBackColor = true;
            this.randomizeButton.Click += new System.EventHandler(this.randomizeButton_Click);
            // 
            // feedbackWindow
            // 
            this.feedbackWindow.Location = new System.Drawing.Point(176, 121);
            this.feedbackWindow.Multiline = true;
            this.feedbackWindow.Name = "feedbackWindow";
            this.feedbackWindow.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.feedbackWindow.Size = new System.Drawing.Size(228, 61);
            this.feedbackWindow.TabIndex = 15;
            // 
            // unrand
            // 
            this.unrand.Location = new System.Drawing.Point(176, 226);
            this.unrand.Name = "unrand";
            this.unrand.Size = new System.Drawing.Size(228, 53);
            this.unrand.TabIndex = 16;
            this.unrand.Text = "Unrandomize";
            this.unrand.UseVisualStyleBackColor = true;
            this.unrand.Click += new System.EventHandler(this.unrand_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Helper window";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(176, 197);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(228, 23);
            this.progressBar.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Execution information";
            // 
            // helperWindow
            // 
            this.helperWindow.Location = new System.Drawing.Point(178, 41);
            this.helperWindow.Multiline = true;
            this.helperWindow.Name = "helperWindow";
            this.helperWindow.Size = new System.Drawing.Size(226, 61);
            this.helperWindow.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 350);
            this.Controls.Add(this.helperWindow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.unrand);
            this.Controls.Add(this.feedbackWindow);
            this.Controls.Add(this.randomizeButton);
            this.Controls.Add(this.staticSwap);
            this.Controls.Add(this.randConf);
            this.Controls.Add(this.mapManConfig);
            this.Controls.Add(this.incMapMan);
            this.Controls.Add(this.mixEntStat);
            this.Controls.Add(this.doMusic);
            this.Controls.Add(this.incDiaries);
            this.Controls.Add(this.soundSnts);
            this.Controls.Add(this.userSounds);
            this.Controls.Add(this.incSounds);
            this.Controls.Add(this.userImag);
            this.Controls.Add(this.normalsSpecs);
            this.Controls.Add(this.incTextures);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Amnesia Randomizer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox incTextures;
        private System.Windows.Forms.CheckBox normalsSpecs;
        private System.Windows.Forms.CheckBox userImag;
        private System.Windows.Forms.CheckBox incSounds;
        private System.Windows.Forms.CheckBox userSounds;
        private System.Windows.Forms.CheckBox soundSnts;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem userManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tLDRToolStripMenuItem;
        private System.Windows.Forms.CheckBox incDiaries;
        private System.Windows.Forms.CheckBox doMusic;
        private System.Windows.Forms.CheckBox mixEntStat;
        private System.Windows.Forms.CheckBox incMapMan;
        private System.Windows.Forms.Button mapManConfig;
        private System.Windows.Forms.Button randConf;
        private System.Windows.Forms.CheckBox staticSwap;
        private System.Windows.Forms.Button randomizeButton;
        private System.Windows.Forms.TextBox feedbackWindow;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem removeBackupToolStripMenuItem;
        private System.Windows.Forms.Button unrand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem pLZHALPToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox helperWindow;
    }
}

