using CafeMVVM.Dal;
using CafeMVVM.Models;
using CafeMVVM.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CafeMVVM.ViewModels
{
    public class ThongKeViewModels:INotifyPropertyChanged
    {
        private List<ThongKeModels> _DanhSachThongKeMon;
        private List<ThongKeModels> _DanhSachMacDinh;
        private List<ThongKeModels> _ChiTietHoaDon;
        private ThongKeModels _SelectedDoanhThuMacDinh;
        private string _CbNgay_Mon;
        private string _CbThang_Mon;
        private object _Date_tuchon_Mon;
        private string _CbNgay_DoanhThu;
        private string _CbThang_DoanhThu;
        private object _Date_tuchonDoanhThu;
        public ICommand TkMonCommand { get; set; }
        public ICommand TkDtCommand { get; set; }
        public ICommand rdNgayCommand { get; set; }
        public ICommand rdThangComand { get; set; }
        public ICommand rdTuchonComand { get; set; }
        public ICommand rdNgayCommand_dt { get; set; }
        public ICommand rdThangComand_dt { get; set; }
        public ICommand rdTuchonComand_dt { get; set; }
        private string _SOLUONGHOADON;
        private string _TONGTIENHOADON;
        ThongKeDal tkdal = new ThongKeDal();

        public List<ThongKeModels> DanhSachThongKeMon
        {
            get
            {
                return _DanhSachThongKeMon;
            }

            set
            {
                _DanhSachThongKeMon = value;
                OnPropertyChanged("DanhSachThongKeMon");
            }
        }

        public List<ThongKeModels> DanhSachMacDinh
        {
            get
            {
                return _DanhSachMacDinh;
            }

            set
            {
                _DanhSachMacDinh = value;
                OnPropertyChanged("DanhSachMacDinh");
            }
        }

        public string SOLUONGHOADON
        {
            get
            {
                return _SOLUONGHOADON;
            }

            set
            {
                _SOLUONGHOADON = value;
                OnPropertyChanged("SOLUONGHOADON");
            }
        }

        public string TONGTIENHOADON
        {
            get
            {
                return _TONGTIENHOADON;
            }

            set
            {
                _TONGTIENHOADON = value;
                OnPropertyChanged("TONGTIENHOADON");
            }
        }

        public ThongKeModels SelectedDoanhThuMacDinh
        {
            get
            {
                return _SelectedDoanhThuMacDinh;
            }

            set
            {
                _SelectedDoanhThuMacDinh = value;
                if (_SelectedDoanhThuMacDinh != null)
                {
                    ChiTietHoaDon = tkdal.sp_loaddanhsachthucdoncuaban_thongke(SelectedDoanhThuMacDinh.IDHOADON);
                    PageChiTietHoaDon chitiet = new PageChiTietHoaDon { DataContext = this };
                    chitiet.ShowDialog();
                }
                OnPropertyChanged("SelectedDoanhThuMacDinh");
            }
        }

        public List<ThongKeModels> ChiTietHoaDon
        {
            get
            {
                return _ChiTietHoaDon;
            }

            set
            {
                _ChiTietHoaDon = value;
                OnPropertyChanged("ChiTietHoaDon");
            }
        }

        public string CbNgay_Mon
        {
            get
            {
                return _CbNgay_Mon;
            }

            set
            {
                _CbNgay_Mon = value;
                OnPropertyChanged("CbNgay_Mon");
            }
        }

        public string CbThang_Mon
        {
            get
            {
                return _CbThang_Mon;
            }

            set
            {
                _CbThang_Mon = value;
                OnPropertyChanged("CbThang_Mon");
            }
        }

        public object Date_tuchon_Mon
        {
            get
            {
                return _Date_tuchon_Mon;
            }

            set
            {
                _Date_tuchon_Mon = value;
                OnPropertyChanged("Date_tuchon_Mon");
            }
        }

        public string CbNgay_DoanhThu
        {
            get
            {
                return _CbNgay_DoanhThu;
            }

            set
            {
                _CbNgay_DoanhThu = value;
                OnPropertyChanged("CbNgay_DoanhThu");
            }
        }

        public string CbThang_DoanhThu
        {
            get
            {
                return _CbThang_DoanhThu;
            }

            set
            {
                _CbThang_DoanhThu = value;
                OnPropertyChanged("CbThang_DoanhThu");
            }
        }

        public object Date_tuchonDoanhThu
        {
            get
            {
                return _Date_tuchonDoanhThu;
            }

            set
            {
                _Date_tuchonDoanhThu = value;
                OnPropertyChanged("Date_tuchonDoanhThu");
            }
        }
        private void tinhhoadon()
        {
            if (DanhSachMacDinh != null)
            {
                double tong = 0;
                for (int i = 0; i < DanhSachMacDinh.Count; i++)
                {
                    tong = tong + double.Parse(DanhSachMacDinh[i].TONGTIEN.ToString());
                }
                SOLUONGHOADON = "Tổng số lượng hóa đơn: " + DanhSachMacDinh.Count.ToString();
                TONGTIENHOADON = "Tồng tiền: " + double.Parse(tong.ToString()).ToString("N0") + " Vnđ";
            }
            else
            {
                SOLUONGHOADON = "";
                TONGTIENHOADON = "";
            }
        }
        private void tinhmon()
        {
            if (DanhSachThongKeMon != null)
            {
                double tong = 0;
                for (int i = 0; i < DanhSachThongKeMon.Count; i++)
                {
                    tong = tong + double.Parse(DanhSachThongKeMon[i].TONGTIEN.ToString());
                }
                SOLUONGHOADON = "";
                TONGTIENHOADON = "Tồng tiền: " + double.Parse(tong.ToString()).ToString("N0") + " Vnđ";
            }
            else
            {
                SOLUONGHOADON = "";
                TONGTIENHOADON = "";
            }
        }
        public ThongKeViewModels()
        {
            bool ngaymon = false, thangmon = false, tuchonmon = false;
            bool ngaydt = false, thangdt = false, tuchondt = false;
            DanhSachMacDinh = tkdal.sp_doanhthutheongay(DateTime.Now.Day);
            tinhhoadon();
            rdNgayCommand = new RelayCommand<object>((p) => true, (p) => { ngaymon = true; thangmon = false;tuchonmon = false; });
            rdThangComand = new RelayCommand<object>((p) => true, (p) => { ngaymon = false; thangmon = true; tuchonmon = false; });
            rdTuchonComand = new RelayCommand<object>((p) => true, (p) => { ngaymon = false; thangmon = false; tuchonmon = true; });
            rdNgayCommand_dt = new RelayCommand<object>((p) => true, (p) => { ngaydt = true; thangdt = false; tuchondt = false; });
            rdThangComand_dt = new RelayCommand<object>((p) => true, (p) => { ngaydt = false; thangdt = true; tuchondt = false; });
            rdTuchonComand_dt = new RelayCommand<object>((p) => true, (p) => { ngaydt = false; thangdt = false; tuchondt = true; });
            TkMonCommand = new RelayCommand<object>((p) => true, (p) => 
            {
                if (ngaymon == true)
                {
                    if (CbNgay_Mon == null || CbNgay_Mon == "")
                    {
                        ThongBao tb = new ThongBao("Chưa chọn ngày.", "CanhBao");
                        tb.ShowDialog();
                    }
                    else
                    {
                        DanhSachThongKeMon = tkdal.sp_thongkemontheongay(int.Parse(CbNgay_Mon.ToString()));
                        tinhmon();
                    }
                }
                else if (thangmon == true)
                {
                    if (CbThang_Mon == null || CbThang_Mon == "")
                    {
                        ThongBao tb = new ThongBao("Chưa chọn tháng.", "CanhBao");
                        tb.ShowDialog();
                    }
                    else
                    {
                        DanhSachThongKeMon = tkdal.sp_thongkemontheothang(int.Parse(CbThang_Mon.ToString()));
                        tinhmon();
                    }
                }
                else if (tuchonmon == true)
                {
                    if (Date_tuchon_Mon == null || Date_tuchon_Mon.ToString() == "")
                    {
                        ThongBao tb = new ThongBao("Chưa chọn ngày cụ thể.", "CanhBao");
                        tb.ShowDialog();
                    }
                    else
                    {
                        DanhSachThongKeMon = tkdal.sp_thongkemontheonam(DateTime.Parse(Date_tuchon_Mon.ToString()).ToString("yyyy-MM-dd"));
                        tinhmon();
                    }
                }
                else
                {
                    ThongBao tb = new ThongBao("Chưa chọn thời gian cần thống kê.!", "CanhBao");
                    tb.ShowDialog();
                    tinhmon();
                }
                
            });
            TkDtCommand = new RelayCommand<object>((p) => true, (p) => 
            {
                if (ngaydt == true)
                {
                    if (CbNgay_DoanhThu == null || CbNgay_DoanhThu == "")
                    {
                        ThongBao tb = new ThongBao("Chưa chọn ngày.", "CanhBao");
                        tb.ShowDialog();
                    }
                    else
                    {
                        DanhSachMacDinh =tkdal.sp_doanhthutheongay(int.Parse(CbNgay_DoanhThu));
                        tinhhoadon();
                    }
                }
                else if (thangdt == true)
                {
                    if (CbThang_DoanhThu == null || CbThang_DoanhThu == "")
                    {
                        ThongBao tb = new ThongBao("Chưa chọn tháng.", "CanhBao");
                        tb.ShowDialog();
                    }
                    else
                    {
                        DanhSachMacDinh =tkdal.sp_danhthutheothang(int.Parse(CbThang_DoanhThu));
                        tinhhoadon();
                    }
                }
                else if (tuchondt == true)
                {
                    if (Date_tuchonDoanhThu == null || Date_tuchonDoanhThu.ToString() == "")
                    {
                        ThongBao tb = new ThongBao("Chưa chọn ngày cụ thể.", "CanhBao");
                        tb.ShowDialog();
                    }
                    else
                    {
                        DanhSachMacDinh =tkdal.sp_doanhthutheonam(DateTime.Parse(Date_tuchonDoanhThu.ToString()).ToString("yyyy-MM-dd"));
                        tinhhoadon();
                    }
                }
                else
                {
                    ThongBao tb = new ThongBao("Chưa chọn thời gian cần thống kê.!", "CanhBao");
                    tb.ShowDialog();
                    tinhhoadon();
                }

            });           
        }
        #region PropertyChange
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        private string convertday(string ngay)
        {
            string values_ngay = "";
            switch (ngay)
            {
                case "1":
                    {
                        values_ngay = "01";
                        break;
                    }
                case "2":
                    {
                        values_ngay = "02";
                        break;
                    }
                case "3":
                    {
                        values_ngay = "03";
                        break;
                    }
                case "4":
                    {
                        values_ngay = "04";
                        break;
                    }
                case "5":
                    {
                        values_ngay = "05";
                        break;
                    }
                case "6":
                    {
                        values_ngay = "06";
                        break;
                    }
                case "7":
                    {
                        values_ngay = "07";
                        break;
                    }
                case "8":
                    {
                        values_ngay = "08";
                        break;
                    }
                case "9":
                    {
                        values_ngay = "09";
                        break;
                    }
                default:
                    {
                        values_ngay = ngay;
                        break;
                    }
            }
            return values_ngay;
        }
        #endregion
    }
}
