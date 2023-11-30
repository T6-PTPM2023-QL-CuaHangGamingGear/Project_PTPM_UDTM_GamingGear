﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class KhachHangDTO
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string MatKhau { get; set; }
        public string DiaChi { get; set; }
        public string TinhTrang { get; set; }

    }
}
