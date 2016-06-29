using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Amnesia_Randomizer_UI
{
    public class fileSwapper
    {
        public bool swapFile(string path1, string path2, bool noNrm)
        {
            //Check if the swap can be done, filenames must be the same.
            string[] fileName1 = path1.Split('.');
            string[] fileName2 = path2.Split('.');

            //Check so that none of these are spec or normal maps.
            if(noNrm)
            {
                if(fileName1[0][fileName1[0].Length-1] == 'm' && fileName1[0][fileName1[0].Length - 2] == 'r' && fileName1[0][fileName1[0].Length - 3] == 'n')
                {
                    return false;
                }
                if (fileName2[0][fileName2[0].Length - 1] == 'm' && fileName2[0][fileName2[0].Length - 2] == 'r' && fileName2[0][fileName2[0].Length - 3] == 'n')
                {
                    return false;
                }

                if (fileName1[0][fileName1[0].Length - 1] == 'c' && fileName1[0][fileName1[0].Length - 2] == 'e' && fileName1[0][fileName1[0].Length - 3] == 'p')
                {
                    return false;
                }
                if (fileName2[0][fileName2[0].Length - 1] == 'c' && fileName2[0][fileName2[0].Length - 2] == 'e' && fileName2[0][fileName2[0].Length - 3] == 'p')
                {
                    return false;
                }
            }

            if(fileName1[1] != fileName2[1])
            {
                //Here add a case for conversion.
                return false;
            }


            //First create a temporary for the first object i.e.
            System.IO.File.Move(path1, path1+"_temp");
            System.IO.File.Move(path2, path1);
            System.IO.File.Move(path1+"_temp", path2);

            Console.WriteLine(path1 + "<-->" + path2);

            return true;
        }

        public bool swapFileOneWay(string path1, string path2, bool noNrm)
        {
            //Check if the swap can be done, filenames must be the same.
            string[] fileName1 = path1.Split('.');
            string[] fileName2 = path2.Split('.');

            //Check so that none of these are spec or normal maps.
            if (noNrm)
            {
                if (fileName1[0][fileName1[0].Length - 1] == 'm' && fileName1[0][fileName1[0].Length - 2] == 'r' && fileName1[0][fileName1[0].Length - 3] == 'n')
                {
                    return false;
                }
                if (fileName2[0][fileName2[0].Length - 1] == 'm' && fileName2[0][fileName2[0].Length - 2] == 'r' && fileName2[0][fileName2[0].Length - 3] == 'n')
                {
                    return false;
                }

                if (fileName1[0][fileName1[0].Length - 1] == 'c' && fileName1[0][fileName1[0].Length - 2] == 'e' && fileName1[0][fileName1[0].Length - 3] == 'p')
                {
                    return false;
                }
                if (fileName2[0][fileName2[0].Length - 1] == 'c' && fileName2[0][fileName2[0].Length - 2] == 'e' && fileName2[0][fileName2[0].Length - 3] == 'p')
                {
                    return false;
                }
            }

            if (fileName1[1] != fileName2[1])
            {
                //Here add a case for conversion.
                return false;
            }


            //First create a temporary for the first object i.e.
            System.IO.File.Delete(path2);
            System.IO.File.Copy(path1, path2);

            Console.WriteLine(path1 + "-->" + path2);

            return true;
        }
    }
}
