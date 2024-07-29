using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressureUpper
{
    public static class ColorMap
    {
        #region Variables
 

        private static int FieldmapLength = 100;
        private static int Alpha = 255;
        #endregion

        

        #region Methods

        public static int[,] Mix4()
        {
           
            int[,] Fmap = new int[FieldmapLength, 4];
            int Ncol = 6;
            double fac3 = 200;
            int n = (int)(FieldmapLength / (float)Ncol);

            int[] num = new int[Ncol];
            int diff = FieldmapLength - n * Ncol;
            for (int i = 0; i < Ncol; i++)
            {
                num[i] = n;
                if ((diff) > Ncol - i - 1)
                    num[i] = n + 1;
            }

            double fac2 = ((255) / (float)num[3]);
            double fac4 = ((255 - fac3) / (float)num[5]);

            double[,] Red = new double[Ncol, 3];
            double[,] Green = new double[Ncol, 3];
            double[,] Blue = new double[Ncol, 3];

            Red[0, 0] = 0; Red[0, 1] = 0; Red[0, 2] = 0;
            Red[1, 0] = 0; Red[1, 1] = 0; Red[1, 2] = 0;
            Red[2, 0] = 0; Red[2, 1] = 0; Red[2, 2] = 0;
            Red[3, 0] = 0; Red[3, 1] = 1; Red[3, 2] = fac2;
            Red[4, 0] = 255; Red[4, 1] = 0; Red[4, 2] = 0;
            Red[5, 0] = 255; Red[5, 1] = -1; Red[5, 2] = fac4;

            fac2 = ((255) / (float)num[1]);
            fac4 = ((255) / (float)num[4]);

            Green[0, 0] = 0; Green[0, 1] = 0; Green[0, 2] = 0;
            Green[1, 0] = 0; Green[1, 1] = 1; Green[1, 2] = fac2;
            Green[2, 0] = 255; Green[2, 1] = 0; Green[2, 2] = 0;
            Green[3, 0] = 255; Green[3, 1] = 0; Green[3, 2] = 0;
            Green[4, 0] = 255; Green[4, 1] = -1; Green[4, 2] = fac4;
            Green[5, 0] = 0; Green[5, 1] = 0; Green[5, 2] = 0;

            fac2 = ((255) / (float)num[2]);
            fac4 = ((255 - fac3) / (float)num[0]);

            Blue[0, 0] = fac3; Blue[0, 1] = 1; Blue[0, 2] = fac4;
            Blue[1, 0] = 255; Blue[1, 1] = 0; Blue[1, 2] = 0;
            Blue[2, 0] = 255; Blue[2, 1] = -1; Blue[2, 2] = fac2;
            Blue[3, 0] = 0; Blue[3, 1] = 0; Blue[3, 2] = 0;
            Blue[4, 0] = 0; Blue[4, 1] = 0; Blue[4, 2] = 0;
            Blue[5, 0] = 0; Blue[5, 1] = 0; Blue[5, 2] = 0;
            double fac = 0.0;
            int st = 0;
            int stop = 0;
            for (int j = 0; j < Ncol; j++)
            {
                st = stop;
                stop = st + num[j];
                for (int i = st; i < stop; i++)
                {
                    Fmap[i, 0] = Alpha;
                    fac = Red[j, 0] + Red[j, 1] * Red[j, 2] * (i - st);
                    if (fac > 255)
                        fac = 255;
                    if (fac < 0)
                        fac = 0;
                    Fmap[FieldmapLength - 1 - i, 1] = (int)fac;
                    fac = Green[j, 0] + Green[j, 1] * Green[j, 2] * (i - st);
                    if (fac > 255)
                        fac = 255;
                    if (fac < 0)
                        fac = 0;
                    Fmap[FieldmapLength - 1 - i, 2] = (int)fac;
                    fac = Blue[j, 0] + Blue[j, 1] * Blue[j, 2] * (i - st);
                    if (fac > 255)
                        fac = 255;
                    if (fac < 0)
                        fac = 0;
                    Fmap[FieldmapLength - 1 - i, 3] = (int)fac;
                }
            }

            return Fmap;
        }

        public static int[,] Mix3()
        {
            //Dark Red 200,0,0
            //Red      255,0,0 
            //orange   255,128,0
            //yellow   255,255,0
            //Green    0,128,0

            int[,] Fmap = new int[FieldmapLength, 4];
            int Ncol = 6;
            double fac3 = 200;
            int n = (int)(FieldmapLength / (float)Ncol);

            int[] num = new int[Ncol];
            int diff = FieldmapLength - n * Ncol;
            for (int i = 0; i < Ncol; i++)
            {
                num[i] = n;
                if ((diff) > Ncol - i - 1)
                    num[i] = n + 1;
            }

            double fac2 = ((255) / (float)num[3]);
            double fac4 = ((255 - fac3) / (float)num[5]);

            double[,] Red = new double[Ncol, 3];
            double[,] Green = new double[Ncol, 3];
            double[,] Blue = new double[Ncol, 3];

            Red[0, 0] = 0; Red[0, 1] = 0; Red[0, 2] = 0;
            Red[1, 0] = 0; Red[1, 1] = 0; Red[1, 2] = 0;
            Red[2, 0] = 0; Red[2, 1] = 0; Red[2, 2] = 0;
            Red[3, 0] = 0; Red[3, 1] = 1; Red[3, 2] = fac2;
            Red[4, 0] = 255; Red[4, 1] = 0; Red[4, 2] = 0;
            Red[5, 0] = 255; Red[5, 1] = -1; Red[5, 2] = fac4;

            fac2 = ((255) / (float)num[1]);
            fac4 = ((255) / (float)num[4]);

            Green[0, 0] = 0; Green[0, 1] = 0; Green[0, 2] = 0;
            Green[1, 0] = 0; Green[1, 1] = 1; Green[1, 2] = fac2;
            Green[2, 0] = 255; Green[2, 1] = 0; Green[2, 2] = 0;
            Green[3, 0] = 255; Green[3, 1] = 0; Green[3, 2] = 0;
            Green[4, 0] = 255; Green[4, 1] = -1; Green[4, 2] = fac2;
            Green[5, 0] = 0; Green[5, 1] = 0; Green[5, 2] = 0;

            fac2 = ((255) / (float)num[2]);
            fac4 = ((255 - fac3) / (float)num[0]);

            Blue[0, 0] = fac3; Blue[0, 1] = 1; Blue[0, 2] = fac4;
            Blue[1, 0] = 255; Blue[1, 1] = 0; Blue[1, 2] = 0;
            Blue[2, 0] = 255; Blue[2, 1] = -1; Blue[2, 2] = fac2;
            Blue[3, 0] = 0; Blue[3, 1] = 0; Blue[3, 2] = 0;
            Blue[4, 0] = 0; Blue[4, 1] = 0; Blue[4, 2] = 0;
            Blue[5, 0] = 0; Blue[5, 1] = 0; Blue[5, 2] = 0;
            double fac = 0.0;
            int st = 0;
            int stop = 0;
            for (int j = 0; j < Ncol; j++)
            {
                st = stop;
                stop = st + num[j];
                for (int i = st; i < stop; i++)
                {
                    Fmap[i, 0] = Alpha;
                    fac = Red[j, 0] + Red[j, 1] * Red[j, 2] * (i - st);
                    if (fac > 255)
                        fac = 255;
                    if (fac < 0)
                        fac = 0;
                    Fmap[i, 1] = (int)fac;
                    fac = Green[j, 0] + Green[j, 1] * Green[j, 2] * (i - st);
                    if (fac > 255)
                        fac = 255;
                    if (fac < 0)
                        fac = 0;
                    Fmap[i, 2] = (int)fac;
                    fac = Blue[j, 0] + Blue[j, 1] * Blue[j, 2] * (i - st);
                    if (fac > 255)
                        fac = 255;
                    if (fac < 0)
                        fac = 0;
                    Fmap[i, 3] = (int)fac;
                }
            }

            return Fmap;
        }

        public static int[,] FallRdGr()
        {
            //Dark Red 200,0,0
            //Red      255,0,0 
            //orange   255,128,0
            //yellow   255,255,0
            //Green    0,128,0

            int[,] Fmap = new int[FieldmapLength, 4];
            int Ncol = 5;
            double fac = 200;
            int n = (int)(FieldmapLength / (float)Ncol);

            int[] num = new int[Ncol];
            int diff = FieldmapLength - n * Ncol;
            for (int i = 0; i < Ncol; i++)
            {
                num[i] = n;
                if ((diff) > Ncol - i - 1)
                    num[i] = n + 1;
            }
            double fac2 = ((fac) / (float)num[0]);
            double fac3 = ((fac) / (float)num[1]);
            double fac4 = ((255 - fac) / (float)num[4]);

            double[,] Red = new double[Ncol, 3];
            double[,] Green = new double[Ncol, 3];
            double[,] Blue = new double[Ncol, 3];

            Red[0, 0] = 0; Red[0, 1] = 1; Red[0, 2] = fac2;
            Red[1, 0] = 128; Red[1, 1] = 1; Red[1, 2] = fac2;
            Red[2, 0] = 255; Red[2, 1] = 0; Red[2, 2] = 0;
            Red[3, 0] = 255; Red[3, 1] = 0; Red[3, 2] = 0;
            Red[4, 0] = 255; Red[4, 1] = -1; Red[4, 2] = fac4;

            Green[0, 0] = 15; Green[0, 1] = 0; Green[0, 2] = 0;
            Green[1, 0] = 0; Green[1, 1] = 0; Green[1, 2] = 0;
            Green[2, 0] = 0; Green[2, 1] = 0; Green[2, 2] = 0;
            Green[3, 0] = 0; Green[3, 1] = 0; Green[3, 2] = 0;
            Green[4, 0] = 0; Green[4, 1] = 0; Green[4, 2] = 0;

            fac2 = ((255 - 128) / (float)num[3]);
            fac3 = ((128) / (float)num[1]);
            fac4 = ((255 - 128) / (float)num[2]);

            Blue[0, 0] = 255; Blue[0, 1] = 0; Blue[0, 2] = 0;
            Blue[1, 0] = 128; Blue[1, 1] = 1; Blue[1, 2] = fac3;
            Blue[2, 0] = 255; Blue[2, 1] = -1; Blue[2, 2] = fac4;
            Blue[3, 0] = 128; Blue[3, 1] = -1; Blue[3, 2] = fac2;
            Blue[4, 0] = 0; Blue[4, 1] = 0; Blue[4, 2] = 0;

           

            int st = 0;
            int stop = 0;
            for (int j = 0; j < Ncol; j++)
            {
                st = stop;
                stop = st + num[j];
                for (int i = st; i < stop; i++)
                {
                    Fmap[i, 0] = Alpha;
                    fac = Red[j, 0] + Red[j, 1] * Red[j, 2] * (i - st);
                    if (fac > 255)
                        fac = 255;
                    if (fac < 0)
                        fac = 0;
                    Fmap[i, 1] = (int)fac;
                    fac = Green[j, 0] + Green[j, 1] * Green[j, 2] * (i - st);
                    if (fac > 255)
                        fac = 255;
                    if (fac < 0)
                        fac = 0;
                    Fmap[i, 2] = (int)fac;
                    fac = Blue[j, 0] + Blue[j, 1] * Blue[j, 2] * (i - st);
                    if (fac > 255)
                        fac = 255;
                    if (fac < 0)
                        fac = 0;
                    Fmap[i, 3] = (int)fac;
                }
            }

            return Fmap;
        }
        
        public static int[,] FallRdGrV2()
        {
            int interpNum = 128;
            int[][] rawColors = new int[8][]{
              new int[]{0,0,255 },
              new int[] { 0, 127, 255 },
              new int[] { 0, 255, 255 },
              new int[] { 127, 255, 127 },
              new int[] { 255, 255, 0 },
              new int[] { 255, 127, 0 },
              new int[] { 255, 0, 0 },
              new int[] { 127, 0, 0 },
                };

            int[,] Fmap = new int[(rawColors.Length - 1) * interpNum + 1, 4];
            for (int i = 0;i < rawColors.Length - 1; i++)
            {
                int[] l = rawColors[i];
                int[] r = rawColors[i + 1];
                for (int j = 0;j < interpNum; j++)
                {
                    Fmap[i * interpNum + j, 0] = 255;
                    Fmap[i * interpNum + j, 1] = l[0] + (r[0]-l[0])*j/interpNum;
                    Fmap[i * interpNum + j, 2] = l[1] + (r[1] - l[1]) * j / interpNum;
                    Fmap[i * interpNum + j, 3] = l[2] + (r[2] - l[2]) * j / interpNum;
                }
            }
            Fmap[(rawColors.Length - 1) * interpNum, 0] = 255;
            Fmap[(rawColors.Length - 1) * interpNum, 1] = rawColors[rawColors.Length - 1][0];
            Fmap[(rawColors.Length - 1) * interpNum, 2] = rawColors[rawColors.Length - 1][1];
            Fmap[(rawColors.Length - 1) * interpNum, 3] = rawColors[rawColors.Length - 1][2];

            return Fmap;
        }


        public static int[,] Rainbow(int ind)
        {
            //Red       255,0,0
            //Orange    255,102,0 or 255,165,0
            //Yellow    255,255,0
            //Green     0,127,0
            //Blue      0,0,255
            //Indigo    111,0,255 75,0,130 or 51,51,153 or 
            //Violet    127,0,255 or 238,130,238 or 128,0,128 or 139,0,255 or 143,0,255

            int[,] Fmap = new int[FieldmapLength, 4];
            int Ncol = 7;
            double fac = 150;
            int n = (int)(FieldmapLength / (float)Ncol);

            int[] num = new int[Ncol];
            int diff = FieldmapLength - n * Ncol;
            for (int i = 0; i < Ncol; i++)
            {
                num[i] = n;
                if ((diff) > Ncol - i - 1)
                    num[i] = n + 1;
            }

            double fac2 = ((fac) / (float)num[2]);
            double fac6 = ((255 - 111) / (float)num[1]);

            double[,] Red = new double[Ncol, 3];
            double[,] Green = new double[Ncol, 3];
            double[,] Blue = new double[Ncol, 3];

            Red[0, 0] = 255; Red[0, 1] = 0; Red[0, 2] = 0;
            Red[1, 0] = 255; Red[1, 1] = -1; Red[1, 2] = fac6;
            Red[2, 0] = fac; Red[2, 1] = -1; Red[2, 2] = fac2;
            Red[3, 0] = 0; Red[3, 1] = 0; Red[3, 2] = 0;
            Red[4, 0] = 255; Red[4, 1] = 0; Red[4, 2] = 0;
            Red[5, 0] = 255; Red[5, 1] = 0; Red[5, 2] = 0;//Orange
            Red[6, 0] = 255; Red[6, 1] = 0; Red[6, 2] = 0;//Red

            fac2 = ((fac) / (float)num[2]);
            double fac3 = ((255 - 102) / (float)num[5]);
            double fac5 = ((255 - 127) / (float)num[3]);
            fac6 = ((fac) / (float)num[6]);

            Green[0, 0] = 0; Green[0, 1] = 0; Green[0, 2] = 0;
            Green[1, 0] = 0; Green[1, 1] = 0; Green[1, 2] = 0;
            Green[2, 0] = fac; Green[2, 1] = -1; Green[2, 2] = fac2;
            Green[3, 0] = 255; Green[3, 1] = -1; Green[3, 2] = fac5;
            Green[4, 0] = 255; Green[4, 1] = 0; Green[4, 2] = 0;
            Green[5, 0] = 255; Green[5, 1] = -1; Green[5, 2] = fac3;
            Green[6, 0] = fac; Green[6, 1] = -1; Green[6, 2] = fac6;

            fac2 = ((fac) / (float)num[6]);
            fac3 = ((255 - 102) / (float)num[5]);
            double fac4 = ((175) / (float)num[4]);
            fac5 = ((255 - 127) / (float)num[1]);
            fac6 = ((255 - 111) / (float)num[0]);

            Blue[0, 0] = 255; Blue[0, 1] = -1; Blue[0, 2] = fac5;
            Blue[1, 0] = 255; Blue[1, 1] = -1; Blue[1, 2] = fac6;
            Blue[2, 0] = 255; Blue[2, 1] = 0; Blue[2, 2] = 0;
            Blue[3, 0] = 0; Blue[3, 1] = 0; Blue[3, 2] = 0;
            Blue[4, 0] = 175; Blue[4, 1] = -1; Blue[4, 2] = fac4;
            Blue[5, 0] = 255 - 102; Blue[5, 1] = -1; Blue[5, 2] = fac3;
            Blue[6, 0] = fac; Blue[6, 1] = -1; Blue[6, 2] = fac2;


            int st = 0;
            int stop = 0;
            for (int j = 0; j < Ncol; j++)
            {
                st = stop;
                stop = st + num[j];
                for (int i = st; i < stop; i++)
                {
                    Fmap[i, 0] = Alpha;
                    fac = Red[j, 0] + Red[j, 1] * Red[j, 2] * (i - st);
                    if (fac > 255)
                        fac = 255;
                    if (fac < 0)
                        fac = 0;
                    Fmap[i, 1] = (int)fac;
                    fac = Green[j, 0] + Green[j, 1] * Green[j, 2] * (i - st);
                    if (fac > 255)
                        fac = 255;
                    if (fac < 0)
                        fac = 0;
                    Fmap[i, 2] = (int)fac;
                    fac = Blue[j, 0] + Blue[j, 1] * Blue[j, 2] * (i - st);
                    if (fac > 255)
                        fac = 255;
                    if (fac < 0)
                        fac = 0;
                    Fmap[i, 3] = (int)fac;
                }
            }

            return Fmap;
        }

        #endregion
    }
}
