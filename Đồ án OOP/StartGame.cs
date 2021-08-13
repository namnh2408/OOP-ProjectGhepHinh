using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án_OOP
{
    public partial class StartGame : Form
    {
        int ktraAmThanh = 1;
        playSound ps = new playSound();
        public StartGame()
        {
            InitializeComponent();
            BtnAmThanh_Click(null, null);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            new fmGame1().Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            new fmGame2().Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            new FormTime().Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnMove_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.LightPink;
        }
        private void btnUp_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.White;
        }

        private void BtnAmThanh_Click(object sender, EventArgs e)
        {
            if(ktraAmThanh==1)
            {
                ps.OpenMediaFile("NhacNen.mp3");//ten bai hat.đinh dangcbai hat(bai hat phai di kem voi file exe)
                ps.PlayMediaFile(true);
                btnAmThanh.Text = "Tắt Âm Thanh";
                ktraAmThanh = 0;
            }
            else
            {
                ps.ClosePlayer();
                btnAmThanh.Text = "Bật Âm Thanh";
                ktraAmThanh = 1;
            }
            
        }
    }
}
