using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án_OOP
{
    public partial class FormTime : Form
    {
        LockComputer lockComputer = new LockComputer();
        Global global = new Global();

        private string strAction = null;
        private int intMinutes = 0;
        private int intSecond = 59;
        private bool boolMessage = false;
        public FormTime()
        {
            InitializeComponent();
        }


        //Chuyển Số Phút Thành Giờ : Phút

        private string ConvertTime(int intPhut)
        {
            intPhut = intPhut - 1;
            int intHour = intPhut / 60;
            int intMinute = intPhut - (60 * intHour);
            intSecond = intSecond - 1;

            //xử lý lúc thời gian giảm
            //khi minutes còn lớn hơn hay bằng không
            if (intSecond == 0)
            {
                intSecond = 59;
                intMinutes = intMinutes - 1;
                if (intMinutes <= 0)
                {
                    intSecond = 0;
                }
            }
            string strTime = intHour.ToString() + " : " + intMinute.ToString() + " : " + intSecond.ToString();
            return strTime;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 950;  // trì hoãn thời gian của timer giảm dần
            lblTime.Text = ConvertTime(intMinutes);
            if ((intMinutes == 0) && (intSecond == 0))
            {
                //khi có check thông báo thì
                //thòi gian đúng lúc 0 : 0 : 0 sẽ dừng lại và không thay đổi
                if (boolMessage)
                {
                    timer1.Enabled = false;
                    if (MessageBox.Show("Bạn Có Muốn " + strAction + " " + "Máy Tính Không ?", "Time Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Action(strAction);
                        lblTime.Text = "00 : 00 : 00";
                    }
                }
                //Lưu ý khi bạn thực hiện công việc mà
                //bạn không click check thông báo thì
                //công việc của bạn sẽ thực thi luôn không hiện gì hết
                //do đó, bạn không cần quan tâm tới trễ thời gian bạn đăt
                else
                {
                    Action(strAction);
                    lblTime.Text = "00 : 00 : 00";
                }
                //timer dừng lại cũng có thể hiểu là timer.Stop()
                timer1.Enabled = false;
            }
        }
        //Action
        private void Action(string str)
        {
            if (str == "Khoá Máy")
            {
                lockComputer.Lock();
            }
            else if (str == "Khởi Động Lại")
            {
                lockComputer.Restart();
            }
            else if (str == "Tắt Máy")
            {
                lockComputer.Shutdown();
            }
            else if (str == "Hibernate")
            {
                lockComputer.Hibernate();
            }
            else if (str == "Đăng xuất")
            {
                lockComputer.LogOff();
            }
        }

        private void mnHibernate_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có muốn bật chế độ ngủ đông ngay bây giờ không ?", "Hibernate", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                lockComputer.Hibernate();
            }
            
        }

        private void mnLock_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có muốn khóa máy ngay bây giờ không ?", "Lock Computer", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                lockComputer.Lock();
            }
            
        }

        private void mnRestart_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có muốn khởi động lại máy ngay bây giờ không ?", "Restart", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                lockComputer.Restart();
            }
            
        }

        private void mnShutdown_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có muốn tắt máy ngay bây giờ không ?", "Shutdown", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                lockComputer.Shutdown();
            }
            
        }

        private void mnExit_Click(object sender, EventArgs e)
        {            
             if (DialogResult.Yes == MessageBox.Show("Bạn muốn thoát chương trình ngay lúc này ?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
             {
                this.Close();
             }         
        }

        private void mnLogoff_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có muốn đăng xuất máy ngay bây giờ không ?", "Log Off", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                lockComputer.LogOff();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                //Giờ

                cbGio.Items.Clear();
                cbGio.Text = "";
                string strValueItem = null;
                for (int i = 0; i < 24; i++)
                {
                    if (i < 10)
                    {
                        strValueItem = "0" + i.ToString();
                    }
                    else
                    {
                        strValueItem = i.ToString();
                    }

                    cbGio.Items.Add(strValueItem);
                }

                //Phút

                cbPhut.Items.Clear();
                cbPhut.Text = "";
                for (int i = 0; i < 60; i++)
                {
                    if (i < 10)
                    {
                        strValueItem = "0" + i.ToString();
                    }
                    else
                    {
                        strValueItem = i.ToString();
                    }

                    cbPhut.Items.Add(strValueItem);
                }

                //Ngày

                dtpNgay.Text = DateTime.Now.ToShortDateString();

                //công việc

                cbHanhDong.Items.Clear();
                cbHanhDong.Text = "";
                cbHanhDong.Items.Add("Khoá Máy");
                cbHanhDong.Items.Add("Đăng xuất");
                cbHanhDong.Items.Add("Khởi Động Lại");
                cbHanhDong.Items.Add("Tắt Máy");
                cbHanhDong.Items.Add("Hibernate");

                //Time
                timer1.Enabled = false;

                // lblTime set lại
                lblTime.Text = " 00 : 00 : 00";

                //checkbox thông báo
                cbMessage.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                //Lấy Giờ Và Ngày Thực Hiện Công Việc 

                string strHour = null;
                string strDay = null;

                if ((cbGio.Text.Trim() != "") && (cbHanhDong.Text.Trim() != ""))
                {
                    if (cbPhut.Text.Trim() != "")
                    {
                        strHour = cbGio.Text.Trim() + ":" + cbPhut.Text.Trim() + " ";
                    }
                    else
                    {
                        strHour = cbGio.Text.Trim() + ":" + "00" + " ";
                    }
                    if (dtpNgay.Checked)
                    {
                        strDay = dtpNgay.Text.Trim();
                    }
                    else
                    {
                        strDay = DateTime.Now.ToShortDateString();
                        strDay = global.Convert_Day(strDay);
                    }

                    //Lấy Giờ Và Ngày Hệ Thống
                    string strSystemHour = null;
                    string strSystemTime = null;
                    strSystemHour = DateTime.Now.ToShortTimeString();
                    strSystemTime = DateTime.Now.ToShortDateString();
                    strSystemTime = global.Convert_Day(strSystemTime);

                    //Tính ra số phút còn lại 
                    intMinutes = global.ConvertHourToNumber(strHour, strSystemHour, strDay, strSystemTime);
                    if (intMinutes > 0)
                    {
                        //Lấy công việc muốn thực hiện
                        strAction = cbHanhDong.Text.Trim();

                        //Lấy boolMessageShutDown
                        if (cbMessage.Checked)
                        {
                            boolMessage = true;
                        }

                        timer1.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Thời gian muốn thực thi phải lớn hơn thời gian hiện tại", "Nhắc Nhở", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa thiết đặt thời gian hoặc công việc thực thi", "Nhắc Nhở", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fmShutdown_Load(object sender, EventArgs e)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;
            SetShortDate("MM/dd/yyyy");
        }

        //Format Date
        [DllImport("kernel32.dll")]
        private static extern uint GetUserDefaultLCID();
        [DllImport("kernel32.dll")]
        static extern bool SetLocaleInfo(uint Locale, uint LCType,
        string lpLCData);
        public const int LOCALE_SSHORTDATE = 0x1F;
        public const int LOCALE_SDATE = 0x1D;

        public static void SetShortDate(string strShortDate)
        {
            uint lngLCID;
            lngLCID = GetUserDefaultLCID();
            SetLocaleInfo(lngLCID, LOCALE_SSHORTDATE, strShortDate);
            SetLocaleInfo(lngLCID, LOCALE_SDATE, "/");
        }
    }
}
