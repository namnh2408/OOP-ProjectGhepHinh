using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_OOP
{
    class SumDayOfYear
    {
        public int SumDay(int intNam, int intThang, int intNgay)
        {
            int intSoNam = ((intNam - 1) * 365) + ((intNam - 1) / 4);
            int i;
            if (intNam % 4 == 0)
            {
                i = 1;
            }
            else
            {
                i = 0;
            }
            int Thang1 = 31;
            int Thang2 = Thang1 + 28 + i;
            int Thang3 = Thang2 + 31;
            int Thang4 = Thang3 + 30;
            int Thang5 = Thang4 + 31;
            int Thang6 = Thang5 + 30;
            int Thang7 = Thang6 + 31;
            int Thang8 = Thang7 + 31;
            int Thang9 = Thang8 + 30;
            int Thang10 = Thang9 + 31;
            int Thang11 = Thang10 + 30;
            int Thang12 = Thang11 + 31;
            int intSoThang = intThang - 1;

            switch (intSoThang)
            {
                case 0: intSoThang = 0; break;
                case 1: intSoThang = Thang1; break;
                case 2: intSoThang = Thang2; break;
                case 3: intSoThang = Thang3; break;
                case 4: intSoThang = Thang4; break;
                case 5: intSoThang = Thang5; break;
                case 6: intSoThang = Thang6; break;
                case 7: intSoThang = Thang7; break;
                case 8: intSoThang = Thang8; break;
                case 9: intSoThang = Thang9; break;
                case 10: intSoThang = Thang10; break;
                case 11: intSoThang = Thang11; break;
            }

            return intSoNam + intSoThang + intNgay;
        }
    }
}
