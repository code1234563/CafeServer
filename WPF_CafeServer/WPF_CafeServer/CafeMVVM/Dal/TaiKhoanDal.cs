using CafeMVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVVM.Dal
{
    public class TaiKhoanDal:XuLySqlServer
    {
        public List<TaiKhoanModels> sp_loadtaikhoan()
        {
            string json = JsonConvert.SerializeObject(LoadData("sp_loadtaikhoan"));
            return JsonConvert.DeserializeObject<List<TaiKhoanModels>>(json);
        }
        public bool sp_themtaikhoan(TaiKhoanModels tk_md)
        {
            int parameter = 4;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0]= "@tentaikhoan";
            name[1]= "@matkhau";
            name[2]= "@quyen";
            name[3] = "@hoten";
            values[0]=tk_md.TENDANGNHAP;
            values[1]=tk_md.MATKHAU;
            values[2]=tk_md.QUYEN;
            values[3] = tk_md.HOTEN;
            return Execute("sp_themtaikhoan", name, values,parameter);
        }
        public bool sp_xoataikhoan(TaiKhoanModels tk_md)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@tentaikhoan";           
            values[0] = tk_md.TENDANGNHAP;            
            return Execute("sp_xoataikhoan", name, values, parameter);
        }
        public bool sp_resetmatkhau(TaiKhoanModels tk_md)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@tentaikhoan";
            values[0] = tk_md.TENDANGNHAP;
            return Execute("sp_resetmatkhau", name, values, parameter);
        }
        public List<TaiKhoanModels> sp_kiemtradangnhap(TaiKhoanModels tk_md)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0]= "@tendangnhap";
            values[0]=tk_md.TENDANGNHAP;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_kiemtradangnhap", name, values, parameter));
            return JsonConvert.DeserializeObject<List<TaiKhoanModels>>(json);
        }
    }
}
