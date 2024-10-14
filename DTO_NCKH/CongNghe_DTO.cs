using DTO_NCKH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_NCKH
{
    public class CongNghe_DTO : DeTaiDTO, KinhPhiHoTro
    {

        private string moiTruong;
        public string MoiTruong { get => moiTruong; set
            {
                if (value == "Web" || value == "Window" || value == "Mobile") moiTruong = value;
                else moiTruong = "Window";
            }
        }

        #region Methods
        public CongNghe_DTO() : base()
        {
            MoiTruong = null;
        }
        public CongNghe_DTO(string moiTruong, string tenDeTai, string truongNhom, string gvHuongDan, DateTime tgBatDau, DateTime tgKetThuc)
            : base(tenDeTai, truongNhom, gvHuongDan, tgBatDau, tgKetThuc)
        {
            MoiTruong = moiTruong;
        }

        /*Abstract method*/
        public override double TinhKinhPhi()
        {
            if (MoiTruong == "Window") KinhPhi = 10000000;
            else KinhPhi = 15000000;
            return KinhPhi;
        }
        public override string to_String()
        {
            return base.to_String() + "\n" + "-Phí hỗ trợ: " + HoTro() + "\n" + "-Môi trường: " + MoiTruong;
        }

        /*Interface method*/
        public double HoTro()
        {
            if (MoiTruong == "Mobile") return 1000000;
            else if (MoiTruong == "Web") return 800000;
            else return 500000;
        }
        #endregion
    }
}
