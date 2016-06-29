using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.DevIl;
using NAudio;

namespace Amnesia_Randomizer_UI
{
    public class Converter
    {
        public Converter()
        {
            //Constructor initializes devil libraries.
            Il.ilInit();
            Ilu.iluInit();
        }

        //Convert a png image into a dds image.
        public string convertPNG(string png)
        {
            int image;

            Il.ilGenImages(1, out image);

            Il.ilBindImage(image);

            //Return if it fucks up the loading.
            if(!Il.ilLoadImage(png))
            {
                return null;
            }

            //Convert image to closest power of 2, creds to http://thecsharpmind.blogspot.se/2006/11/using-tao-and-devil-to-load-opengl.html 
            int image_width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
            int image_height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);
            int image_depth = Il.ilGetInteger(Il.IL_IMAGE_DEPTH);
            int texture_width = NextPowerOfTwo(image_width);
            int texture_height = NextPowerOfTwo(image_height);

            if ((texture_width != image_width) || (texture_height != image_height))
            {
                Ilu.iluScale(texture_height, texture_height, image_depth);
            }

            //Now simply save this as a dds file with the .dds extension.
            if(Il.ilSaveImage(png.Split('.')[0] + ".dds"))
            {
                Il.ilDeleteImage(image);
                return png.Split('.')[0] + ".dds";
            }
            else
            {
                Il.ilDeleteImage(image);
                return null;
            }
        }

        public string convertJPG(string jpgs)
        {
            int image;

            Il.ilGenImages(1, out image);

            Il.ilBindImage(image);

            //Return if it fucks up the loading.
            if (!Il.ilLoadImage(jpgs))
            {
                return null;
            }

            //Convert image to closest power of 2, creds to http://thecsharpmind.blogspot.se/2006/11/using-tao-and-devil-to-load-opengl.html 
            int image_width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
            int image_height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);
            int image_depth = Il.ilGetInteger(Il.IL_IMAGE_DEPTH);
            int texture_width = NextPowerOfTwo(image_width);
            int texture_height = NextPowerOfTwo(image_height);

            if ((texture_width != image_width) || (texture_height != image_height))
            {
                Ilu.iluScale(texture_height, texture_height, image_depth);
            }

            //Now simply save this as a dds file with the .dds extension.
            if (Il.ilSaveImage(jpgs.Split('.')[0] + ".dds"))
            {
                Il.ilDeleteImage(image);
                return jpgs.Split('.')[0] + ".dds";
            }
            else
            {
                Il.ilDeleteImage(image);
                return null;
            }

        }

        public string  convertJPEG(string jpgs)
        {
            int image;

            Il.ilGenImages(1, out image);

            Il.ilBindImage(image);

            //Return if it fucks up the loading.
            if (!Il.ilLoadImage(jpgs))
            {
                return null;
            }

            //Convert image to closest power of 2, creds to http://thecsharpmind.blogspot.se/2006/11/using-tao-and-devil-to-load-opengl.html 
            int image_width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
            int image_height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);
            int image_depth = Il.ilGetInteger(Il.IL_IMAGE_DEPTH);
            int texture_width = NextPowerOfTwo(image_width);
            int texture_height = NextPowerOfTwo(image_height);

            if ((texture_width != image_width) || (texture_height != image_height))
            {
                Ilu.iluScale(texture_height, texture_height, image_depth);
            }

            //Now simply save this as a dds file with the .dds extension.
            if (Il.ilSaveImage(jpgs.Split('.')[0] + ".dds"))
            {
                Il.ilDeleteImage(image);
                return jpgs.Split('.')[0] + ".dds";
            }
            else
            {
                Il.ilDeleteImage(image);
                return null;
            }
        }

        public string  convertWav(string wavs)
        {
            return null;
        }

        public string convertMP3(string mp3)
        {
            return null;
        }

        public static int NextPowerOfTwo(int n)
        {
            double power = 0;
            while (n > Math.Pow(2.0, power))
                power++;
            return (int)Math.Pow(2.0, power);
        }

        //Localises all png, jpg and so on and converts them into dds.

    }
}
