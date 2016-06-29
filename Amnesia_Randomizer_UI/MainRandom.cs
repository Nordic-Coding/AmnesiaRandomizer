using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amnesia_Randomizer_UI
{
    class MainRandom
    {
        //All public variables.


        //Accept user input.
        public bool isNormals;
        public bool doSounds;
        public bool doSnt;
        public bool doTextures;
        public bool doMusic;
        public bool doDiaries;
        public bool doStatics;
        public bool doUserImag;
        public bool doUserSounds;
        public bool mixItUp;
        public bool doMaps;
        public bool changeModels;

        public float scaleForce;
        public float rotForce;
        public float transForce;

        public float scaleForceE;
        public float rotForceE;
        public float transForceE;

        public int rL,uLt,uLs;

        public MainRandom()
        {

            //Accept user input.
            isNormals = false;
            doSounds = false;
            doSnt = true;
            doTextures = false;
            doMusic = false;
            doDiaries = false;
            doStatics = false;
            doUserImag = false;
            doUserSounds = false;
            mixItUp = false;
            doMaps = false;
            changeModels = false;

            scaleForce = 0f;
            rotForce = 0f;
            transForce = 0f;

            rL = 0;
            uLt = 0;
            uLs = 0;

        }


        public void run(ProgressBar pbar)
        {
            /*
             * This program when exectued finds all dds and sound files in the sub-folders entities, sounds & 
             * such stuff and then mixes them up a specified amount of times.
             */

            //The different files.
            List<String> soundFiles = new List<String>();
            List<String> entFiles = new List<String>();
            List<String> musicFiles = new List<String>();
            List<String> staticFiles = new List<String>();
            List<String> diaryFiles = new List<String>();
            List<String> userContent = new List<String>();
            List<String> userFilesTextures = new List<String>();
            List<String> userFilesSounds = new List<String>();
            List<String> mapFiles = new List<String>();

            //User input is replaced with the UI.
            pbar.Value = 1;

            //Create the filefinder.
            fileFinder _fileFinder = new fileFinder();

            //Find the current working directory.
            string mainDir = System.IO.Directory.GetCurrentDirectory();
            string finalDir = Path.GetDirectoryName(mainDir);


            //Find all files.
            soundFiles = _fileFinder.DirSearch(finalDir+"/sounds");
            entFiles = _fileFinder.DirSearch(finalDir + "/entities");
            staticFiles = _fileFinder.DirSearch(finalDir + "/static_objects");
            musicFiles = _fileFinder.DirSearch(finalDir + "/music");
            diaryFiles = _fileFinder.DirSearch(finalDir + "/lang");
            userContent = _fileFinder.DirSearch(mainDir + "/custom_content");
            mapFiles = _fileFinder.DirSearch(finalDir + "/maps");

            pbar.Value = 10;

            Console.WriteLine("Converting files in custom_content folder, might take som time.");

            #region converter
            //Convert all the userContent into userFiles.
            Converter converter = new Converter();

            //This will have to wait for some time.
            int progressCount = 0;
            foreach(string element in userContent)
            {
                progressCount++;

                string temp = null;

                pbar.Value = 10 + (int)(30f * (float) progressCount / (float)userContent.Count);

                //Assuming that all files have an ending.
                if (doUserImag)
                {
                    switch (element.Split('.')[1])
                    {

                        case "png":
                            temp = converter.convertPNG(element);

                            if (temp != null)
                            {
                                userFilesTextures.Add(temp);
                            }
                            break;

                        case "jpg":
                            temp = converter.convertJPG(element);

                            if (temp != null)
                            {
                                userFilesTextures.Add(temp);
                            }
                            break;

                        case "jpeg":
                            temp = converter.convertJPEG(element);

                            if (temp != null)
                            {
                                userFilesTextures.Add(temp);
                            }
                            break;

                        case "dds":
                            //Add directly to the userFiles list
                            userFilesTextures.Add(element);
                            break;
                    }
                }

                if (doUserSounds)
                {
                    switch (element.Split('.')[1])
                    {
                        case "wav":
                            //Do wave to ogg conversion, not implemented yet.
                            break;

                        case "mp3":
                            //Do mp3 to ogg conversion, not implemented yet.
                            break;

                        case "ogg":
                            //Add directly to the userFiles list
                            userFilesSounds.Add(element);
                            break;
                    }
                }
            }

            #endregion

            pbar.Value = 40;

            #region PrintPart


            //Write everything out so it looks cool n stuff.
            /*
            foreach(string element in soundFiles)
            {
                Console.WriteLine(element);
            }

            foreach (string element in entFiles)
            {
                Console.WriteLine(element);
            }

            foreach (string element in musicFiles)
            {
                Console.WriteLine(element);
            }

            foreach (string element in staticFiles)
            {
                Console.WriteLine(element);
            }

            foreach (string element in diaryFiles)
            {
                Console.WriteLine(element);
            }

            foreach (string element in userContent)
            {
                Console.WriteLine(element);
            }

            foreach (string element in mapFiles)
            {
                Console.WriteLine(element);
            }*/



            #endregion

            //Create the randomisation.
            Random random = new Random();

            //Initialize the fileswapper object.
            fileSwapper _fileSwapper = new fileSwapper();

            #region swapping

            //Swap sounds.
            if (doSounds)
            {
                for (int i = 0; i < rL; i++)
                {
                    int obj1 = random.Next(soundFiles.Count);
                    int obj2 = random.Next(soundFiles.Count);

                    if (doSnt)
                    {
                        if (obj1 != obj2)
                        {
                            if (!_fileSwapper.swapFile(soundFiles[obj1], soundFiles[obj2], false)) //Always false for sounds.
                            {
                                //Dont progress since a swap hasn't been performed.
                                i--;
                            }
                        }
                    }
                    else
                    {
                        if (obj1 != obj2)
                        {
                            if(soundFiles[obj1].Split('.')[1] != "snt" && soundFiles[obj2].Split('.')[1] != "snt")
                            {
                                if (!_fileSwapper.swapFile(soundFiles[obj1], soundFiles[obj2], false)) //Always false for sounds.
                                {
                                    //Dont progress since a swap hasn't been performed.
                                    i--;
                                }
                            }
                               
                        }
                    }
                }
            }

            pbar.Value = 60;

            //Swap textures.
            if (doTextures)
            {
                for (int i = 0; i < rL; i++)
                {
                    //Just take random, you'll hit combinations of .dds textures... sometimes... like one in 16 (2^4) times, close enough i guess.
                    int obj1 = random.Next(entFiles.Count);
                    int obj2 = random.Next(entFiles.Count);

                    if (obj1 != obj2)
                    {
                        //Make sure that you are not swapping anything but textures.
                        if (isEnding(entFiles[obj1], "dds") && isEnding(entFiles[obj2], "dds"))
                        {
                            if (!_fileSwapper.swapFile(entFiles[obj1], entFiles[obj2], !isNormals))
                            {
                                //Dont progress since a swap hasn't been performed.
                                i--;
                            }
                        }
                        else
                        {
                            i--;
                        }

                    }
                }
            }

            //Swap static textures.
            if (doStatics)
            {
                for (int i = 0; i < rL; i++)
                {
                    //Just take random, you'll hit combinations of .dds textures... sometimes... like one in 16 (2^4) times, close enough i guess.
                    int obj1 = random.Next(staticFiles.Count);
                    int obj2 = random.Next(staticFiles.Count);

                    if (obj1 != obj2)
                    {
                        //Make sure that you are not swapping anything but textures.
                        if (isEnding(staticFiles[obj1], "dds") && isEnding(staticFiles[obj2], "dds"))
                        {
                            if (!_fileSwapper.swapFile(staticFiles[obj1], staticFiles[obj2], !isNormals))
                            {
                                //Dont progress since a swap hasn't been performed.
                                i--;
                            }
                        }
                        else
                        {
                            //Dont progress since a swap hasn't been performed.
                            i--;
                        }

                    }
                }
            }

            pbar.Value = 70;

            //Swap music.
            if (doMusic)
            {
                for (int i = 0; i < rL; i++)
                {
                    //Just take random, you'll hit combinations of .dds textures... sometimes... like one in 16 (2^4) times, close enough i guess.
                    int obj1 = random.Next(musicFiles.Count);
                    int obj2 = random.Next(musicFiles.Count);

                    if (obj1 != obj2)
                    {
                        if (!_fileSwapper.swapFile(musicFiles[obj1], musicFiles[obj2], false))
                        {
                            //Dont progress since a swap hasn't been performed.
                            i--;
                        }
                    }
                }
            }

            //Swap diaries.
            if (doDiaries)
            {
                for (int i = 0; i < rL; i++)
                {
                    //Just take random, you'll hit combinations of .dds textures... sometimes... like one in 16 (2^4) times, close enough i guess.
                    int obj1 = random.Next(diaryFiles.Count);
                    int obj2 = random.Next(diaryFiles.Count);

                    if (obj1 != obj2)
                    {
                        if (!_fileSwapper.swapFile(diaryFiles[obj1], diaryFiles[obj2], false))
                        {
                            //Dont progress since a swap hasn't been performed.
                            i--;
                        }
                    }
                }
            }

            pbar.Value = 80;

            //Mix diaries and music, entities and statics.
            if (mixItUp)
            {
                //Diaries and music
                for (int i = 0; i < rL; i++)
                {
                    int obj1 = random.Next(musicFiles.Count);
                    int obj2 = random.Next(diaryFiles.Count);

                    if (!_fileSwapper.swapFile(musicFiles[obj1], diaryFiles[obj2], false))
                    {
                        //Dont progress since a swap hasn't been performed.
                        i--;
                    }
                }

                //Entities and statics.
                for (int i = 0; i < rL; i++)
                {
                    int obj1 = random.Next(entFiles.Count);
                    int obj2 = random.Next(staticFiles.Count);

                    //Make sure that you are not swapping anything but textures.
                    if (isEnding(entFiles[obj1], "dds") && isEnding(staticFiles[obj2], "dds"))
                    {
                        if (!_fileSwapper.swapFile(entFiles[obj1], staticFiles[obj2], !isNormals))
                        {
                            //Dont progress since a swap hasn't been performed.
                            i--;
                        }
                    }
                    else
                    {
                        //Dont progress since a swap hasn't been performed.
                        i--;
                    }
                }
            }

            if (doUserSounds)
            {

                //First splice in the sounds.
                if (userFilesSounds.Count > 0)
                {
                    for (int i = 0; i < uLs; i++)
                    {

                        int obj1 = random.Next(userFilesSounds.Count);
                        int obj2 = random.Next(soundFiles.Count);

                        if (!_fileSwapper.swapFileOneWay(userFilesSounds[obj1], soundFiles[obj2], false))
                        {
                            //Dont progress since a swap hasn't been performed.
                            i--;
                        }
                    }
                }
            }

            pbar.Value = 90;

            if (doUserImag)
            {
                //Now some textures, entities first.
                if (userFilesTextures.Count > 0)
                {
                    for (int i = 0; i < uLt; i++)
                    {
                        int obj1 = random.Next(userFilesTextures.Count);
                        int obj2 = random.Next(entFiles.Count);

                        if (!_fileSwapper.swapFileOneWay(userFilesTextures[obj1], entFiles[obj2], !isNormals))
                        {
                            //Dont progress since a swap hasn't been performed.
                            i--;
                        }
                    }
                }

                //Then statics.
                if (userFilesTextures.Count > 0)
                {
                    for (int i = 0; i < uLt; i++)
                    {
                        int obj1 = random.Next(userFilesTextures.Count);
                        int obj2 = random.Next(staticFiles.Count);

                        if (!_fileSwapper.swapFileOneWay(userFilesTextures[obj1], staticFiles[obj2], !isNormals))
                        {
                            //Dont progress since a swap hasn't been performed.
                            i--;
                        }
                    }
                }
            }

            #endregion

            #region mapManipulation

            if (doMaps)
            {
                mapManipulator _mapManipulator = new mapManipulator();

                //Manipulate all maps
                foreach (string element in mapFiles)
                {
                    if (element.Split('.')[1] == "map")
                    {
                        _mapManipulator.manipulateMap(element,scaleForce,transForce,rotForce, scaleForceE, transForceE, rotForceE, changeModels);
                        Console.WriteLine("Manipulated: " + element);
                    }
                    else if(element.Split('.')[1] == "map_cache")
                    {
                        File.Delete(element);
                        Console.WriteLine("Deleted: " + element);
                    }

                }
            }

            pbar.Value = 95;

            #endregion

            #region cleanUp

            //Simply delete all the created user content.

            Console.WriteLine("Deleting" + (userFilesTextures.Count) + "temporary user files.");

            foreach (string element in userFilesTextures)
            {
                System.IO.File.Delete(element);
            }

            #endregion

            Console.WriteLine("");

            Console.WriteLine("Done randomizing! You can start amnesia and leave this program on");

        }

        static bool isEnding(string file, string type)
        {
            string[] temp = file.Split('.');

            if(temp[1] == type)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool removeBackup()
        {
            //Find the current working directory.
            string mainDir = System.IO.Directory.GetCurrentDirectory();

            //Delete all the directories
            System.IO.Directory.Delete(mainDir + "/backup/sounds", true);
            System.IO.Directory.Delete(mainDir + "/backup/entities", true);
            System.IO.Directory.Delete(mainDir + "/backup/static_objects", true);
            System.IO.Directory.Delete(mainDir + "/backup/music", true);
            System.IO.Directory.Delete(mainDir + "/backup/lang", true);
            System.IO.Directory.Delete(mainDir + "/backup/maps", true);

            return true;
        }

        public bool backup(ProgressBar pbar)
        {

            //Find the current working directory.
            string mainDir = System.IO.Directory.GetCurrentDirectory();
            string finalDir = Path.GetDirectoryName(mainDir);

            //Not necessary to find all files, just copy the directories.
            DirectoryCopy(finalDir + "/sounds", mainDir + "/backup/sounds",true);

            pbar.Value = 14;
            Console.Write("\r");
            Console.Write("Finished sounds");

            DirectoryCopy(finalDir + "/entities", mainDir + "/backup/entities", true);

            pbar.Value = 34;
            Console.Write("\r");
            Console.Write("Finished entities");

            DirectoryCopy(finalDir + "/static_objects", mainDir + "/backup/static_objects", true);

            pbar.Value = 64;
            Console.Write("\r");
            Console.Write("Finished static objects");

            DirectoryCopy(finalDir + "/music", mainDir + "/backup/music", true);

            pbar.Value = 74;
            Console.Write("\r");
            Console.Write("Finished music");

            DirectoryCopy(finalDir + "/lang", mainDir + "/backup/lang", true);

            pbar.Value = 84;
            Console.Write("\r");
            Console.Write("Finished lang");

            DirectoryCopy(finalDir + "/maps", mainDir + "/backup/maps", true);

            return true;
        }

        public bool unScramble(ProgressBar pbar)
        {

            //Find the current working directory.
            string mainDir = System.IO.Directory.GetCurrentDirectory();
            string finalDir = Path.GetDirectoryName(mainDir);

            //Not necessary to find all files, just copy the directories.
            DirectoryCopy(mainDir + "/backup/sounds", finalDir + "/sounds", true);

            pbar.Value = 14;
            Console.Write("\r");
            Console.Write("Finished sounds");

            DirectoryCopy(mainDir + "/backup/entities", finalDir + "/entities", true);

            pbar.Value = 34;
            Console.Write("\r");
            Console.Write("Finished entities");

            DirectoryCopy(mainDir + "/backup/static_objects", finalDir + "/static_objects", true);

            pbar.Value = 64;
            Console.Write("\r");
            Console.Write("Finished static objects");

            DirectoryCopy(mainDir + "/backup/music", finalDir + "/music", true);

            pbar.Value = 74;
            Console.Write("\r");
            Console.Write("Finished music");

            DirectoryCopy(mainDir + "/backup/lang", finalDir + "/lang", true);

            pbar.Value = 84;
            Console.Write("\r");
            Console.Write("Finished lang");

            DirectoryCopy(mainDir + "/backup/maps", finalDir + "/maps", true);

            return true;
        }

        //Taken directly from https://msdn.microsoft.com/en-us/library/bb762914(v=vs.110).aspx
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }



        public static string reconstructor(string[] splitted, char splitArg)
        {

            string returner = "";

            for (int i = 0; i < splitted.Length - 1; i++)
            {
                //TODO not sure if right way...?
                returner = returner + splitted[i] + splitArg.ToString();
            }

            returner = returner + splitted[splitted.Length - 1];

            return returner;

        }
    }
}
