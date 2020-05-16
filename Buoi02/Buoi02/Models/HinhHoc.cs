using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi02.Models
{
    public class HinhHoc
    {
        public static string RandomKey()
        {
            return $"NN-{new Random().Next()}";
        }

        public double DienTich { get; set; }
        public double ChuVi { get; set; }
        public virtual void TinhDienTichChuVi()
        {
        }
        public override string ToString()
        {
            return $"S = {DienTich}, P = {ChuVi}";
        }
    }//end class HinhHoc

    public class HinhChuNhat : HinhHoc
    {
        public double Dai { get; set; }
        public double Rong { get; set; }
        public override void TinhDienTichChuVi()
        {
            DienTich = Dai * Rong;
            ChuVi = 2 * (Dai + Rong);
        }
        public override string ToString()
        {
            return $"W = {Rong}, H = {Dai}, {base.ToString()}";
        }
    }//end class HinhChuNhat

    public class HinhTron : HinhHoc
    {
        public double BanKinh { get; set; }        
        public override void TinhDienTichChuVi()
        {
            DienTich = Math.Pow(BanKinh, 2) * Math.PI;
            ChuVi = 2 * BanKinh * Math.PI;
        }
        public override string ToString()
        {
            return $"R = {BanKinh}, {base.ToString()}";
        }
    }//end class HinhChuNhat
}
