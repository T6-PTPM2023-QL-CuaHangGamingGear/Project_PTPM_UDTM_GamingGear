﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class PhieuNhapDTO
    {
        public int MaPN { get; set; }
        public int MaNCC { get; set; }
        public int MaNV { get; set; }
        public string NgayNhap { get; set; }
        public string TongTienPN { get; set; }
        public string GhiChu { get; set; }



        public int MaSP { get; set; }
        public int SoLuongSP { get; set; }
        public string ThanhTien { get; set; }
        public string GhiChu1 { get; set; }
    }
}
