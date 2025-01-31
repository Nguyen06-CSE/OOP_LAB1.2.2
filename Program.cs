using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LAB1._2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int n = 0;
            //int soMenu = 30;
            //int chon;
            List<int> ds = new List<int>();
            //do
            //{
            //    XuatMenu();
            //    chon = ChonMenu(soMenu);
            //    XuLyMenu(chon, ref n, ds);
            //} while (chon != 0);
            NhapNgauNhien(ds, 10);
            Xuat(ds);
            LeTang_ChanGiuNguyen(ds);
            Xuat(ds);
        }


        static void XuatMenu()
        {
            Console.WriteLine("____________________MENU_____________________");
            Console.WriteLine("0.\tthoat khoi chuong trinh ");
            Console.WriteLine("1.\tSắp xếp mảng theo thứ tự tăng dần.\r\n2.\tSắp xếp mảng theo thứ tự giảm dần.\r\n3.\tSắp xếp chỉ các phần tử lẻ theo thứ tự tăng dần, giữ nguyên vị trí các phần tử chẵn.\r\n4.\tTìm phần tử lớn thứ hai trong mảng.\r\n5.\tTìm phần tử nhỏ thứ hai trong mảng.\r\n6.\tTìm cặp phần tử có tổng bằng x.\r\n7.\tTìm phần tử có tổng của các chữ số lớn nhất.\r\n8.\tTìm giá trị lớn nhất nhưng không phải là phần tử cuối cùng.\r\n9.\tTìm tất cả các cặp phần tử có hiệu là số nguyên tố.\r\n10.\tXoá phần tử đầu tiên lớn hơn x.\r\n11.\tChèn phần tử x vào sao cho mảng vẫn tăng dần.\r\n12.\tChèn phần tử x vào đầu mảng.\r\n13.\tXoá tất cả các phần tử có giá trị lớn hơn x.\r\n14.\tXoá tất cả các số nguyên tố trong mảng.\r\n15.\tTìm vị trí đầu tiên của phần tử lớn nhất.\r\n16.\tTìm vị trí của phần tử nhỏ nhất cuối cùng.\r\n17.\tĐếm số lượng phần tử lớn hơn phần tử đứng trước nó.\r\n18.\tĐếm số lượng phần tử nhỏ hơn phần tử đứng sau nó.\r\n19.\tTìm phần tử có giá trị nhỏ nhất nhưng không phải số âm.\r\n20.\tĐếm số lần hoán đổi tối thiểu để sắp xếp mảng.\r\n21.\tTìm phần tử xuất hiện nhiều nhất trong mảng.\r\n22.\tSắp xếp mảng để phần tử lớn nhất nằm ở đầu và phần tử nhỏ nhất nằm cuối.\r\n23.\tXoá phần tử tại vị trí k.\r\n24.\tTìm tất cả các số chẵn liên tiếp có hiệu bằng d.\r\n25.\tTìm vị trí của phần tử nhỏ nhất trong một mảng tăng dần.\r\n26.\tKiểm tra xem hai mảng có chứa phần tử chung hay không.\r\n27.\tTách mảng thành hai mảng con: mảng chẵn và mảng lẻ.\r\n28.\tKiểm tra xem một mảng đã được sắp xếp chưa.\r\n29.\tTìm số chẵn nhỏ nhất lớn hơn một số cho trước.\r\n30.\tTìm phần tử xuất hiện ít nhất trong mảng.\r\n");

        }

        static int ChonMenu(int soMenu)
        {
            int chon;

            do
            {
                Console.Write($"Nhập chọn [0....{soMenu}]: ");
                chon = int.Parse(Console.ReadLine());
                if (chon >= 0 && chon <= soMenu)
                {
                    break;
                }
            } while (true);
            return chon;
        }

        static void XuLyMenu(int chon, ref int n, List<int> ds)
        {
            int x;
            switch (chon)
            {
                case 0:
                    Console.WriteLine("Thoát khỏi chương trình");
                    break;
                case 1:
                    SapTang(ds);
                    Xuat(ds);
                    break;
                case 2:
                    SapGiam(ds);
                    Xuat(ds);
                    break;
                case 3:
                    LeTang_ChanGiuNguyen(ds);
                    Xuat(ds);
                    break;
                case 4:
                    Console.Write("phan tu lon thu hai trong mang la: " + TimPhanTuLonThuHai(ds));
                    break;
                case 5:
                    Console.Write("phan tu nho thu hai trong mang la: " + TimPhanTuNhoThuHai(ds));

                    break;
                case 6:
                    Console.Write("Nhap gia tri x ban muon: ");
                    x = int.Parse(Console.ReadLine());
                    List<(int, int)> capPhanTu = TimCapCoTongBangX(ds, x);
                    XuLyChucNang(capPhanTu);
                    
                    break;
                case 7:
                    Console.Write("Phan tu co tong cac chu so lon nhat la: " + TimPTCoTongCacChuSoLonNhat(ds));
                    break;
                case 8:

                    int pt = TimGiaTriLonNhatNhungKhongPhaiCuoi(ds);
                    if (pt == -1)
                    {
                        Console.Write("Phan tu lon nhat nhung ko phai la phan tu cuoi cung khong co trong mang");
                    }
                    else      Console.Write("Phan tu lon nhat nhung ko phai la phan tu cuoi cung la: " + pt);
                    break;
                case 9:
                    List<(int, int)> capPhanTuCoHieuLaSoNT = TimCacCapCoHieuLaSoNT(ds);
                    XuLyChucNang(capPhanTuCoHieuLaSoNT);

                    break;
                case 10:
                    Console.Write("Nhap gia tri x ban muon: ");
                    x = int.Parse(Console.ReadLine());
                    XoaPTDauTienLonHonX(ds, x);
                    Console.WriteLine("mang sau khi xoa phan tu dau tien lon hon x la: ");
                    Xuat(ds);


                    break;
                case 11:
                    Console.Write("Nhap gia tri x ban muon: ");
                    x = int.Parse(Console.ReadLine());
                    
                    Xuat(ChenPhanTuXSaoChoMangVanTangDan(ds, x));
                    break;
                case 12:
                    Console.Write("Nhap gia tri x ban muon: ");
                    x = int.Parse(Console.ReadLine());
                    Xuat(ChenXVaoDauMang(ds, x));
                    break;
                case 13:
                    Console.Write("Nhap gia tri x ban muon: ");
                    x = int.Parse(Console.ReadLine());
                    Console.Write("mang sau khi coa cac phan tu co gia tri lon hon x la: ");
                    Xuat(XoaCacPTLonHonX(ds, x));

                    break;
                case 14:
                    Console.WriteLine("mang sau khi xoa tat ca cac so NT la: ");
                    Xuat(XoaCacSoNT(ds));
                    break;
                case 15:

                    break;
                case 15:

                    break;

                default:
                    break;
            }
            Console.ReadKey();
        }

        static void Nhap(List<int> ds)
        {
            Console.WriteLine("nhap so phan tu");
            var dem = int.Parse(Console.ReadLine());
            for (int i = 0; i < dem; i++)
            {
                Console.Write("nhap vao phan tu thu {0}: ", i); // Sử dụng Console.Write thay vì Console.WriteLine
                ds.Add(int.Parse(Console.ReadLine()));
            }
        }

        static void NhapNgauNhien(List<int> ds, int k)
        {

            Random random = new Random();
            for (int i = 0; i < k; i++)
            {
                ds.Add(random.Next(10));
            }
        }

        static void Xuat(List<int> ds)
        {
            foreach (int i in ds)
            {
                Console.Write($"{i}" + '\t');
            }
            Console.WriteLine();
        }

        static void HoanVi(List<int> ds, int i, int j)
        {
            int tmp = ds[i];
            ds[i] = ds[j];
            ds[j] = tmp;
        }

        static void SapTang(List<int> ds)
        {
            for(int i = 0; i < ds.Count - 1; i++)
            {
                for (int j = i+1; j < ds.Count; j++)
                {
                    if (ds[j] < ds[i])
                    {
                        HoanVi(ds, i, j);
                    }
                }
            }
        }
        static void SapGiam(List<int> ds)
        {
            for (int i = 0; i < ds.Count - 1; i++)
            {
                for (int j = i + 1; j < ds.Count; j++)
                {
                    if (ds[j] > ds[i])
                    {
                        HoanVi(ds, i, j);
                    }
                }
            }
        }

        static void LeTang_ChanGiuNguyen(List<int> ds)
        {
            for (int i = 0; i < ds.Count - 1; i++)
            {
                for (int j = i + 1; j < ds.Count; j++)
                {
                    if (ds[i] % 2 == 1 && ds[j] % 2 == 1 && ds[i] > ds[j])
                    {
                        HoanVi(ds, i, j);
                    }
                }
            }
        }

        static int TimPhanTuLonThuHai(List<int> ds)
        {
            SapTang(ds);
            return ds[ds.Count - 1];
        }

        static int TimPhanTuNhoThuHai(List<int> ds)
        {
            SapGiam(ds);
            return ds[ds.Count - 1];
        }

        

        static List<(int, int)> TimCapCoTongBangX(List<int> ds, int x)
        {
            List<(int, int)> result = new List<(int, int)>();

            for (int i = 0; i < ds.Count - 1; i++)
            {
                for (int j = i + 1; j < ds.Count; j++)
                {
                    if (ds[i] + ds[j] == x)
                    {
                        result.Add((ds[i], ds[j]));
                    }
                }
            }
            return result;
        }

        static void XuLyChucNang(List<(int, int)> capPhanTu)
        {
            if (capPhanTu.Count > 0)
            {
                Console.WriteLine("Cac cap phan tu thoa man theo de bai mang la: ");
                foreach (var cap in capPhanTu)
                {
                    Console.WriteLine($"({cap.Item1}, {cap.Item2})");
                }
            }
            else
            {
                Console.WriteLine("khong thoa man");
            }
        }
        

        static int TinhTongCacChuSo(int tmp)
        {
            int sum = 0;
            while(tmp > 0)
            {
                sum += tmp % 10;
                tmp /= 10;
            }
            return sum;
        }

        static int TimPTCoTongCacChuSoLonNhat(List<int> ds)
        {
            int result = TinhTongCacChuSo(ds[0]);
            for(int i =1;i < ds.Count; i++)
            {
                if (TinhTongCacChuSo(ds[i]) > result)
                {
                    result = TinhTongCacChuSo(ds[i]);
                }
            }
            return result;
        }

        static int TimGiaTriLonNhatNhungKhongPhaiCuoi(List<int> ds)
        {
            SapTang(ds);
            if (ds[ds.Count - 1] == ds[ds.Count - 2])
            {
                return ds[ds.Count - 2];
            }
            else return -1;
        }

        static bool LaSoNT(int n)
        {
            if(n < 2)   return false;
            for(int i = 2; i < Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        static List<(int, int)> TimCacCapCoHieuLaSoNT(List<int> ds)
        {
            List<(int, int)> result = new List<(int, int)>();
            for (int i = 0; i < ds.Count - 1; i++)
            {
                for (int j = i + 1; j < ds.Count; j++)
                {
                    if (LaSoNT(ds[i] - ds[j]))
                    {
                        result.Add((ds[i], ds[j]));
                    }
                }
            }
            return result;
        }

        static List<int> XoaPTDauTienLonHonX(List<int> ds, int x)
        {
            for(int i = 0; i < ds.Count; i++)
            {
                if (ds[i] > x)
                {
                    ds.RemoveAt(i);
                    break;
                }
            }   
            return ds;
        }

        static List<int> ChenPhanTuXSaoChoMangVanTangDan(List<int> ds, int x)
        {
            SapTang(ds);
            for (int i = 0; i < ds.Count; i++)
            {
                if (x < ds[i])
                {
                    ds.Insert(i,x);
                    break;
                }
            }
            ds.Add(x);
            return ds;
        }

        static List<int> ChenXVaoDauMang(List<int> ds, int x)
        {
            ds.Insert(0, x);
            return ds;
        }

        static List<int> XoaCacPTLonHonX(List <int> ds, int x)
        {
            for(int i = 0; i < ds.Count; i++)
            {
                if (ds[i] > x)
                {
                    ds.RemoveAt(i);
                }
            }
            return ds;
        }

        static List<int> XoaCacSoNT(List <int> ds)
        {
            for(int i = 0;i < ds.Count; i++)
            {
                if (LaSoNT(ds[i]))
                {
                    ds.RemoveAt(i);
                }
            }
            return ds;
        }

        static int TimVTDauTienCuaPTLonNhat(List<int> ds)
        {
            int vt = - 1;
            int max = int.MinValue;
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i] > max)
                {
                    max = ds[i];
                    vt = i;
                }
            }
            return vt;
        }

        static int TimVTCuoiCungCuaPTNhoNhat(List<int> ds)
        {
            int vt = -1;
            int min = int.MaxValue;
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i] <= min)
                {
                    min = ds[i];
                    vt = i;
                }
            }
            return vt;
        }

        //static void DemSoLuongVaInKetQua(List<int> ds)
        //{
        //    for (int i = 0; i < ds.Count; i++)
        //    {
        //        int count = 0;
        //        for (int j = 0; j < i; j++)
        //        {
        //            if (ds[i] > ds[j])
        //            {
        //                count++;
        //            }
        //        }
        //        Console.WriteLine($"{ds[i]} {count}");
        //    }
        //}

        static int DemSoLuongPhanTuLonHonPhanTuTruoc(List<int> ds)
        {
            int count = 0;
            for (int i = 1; i < ds.Count; i++) 
            {
                if (ds[i] > ds[i - 1])
                {
                    count++;
                }
            }
            return count;
        }

        static int DemSoLuongPhanTuNhoHonPhanTuTruoc(List<int> ds)
        {
            int count = 0;
            for (int i = 1; i < ds.Count; i++)
            {
                if (ds[i] < ds[i - 1])
                {
                    count++;
                }
            }
            return count;
        }

        static int TimPTNhoNhatNhungKoAm(List<int> ds)
        {
            int min = int.MaxValue;
            for(int i = 0;i < ds.Count; i++)
            {
                if(ds[i] < min && ds[i] >= 0)
                {
                    min = ds[i];
                }
            }
            return min;
        }

        static int DemSoLanToiThieuDeSapXepMang(List<int> ds)
        {
            int dem = 0 ;
            for(int i = 0; i < ds.Count - 1; i++)
            {
                for(int j = i + 1; j < ds.Count; i++)
                {
                    if (ds[i] < ds[j])
                    {
                        HoanVi(ds, ds[i], ds[j]);
                        ++dem;
                    }
                }
            }
            return dem;
        }

        static int DemSoLanXuatHien(List<int> ds, int giaTri)
        {
            int dem = 0;
            foreach (int num in ds)
            {
                if (num == giaTri)
                    dem++;
            }
            return dem;
        }
        static int TimTanSuatCaoNhat(List<int> ds)
        {
            int maxTanSuat = 0;
            int phanTuMax = ds[0];

            foreach (int num in ds)
            {
                int tanSuat = DemSoLanXuatHien(ds, num);
                if (tanSuat > maxTanSuat)
                {
                    maxTanSuat = tanSuat;
                    phanTuMax = num;
                }
            }
            return phanTuMax;
        }

        static void SapXepLonDauNhoCuoi(List<int> ds)
        {
            int ptLonNhat = ds[TimVTDauTienCuaPTLonNhat(ds)];
            int ptNhoNhat = ds[TimVTCuoiCungCuaPTNhoNhat(ds)];
            int dau = 0, cuoi = ds.Count - 1;
            for(int i = 0; i < ds.Count; i++)
            {
                if(ds[i] == ptLonNhat)
                {
                    HoanVi(ds, i, dau);
                    ++dau;
                }
                if (ds[i] == ptNhoNhat)
                {
                    HoanVi(ds, i, cuoi);
                    --cuoi;
                }
            }
        }

        static List<int> XoaPTTaiVTK(List<int> ds, int k)
        {
            ds.Remove(k);
            return ds;
        }

        static void TimTatCaCacSoChanLienTiepCoHieuBangD(List<int> ds, int d)
        {
            List<int> chuoiChan = new List<int>();
            for(int i = 0; i < ds.Count - 1; i++)
            {
                if (ds[i] % 2 == 0)
                {
                    chuoiChan.Add(ds[i]);
                }
                else
                {
                    XuLyChuoiChan(chuoiChan, d);
                    chuoiChan.Clear();
                }
            }
            XuLyChuoiChan(chuoiChan, d);
        }

        static void XuLyChuoiChan(List<int> chuoiChan, int d)
        {
            int hieu = 0;
            for(int i = 0; i < chuoiChan.Count - 1; i++)
            {
                hieu += chuoiChan[i] - chuoiChan[i+1];
            }
            if(hieu == d)
            {
                Xuat(chuoiChan);
            }

        }

        //đề bài là "Tìm vị trí của phần tử nhỏ nhất trong một mảng tăng dần" mà mảng tăng dần lúc nào pt bé nhất cũng ở đầu mảng nên return về 0 
        static int TimVTCuaPTNhoNhatTrongMotMangTangDan(List<int> ds)
        {
            SapTang(ds);
            return 0;
        }

        static bool KTXemHaiMangCoChuaPTChungKo(List<int> ds1, List<int> ds2)
        {
            for(int i = 0; i < ds1.Count ; i++)
            {
                for (int j = 0; j < ds2.Count; j++)
                {
                    if (ds1[i] == ds2[j]) { return true; }
                }
            }
            return false;
        }

        static void TachMang(List<int> ds)
        {
            List<int> chan = new List<int>();
            List<int> le = new List<int>();
            for(int i = 0; i < ds.Count ; i++)
            {
                if(ds[i] % 2 == 0)
                {
                    chan.Add(ds[i]);
                }
                else le.Add(ds[i]);
            }
            Xuat(chan);
            Xuat(le);
        }


        static bool KiemTraSapXep(List<int> ds)
        {
            if (ds.Count < 2) return true;  

            bool tang = true, giam = true;

            for (int i = 1; i < ds.Count; i++)
            {
                if (ds[i] < ds[i - 1]) tang = false;  
                if (ds[i] > ds[i - 1]) giam = false;  
            }

            return tang || giam;  
        }

        static int TimSoChanLonHonSoChoTruoc(List<int> ds, int x)
        {
            for(int i =0; i < ds.Count; i++)
            {
                if (ds[i] % 2 == 0 && ds[i] > x)
                {
                    return ds[i];
                }
            }
            return -1;
        }
        static int TimPTXuatHienItNhat(List<int> ds)
        {
            int minval = int.MaxValue;
            int pt = -1;
            for(int i = 0; i < ds.Count - 1; i++)
            {
                int dem = 0;
                for(int j = 0; j < ds.Count; j++)
                {
                    if (ds[i] == ds[j])
                    {
                        ++dem;
                    }
                }
                if (dem < minval)
                {
                    minval = dem;
                    pt = ds[i];
                }
            }
            return pt;
        }
    }
}
