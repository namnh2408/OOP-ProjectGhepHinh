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
    public partial class fmGame2 : Form
    {
        #region Properties
        private Bitmap ImageFile;
        private int cellSize;
        private int CELL_COUNT=0;
        private int ktraKhungRed = 0;
        private string fileName= Application.StartupPath + "\\anh.bmp";
        private List<PictureBox> anhGoc=new List<PictureBox>();
        // tọa độ để xác định vị trí các khung ảnh sẽ tạo ra
        private int OffSetX;
        private int OffSetY;
        /// <summary>
        /// Vị trí chuột trên khung ảnh khi bắt đầu khi bắt đầu drag
        /// Dùng để điều chỉnh vị trí chuột luôn tương đối với khung ảnh
        /// </summary>
        private Point startDragPoint;

        /// <summary>
        /// Vị trí khung ảnh gốc khi bắt đầu drag
        /// dùng để hoán đổi vị trí ảnh nếu 2 ảnh mới đè lên ảnh cũ 
        /// </summary>
        private Point picLocation;

        #endregion
        #region Form

        public fmGame2()
        {
            InitializeComponent();
            doKho(4);
        }
        void doKho(int x)
        {
            PictureBox A = null;
            for (int i = 0; i < CELL_COUNT * CELL_COUNT; i++)
               panel1.Controls.Remove(anhGoc[i]);
            anhGoc.RemoveRange(0,CELL_COUNT*CELL_COUNT);
            panelImage.Controls.Clear();
            panelImage.Invalidate();
            CELL_COUNT = x;
            for (int i = 0; i < CELL_COUNT * CELL_COUNT; i++)
                anhGoc.Add(A);
            for (int i = 0; i < anhGoc.Count; i++)
            {
                anhGoc[i] = new PictureBox();
                anhGoc[i].MouseUp += new MouseEventHandler(picCell_MouseUp);
                anhGoc[i].MouseMove += new MouseEventHandler(picCell_MouseMove);
                anhGoc[i].MouseDown += new MouseEventHandler(picCell_MouseDown);
                panel1.Controls.Add(anhGoc[i]);
            }
            // Thêm sự kiện vẽ lưới vào sự kiện Paint của panel Image
            panelImage.Paint += new PaintEventHandler(DrawGrid);
            LoadPicture();
            mnTronAnh.Enabled = true;
        }

        #endregion

        #region Function

        /// <summary>
        /// Sự kiện vẽ lưới cho panel Image
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="pe"></param>
        void DrawGrid(object obj, PaintEventArgs pe)
        {
            Graphics g = panelImage.CreateGraphics();
            Pen p = Pens.White;
            int length = cellSize * CELL_COUNT;
            for (int i = 0; i <= CELL_COUNT; i++)
            {
                int pos = cellSize * i;
                // Vẽ lưới ngang
                Point p1 = new Point(0, pos);
                Point p2 = new Point(length, pos);
                g.DrawLine(p, p1, p2);
                // Vẽ lưới dọc
                p1 = new Point(pos, 0);
                p2 = new Point(pos, length);
                g.DrawLine(p, p1, p2);
            }

        }

        /// <summary>
        ///  Load ảnh
        /// </summary>
        /// <param name="fileName"></param>
        private void LoadPicture()
        {
            if (!System.IO.File.Exists(fileName))
            {
                MessageBox.Show("Không tìm thấy file \n" + fileName);
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
                int imageSize;
                ImageFile = new Bitmap(bmp, new Size((int)width, (int)height));
                if (ImageFile.Width < ImageFile.Height)
                    imageSize = ImageFile.Width;
                else
                    imageSize = ImageFile.Height;
                imageSize -= imageSize % CELL_COUNT;
                cellSize = imageSize / CELL_COUNT;
                // Tạo và sắp xếp các khung ảnh
                int kichThuoc = 150;
                int size = cellSize * CELL_COUNT + 3;
                OffSetX = size+117;
                OffSetY = 0;
                Common.catAnh(anhGoc, ImageFile, CELL_COUNT, cellSize, OffSetX, OffSetY, 0);
                // Xáo trộn các khung ảnh
                MnTronAnh_Click(null, null);
                Rectangle imageRect = new Rectangle(0, 0, imageSize, imageSize);
                Bitmap anhGocc = ImageFile.Clone(imageRect, PixelFormat.DontCare);
                pbAnhGoc.Image = new Bitmap(anhGocc, new Size(kichThuoc, kichThuoc));
                // Tính toán vị trí
                panelImage.Size = new Size(size, size);
                this.Size = new Size(size * 2 + 130, size + kichThuoc + 100 + 24);
                pbAnhGoc.Location = new Point((size * 2 + 130) / 2 - (kichThuoc / 2), size + 60);
                lblKhunXepAnh.Location = new Point(size/2-88, size/2-19);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        #endregion

        #region Menu Event
        private void MnMo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.RestoreDirectory = true;
            dlgOpen.Filter = "JPEG Files(*.jpg)|*.jpg|Bitmap Files(*.bmp)|*.bmp|GIF Files(*.gif)|*.gif|All Files|*.*";
            dlgOpen.FilterIndex = 1; // Để làm gì???
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                fileName = dlgOpen.FileName;
                LoadPicture();
                mnTronAnh.Enabled = true;
            }
        }
        private void MnTronAnh_Click(object sender, EventArgs e)
        {
            Common.TronAnh(anhGoc, CELL_COUNT);
            mnTronAnh.Enabled = false;
        }
        #endregion

        #region Drag Drop Picture
        private void picCell_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            // Di chuyển khung ảnh theo chuột khi kéo
            if (e.Button == MouseButtons.Left)
            {
                pic.Location = new Point(pic.Left + e.X - startDragPoint.X,
                    pic.Top + e.Y - startDragPoint.Y);
            }
            // Tính vị trí dòng và cột với đơn vị là 1 CELL_SIZE
            int col = pic.Location.X / cellSize;
            int row = pic.Location.Y / cellSize;
            // Nếu nằm ngoài panel Image thì thoát hàm
            if (col >= CELL_COUNT || row >= CELL_COUNT)
                return;
            // Vẽ đường biên màu đỏ xác định vị trí mới của ảnh trên panel
            if (ktraKhungRed==1)
            {
                Graphics g = panelImage.CreateGraphics();
                g.DrawRectangle(Pens.Red, new Rectangle(col * cellSize, row * cellSize, cellSize, cellSize));
            }
        }

        private void picCell_MouseDown(object sender, MouseEventArgs e)
        {
            if (mnTronAnh.Enabled == true)
                MessageBox.Show("Bạn hãy nhấn F3 để trộn ảnh!!!");
            // Khi nhấn chuột và khung ảnh
            // ta sẽ lưu vị trí nhấn chuột và vị trí khung ảnh lại
            PictureBox pic = (PictureBox)sender;
            startDragPoint = e.Location;

            picLocation = pic.Location;
            // Đưa khung ảnh lên trên cùng để ko bị che mất
            pic.BringToFront();
            ktraKhungRed = 1;
        }
        // thả chuột 
        private void picCell_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            // Tính vị trí mới của ảnh khít với dòng, cột trên panel
            int col = pic.Location.X / cellSize;
            int row = pic.Location.Y / cellSize;
            if (col >= CELL_COUNT || row >= CELL_COUNT)
                return;
            // Lấy control tại ví trí mới
            Control ctl = panel1.GetChildAtPoint(new Point(col * cellSize+1, row * cellSize+1));
            // Nếu đã có một khung ảnh tại ô này
            // thì chuyển vị trí của khung ảnh này về vị trí của khung ảnh vừa drop
            if (ctl != null && ctl is PictureBox)
            {
                ctl.Location = picLocation;
            }
            // Gán vị trí mới cho khung ảnh
            pic.Location = new Point(col * cellSize+1, row * cellSize+1);

            if (CheckWin)
            {
                MessageBox.Show("Bạn đã hoàn thành !!!","WINNER",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            ktraKhungRed = 0;
        }

        #endregion 

        /// <summary>
        /// Kiểm tra thắng, viết theo dạng set/get
        /// </summary>
        private bool CheckWin
        {
            // Phương pháp:
            // Lặp qua tất cả các cột và dòng trong panel Image
            // Lấy khung ảnh tại vị trí dòng, cột đó
            // Nếu khung ảnh ko tồn tại trả về false
            // Nếu khung ảnh có vị trí sai thứ tự trả về false
            get
            {
                for (int i = 0; i < CELL_COUNT; i++)
                {
                    for (int j = 0; j < CELL_COUNT; j++)
                    {
                        // Tính thứ tự đúng của khung ảnh ở vị trí hiện tại
                        int index = i * CELL_COUNT + j;
                        // Lấy control tại vị trí hiện tại
                        Control ctl = panel1.GetChildAtPoint(new Point(j * cellSize+1, i * cellSize+1));
                        // Nếu khung ảnh ko tồn tại trả về false
                        if (ctl == null || !(ctl is PictureBox))
                            return false;
                        // Nếu khung ảnh có vị trí sai trả về false
                        if (ctl.Tag.ToString() != index.ToString())
                            return false;
                    }
                }
                return true;
            }
        }

        private void DoKho1_Click(object sender, EventArgs e)
        {
            doKho(4);
        }

        private void DoKho2_Click(object sender, EventArgs e)
        {
            doKho(5);
        }

        private void DoKho3_Click(object sender, EventArgs e)
        {
            doKho(6);
        }

        private void DoKho4_Click(object sender, EventArgs e)
        {
            doKho(8);
        }
        private void MnChoiLai_Click(object sender, EventArgs e)
        {
            doKho(CELL_COUNT);
        }
        private void MnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
