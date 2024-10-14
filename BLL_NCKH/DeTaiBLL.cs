using DAL_NCKH;
using DTO_NCKH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_NCKH
{
    public class DeTaiBLL
    {

        DeTaiDAL dT;

        #region Methods
        public DeTaiBLL()
        {
            dT = new DeTaiDAL();
        }
        public DeTaiDAL DT { get => dT; set => dT = value; }

        public List<DeTaiDTO> DsDeTaiFile()
        {
            return dT.ReadFile("C:/IT/C/NCKH_3Layer/Data/DeTai_NCKH.xml");
        }

        public DeTaiDTO TimKiemDeTai(string tenDeTai, string gvHD, string truongNhom)
        {
            return dT.List_DeTai.Where(i => i.TenDeTai == tenDeTai).Where(j => j.GvHuongDan == gvHD).FirstOrDefault(l => l.TruongNhom == truongNhom);
        }

        public List<DeTaiDTO> DsDeTai_GvHD(string gvHD)
        {
            return dT.List_DeTai.Where(i => i.GvHuongDan == gvHD).ToList();
        }

        public List<DeTaiDTO> DsDeTaiTheoKinhPhi()
        {
            return dT.List_DeTai.Where(i => i.KinhPhi > 10000000).ToList();
        }


        public List<DeTaiDTO> DsDeTai_ThucTe_True()
        {
            List<DeTaiDTO> lstThucTe_True = new List<DeTaiDTO>();
            foreach (DeTaiDTO i in dT.List_DeTai)
            {
                if (i is NghienCuuLT_DTO nghienCuu_LT)
                {
                    if (nghienCuu_LT.ThucTe == true)
                    {
                        lstThucTe_True.Add(nghienCuu_LT);
                    }
                }
            }
            return lstThucTe_True;
        }

        public List<DeTaiDTO> DsDeTai_SoCauHoiKS_Tren100()
        {
            List<DeTaiDTO> lstCauHoiKS = new List<DeTaiDTO>();
            foreach (DeTaiDTO i in dT.List_DeTai)
            {
                if (i is KinhTe_DTO kinhTe)
                {
                    if (kinhTe.SoCauHoiKhaoSat > 100)
                    {
                        lstCauHoiKS.Add(kinhTe);
                    }
                }
            }
            return lstCauHoiKS;
        }

        public List<DeTaiDTO> DsDeTai_ThoiGian_Tren4Thang()
        {
            List<DeTaiDTO> lstTG_Tren4Thang = new List<DeTaiDTO>();
            foreach (var i in dT.List_DeTai)
            {
                if (i.TgKetThuc.Month - i.TgBatDau.Month > 4)
                {
                    lstTG_Tren4Thang.Add(i);
                }
            }
            return lstTG_Tren4Thang;
        }

        public List<DeTaiDTO> DsDeTai_KinhPhi_Tang()
        {
            return dT.CapNhat_KinhPhi();
        }
        #endregion
    }
}
