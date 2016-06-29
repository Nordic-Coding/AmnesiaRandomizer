using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Amnesia_Randomizer_UI
{
    public partial class Form1 : Form
    {
        //This class has two subforms.
        randConfig _randConfig;
        mapConfig _mapConfig;
        MainRandom _mainRandom;
        bool backup;
        bool working;

        public Form1()
        {
            InitializeComponent();

            //Disable resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            //Set so that the randomization can only be done if the backup has been carried out.
            System.IO.StreamReader file = new System.IO.StreamReader("backup/backup.state");

            working = false;

            string line = file.ReadLine();
            
            if(line == "backup")
            {
                backup = true;
            }
            else
            {
                backup = false;
                feedbackWindow.Text = "Perform a backup before randomizing, see toolbar above.";
            }

            //Close the file and delete it.
            file.Close();
            file.Dispose();

            //Initialize the other forms.
            _randConfig = new randConfig();
            _mapConfig = new mapConfig();

            //Initialize the randomizer.
            _mainRandom = new MainRandom();

        }

        private void mapManConfig_Click(object sender, EventArgs e)
        {
            _mapConfig.ShowDialog();
        }

        private void randConf_Click(object sender, EventArgs e)
        {
            _randConfig.ShowDialog();
        }

        private void theFullVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        void randomize()
        {
            if (backup)
            {
                //First all the checkboxes.
                _mainRandom.doTextures = incTextures.Checked;
                _mainRandom.isNormals = !incTextures.Checked;
                _mainRandom.doUserImag = userImag.Checked;
                _mainRandom.mixItUp = mixEntStat.Checked;
                _mainRandom.doSounds = incSounds.Checked;
                _mainRandom.doUserSounds = userSounds.Checked;
                _mainRandom.doSnt = soundSnts.Checked;
                _mainRandom.doDiaries = incDiaries.Checked;
                _mainRandom.doMusic = doMusic.Checked;
                _mainRandom.doMaps = incMapMan.Checked;
                _mainRandom.changeModels = staticSwap.Checked;

                //Now set the values for the randomizer.
                _mainRandom.rL = Convert.ToInt32(_randConfig.randLevel.Value);
                _mainRandom.uLs = Convert.ToInt32(_randConfig.soundLevel.Value);
                _mainRandom.uLt = Convert.ToInt32(_randConfig.textureLevel.Value);

                //And the values for the map-manipulator.
                _mainRandom.rotForce = (float)Convert.ToInt32(_mapConfig.rotationNumber.Value) / 100f;
                _mainRandom.scaleForce = (float)Convert.ToInt32(_mapConfig.scaleNumber.Value) / 100f;
                _mainRandom.transForce = (float)Convert.ToInt32(_mapConfig.translationNumber.Value) / 100f;

                //And the values for the map-manipulator with the entities.
                _mainRandom.rotForceE = (float)Convert.ToInt32(_mapConfig.rotationNumberE.Value) / 100f;
                _mainRandom.scaleForceE = (float)Convert.ToInt32(_mapConfig.scaleNumberE.Value) / 100f;
                _mainRandom.transForceE = (float)Convert.ToInt32(_mapConfig.translationNumberE.Value) / 100f;

                //Now fire the main randomizer.
                _mainRandom.run(progressBar);

                //Give text hint.
                feedbackWindow.Text = "Done randomizing! You can start amnesia and leave this program on.";
                progressBar.Value = 0;
            }
            else
            {
                feedbackWindow.Text = "Perform a backup before randomizing, see toolbar above.";
            }

            working = false;
        }

        #region threadfiles

        void backUp()
        {
            if (!backup)
            {
                Console.WriteLine("Performing backup, might take a minute.");
                feedbackWindow.Text = "Performing backup, might take a minute.";
                if (_mainRandom.backup(progressBar))
                {
                    feedbackWindow.Text = "Backup created.";
                    Console.WriteLine("Backup created.");
                    System.IO.File.WriteAllLines(System.IO.Directory.GetCurrentDirectory() + "/backup/backup.state", new string[] { "backup" });
                    progressBar.Value = 0;
                    backup = true;
                }
                else
                {
                    feedbackWindow.Text = "Backup failed.";
                }
            }
            else
            {
                feedbackWindow.Text = "There already exists a backup! If you manually deleted the files then delete the content of the backup.state file.";
            }

            working = false;
        }

        void removeBackUp()
        {
            if (!backup)
            {
                feedbackWindow.Text = "There does not seem to exist a backup? If this is not the case then it is safe to remove the files manually.";
            }
            else
            {
                feedbackWindow.Text = "Removing backup files...";

                if (_mainRandom.removeBackup())
                {
                    feedbackWindow.Text = "Backup removed.";
                    System.IO.File.WriteAllLines(System.IO.Directory.GetCurrentDirectory() + "/backup/backup.state", new string[] { "" });
                    backup = false;
                }
                else
                {
                    feedbackWindow.Text = "Failed to remove backup..";
                }
            }

            working = false;
        }

        void unRand()
        {
            if (backup)
            {
                feedbackWindow.Text = "Copying backup files into amnesia folder.";

                if (_mainRandom.unScramble(progressBar))
                {
                    Console.WriteLine("Files copied back into amnesia folder.");
                    feedbackWindow.Text = "Files copied back into amnesia folder.";
                    progressBar.Value = 0;
                }
                else
                {
                    feedbackWindow.Text = "Failed with copying files for some reason?";
                }

            }
            else
            {
                feedbackWindow.Text = "No backup exists.";
            }

            working = false;
        }

        #endregion

        #region buttonHandlers

        private void randomizeButton_Click(object sender, EventArgs e)
        {
            if (!working)
            {
                working = true;
                Thread t = new Thread(new ThreadStart(randomize));
                t.IsBackground = true;
                t.Start();
            }
        }

        private void backupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!working)
            {
                working = true;
                Thread t = new Thread(new ThreadStart(backUp));
                t.IsBackground = true;
                t.Start();
            }
        }



        private void removeBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!working)
            {
                working = true;
                Thread t = new Thread(new ThreadStart(removeBackUp));
                t.IsBackground = true;
                t.Start();
            }
        }

        private void unrand_Click(object sender, EventArgs e)
        {
            if (!working)
            {
                working = true;
                Thread t = new Thread(new ThreadStart(unRand));
                t.IsBackground = true;
                t.Start();
            }
        }

        private void pLZHALPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.frictionalgames.com/forum/thread-45660.html");
        }

        #endregion

        #region mouseOverHints


        #endregion

        private void incTextures_MouseEnter(object sender, EventArgs e)
        {
            helperWindow.Text = "Randomize textures.";
        }

        private void normalsSpecs_MouseEnter(object sender, EventArgs e)
        {
            helperWindow.Text = "Include normals and specs in the randomizing, (looks horrible.).";
        }

        private void userImag_MouseEnter(object sender, EventArgs e)
        {
            helperWindow.Text = "Include user supplied .png, .jpg and .jpeg files in the randomization.";
        }

        private void mixEntStat_MouseEnter(object sender, EventArgs e)
        {
            helperWindow.Text = "Mix textures from static objects with those of entities.";
        }

        private void incSounds_MouseEnter(object sender, EventArgs e)
        {
            helperWindow.Text = "Include sounds in the randomization.";
        }

        private void userSounds_MouseEnter(object sender, EventArgs e)
        {
            helperWindow.Text = "Mix user sounds, only .ogg format currently compatible.";
        }

        private void soundSnts_MouseEnter(object sender, EventArgs e)
        {
            helperWindow.Text = "Affects in what manner the sound is supposed to be playbacked in game, i would recommend not scrambling these.";
        }

        private void incDiaries_MouseEnter(object sender, EventArgs e)
        {
            helperWindow.Text = "Randomize diaries?";
        }

        private void doMusic_MouseEnter(object sender, EventArgs e)
        {
            helperWindow.Text = "Randomize music?";
        }

        private void incMapMan_MouseEnter(object sender, EventArgs e)
        {
            helperWindow.Text = "Do map-manipulation, that is translate, offset and scale objects within the .map-files randomly. The factors are set at the Configure Map-Manipulator submenu.";
        }

        private void staticSwap_MouseEnter(object sender, EventArgs e)
        {
            helperWindow.Text = "Swap static objects in the map-files, this is as gamebreaking as it is hilarious.";
        }

        private void incTextures_MouseLeave(object sender, EventArgs e)
        {
            helperWindow.Text = "";
        }

        private void normalsSpecs_MouseLeave(object sender, EventArgs e)
        {
            helperWindow.Text = "";
        }

        private void userImag_MouseLeave(object sender, EventArgs e)
        {
            helperWindow.Text = "";
        }

        private void mixEntStat_MouseLeave(object sender, EventArgs e)
        {
            helperWindow.Text = "";
        }

        private void incSounds_MouseLeave(object sender, EventArgs e)
        {
            helperWindow.Text = "";
        }

        private void userSounds_MouseLeave(object sender, EventArgs e)
        {
            helperWindow.Text = "";
        }

        private void soundSnts_MouseLeave(object sender, EventArgs e)
        {
            helperWindow.Text = "";
        }

        private void incDiaries_MouseLeave(object sender, EventArgs e)
        {
            helperWindow.Text = "";
        }

        private void doMusic_MouseLeave(object sender, EventArgs e)
        {
            helperWindow.Text = "";
        }

        private void incMapMan_MouseLeave(object sender, EventArgs e)
        {
            helperWindow.Text = "";
        }

        private void staticSwap_MouseLeave(object sender, EventArgs e)
        {
            helperWindow.Text = "";
        }

        private void tLDRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=_Ha2uJxRDUU&feature=youtu.be");
        }

        private void mapManConfig_MouseEnter(object sender, EventArgs e)
        {
            helperWindow.Text = "Recommended values are between 1 and 20.";
        }

        private void randConf_MouseEnter(object sender, EventArgs e)
        {
            helperWindow.Text = "Recommended values are between 100 and 5000.";
        }

        private void mapManConfig_MouseLeave(object sender, EventArgs e)
        {
            helperWindow.Text = "";
        }

        private void randConf_MouseLeave(object sender, EventArgs e)
        {
            helperWindow.Text = "";
        }
    }
}
