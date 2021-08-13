using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án_OOP
{
    class LockComputer
    {
        //Import Windows API library
        [DllImport("user32.dll")]
        public static extern void LockWorkStation();

        [DllImport("user32.dll")]
        public static extern int ExitWindowsEx(int uFlags, int dwReason);

        //Khoá Máy
        public void Lock()
        {
            LockWorkStation();           
        }

        //Restart
        public void Restart()
        {
            ExitWindowsEx(2, 0);            
        }

        //ShutDown
        public void Shutdown()
        {
            ExitWindowsEx(1, 0);            
        }

        //Hibernate
        public void Hibernate()
        {
            Application.SetSuspendState(PowerState.Hibernate, true, true);
        }
        //Log Off
        public void LogOff()
        {
            ExitWindowsEx(0, 0);            
        }
    }
}
