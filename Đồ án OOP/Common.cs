using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Đồ_án_OOP
{
    public class Common
    {
        public static void TronAnh(List<PictureBox> anhGoc, int CELL_COUNT)
        {
            Bitmap bmp;
            Random rnd = new Random();
            int maxValue = CELL_COUNT * CELL_COUNT;
            for (int i = 0; i < maxValue; i++)
            {
                int indexSource = rnd.Next(maxValue);
                int indexDest = rnd.Next(maxValue);
                if (indexSource == indexDest)
                    continue;
                try
                {
                    bmp = (Bitmap)anhGoc[indexSource].Image;
                    bmp.Tag = anhGoc[indexSource].Tag.ToString();
                    anhGoc[indexSource].Image = anhGoc[indexDest].Image;
                    anhGoc[indexSource].Tag = anhGoc[indexDest].Tag;
                    anhGoc[indexDest].Image = bmp;
                    anhGoc[indexDest].Tag = bmp.Tag;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public static void catAnh(List<PictureBox> anhGoc, Bitmap ImageFile, int CELL_COUNT,int cellSize,int OffSetX,int OffSetY,int khoangCach)
        {

            if (ImageFile != null)
            {
                int cellIndex = 0;
                for (int j = 0; j < CELL_COUNT; j++)
                {
                    for (int i = 0; i < CELL_COUNT; i++)
                    {
                        try
                        {
                            Rectangle imageRect = new Rectangle(i * cellSize, j * cellSize, cellSize, cellSize);
                            anhGoc[cellIndex].Image = null;
                            anhGoc[cellIndex].Image = ImageFile.Clone(imageRect, PixelFormat.DontCare);
                            anhGoc[cellIndex].Location = new Point(OffSetX + i * (cellSize+khoangCach), OffSetY + j *(cellSize+khoangCach));
                            anhGoc[cellIndex].Size = new Size(cellSize, cellSize);
                            anhGoc[cellIndex].Tag = cellIndex.ToString();
                            cellIndex++;
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                    }
                }
            }
        }
    }
}