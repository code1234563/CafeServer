using CafeMVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVVM.Dal
{
    public class ThucDonDal:XuLySqlServer
    {
        public List<ThucDonModels> sp_danhmucloadthucdon()
        {
            string json = JsonConvert.SerializeObject(LoadData("sp_danhmucloadthucdon"));
            return JsonConvert.DeserializeObject<List<ThucDonModels>>(json);
        }
        public List<ThucDonModels> sp_loadthucdon(int madm)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@madm";
            values[0] = madm;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_loadthucdon", name, values, parameter));
            return JsonConvert.DeserializeObject<List<ThucDonModels>>(json);
        }
        public bool sp_themdanhmucthucdon(string tendanhmuc)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@tendanhmuc";
            values[0] = tendanhmuc;
            return Execute("sp_themdanhmucthucdon", name, values, parameter);
        }
        public bool sp_xoadanhmucthucdon(int madanhmuc)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@iddanhmuc";
            values[0] = madanhmuc;
            return Execute("sp_xoadanhmucthucdon",name,values,parameter);
        }
        public bool sp_themthucdon(string tenthucdon, double dongia, int madanhmuc)
        {
            int parameter = 3;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0]= "@tenthucdon";
            name[1]= "@dongia";
            name[2]= "@iddm";
            values[0]=tenthucdon;
            values[1]=dongia;
            values[2]=madanhmuc;
            return Execute("sp_themthucdon",name,values,parameter);
        }
        public bool sp_xoathucdon(int mathucdon)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@mathucdon";
            values[0] = mathucdon;
            return Execute("sp_xoathucdon", name, values, parameter);
        }
        public bool sp_themgiamgia(int mathucdon, int giamgia)
        {
            int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0]= "@mathucdon";
            name[1]= "@giamgia";
            values[0]=mathucdon;
            values[1]=giamgia;
            return Execute("sp_themgiamgia", name,values,parameter);
        }
        public bool sp_xoagiamgia(int mathucdon)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@mathucdon";           
            values[0] = mathucdon;          
            return Execute("sp_xoagiamgia", name, values, parameter);
        }
        public bool sp_suagiathucdon(int mathucdon, double dongia)
        {
            int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0]= "@mathucdon";
            name[1]= "@dongia";
            values[0]=mathucdon;
            values[1]=dongia;
            return Execute("sp_suagiathucdon", name, values, parameter);
        }
    }
}
