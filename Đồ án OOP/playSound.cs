using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections;

namespace Đồ_án_OOP
{
    public class playSound
    {
        private string PlayCommand;
        private bool isOpen;
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr oCallback);
        public void OpenMediaFile(string strFileName)
        {

            if (!System.IO.File.Exists(strFileName))
            {
                MessageBox.Show("Không tìm thấy file \n" + strFileName, "Lỗi tìm FILE!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (strFileName != null)
                {
                    PlayCommand = "Open \"" + strFileName + "\" alias MediaFile";
                    mciSendString(PlayCommand, null, 0, IntPtr.Zero);
                    isOpen = true;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public void PlayMediaFile(bool loop)
        {
            if (isOpen)
            {
                PlayCommand = "Play MediaFile";
                if (loop)
                    PlayCommand += " REPEAT";
                mciSendString(PlayCommand, null, 0, IntPtr.Zero);
            }
        }
        public void ClosePlayer()
        {
            PlayCommand = "Close MediaFile";
            mciSendString(PlayCommand, null, 0, IntPtr.Zero);
            isOpen = false;
        }
    }
}
