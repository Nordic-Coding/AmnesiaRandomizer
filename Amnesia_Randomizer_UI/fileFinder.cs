using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amnesia_Randomizer_UI
{
    /*
     * This class finds all files in the specified subfolder. 
     */
    class fileFinder
    {
        public fileFinder()
        {
            //Constructor does nothing now.
        }

        public List<String> DirSearch(string sDir)
        {
            List<String> files = new List<String>();
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    files.AddRange(DirSearch(d));
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine("Something fucked up, did you place the program in the correct folder?\nFor pros: " + excpt);
                Console.ReadKey();
            }

            return files;
        }
    }
}
