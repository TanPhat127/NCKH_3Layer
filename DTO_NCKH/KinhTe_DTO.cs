using DTO_NCKH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_NCKH
{
    public class KinhTe_DTO : DeTaiDTO, KinhPhiHoTro
    {
        private int soCauHoiKhaoSat;

        public KinhTe_DTO() : base()
        {
            soCauHoiKhaoSat = 0;
        }

        public KinhTe_DTO(int soCauHoiKhaoSat, string tenDeTai, string truongNhom, string gvHuongDan, DateTime tgBatDau, DateTime tgKetThuc)
            : base(tenDeTai, truongNhom, gvHuongDan, tgBatDau, tgKetThuc)
        {
            SoCauHoiKhaoSat = soCauHoiKhaoSat;
        }

        public int SoCauHoiKhaoSat { get => soCauHoiKhaoSat; set => soCauHoiKhaoSat = value; }

        /*Interface method*/

        public double HoTro()
        {
            if (SoCauHoiKhaoSat > 100) return 550;
            else return 450;
        }

        /*Abstract method*/

        public override double TinhKinhPhi()
        {
            if (SoCauHoiKhaoSat > 100) KinhPhi = 12000000;
            else KinhPhi = 7000000;
            return KinhPhi;
        }

        public override string to_String()
        {
            return base.to_String() + "\n" + "-Phí hỗ trợ: " + HoTro() + "\n" + "-Số câu hỏi khảo sát: " + SoCauHoiKhaoSat;
        }
    }
}
