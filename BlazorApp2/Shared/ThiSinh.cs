using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorApp2.Shared.PageSetUp;

namespace BlazorApp2.Shared
{
    public class ThiSinh
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public string Cmnd { get; set; } = "000000000";
        public string NgaySinh { get; set; } = "7/7/2022";
        public string? GioiTinh { get; set; }
        public string BacHoc { get; set; } = "Dai Hoc";
        public string MaNganhXetTuyen { get; set; }
        public string? DoiTuong { get; set; }
        public int DiemUuTienDT { get; set; } = 1;
        public string? KhuVuc { get; set; } = "KV_HG";
        public double DiemUuTienKV { get; set; } = 1;
        public string KhoiXetTuyen { get; set; } = "1";
        public string? Mon1 { get; set; } = "1";
        public string? Mon2 { get; set; } = "1";
        public string? Mon3 { get; set; } = "1";
        public double Diem1111 { get; set; } = 1;
        public double Diem1211 { get; set; } = 1;
        public double Diem1112 { get; set; } = 1;
        public double Diem1212 { get; set; } = 1;
        public double Diem1TB12 { get; set; } = 1;
        public double Diem2111 { get; set; } = 1;
        public double Diem2211 { get; set; } = 1;
        public double Diem2112 { get; set; } = 1;
        public double Diem2212 { get; set; } = 1;
        public double Diem2TB12 { get; set; } = 1;
        public double Diem3111 { get; set; } = 1;
        public double Diem3211 { get; set; } = 1;
        public double Diem3112 { get; set; } = 1;
        public double Diem3212 { get; set; } = 1;
        public double Diem3TB12 { get; set; } = 1;
        public double DiemTBPT1 { get; set; } = 1;
        public double DiemTBPT2 { get; set; } = 1;
        public double DiemTBPT3 { get; set; } = 1;
        public string TruongTHPT { get; set; } = "1";
        public string HK11 { get; set; } = "1";
        public string HK12 { get; set; } = "1";
        public int? MaDKXT { get; set; } = 1;
        public double diem1 { get; set; } = 1;
        public double diem2 { get; set; } = 1;
        public double diem3 { get; set; } = 1;
        public double Tong { get; set; } = 1;
        public string Sdt { get; set; } = "1";
        public string Email { get; set; } = "1";
        public string Diachi { get; set; } = "1";
        public DateTime Ngaygui { get; set; } = DateTime.Now;
        public string? CBTuVan { get; set; } = "1";
        public string TrangThai { get; set; } = "1";
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
        public DateTime UpdateDateTime { get; set; } = DateTime.Now;
        public List<HinhAnh> HinhAnhs { get; set; } = new List<HinhAnh>();
    }
}
