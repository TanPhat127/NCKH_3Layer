using BLL_NCKH;
using DTO_NCKH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_NCKH
{
    internal class Program
    {
        public static void Menu()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("\t\tMenu:");
            Console.WriteLine("1. Đọc danh sách các đề tài từ file XML");
            Console.WriteLine("2. Thêm mới 1 đề tài từ bàn phím");
            Console.WriteLine("3. Xuất danh sách các đề tài");
            Console.WriteLine("4. Tìm kiếm đề tài");
            Console.WriteLine("5. Xuất danh sách đề tài theo giảng viên hướng dẫn");
            Console.WriteLine("6. Cập nhật kinh phí thực hiện của các đề tài tăng lên 10%");
            Console.WriteLine("7. Xuất danh sách các đề tài có kinh phí trên 10 triệu");
            Console.WriteLine("8. Xuất danh sách các đề tài thuộc lĩnh vực nghiên cứu lý thuyết và có khả năng triển khai vào thực tế");
            Console.WriteLine("9. In ra danh sách đề tài có số câu hỏi khảo sát trên 100 câu");
            Console.WriteLine("10. In ra danh sách đề tài có thời gian thực hiện trên 4 tháng");
            Console.WriteLine("0. Thoát");
        }
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            DeTaiBLL dT1 = new DeTaiBLL();
            DeTaiGUI dT = new DeTaiGUI();
            int n, chon = -1;
            while (chon != 0)
            {
                Menu();
                Console.Write("\t---> "); chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1: dT.XuatFile(); break;
                    case 2: dT.NhapDeTai(); break;
                    case 3: dT.XuatDS(); break;
                    case 4:
                        Console.Write("Tên đề tại: "); string tenDT = Console.ReadLine();
                        Console.Write("Tên giảng viên HD: "); string gvHD = Console.ReadLine();
                        Console.Write("Tên trưởng nhóm: "); string truongNhom = Console.ReadLine();
                        dT.DT_TimKiem(tenDT, gvHD, truongNhom);
                        break;
                    case 5:
                        Console.WriteLine("Tên giảng viên HD: "); string gvHuongDan = Console.ReadLine();
                        dT.XuatDS_DT_GvHD(gvHuongDan);
                        break;
                    case 6: dT.XuatDS_TangKinhPhi(); break;
                    case 7: dT.XuatDS_DT_KinhPhi(); break;
                    case 8: dT.XuatDS_ThucTe(); break;
                    case 9: dT.XuatDS_KS(); break;
                    case 10: dT.XuatDS_ThoiGian_ThucHien(); break;
                    default:
                        Console.WriteLine("===>Thoát<===");
                        break;
                }
            }
        }
    }
}
