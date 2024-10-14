using DTO_NCKH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_NCKH
{
    public class NghienCuuLT_DTO : DeTaiDTO
    {
        private Boolean thucTe;

        public NghienCuuLT_DTO() : base()
        {
            ThucTe = false;
        }

        public NghienCuuLT_DTO(bool thucTe, string tenDeTai, string truongNhom, string gvHuongDan, DateTime tgBatDau, DateTime tgKetThuc)
            : base(tenDeTai, truongNhom, gvHuongDan, tgBatDau, tgKetThuc)
        {
            ThucTe = thucTe;
        }

        public bool ThucTe { get => thucTe; set => thucTe = value; }

        /*Abstract method*/
        public override double TinhKinhPhi()
        {
            if (ThucTe == true) KinhPhi = 15000000;
            else KinhPhi = 8000000;
            return KinhPhi;
        }

        public override string to_String()
        {
            return base.to_String() + "\n" + "-Áp dụng thực tế: " + ThucTe;
        }
    }
}
