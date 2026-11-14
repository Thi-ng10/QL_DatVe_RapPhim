using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLDatVe
{
    public class TestTinhGiaClass // Phải nằm trong một class
    {
        public void TestTinhGia()
        {
            decimal giaCoBan = 70000;
            List<Ghe> danhSachGhe = new List<Ghe>();

            danhSachGhe.Add(new GheThuong("A01"));
            danhSachGhe.Add(new GheVip("A02"));
            danhSachGhe.Add(new GheDoi("A03"));

            foreach (Ghe ghe in danhSachGhe)
            {
                decimal gia = ghe.TinhGia(giaCoBan);

                MessageBox.Show(
                    "Ma ghe: " + ghe.MaGhe +
                    "\nLoai ghe: " + ghe.LoaiGhe +
                    "\nGia ve: " + gia.ToString("N0") + " VND"
                );
            }
        }
    }
}