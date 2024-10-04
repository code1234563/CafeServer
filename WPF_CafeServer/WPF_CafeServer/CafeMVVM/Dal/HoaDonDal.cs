using CafeMVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVVM.Dal
{
    public class HoaDonDal: XuLySqlServer
    {
        public List<HoaDonModels> sp_loaddanhsachthucdoncuaban(int maban, int mahoadon)
        {
            int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0]= "@maban";
            name[1]= "@mahoadon";
            values[0]=maban;
            values[1]=mahoadon;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_loaddanhsachthucdoncuaban", name, values, parameter));
            return JsonConvert.DeserializeObject<List<HoaDonModels>>(json);
        }
        public List<HoaDonModels> sp_layidhoadontheo_khuvucban(int maban, int makhuvuc)
        {
            int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@maban";
            name[1] = "@makhuvuc";
            values[0] = maban;
            values[1] = makhuvuc;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_layidhoadontheo_khuvucban", name, values, parameter));
            return JsonConvert.DeserializeObject<List<HoaDonModels>>(json);
        }
        public bool sp_themhoadon(object ngaylap, int maban)
        {
            int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@ngaylap";
            name[1] = "@maban";       
            values[0] = ngaylap;
            values[1] = maban;        
            return Execute("sp_themhoadon", name, values, parameter);
        }
        public bool sp_themcthdban(int idhoadon, int mathucdon, int soluong,int giamgia)
        {
            int parameter = 4;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0]= "@idhoadon";
            name[1]= "@mathucdon";
            name[2]= "@soluong";
            name[3] = "@giamgia";
            values[0]= idhoadon;
            values[1]= mathucdon;
            values[2]= soluong;
            values[3] = giamgia;
            return Execute("sp_themcthdban", name, values, parameter);
        }
        public bool sp_thanhtoanban(int maban, int mahoadon, double tongtien,string idnhanvien)
        {
            int parameter = 4;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0]= "@maban";
            name[1]= "@mahoadon";
            name[2]= "@tongtien";
            name[3] = "@idnhanvien";
            values[0]=maban;
            values[1]=mahoadon;
            values[2]= tongtien;
            values[3] = idnhanvien;
            return Execute("sp_thanhtoanban", name,values,parameter);
        }
        public DataTable sp_loaddanhsachthucdoncuaban_rpt(int maban, int mahoadon, string giora)
        {
            int parameter = 3;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@maban";
            name[1] = "@mahoadon";
            name[2] = "@giora";
            values[0] = maban;
            values[1] = mahoadon;
            values[2] = giora;
            return LoadDataParameter("sp_loaddanhsachthucdoncuaban_rpt", name, values, parameter);
        }
        public bool sp_capnhathoadondain(int idhoadon)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@idhoadon";         
            values[0] = idhoadon;          
            return Execute("sp_capnhathoadondain", name, values, parameter);
        }
        public List<HoaDonModels> sp_loadhoadoncanin()
        {
            string json = JsonConvert.SerializeObject(LoadData("sp_loadhoadoncanin"));
            return JsonConvert.DeserializeObject<List<HoaDonModels>>(json);
        }
    }

}
