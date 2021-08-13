using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án_OOP
{
    public enum Direction { Left, Right, Up, Down };
    public partial class fmGame1 : Form
    {
        private Bitmap ImageFile;
        private int cellSize;
        private int CELL_COUNT;
        private int emptyCellIndex;
        private int imageSize;
        private int khoangCach = 2;
        private string fileName= Application.StartupPath + "\\anh.bmp";
        private List<PictureBox> anhGoc = new List<PictureBox>();        
        private List<PictureBox> anhNen = new List<PictureBox>();  
        
        public fmGame1()
        { 
            InitializeComponent();
            doKho(4);
        }
        private void MnMo_Click(object sender, EventArgs e)
        {
            panelNen.Visible = true;
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Image Files|*.bmp;*.jpg;*.gif;*.png";        
            if (dlgOpen.ShowDialog() == DialogResult.OK)             
            {
                fileName = dlgOpen.FileName;   
                LoadAnhGoc();                       
                LoadAnhNen(Application.StartupPath + "\\xam.jpg");
                TronAnh();
                mnTronAnh.Enabled = true;
            }
        }
        private void MnTronAnh_Click(object sender, EventArgs e)
        {
            int viTriCuoi = 0;
            int diemCuoi = CELL_COUNT * CELL_COUNT - 1;
            panelNen.Visible = false;
            moLbl();
            TronAnh();
            for (int i = 0; i < diemCuoi + 1; i++)
            {
                if (anhGoc[i].Tag.ToString() == diemCuoi.ToString())
                {
                    viTriCuoi = i;
                    break;
                }
            }
            anhGoc[viTriCuoi].Image = anhGoc[diemCuoi].Image;
            anhGoc[viTriCuoi].Tag = anhGoc[diemCuoi].Tag;
            anhGoc[diemCuoi].Tag = diemCuoi;
            anhGoc[diemCuoi].Image = null;
            int size = cellSize * CELL_COUNT + khoangCach * (CELL_COUNT - 1);
            int kichThuoc = 150;
            panelGoc.Location = new Point(12, 14);
            panelGoc.Size = new Size(size, size);
            this.Size = new Size(size + 185, size + kichThuoc + 100 + 24);
            pbAnhGoc.Location = new Point((size + 185) / 2 - (kichThuoc / 2), size + 60);
            gbAnhGoc.Location = new Point(0, size + 33);
        }
        private void LoadAnhNen(string fileName)
        {
            if (!System.IO.File.Exists(fileName))   
            {
                MessageBox.Show("Không tìm thấy file \n" + fileName, "Lỗi tìm FILE!", MessageBoxButtons.OK, MessageBoxIcon.Error);         
                return;                            
            }
            try
            {
                Bitmap bmp = new Bitmap(fileName);
                ImageFile = new Bitmap(bmp, new Size((int)imageSize, (int)imageSize));
                cellSize = imageSize / CELL_COUNT;
                //                catAnh(anhNen);
                Common.catAnh(anhNen, ImageFile, CELL_COUNT, cellSize, 0, 0, khoangCach);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadAnhGoc()
        {
            if (!System.IO.File.Exists(fileName))
            {
                MessageBox.Show("Không tìm thấy file \n" + fileName, "Lỗi tìm FILE!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Bitmap bmp = new Bitmap(fileName);
                float minSize;
                float width, height;
                if (bmp.Size.Width < bmp.Size.Height)
                    minSize = bmp.Size.Width;
                else
                    minSize = bmp.Size.Height;
                width = bmp.Size.Width;
                height = bmp.Size.Height;
                float heso = 350 / minSize;
                if (heso > 0)
                {
                    width *= heso;
                    height *= heso;
                }
                ImageFile = new Bitmap(bmp, new Size((int)width, (int)height));
                if (ImageFile.Width < ImageFile.Height)
                    imageSize = ImageFile.Width;
                else
                    imageSize = ImageFile.Height;
                imageSize -= imageSize % CELL_COUNT;
                cellSize = imageSize / CELL_COUNT;
                int kichThuoc = 150;
                Rectangle imageRect = new Rectangle(0, 0, imageSize, imageSize);
                Bitmap anhGocc = ImageFile.Clone(imageRect, PixelFormat.DontCare);
                pbAnhGoc.Image = new Bitmap(anhGocc, new Size(kichThuoc, kichThuoc));
                Common.catAnh(anhGoc, ImageFile, CELL_COUNT, cellSize, 0, 0, khoangCach);
                emptyCellIndex = CELL_COUNT * CELL_COUNT - 1;
                // Làm việc với vị trí và kich thước
                int size = cellSize * CELL_COUNT + khoangCach * (CELL_COUNT - 1);
                panelNen.Size = new Size(size, size);
                panelGoc.Size = new Size(size, size);
                this.Size = new Size(size * 2 + 185, size + kichThuoc + 100 + 24);
                pbAnhGoc.Location = new Point((size * 2 + 185) / 2 - (kichThuoc / 2), size + 60);
                gbAnhGoc.Location = new Point(0, size + 33);
                panelGoc.Location = new Point(size + 158, 14);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TronAnh()
        {
            Common.TronAnh(anhGoc, CELL_COUNT);
            mnTronAnh.Enabled = false;
        }
        // gọi lbl left, right, up, down sau đó nó gọi hàm lblMove_Click(đối tượng, empty) ktra các thứ: tắt trộn, các nút có thể sử dụng nếu đc thì thi hành 
        // các phép tính định vị lại PictureBox null và hoán đổi thích hợp, cuối cùng kiểm tra hình ghép hoàn chỉnh chưa nếu xong thông báo đã hoàn thành
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Up)
                lblMove_Click(lblUp, EventArgs.Empty);
            else if (keyData == Keys.Down)
                lblMove_Click(lblDown, EventArgs.Empty);
            else if (keyData == Keys.Left)
                lblMove_Click(lblLeft, EventArgs.Empty);
            else if (keyData == Keys.Right)
                lblMove_Click(lblRight, EventArgs.Empty);

            return base.ProcessDialogKey(keyData);
        }
        private void lblMove_Click(object sender, EventArgs e)
        {
            if (mnTronAnh.Enabled==true)
            {
                MessageBox.Show("Bạn hãy nhấn F3 để trộn ảnh!!!");
                return;
            }
            Bitmap tempBmp;
            int indexToSwap = -1;
            if (sender == lblLeft)
            {
                if (IsMoveValid(Direction.Left))
                {
                    indexToSwap = emptyCellIndex + 1;
                }
            }
            if (sender == lblRight)
            {
                if (IsMoveValid(Direction.Right))
                {
                    indexToSwap = emptyCellIndex - 1;
                }
            }
            if (sender == lblUp)
            {
                if (IsMoveValid(Direction.Up))
                {
                    indexToSwap = emptyCellIndex + CELL_COUNT;
                }
            }
            if (sender == lblDown)
            {
                if (IsMoveValid(Direction.Down))
                {
                    indexToSwap = emptyCellIndex - CELL_COUNT;
                }
            }
            if (indexToSwap != -1)
            {
                try
                {
                    tempBmp = (Bitmap)anhGoc[indexToSwap].Image;
                    tempBmp.Tag = anhGoc[indexToSwap].Tag;
                    anhGoc[indexToSwap].Image = anhGoc[emptyCellIndex].Image;
                    anhGoc[indexToSwap].Tag = anhGoc[emptyCellIndex].Tag;
                    anhGoc[emptyCellIndex].Image = tempBmp;
                    anhGoc[emptyCellIndex].Tag = tempBmp.Tag;
                    emptyCellIndex = indexToSwap;
                }
                catch (Exception)
                {
                }
            }
            if (CheckFinish())
            {
                MessageBox.Show("Bạn đã hoàn thành!!!", "WINNER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public bool IsMoveValid(Direction direct)
        {
            bool isValid = false;
            switch (direct)
            {
                case Direction.Left:
                    isValid = (emptyCellIndex % CELL_COUNT != (CELL_COUNT - 1));//(15%4==4-1)false
                    break;
                case Direction.Right:
                    isValid = (emptyCellIndex % CELL_COUNT != 0);//(12%4==0)false
                    break;
                case Direction.Up:
                    isValid = (emptyCellIndex < CELL_COUNT * CELL_COUNT - CELL_COUNT);//(x<16-4=12)flase
                    break;
                case Direction.Down:
                    isValid = (emptyCellIndex > CELL_COUNT - 1);//(x>4-1=3)flase
                    break;
            }
            return isValid;
        }
        private bool CheckFinish()
        {
            for (int i = 0; i < anhGoc.Count; i++)
            {
                if (anhGoc[i].Tag.ToString() != i.ToString())
                    return false;
            }
            return true;
        }
        private void lblMove_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.Wheat;
        }

        private void lblUp_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.Transparent;
        }
        private void doKho(int x)
        {
            PictureBox A = null;
            anhNen.RemoveRange(0, CELL_COUNT * CELL_COUNT);
            anhGoc.RemoveRange(0, CELL_COUNT * CELL_COUNT);
            panelNen.Controls.Clear();
            panelGoc.Controls.Clear();
            CELL_COUNT = x;
            emptyCellIndex = CELL_COUNT * CELL_COUNT - 1;
            for (int i = 0; i < CELL_COUNT * CELL_COUNT; i++)
            {
                anhNen.Add(A);
                anhGoc.Add(A);
            }  
            for (int i = 0; i < anhGoc.Count; i++)
            {
                anhNen[i] = new PictureBox();
                panelNen.Controls.Add(anhNen[i]);
                anhGoc[i] = new PictureBox();
                panelGoc.Controls.Add(anhGoc[i]);
            }
            LoadAnhGoc();
            LoadAnhNen(Application.StartupPath + "\\xam.jpg");
            TronAnh();
            mnTronAnh.Enabled = true;
            panelNen.Visible = true;
            dongLbl();
        }
        private void MnDoKho1_Click(object sender, EventArgs e)
        {
            doKho(4);
        }
        private void MnDoKho2_Click(object sender, EventArgs e)
        {
            doKho(5);
        }
        private void MnDoKho3_Click(object sender, EventArgs e)
        {
            doKho(6);
        }
        private void MnDoKho4_Click(object sender, EventArgs e)
        {
            doKho(8);
        }
        private void dongLbl()
        {
            lblDown.Visible = false;
            lblUp.Visible = false;
            lblRight.Visible = false;
            lblLeft.Visible = false;
        }
        private void moLbl()
        {
            lblDown.Visible = true;
            lblUp.Visible = true;
            lblRight.Visible = true;
            lblLeft.Visible = true;
        }
        private void ChoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doKho(CELL_COUNT);
        }
        private void ThoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
