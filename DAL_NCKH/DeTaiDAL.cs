using DTO_NCKH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL_NCKH
{
    public class DeTaiDAL
    {
        #region Atributes
        List<DeTaiDTO> list_DeTai = new List<DeTaiDTO>();

        public DeTaiDAL()
        {
        }

        public List<DeTaiDTO> List_DeTai { get => list_DeTai; set => list_DeTai = value; }
        #endregion

        #region Methods

        /*Doc file xml*/
        public List<DeTaiDTO> ReadFile(string file)
        {
            Console.InputEncoding = Encoding.Unicode;
            try
            {
                XmlDocument docXML = new XmlDocument();
                docXML.Load(file);
                XmlNodeList nodeList = docXML.SelectNodes("/NCKH/DsDeTai/DeTai");
                foreach (XmlNode node in nodeList)
                {
                    DeTaiDTO dT;
                    int loai = int.Parse(node.Attributes["loai"].InnerText);
                    string tenDeTai = node["TenDeTai"].InnerText;
                    string gvHD = node["GvHD"].InnerText;
                    string truongNhom = node["TruongNhom"].InnerText;
                    DateTime tgBD = DateTime.Parse(node["TgBD"].InnerText);
                    DateTime tgKT = DateTime.Parse(node["TgKT"].InnerText);
                    if (loai == 1)
                    {
                        Boolean thucTe = Boolean.Parse(node["ThucTe"].InnerText);
                        dT = new NghienCuuLT_DTO(thucTe, tenDeTai, truongNhom, gvHD, tgBD, tgKT);
                        List_DeTai.Add(dT);
                    }
                    else if (loai == 2)
                    {
                        int soCauHoiKS = int.Parse(node["CauHoiKhaoSat"].InnerText);
                        dT = new KinhTe_DTO(soCauHoiKS, tenDeTai, truongNhom, gvHD, tgBD, tgKT);
                        List_DeTai.Add(dT);
                    }
                    else
                    {
                        string moiTruong = node["MoiTruong"].InnerText;
                        dT = new CongNghe_DTO(moiTruong, tenDeTai, truongNhom, gvHD, tgBD, tgKT);
                        List_DeTai.Add(dT);
                    }
                }
                return List_DeTai;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /*Cap nhat kinh phi*/
        public List<DeTaiDTO> CapNhat_KinhPhi()
        {
            foreach (var i in List_DeTai)
            {
                i.KinhPhi = i.TinhKinhPhi() * 1.1;
            }
            return List_DeTai;
        }
        #endregion
    }
}

