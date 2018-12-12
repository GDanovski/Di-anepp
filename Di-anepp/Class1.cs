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
/// 

using CellToolDK;

namespace Di_anepp
{
    public class Main
    {
        private Transmiter t;
        private TifFileInfo fi;

        private void ApplyChanges()
        {
            //Apply changes and reload the image
            t.ReloadImage();
        }

        public void Input(TifFileInfo fi, Transmiter t)
        {
            this.t = t;
            this.fi = fi;
            //Main entrance

            if (fi == null)
            {
                System.Windows.Forms.MessageBox.Show(
                    "There is no opened image!");
                return;
            }

            if (fi.bitsPerPixel != 8)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Convert the image to 8-bit!");
                return;
            }

            if (fi.sizeT != 1)
            {
                System.Windows.Forms.MessageBox.Show(
                    "The image must contain only 1 time slice!");
                return;
            }

            if (fi.sizeZ != 1)
            {
                System.Windows.Forms.MessageBox.Show(
                    "The image must contain only 1 Z slice!");
                return;
            }

            if (fi.sizeC<2)
            {
                System.Windows.Forms.MessageBox.Show(
                    "The image must contain at least 1 ordered and 1 disordered channel!");
                return;
            }

            Form_Di_anepp myForm = new Form_Di_anepp(fi,t);
            myForm.Show();
        }
    }
}
