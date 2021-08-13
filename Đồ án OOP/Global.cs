using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án_OOP
{
    class Global
    {
        SumDayOfYear sumDay = new SumDayOfYear();

        //Chuyển Đổi Giờ Qua Số

        public int ConvertHourToNumber(string strEmployeeHour, string strSystemHour, string strEmployeeDay, string strSystemDay)
        {
            //Lấy phép trừ 2 ngày 
            int intEmployeeDay = sumDay.SumDay(Convert.ToInt32(getYear(strEmployeeDay)), Convert.ToInt32(getMonth(strEmployeeDay)), Convert.ToInt32(getDay(strEmployeeDay)));
            int intSystemDay = sumDay.SumDay(Convert.ToInt32(getYear(strSystemDay)), Convert.ToInt32(getMonth(strSystemDay)), Convert.ToInt32(getDay(strSystemDay)));
            int intSubtractDay = - intSystemDay + intEmployeeDay;

            //Tính Thời Gian Employee
            string strGetEmployeeHour = getHour(strEmployeeHour);
            string strGetEmployeeMinutes = getMinute(strEmployeeHour);
            int intEmployeeTime = Convert.ToInt32(strGetEmployeeHour) * 60 + Convert.ToInt32(strGetEmployeeMinutes);

            //Tính Thời Gian Của Hệ Thống
            string strGetSystemHour = getHour(strSystemHour);
            if (strGetSystemHour == "12")
            {
                strGetSystemHour = "00";
            }
            string strGetSystemMinutes = getMinute(strSystemHour);
            string strGetSystemPeriod = getPeriod(strSystemHour);
            int intSystemPeriod = 0;
            if ((strGetSystemPeriod == "PM") || (strGetSystemHour == "CH"))
            {
                intSystemPeriod = 12 * 60;
            }
            if ((strGetSystemPeriod == "AM") || (strGetSystemHour == "SA"))
            {
                intSystemPeriod = 0;
            }
            int intSystemTime = Convert.ToInt32(strGetSystemHour) * 60 + Convert.ToInt32(strGetSystemMinutes) + intSystemPeriod;

            //Đổi Giờ
            int intConvertHourToNumber = (intEmployeeTime - intSystemTime) + (intSubtractDay * 24 * 60);
            return intConvertHourToNumber;
        }

        //Hàm Lấy Giờ Trong Chuỗi

        public string getHour(string str)
        {
            int intColon = str.IndexOf(":");
            string strHour = str.Substring(0, intColon);
            return strHour;
        }

        //Hàm Lấy Phút Trong Chuỗi

        public string getMinute(string str)
        {
            int intColon = str.IndexOf(":");
            int intSpace = str.IndexOf(" ");
            string strMinute = str.Substring(intColon + 1, intSpace - intColon - 1);
            return strMinute;
        }

        //Hàm Lấy Buổi 

        public string getPeriod(string str)
        {
            int intSpace = str.IndexOf(" ");
            string strPeriod = str.Substring(intSpace + 1, str.Length - intSpace - 1);
            return strPeriod;
        }

        //Hàm Lấy Ngày Trong Chuỗi dd/mm/yyyy

        public string getDay(string str)
        {
            int intFirstSymbol = str.IndexOf("/");
            string strDay = str.Substring(0, intFirstSymbol);
            return strDay;
        }

        //Hàm Lấy Tháng Trong Chuỗi dd/mm/yyyy

        public string getMonth(string str)
        {
            int intFirstSymbol = str.IndexOf("/");
            int intSecondSymbol = str.IndexOf("/", intFirstSymbol + 1);
            string strMonth = str.Substring(intFirstSymbol + 1, intSecondSymbol - intFirstSymbol - 1);
            return strMonth;
        }

        //Hàm Lấy Năm Trong Chuỗi dd/mm/yyyy

        public string getYear(string str)
        {
            try
            {
                int intFirstSymbol = str.IndexOf("/"); // 3
                int intSecondSymbol = str.IndexOf("/", intFirstSymbol + 1); // '/', 4 == 6
                string strYear = str.Substring(intSecondSymbol + 1, str.Length - intSecondSymbol - 1); // 7, 2 == 19
                return strYear;
            }
            catch
            {
                return "";
            }
        }

        //Hàm Chuyển Đổi Ngày Tháng Năm Thành Tháng Ngày Năm Hoặc Ngược lại

        public string Convert_Day(string strDay)
        {
            try
            {
                string str1 = strDay.Substring(0, 3);
                string str2 = strDay.Substring(3, 3);
                string str3 = strDay.Substring(6, 4);
                return str2 + str1 + str3;
            }
            catch
            {
                return null;
            }
        }
    }
}
