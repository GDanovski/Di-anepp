/*
 Di-anepp - CellTool PlugIn for GP images analysis
 Copyright (C) 2018  Georgi Danovski

 This program is free software: you can redistribute it and/or modify
 it under the terms of the GNU General Public License as published by
 the Free Software Foundation, either version 3 of the License, or
 (at your option) any later version.

 This program is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU General Public License for more details.

 You should have received a copy of the GNU General Public License
 along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

/// <summary>
/// Used Literature:
/// Owen, Dylan & Rentero, Carles & Magenau, Astrid & Abu siniyeh, Ahmed & Gaus, Katharina. (2011). 
/// Quantitative imaging of membrane lipid order in cells and organisms.Nature protocols. 7. 24-35.
/// 10.1038/nprot.2011.419.
/// Based on the ImageJ macro provided with the paper 
/// </summary>

using System;
using System.Data;
using System.Linq;
using CellToolDK;

namespace Di_anepp
{
    class Di_anepp_Processing
    {
        public static double[] GetImage(int C, TifFileInfo fi)
        {
            double[] res = new double[fi.sizeX * fi.sizeY];
            
            for (int y = 0, pointer = 0; y < fi.sizeY; y++)
                for (int x = 0; x < fi.sizeX; x++, pointer++)
                    res[pointer] = (double)fi.image8bit[C][y][x];
            
            return res;
        }

        public static double[] Apply_Gfactor(double[] disordImg, double Gf)
        {
            for (int i = 0; i < disordImg.Length; i++)
                disordImg[i] *= Gf;

            return disordImg;
        }
        public static double[] Get_GPArray()
        {
            double[] GP = new double[256];

            for (int i = 0; i < 256; i++)
            {
                GP[i] = (((double)i - 127) / 127);
            }
            return GP;
        }

        public static double[] Get_GPcArray(double[] GP,double Gf1)
        {
            double[] GPc = new double[256];

            for (int i = 0; i < 256; i++)
            {
                GPc[i] = -(1 + GP[i] + Gf1 * GP[i] - Gf1) / (-1 - GP[i] + Gf1 * GP[i] - Gf1);
            }

            return GPc;
        }
        public static double[] Get_GPImage(double[] ordImg, double[] disordImg, double threshold)
        {
            double t = threshold*2.510;
            double add = 0;
            double[] GPImg = new double[ordImg.Length];

            for (int i = 0; i < GPImg.Length; i++)
            {
                add = ordImg[i] + disordImg[i];
                if (add > t)
                    GPImg[i] = (ordImg[i] - disordImg[i]) / add;
                else
                    GPImg[i] = -100;
            }

            return GPImg;
        }
        public static double[] HistogramGeneration(System.Windows.Forms.DataGridView dgv1,double[] GPImg, double[] GP,double[] GPc, string dir)
        {
            // This funcion obtains the intensity frequency histogram of the images, makes it smoother,
            // calculates the normal average distribution and also includes the GP value (and GP value
            // corrected by the Gfactor) corresponding to each intensity. An MS Excel file is generated
            // with all this data
            
            int[] Cou = GetHistogram(GPImg,GPc);//Histogram pixel count values
            double[] Smo = SmoothHistogram(Cou);//Smooth the histogram
            //double Sa = Smo.Average() * 256 - Cou[0] - Cou[255];//Calculates the number of pixels
            double Sa = Cou.Sum();
            
            double[] NAvDist = new double[256];
            for (int k = 0; k < 256; k++)
                NAvDist[k] = 100 * Smo[k] / Sa;

            dgv1.DataSource = GenerateDataTable(Cou, Smo, NAvDist, GP, GPc);
            
            return NAvDist;
            //write the file
            /*
            dir = dir.Replace(".tif", "_Histogram.txt");

            using(System.IO.StreamWriter sw = new System.IO.StreamWriter(dir))
            {
                sw.WriteLine("Intensity\tCounts\tSmooth\tNorm Av Dist\tGP\tGP corrected");
                for (int i = 0; i < 256; i++)
                    sw.WriteLine("" + i + "\t" + Cou[i] + "\t" + Smo[i] + "\t" + NAvDist[i] + "\t" + GP[i] + "\t" + GPc[i]);
            }*/
        }
        private static DataTable GenerateDataTable(int[] Cou, double[] Smo, double[] NAvDist, double[] GP, double[] GPc)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add(new DataColumn("Intensity", typeof(int)));
            tbl.Columns.Add(new DataColumn("Counts", typeof(int)));
            tbl.Columns.Add(new DataColumn("Smooth", typeof(double)));
            tbl.Columns.Add(new DataColumn("Norm Av Dist", typeof(double)));
            tbl.Columns.Add(new DataColumn("GP", typeof(double)));
            tbl.Columns.Add(new DataColumn("GPc", typeof(double)));

            for(int i = 0; i<Cou.Length; i++)
            {
                DataRow row = tbl.NewRow();
                row["Intensity"] = i;
                row["Counts"] = Cou[i];
                row["Smooth"] = Smo[i];
                row["Norm Av Dist"] = NAvDist[i];
                row["GP"] = GP[i];
                row["GPc"] = GPc[i];
                tbl.Rows.Add(row);
            }

            return tbl;
        }
        public static void WriteImageAsTxt( TifFileInfo fi, double[] GPImg)
        {
           string  dir = fi.Dir.Replace(".tif", "_GPImage.txt");

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(dir))
            {
                double[] buf = new double[fi.sizeX];
                for (int y = 0, position = 0; y < fi.sizeY; y++, position += fi.sizeX)
                {
                    Array.Copy(GPImg, position, buf, 0, fi.sizeX);
                    sw.WriteLine(string.Join("\t", buf));
                }
            }
        }
        private static int[] GetHistogram(double[] GPImg, double[] GPc)
        {
            int[] Cou = new int[256];

            foreach (double val in GPImg)
                if (val != -100)
                    for (int i = 0; i < GPc.Length; i++)
                        if (val <= GPc[i])
                        {
                            Cou[i]++;
                            break;
                        }

            return Cou;
        }
        private static double[] SmoothHistogram(int[] Cou)
        {
            double[] Smo = new double[256];

            for (int i = 0; i < Smo.Length; i++)
                if (i == 0)
                    Smo[i] = 0;
                else if (i == 255)
                    Smo[i] = 0;
                else
                    Smo[i] = (Cou[i - 1] + Cou[i] + Cou[i + 1]) / 3;

            return Smo;
        }
        
    }
}
