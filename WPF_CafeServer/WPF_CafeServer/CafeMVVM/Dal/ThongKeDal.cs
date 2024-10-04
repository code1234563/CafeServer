using CafeMVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVVM.Dal
{
    public class ThongKeDal : XuLySqlServer
    {
        public List<ThongKeModels> sp_thongkemontheongay(int ngay)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0]= "@ngay";
            values[0]= ngay;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_thongkemontheongay", name, values, parameter));
            return JsonConvert.DeserializeObject<List<ThongKeModels>>(json);
        }
        public List<ThongKeModels> sp_thongkemontheothang(int thang)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@thang";
            values[0] = thang;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_thongkemontheothang", name, values, parameter));
            return JsonConvert.DeserializeObject<List<ThongKeModels>>(json);
        }
        public List<ThongKeModels> sp_thongkemontheonam(object nam)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@nam";
            values[0] = nam;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_thongkemontheonam", name, values, parameter));
            return JsonConvert.DeserializeObject<List<ThongKeModels>>(json);
        }
        // Doanh thu
        public List<ThongKeModels> sp_doanhthutheongay(int ngay)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@ngay";
            values[0] = ngay;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_doanhthutheongay", name, values, parameter));
            return JsonConvert.DeserializeObject<List<ThongKeModels>>(json);
        }
        public List<ThongKeModels> sp_danhthutheothang(int thang)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@thang";
            values[0] = thang;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_danhthutheothang", name, values, parameter));
            return JsonConvert.DeserializeObject<List<ThongKeModels>>(json);
        }
        public List<ThongKeModels> sp_doanhthutheonam(object nam)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@nam";
            values[0] = nam;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_doanhthutheonam", name, values, parameter));
            return JsonConvert.DeserializeObject<List<ThongKeModels>>(json);
        }
        public List<ThongKeModels> sp_loaddanhsachthucdoncuaban_thongke(int MAHOADON)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@MAHOADON";
            values[0] = MAHOADON;
            string json = JsonConvert.SerializeObject(LoadDataParameter("sp_loaddanhsachthucdoncuaban_thongke", name, values, parameter));
            return JsonConvert.DeserializeObject<List<ThongKeModels>>(json);
        }
    }
}
