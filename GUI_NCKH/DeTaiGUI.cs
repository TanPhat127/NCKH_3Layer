using BLL_NCKH;
using DTO_NCKH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_NCKH
{
    internal class DeTaiGUI
    {
        DeTaiBLL dT = new DeTaiBLL();
        List<DeTaiDTO> lstDeTai = new List<DeTaiDTO>();

        #region Methods
        public DeTaiGUI()
        {
        }

        public DeTaiBLL DT { get => dT; set => dT = value; }
        public List<DeTaiDTO> LstDeTai { get => lstDeTai; set => lstDeTai = value; }


        /*Nhap danh sach*/
        public void NhapDeTai()
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            DeTaiDTO dT;
            int loai;
            Console.WriteLine();
            Console.WriteLine("1.Nghiên cứu LT.\n2.Kinh tế.\n3.Công nghệ.");
            do
            {
                Console.Write("Loại đề tài: "); loai = int.Parse(Console.ReadLine());
            }
            while (!(loai == 1 || loai == 2 || loai == 3));
            Console.Write("Tên đề tài: "); string tenDeTai = Console.ReadLine();
            Console.Write("Giảng viên HD: "); string tenGV = Console.ReadLine();
            Console.Write("Trưởng nhóm: "); string tenTruongNhom = Console.ReadLine();
            Console.Write("Thời gian bắt đầu: "); DateTime tgBatDau = DateTime.Parse(Console.ReadLine());
            Console.Write("Thời gian kết thúc: "); DateTime tgKetThuc = DateTime.Parse(Console.ReadLine());
            if (true)
            {
                if (loai == 1)
                {
                    int tinhThucTe;
                    Boolean ktThucTe;
                    Console.WriteLine("---------\n1.Có\n0.Không\n---------");
                    do
                    {
                        Console.Write("Tinh thực tế: ");
                        tinhThucTe = int.Parse(Console.ReadLine());
                    } while (!(tinhThucTe == 1 || tinhThucTe == 0));
                    if (tinhThucTe == 1) ktThucTe = true;
                    else ktThucTe = false;
                    dT = new NghienCuuLT_DTO(ktThucTe, tenDeTai, tenTruongNhom, tenGV, tgBatDau, tgKetThuc);
                    LstDeTai.Add(dT);
                }
                else if (loai == 2)
                {
                    Console.Write("Số câu hỏi khảo sát: "); int soCau = int.Parse(Console.ReadLine());
                    dT = new KinhTe_DTO(soCau, tenDeTai, tenTruongNhom, tenGV, tgBatDau, tgKetThuc);
                    LstDeTai.Add(dT);
                }
                else
                {
                    Console.Write("Môi trường: "); string moiTruong = Console.ReadLine();
                    dT = new CongNghe_DTO(moiTruong, tenDeTai, tenTruongNhom, tenGV, tgBatDau, tgKetThuc);
                    LstDeTai.Add(dT);
                }
            }
        }

        /*Xuat danh sach*/
        public void XuatFile()
        {
            Console.OutputEncoding = Encoding.Unicode;
            LstDeTai = dT.DsDeTaiFile();
            try
            {
                Console.WriteLine();
                Console.WriteLine("\t\t===Danh sách đề tài===");
                foreach (var i in LstDeTai)
                {
                    Console.WriteLine(i.to_String());
                }
            }
            catch (Exception)
            {
                Console.WriteLine("NULL!!!");
            }
        }

        public void XuatDS()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine();
            Console.WriteLine("\t\t===Danh sách đề tài===");
            foreach (var i in LstDeTai)
            {
                Console.WriteLine(i.to_String());
            }
        }


        public void XuatDS_DT_GvHD(string gvHD)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine();
            Console.WriteLine("\t\t===Danh sách đề tài theo tên giảng viên hướng dẫn===");
            List<DeTaiDTO> lst = dT.DsDeTai_GvHD(gvHD);
            foreach (var i in lst)
            {
                Console.WriteLine(i.to_String());
            }
        }

        public void XuatDS_DT_KinhPhi()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine();
            Console.WriteLine("\t\t===Danh sách đề tài kinh phí hơn 10 triệu===");
            List<DeTaiDTO> lst = dT.DsDeTaiTheoKinhPhi();
            foreach (var i in lst)
            {
                Console.WriteLine(i.to_String());
            }
        }

        public void XuatDS_ThucTe()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine();
            Console.WriteLine("\t\t===Danh sách đề tài nghiên cứu lý thuyết có khả năng đi vào thực tế===");
            List<DeTaiDTO> lst = dT.DsDeTai_ThucTe_True();
            foreach (var i in lst)
            {
                Console.WriteLine(i.to_String());
            }
        }

        public void XuatDS_KS()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine();
            Console.WriteLine("\t\t===Danh sách đề tài kinh tế có số câu hỏi khảo sát trên 100 câu===");
            List<DeTaiDTO> lst = dT.DsDeTai_SoCauHoiKS_Tren100();
            foreach (var i in lst)
            {
                Console.WriteLine(i.to_String());
            }
        }

        public void XuatDS_ThoiGian_ThucHien()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine();
            Console.WriteLine("\t\t===Danh sách đề tài có thời gian thực hiện trên 4 tháng===");
            List<DeTaiDTO> lst = dT.DsDeTai_ThoiGian_Tren4Thang();
            foreach (var i in lst)
            {
                Console.WriteLine(i.to_String());
            }
        }

        public void DT_TimKiem(string tenDT, string gvHD, string truongNhom)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine();
            Console.WriteLine("\t\t===Đề tài cần tìm===");
            DeTaiDTO deTaiTK = dT.TimKiemDeTai(tenDT, gvHD, truongNhom);
            Console.WriteLine(deTaiTK.to_String());
        }

        public void XuatDS_TangKinhPhi()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("\t\t===Cập nhât kinh phi danh sách 10%===");
            LstDeTai = dT.DsDeTaiTheoKinhPhi();
            foreach (var i in LstDeTai)
            {
                Console.WriteLine(i.to_String());
            }
        }
        #endregion
    }
}
