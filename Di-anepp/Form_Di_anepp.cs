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
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using CellToolDK;

namespace Di_anepp
{
    public partial class Form_Di_anepp : Form
    {
        public Form_Di_anepp(TifFileInfo fi, Transmiter t)
        {
            InitializeComponent();

            this.fi = fi;
            this.t = t;
            this.FormClosing += Form_Closing;
            this.Panel_Border.Resize += Panel_Border_Resize;
            LoadSettings();

        }
        private void Panel_Border_Resize(object sender, EventArgs e)
        {
            panel_Img.Width = Panel_Border.Width / 2;
            chart1.Height = Panel_Border.Height / 2;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
                textBox_Gfactor.Enabled = checkBox1.Checked;
        }
        private void LoadSettings()
        {
            string[] imagesTitles = new string[fi.sizeC];
            for (int i = 0; i < imagesTitles.Length;)
                imagesTitles[i] = "Channel " + (i++);

            comboBox_Disordered.Items.Clear();
            comboBox_Disordered.Items.AddRange(imagesTitles);
            comboBox_Disordered.SelectedIndex = 1;

            comboBox_Ordered.Items.Clear();
            comboBox_Ordered.Items.AddRange(imagesTitles);
            comboBox_Ordered.SelectedIndex = 0;

            if (!ReadXml()) ReadXml("fromFile");

            RefreshData();
        }
        private void RefreshData()
        {
            /// <summary>
            /// Used Literature:
            /// Owen, Dylan & Rentero, Carles & Magenau, Astrid & Abu siniyeh, Ahmed & Gaus, Katharina. (2011). 
            /// Quantitative imaging of membrane lipid order in cells and organisms.Nature protocols. 
            /// 7. 24-35. 10.1038/nprot.2011.419.
            /// </summary>

            ordImg = Di_anepp_Processing.GetImage(comboBox_Ordered.SelectedIndex,fi);
            disordImg = Di_anepp_Processing.GetImage(comboBox_Disordered.SelectedIndex, fi);

            if (checkBox1.Checked && Gf != 1)
            {
                disordImg = Di_anepp_Processing.Apply_Gfactor(disordImg, Gf);
                Gf1 = Gf;
            }
            else Gf1 = 1;

            GP = Di_anepp_Processing.Get_GPArray();
            GPc = Di_anepp_Processing.Get_GPcArray(GP,Gf1);
            GPImg = Di_anepp_Processing.Get_GPImage(ordImg, disordImg, threshold);

            double[] NAvDist = Di_anepp_Processing.HistogramGeneration(dataGridView1,GPImg, GP, GPc, fi.Dir);
            LoadChart(NAvDist);
            LoadBitmap();
            LoadColorBar();
            //Di_anepp_Processing.WriteImageAsTxt(fi, GPImg);

        }
        private void LoadChart(double[] NAvDist)
        {
            chart1.ChartAreas[0].AxisY.Title = "Norm Av Dist";
            chart1.ChartAreas[0].AxisX.Title = "GPc";
            chart1.ChartAreas[0].AxisX.Minimum = -1;
            chart1.ChartAreas[0].AxisX.Maximum = +1;
            chart1.ChartAreas[0].AxisX.Interval = 0.2;

            chart1.Series[0].Points.Clear();

            for (int i = 0; i < NAvDist.Length; i++)
                    chart1.Series[0].Points.AddXY(GPc[i], NAvDist[i]);
        }
        private void LoadColorBar()
        {
            #region Create LUT
            double B = double.Parse(textBox_Brightness.Text);

            Color[] LUT = new Color[pictureBox2.Width];

            int stop = pictureBox2.Width;
            double step = (double)250 / (stop);
            double val = 0;
            for (int i = stop - 1; i >= 0; i--, val += step)
                LUT[i] = MyColorTranslator.ColorFromHSV(val, 1, B);
            
            #endregion Create LUT

            Bitmap bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);

            BitMapEditor.LockBitmap bmpEditor = new BitMapEditor.LockBitmap(bmp);
            bmpEditor.LockBits();

            for (int y = 0, pointer = 0; y < bmpEditor.Height; y++)
                for (int x = 0; x < bmpEditor.Width; x++, pointer++)
                    bmpEditor.SetPixel(x, y, LUT[x]);
           
            bmpEditor.UnlockBits();
            pictureBox2.Image = bmp;

            //vals
            {
                double start = double.Parse(textBox_Min.Text);
                double increment = (double.Parse(textBox_Max.Text) - start) / 4;

                label_val_1.Text = Math.Round(start, 2).ToString();
                start += increment;
                label_val_2.Text = Math.Round(start, 2).ToString();
                start += increment;
                label_val_3.Text = Math.Round(start, 2).ToString();
                start += increment;
                label_val_4.Text = Math.Round(start, 2).ToString();
                label_val_5.Text = Math.Round(double.Parse(textBox_Max.Text), 1).ToString();
            }
            //width
            {
                double start = pictureBox2.Location.X;
                double increment = pictureBox2.Width / 4;

                label_val_1.Location = new Point((int)start - TextRenderer.MeasureText(label_val_1.Text, label_val_1.Font).Width / 2, label_val_1.Location.Y);
                start += increment;
                label_val_2.Location = new Point((int)start - TextRenderer.MeasureText(label_val_2.Text, label_val_2.Font).Width / 2, label_val_1.Location.Y);
                start += increment;
                label_val_3.Location = new Point((int)start - TextRenderer.MeasureText(label_val_3.Text, label_val_3.Font).Width / 2, label_val_1.Location.Y);
                start += increment;
                label_val_4.Location = new Point((int)start - TextRenderer.MeasureText(label_val_4.Text, label_val_4.Font).Width / 2, label_val_1.Location.Y);
                start += increment;
                label_val_5.Location = new Point((int)start - TextRenderer.MeasureText(label_val_5.Text, label_val_5.Font).Width / 2, label_val_1.Location.Y);
            }
        }
        private int DoubleToHue(double val)
        {
            for (int i = 0; i < GPc.Length; i++)
                if (val <= GPc[i])
                    return i;

            return 0;
        }
        private void LoadBitmap()
        {
            #region Create LUT
            double B = double.Parse(textBox_Brightness.Text);

            Color[] LUT = new Color[256];
            
            int start = DoubleToHue(double.Parse(textBox_Min.Text));
            int stop = DoubleToHue(double.Parse(textBox_Max.Text));

            for (int i = 0; i < start; i++)
                LUT[i] = MyColorTranslator.ColorFromHSV(255, 1, B);

            for (int i = stop; i < 256; i++)
                LUT[i] = MyColorTranslator.ColorFromHSV(0, 1, B);

            double step = (double)250/(stop - start);
           
            double val = 0;
            for (int i = stop - 1; i >= start; i--, val += step)
                LUT[i] = MyColorTranslator.ColorFromHSV(val, 1, B);
            
            //for (int b = 255, g = 0; g < 256; g++, b--)
                //LUT[g] = Color.FromArgb(0, g, b);
            #endregion Create LUT

            Bitmap bmp = new Bitmap(fi.sizeX, fi.sizeY);

            BitMapEditor.LockBitmap bmpEditor = new BitMapEditor.LockBitmap(bmp);
            bmpEditor.LockBits();

            for (int y = 0, pointer = 0; y < bmpEditor.Height; y++)
                for (int x = 0; x < bmpEditor.Width; x++, pointer++)
                    if (GPImg[pointer] == -100)
                        bmpEditor.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    else
                        for (int i = 0; i < GPc.Length; i++)
                            if (GPImg[pointer] <= GPc[i])
                            {
                                bmpEditor.SetPixel(x, y, LUT[i]);
                                break;
                            }
            /*
            bmpEditor.SetPixel(x, y, MyColorTranslator.ColorFromHSV(((GPImg[pointer] + 1) / 2)*360, 1, 1));
            //bmpEditor.SetPixel(x, y, MyColorTranslator.FromAhsb(255,(float)((GPImg[pointer] + 1) / 2) * 360, 1.0f, 1.0f));

for (int y = 0, pointer = 0; y < 255; y++)
    for (int x = 0; x < bmpEditor.Width; x++, pointer++)
        bmpEditor.SetPixel(x, y, MyColorTranslator.ColorFromHSV(y, 1, 1));
//bmpEditor.SetPixel(x, y, MyColorTranslator.FromAhsb(255, (float)y, 1.0f, 1.0f));
/*

for (int i = 0; i < GPc.Length; i++)
    if (GPImg[pointer] <= GPc[i])
    {
        bmpEditor.SetPixel(x, y, LUT[i]);
        break;
    }*/

            bmpEditor.UnlockBits();

            pictureBox1.Width = fi.sizeX;
            pictureBox1.Height = fi.sizeY;
            pictureBox1.Image = bmp;
        }
        private void button_Refresh_Click(object sender, EventArgs e)
        {
            Gf = double.Parse(textBox_Gfactor.Text);
            threshold = double.Parse(textBox_Threshold.Text);
            RefreshData();
        }
        private bool ReadXml(string input = "")
        {
            if (input == "")
            {
                if (!(fi.FileDescription.IndexOf("\n<plugin info - Di-anepp>") > -1)) return false;
                if (!(fi.FileDescription.IndexOf("</plugin info - Di-anepp>") > -1)) return false;

                input = fi.FileDescription.Substring(fi.FileDescription.IndexOf("\n<plugin info - Di-anepp>") +
                    ("\n<plugin info - Di-anepp>").Length, fi.FileDescription.IndexOf("</plugin info - Di-anepp>") -
                    fi.FileDescription.IndexOf("\n<plugin info - Di-anepp>") -
                    ("\n<plugin info - Di-anepp>").Length
                    );
            }
            else 
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\CellToolPlugIns\\Di-anepp.xml";
                if (File.Exists(path))
                    try
                    {
                        input = File.ReadAllText(path);
                    }
                    catch { return false; }
                else
                    return false;
            }

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(input);
            XmlNodeList nodelist = xDoc.SelectNodes("/Di-anepp_root"); // get all <testcase> nodes
            
            foreach (XmlNode node in nodelist) // for each <testcase> node
            {
                try
                {
                    string OrderedChannel = node.SelectSingleNode("OrderedChannel").InnerText;
                    string DisorderedChannel = node.SelectSingleNode("DisorderedChannel").InnerText;
                    string Threshold = node.SelectSingleNode("Threshold").InnerText;
                    string UseGfactor = node.SelectSingleNode("UseGfactor").InnerText;
                    string Gfactor = node.SelectSingleNode("Gfactor").InnerText;
                    string LUT_min = node.SelectSingleNode("LUT_min").InnerText;
                    string LUT_max = node.SelectSingleNode("LUT_max").InnerText;
                    string LUT_brightness = node.SelectSingleNode("LUT_brightness").InnerText;

                    if (int.Parse(OrderedChannel) < comboBox_Ordered.Items.Count)
                        comboBox_Ordered.SelectedIndex = int.Parse(OrderedChannel);

                    if (int.Parse(DisorderedChannel) < comboBox_Disordered.Items.Count)
                        comboBox_Disordered.SelectedIndex = int.Parse(DisorderedChannel);

                    textBox_Threshold.Text = Threshold;
                    checkBox1.Checked = bool.Parse(UseGfactor);
                    textBox_Gfactor.Text = Gfactor;
                    textBox_Min.Text = LUT_min;
                    textBox_Max.Text = LUT_max;
                    textBox_Brightness.Text = LUT_brightness;

                    Gf = double.Parse(textBox_Gfactor.Text);
                    threshold = double.Parse(textBox_Threshold.Text);
                    Gf1 = double.Parse(textBox_Gfactor.Text);

                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error in reading XML", "xmlError", MessageBoxButtons.OK);
                    return false;
                }
            }
            return false;
        }
        private void button_Store_Click(object sender, EventArgs e)
        {
            XmlDocument xDoc = new XmlDocument();

            xDoc.AppendChild(xDoc.CreateElement("Di-anepp_root"));

            string[] NodeArray = {
                "OrderedChannel|" + comboBox_Ordered.SelectedIndex,
                "DisorderedChannel|" + comboBox_Disordered.SelectedIndex,
                "Threshold|" + textBox_Threshold.Text,
                "UseGfactor|" + checkBox1.Checked,
                "Gfactor|" + textBox_Gfactor.Text,
                "LUT_min|" + textBox_Min.Text,
                "LUT_max|" + textBox_Max.Text,
                "LUT_brightness|" + textBox_Brightness.Text,
            };

            foreach (string node in NodeArray)
            {
                XmlNode xmlNode = xDoc.CreateNode(XmlNodeType.Element, node.Split('|')[0], null);
                //xmlNode.Value = node.Split('|')[0];
                xmlNode.InnerText = node.Split('|')[1];
                xDoc.DocumentElement.AppendChild(xmlNode);
            }

            string fiDes = fi.FileDescription;


            if (fi.FileDescription.IndexOf("\n<plugin info - Di-anepp>") > -1)
                fiDes = fi.FileDescription.Substring(0, 
                    fi.FileDescription.IndexOf("\n<plugin info - Di-anepp>"));
            
            if (fi.FileDescription.IndexOf("</plugin info - Di-anepp>") > -1)
                fiDes += fi.FileDescription.Substring(
                    fi.FileDescription.IndexOf("</plugin info - Di-anepp>") + ("</plugin info - Di-anepp>").Length);

            fiDes += "\n<plugin info - Di-anepp>" + XmlToString(xDoc) + "</plugin info - Di-anepp>";

            fi.FileDescription = fiDes;
            t.ReloadImage();
            //Load to settings file
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\CellToolPlugIns";
            try
            {
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                path += "\\Di-anepp.xml";

                File.WriteAllText(path, XmlToString(xDoc));
            }
            catch { }
            //export images and histogram
            ExportDataToDrive();
        }
        private void ExportDataToDrive()
        {
            try
            {
                string dir = fi.Dir.Substring(0, fi.Dir.Length - 4) + "_Results";

                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                //Draw GP image
                Bitmap bmp = (Bitmap)pictureBox1.Image;
                bmp.Save(dir + @"\GPImage.bmp");
                //Draw LUT bar
                bmp = new Bitmap(panel_LUT.Width, panel_LUT.Height);
                panel_LUT.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save(dir + @"\LUT.bmp");
                //Write histogram
                using (StreamWriter write = new StreamWriter(File.Create(dir + @"\Histogram.txt")))
                {
                    string str = "";
                    int row = dataGridView1.Rows.Count;
                    int cell = dataGridView1.Rows[1].Cells.Count;

                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        str += dataGridView1.Columns[i].Name + "\t";

                    write.WriteLine(str);

                    for (int i = 0; i < row; i++)
                    {
                        str = "";
                        for (int j = 0; j < cell; j++)
                        {
                            if (dataGridView1.Rows[i].Cells[j].Value == null)
                            {
                                dataGridView1.Rows[i].Cells[j].Value = "null";
                            }
                            str += dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t";
                        }
                        write.WriteLine(str);
                    }

                    write.Close();
                    write.Dispose();
                }
                //Write GP image vals

                using (StreamWriter write = new StreamWriter(File.Create(dir + @"\GPImage.txt")))
                {
                    string str = "";
                    string[] strLine = new string[fi.sizeX];
                    string[] rdyGPimage = new string[GPImg.Length];

                    for (int i = 0; i < GPImg.Length; i++)
                        if (GPImg[i] == -100)
                            rdyGPimage[i] = "-1";
                        else
                            rdyGPimage[i] = GPImg[i].ToString();

                    for (int i = 0; i < GPImg.Length; i += fi.sizeX)
                    {
                        Array.Copy(rdyGPimage, i, strLine, 0, fi.sizeX);
                        write.WriteLine(string.Join("\t", strLine));
                    }

                    strLine = null;
                    rdyGPimage = null;
                    write.Close();
                    write.Dispose();
                }

                MessageBox.Show("Results are saved!");
            }
            catch
            {
                MessageBox.Show("Error! Results are NOT saved!");
            }
        }
        private string XmlToString(XmlDocument xmlDoc)
        {
            using (var stringWriter = new StringWriter())
            using (var xmlTextWriter = XmlWriter.Create(stringWriter))
            {
                xmlDoc.WriteTo(xmlTextWriter);
                xmlTextWriter.Flush();
                return stringWriter.GetStringBuilder().ToString();
            }
        }

        private TifFileInfo fi;
        private Transmiter t;

        private double[] ordImg;
        private double[] disordImg;
        private double[] GPImg;
        private double[] GP;
        private double[] GPc;

        private double Gf = 1;
        private double threshold = 15;
        private double Gf1 = 1;

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            OnDispose();
        }
        private void OnDispose()
        {
            fi = null;
            t = null;
            ordImg = null;
            disordImg = null;
            GPImg = null;
            GP = null;
            GPc = null;
        }

        private void Form_Di_anepp_Load(object sender, EventArgs e)
        {

        }
    }
}
