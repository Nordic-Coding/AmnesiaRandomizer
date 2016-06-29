using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Amnesia_Randomizer_UI
{
    class mapManipulator
    {
        public mapManipulator()
        {
            //Nothing now
        }

        public void manipulateMap(string path, float scaleForce, float translationForce, float rotationForce, float scaleForceE, float translationForceE, float rotationForceE, bool doSwapping)
        {

            #region fileReading

            //Read the file into a string array.
            string[] mapFile = null;
            string line;
            int counter = 0;

            System.IO.StreamReader file = new System.IO.StreamReader(path);

            while ((line = file.ReadLine()) != null)
            {
                counter++;
            }

            //Close the file and delete it, no more reading will be done.
            file.Close();
            file.Dispose();

            mapFile = new string[counter];

            counter = 0;
            file = new System.IO.StreamReader(path);

            while ((line = file.ReadLine()) != null)
            {
                mapFile[counter] = line;
                counter++;
            }

            //Close the file and delete it, no more reading will be done.
            file.Close();
            file.Dispose();

            #endregion

            #region idSwapping

            //First mess around with the id's of the objects.

            bool done = false;
            bool indexSucces = true;
            int beginLine = -1;
            int lastLine = -1;
            counter = 0;

            Random random = new Random();

            while(!done)
            {
                if(mapFile[counter].Contains("FileIndex_StaticObjects"))
                {
                    if(beginLine == -1)
                    {
                        beginLine = counter + 1;
                    }
                    else
                    {
                        lastLine = counter - 1;
                    }
                }

                if(beginLine != -1 && lastLine != -1)
                {
                    done = true;
                }

                if(counter == mapFile.Length-1)
                {
                    indexSucces = false;
                    break;
                }

                counter++;
            }

            //Shuffle some of them.
            //yum spaghetti..
            if (indexSucces && doSwapping)
            {
                for (int i = beginLine; i < lastLine + 1; i++)
                {
                    //One chance in ten
                    if (random.Next(10) == 4)
                    {
                        //Swap with another random element.
                        int eleRand = random.Next(lastLine) + beginLine;

                        if (eleRand == i)
                        {
                            //Stop this iteration.
                            continue;
                        }

                        string[] ele1 = mapFile[i].Split(' ');
                        string[] ele2 = mapFile[eleRand].Split(' ');

                        counter = 0;

                        int ele1_pos = -1;
                        int ele2_pos = -1;

                        //Find the line that contains Id=
                        foreach (string element in ele1)
                        {
                            if (element.Contains("Id="))
                            {
                                ele1_pos = counter;
                            }

                            counter++;
                        }

                        counter = 0;

                        foreach (string element in ele2)
                        {
                            if (element.Contains("Id="))
                            {
                                ele2_pos = counter;
                            }

                            counter++;
                        }

                        //Swap them if the id-s are not zero.
                        if (ele1_pos != -1 && ele2_pos != -1)
                        {
                            string tempEle1 = ele1[ele1_pos];
                            ele1[ele1_pos] = ele2[ele2_pos];
                            ele2[ele2_pos] = tempEle1;
                        }

                        //Make them into strings again.
                        string recEle1 = null;
                        string recEle2 = null;

                        foreach (string element in ele1)
                        {
                            recEle1 += " " + element;
                        }

                        foreach (string element in ele2)
                        {
                            recEle2 += " " + element;
                        }

                        //Place them back into their respective places.
                        mapFile[i] = recEle1;
                        mapFile[eleRand] = recEle2;

                    }
                }
            }

            #endregion

            #region manipulatingStaticStuff

            //Find the rows
            done = false;
            indexSucces = true;
            beginLine = -1;
            lastLine = -1;
            counter = 0;

            while (!done)
            {
                if (mapFile[counter].Contains("<StaticObjects>"))
                {
                    beginLine = counter + 1;
                }
                else if(mapFile[counter].Contains("</StaticObjects>"))
                {
                    lastLine = counter - 1;
                }


                if (beginLine != -1 && lastLine != -1)
                {
                    done = true;
                }

                if (counter == mapFile.Length - 1)
                {
                    indexSucces = false;
                    break;
                }

                counter++;
            }

            //Switch it around.
            if (indexSucces)
            {
                for (int i = beginLine; i < lastLine + 1; i++)
                {
                    bool hasRot = false;
                    bool hasTrans = false;
                    bool hasScale = false;

                    if (mapFile[i].Contains("Rotation="))
                    {
                        hasRot = true;
                    }

                    if (mapFile[i].Contains("WorldPos="))
                    {
                        hasTrans = true;
                    }

                    if (mapFile[i].Contains("Scale="))
                    {
                        hasScale = true;
                    }

                    if(!hasRot && !hasTrans && !hasScale)
                    {
                        continue;
                    }

                    //Manipulate the index.
                    string[] splitterManipulator = mapFile[i].Split('"');

                    if (hasRot)
                    {

                        //When you find a string that contains Rotation= it means that the next one is the rotations.
                        int rotIndex = -1;

                        for(int k = 0; k < splitterManipulator.Length; k++)
                        {
                            if(splitterManipulator[k].Contains("Rotation="))
                            {
                                rotIndex = k;
                            }
                        } 

                        //Exit the loop if it wasn't found.
                        if(rotIndex == -1)
                        {
                            continue;
                        }

                        string[] rotation = splitterManipulator[rotIndex + 1].Split(' ');
                        
                        //Now offset the rotations with the force supplied earlier.
                        rotation[0] = Convert.ToString((float.Parse(rotation[0], CultureInfo.InvariantCulture.NumberFormat) + ((float)random.NextDouble() * 2f - 1f) * rotationForce));
                        rotation[1] = Convert.ToString((float.Parse(rotation[1], CultureInfo.InvariantCulture.NumberFormat) + ((float)random.NextDouble() * 2f - 1f) * rotationForce));
                        rotation[2] = Convert.ToString((float.Parse(rotation[2], CultureInfo.InvariantCulture.NumberFormat) + ((float)random.NextDouble() * 2f - 1f) * rotationForce));

                        //Reconstruct the original and place it back into the splitter
                        string rotRec = rotation[0] + " " + rotation[1] + " " + rotation[2];
                        splitterManipulator[rotIndex + 1] = rotRec;

                        //Reconstruct the splitted one and place it back into the mapFile
                        string rotReconstruct = reconstructor(splitterManipulator,'"');
                        mapFile[i] = rotReconstruct;
                    }

                    if (hasScale)
                    {

                        //When you find a string that contains scaation= it means that the next one is the scaations.
                        int scaIndex = -1;

                        for (int k = 0; k < splitterManipulator.Length; k++)
                        {
                            if (splitterManipulator[k].Contains("Scale="))
                            {
                                scaIndex = k;
                            }
                        }

                        //Exit the loop if it wasn't found.
                        if (scaIndex == -1)
                        {
                            continue;
                        }

                        string[] scaation = splitterManipulator[scaIndex + 1].Split(' ');

                        //Now offset the scaations with the force supplied earlier.
                        scaation[0] = Convert.ToString((float.Parse(scaation[0], CultureInfo.InvariantCulture.NumberFormat) + ((float)random.NextDouble() * 2f - 1f) * scaleForce));
                        scaation[1] = Convert.ToString((float.Parse(scaation[1], CultureInfo.InvariantCulture.NumberFormat) + ((float)random.NextDouble() * 2f - 1f) * scaleForce));
                        scaation[2] = Convert.ToString((float.Parse(scaation[2], CultureInfo.InvariantCulture.NumberFormat) + ((float)random.NextDouble() * 2f - 1f) * scaleForce));

                        //Reconstruct the original and place it back into the splitter
                        string scaRec = scaation[0] + " " + scaation[1] + " " + scaation[2];
                        splitterManipulator[scaIndex + 1] = scaRec;

                        //Reconstruct the splitted one and place it back into the mapFile
                        string scaReconstruct = reconstructor(splitterManipulator, '"');
                        mapFile[i] = scaReconstruct;
                    }

                    if (hasTrans)
                    {

                        //When you find a string that contains traation= it means that the next one is the traations.
                        int traIndex = -1;

                        for (int k = 0; k < splitterManipulator.Length; k++)
                        {
                            if (splitterManipulator[k].Contains("WorldPos="))
                            {
                                traIndex = k;
                            }
                        }

                        //Exit the loop if it wasn't found.
                        if (traIndex == -1)
                        {
                            continue;
                        }

                        string[] traation = splitterManipulator[traIndex + 1].Split(' ');

                        //Now offset the traations with the force supplied earlier.
                        traation[0] = Convert.ToString((float.Parse(traation[0], CultureInfo.InvariantCulture.NumberFormat) + ((float)random.NextDouble() * 2f - 1f) * translationForce));
                        traation[1] = Convert.ToString((float.Parse(traation[1], CultureInfo.InvariantCulture.NumberFormat) + ((float)random.NextDouble() * 2f - 1f) * translationForce));
                        traation[2] = Convert.ToString((float.Parse(traation[2], CultureInfo.InvariantCulture.NumberFormat) + ((float)random.NextDouble() * 2f - 1f) * translationForce));

                        //Reconstruct the original and place it back into the splitter
                        string traRec = traation[0] + " " + traation[1] + " " + traation[2];
                        splitterManipulator[traIndex + 1] = traRec;

                        //Reconstruct the splitted one and place it back into the mapFile
                        string traReconstruct = reconstructor(splitterManipulator, '"');
                        mapFile[i] = traReconstruct;
                    }

                    //Just hack it, replace all commas with '.'
                    mapFile[i] = mapFile[i].Replace(',', '.');    

                }
            }

            #endregion

            #region manipulatingEntityStuff

            //Yes i am copy pasting exactly the same code with minute changes.
            //Find the rows
            done = false;
            indexSucces = true;
            beginLine = -1;
            lastLine = -1;
            counter = 0;

            while (!done)
            {
                if (mapFile[counter].Contains("<Entities>"))
                {
                    beginLine = counter + 1;
                }
                else if (mapFile[counter].Contains("</Entities>"))
                {
                    lastLine = counter - 1;
                }


                if (beginLine != -1 && lastLine != -1)
                {
                    done = true;
                }

                if (counter == mapFile.Length - 1)
                {
                    indexSucces = false;
                    break;
                }

                counter++;
            }

            //Switch it around.
            if (indexSucces)
            {
                for (int i = beginLine; i < lastLine + 1; i++)
                {
                    bool hasRot = false;
                    bool hasTrans = false;
                    bool hasScale = false;

                    if (mapFile[i].Contains("Rotation="))
                    {
                        hasRot = true;
                    }

                    if (mapFile[i].Contains("WorldPos="))
                    {
                        hasTrans = true;
                    }

                    if (mapFile[i].Contains("Scale="))
                    {
                        hasScale = true;
                    }

                    if (!hasRot && !hasTrans && !hasScale)
                    {
                        continue;
                    }

                    //Manipulate the index.
                    string[] splitterManipulator = mapFile[i].Split('"');

                    if (hasRot)
                    {

                        //When you find a string that contains Rotation= it means that the next one is the rotations.
                        int rotIndex = -1;

                        for (int k = 0; k < splitterManipulator.Length; k++)
                        {
                            if (splitterManipulator[k].Contains("Rotation="))
                            {
                                rotIndex = k;
                            }
                        }

                        //Exit the loop if it wasn't found.
                        if (rotIndex == -1)
                        {
                            continue;
                        }

                        string[] rotation = splitterManipulator[rotIndex + 1].Split(' ');

                        //Now offset the rotations with the force supplied earlier.
                        rotation[0] = Convert.ToString((float.Parse(rotation[0], CultureInfo.InvariantCulture.NumberFormat) + ((float)random.NextDouble() * 2f - 1f) * rotationForceE));
                        rotation[1] = Convert.ToString((float.Parse(rotation[1], CultureInfo.InvariantCulture.NumberFormat) + ((float)random.NextDouble() * 2f - 1f) * rotationForceE));
                        rotation[2] = Convert.ToString((float.Parse(rotation[2], CultureInfo.InvariantCulture.NumberFormat) + ((float)random.NextDouble() * 2f - 1f) * rotationForceE));

                        //Reconstruct the original and place it back into the splitter
                        string rotRec = rotation[0] + " " + rotation[1] + " " + rotation[2];
                        splitterManipulator[rotIndex + 1] = rotRec;

                        //Reconstruct the splitted one and place it back into the mapFile
                        string rotReconstruct = reconstructor(splitterManipulator, '"');
                        mapFile[i] = rotReconstruct;
                    }

                    if (hasScale)
                    {

                        //When you find a string that contains scaation= it means that the next one is the scaations.
                        int scaIndex = -1;

                        for (int k = 0; k < splitterManipulator.Length; k++)
                        {
                            if (splitterManipulator[k].Contains("Scale="))
                            {
                                scaIndex = k;
                            }
                        }

                        //Exit the loop if it wasn't found.
                        if (scaIndex == -1)
                        {
                            continue;
                        }

                        string[] scaation = splitterManipulator[scaIndex + 1].Split(' ');

                        //Now offset the scaations with the force supplied earlier.
                        scaation[0] = Convert.ToString((float.Parse(scaation[0], CultureInfo.InvariantCulture.NumberFormat) + ((float)random.NextDouble() * 2f - 1f) * scaleForceE));
                        scaation[1] = Convert.ToString((float.Parse(scaation[1], CultureInfo.InvariantCulture.NumberFormat) + ((float)random.NextDouble() * 2f - 1f) * scaleForceE));
                        scaation[2] = Convert.ToString((float.Parse(scaation[2], CultureInfo.InvariantCulture.NumberFormat) + ((float)random.NextDouble() * 2f - 1f) * scaleForceE));

                        //Reconstruct the original and place it back into the splitter
                        string scaRec = scaation[0] + " " + scaation[1] + " " + scaation[2];
                        splitterManipulator[scaIndex + 1] = scaRec;

                        //Reconstruct the splitted one and place it back into the mapFile
                        string scaReconstruct = reconstructor(splitterManipulator, '"');
                        mapFile[i] = scaReconstruct;
                    }

                    if (hasTrans)
                    {

                        //When you find a string that contains traation= it means that the next one is the traations.
                        int traIndex = -1;

                        for (int k = 0; k < splitterManipulator.Length; k++)
                        {
                            if (splitterManipulator[k].Contains("WorldPos="))
                            {
                                traIndex = k;
                            }
                        }

                        //Exit the loop if it wasn't found.
                        if (traIndex == -1)
                        {
                            continue;
                        }

                        string[] traation = splitterManipulator[traIndex + 1].Split(' ');

                        //Now offset the traations with the force supplied earlier.
                        traation[0] = Convert.ToString((float.Parse(traation[0], CultureInfo.InvariantCulture.NumberFormat) + ((float)random.NextDouble() * 2f - 1f) * translationForceE));
                        traation[1] = Convert.ToString((float.Parse(traation[1], CultureInfo.InvariantCulture.NumberFormat) + ((float)random.NextDouble() * 2f - 1f) * translationForceE));
                        traation[2] = Convert.ToString((float.Parse(traation[2], CultureInfo.InvariantCulture.NumberFormat) + ((float)random.NextDouble() * 2f - 1f) * translationForceE));

                        //Reconstruct the original and place it back into the splitter
                        string traRec = traation[0] + " " + traation[1] + " " + traation[2];
                        splitterManipulator[traIndex + 1] = traRec;

                        //Reconstruct the splitted one and place it back into the mapFile
                        string traReconstruct = reconstructor(splitterManipulator, '"');
                        mapFile[i] = traReconstruct;
                    }

                    //Just hack it, replace all commas with '.'
                    mapFile[i] = mapFile[i].Replace(',', '.');

                }
            }

            #endregion

            #region fileSaving


            using (StreamWriter newTask = new StreamWriter(path, false))
            {
                foreach(string element in mapFile)
                newTask.WriteLine(element);
            }

            #endregion
        }

        public static string reconstructor(string[] splitted, char splitArg)
        {

            string returner = "";

            for (int i = 0; i < splitted.Length-1; i++)
            {
                //TODO not sure if right way...?
                returner = returner + splitted[i] + splitArg.ToString();
            }

            returner = returner + splitted[splitted.Length-1];

            return returner;

        }

    }
}
