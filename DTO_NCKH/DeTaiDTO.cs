using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_NCKH
{
    public abstract class DeTaiDTO
    {
        #region Atribute
        private string gvHuongDan;
        private DateTime tgKetThuc;
        private string tenDeTai;
        private string truongNhom;
        private DateTime tgBatDau;
        public string GvHuongDan { get => gvHuongDan; set => gvHuongDan = value; }
        public DateTime TgKetThuc
        {
            get => tgKetThuc; set
            {
                if (value > DateTime.Now) tgKetThuc = DateTime.Now;
                else tgKetThuc = value;
            }
        }
        public string TenDeTai { get => tenDeTai; set => tenDeTai = value; }
        public string TruongNhom { get => truongNhom; set => truongNhom = value; }
        public DateTime TgBatDau
        {
            get => tgBatDau; set
            {
                if (value > DateTime.Now) tgBatDau = DateTime.Now;
                else tgBatDau = value;
            }
        }



        private double kinhPhi;
        public double KinhPhi { get => kinhPhi; set => kinhPhi = value; }
        #endregion


        #region Methods

        /*===Constructor===*/
        public DeTaiDTO()
        {
            TenDeTai = "";
            TruongNhom = "";
            GvHuongDan = "";
            TgBatDau = DateTime.Now;
            TgKetThuc = DateTime.Now;
        }
        public DeTaiDTO(string tenDeTai, string truongNhom, string gvHuongDan, DateTime tgBatDau, DateTime tgKetThuc)
        {
            TenDeTai = tenDeTai;
            TruongNhom = truongNhom;
            GvHuongDan = gvHuongDan;
            TgBatDau = tgBatDau;
            TgKetThuc = tgKetThuc;
        }

        /*===Abs methods===*/
        public abstract double TinhKinhPhi();


        /*===In/Out===*/
        public virtual string to_String()
        {
            if (KinhPhi == 0)
                TinhKinhPhi();
            return "\n\tĐề tài: " + TenDeTai + "\n" 
                + "-Giảng viên HD: " + GvHuongDan + "\n" + "-Trưởng nhóm: " + TruongNhom
                + "\n" + "-Kinh phí: " + KinhPhi
                + "\n" + "-Thời gian bắt đầu: " + TgBatDau.ToString("dd/MM/yyyy") + "\n" + "-Thời gian kết thúc: " + TgKetThuc.ToString("dd/MM/yyyy");
        }

        #endregion
    }
}