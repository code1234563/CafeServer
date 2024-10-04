using CafeMVVM.Dal;
using CafeMVVM.Models;
using CafeMVVM.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CafeMVVM.ViewModels
{
    public class ThucDonViewModels:INotifyPropertyChanged
    {
        List<ThucDonModels> _DanhMucThucDon;
        List<ThucDonModels> _DanhSachMon;
        private ThucDonModels _SelectedItemDanhMucTd;
        private ThucDonModels _SelectedItemMon;
        private string _TenDanhMuc;
        private string _Mon;
        private object _DonGia;
        public ICommand ThemDanhMucTdComand { get; set; }
        public ICommand XoaDanhMucTdComand { get; set; }
        public ICommand ThemMonComand { get; set; }
        public ICommand XoaMonTdComand { get; set; }
        public ICommand SuaMonComand { get; set; }
        ThucDonDal thucdondal = new ThucDonDal();
        public List<ThucDonModels> DanhMucThucDon
        {
            get
            {
                return _DanhMucThucDon;
            }

            set
            {
                _DanhMucThucDon = value;
                OnPropertyChanged("DanhMucThucDon");
            }
        }

        public ThucDonModels SelectedItemDanhMucTd
        {
            get
            {
                return _SelectedItemDanhMucTd;
            }

            set
            {
                _SelectedItemDanhMucTd = value;
                if (_SelectedItemDanhMucTd != null)
                {
                    DanhSachMon = thucdondal.sp_loadthucdon(SelectedItemDanhMucTd.MADM);
                }
            }
        }

        public string TenDanhMuc
        {
            get
            {
                return _TenDanhMuc;
            }

            set
            {
                _TenDanhMuc = value;
                OnPropertyChanged("TenDanhMuc");
            }
        }

        public List<ThucDonModels> DanhSachMon
        {
            get
            {
                return _DanhSachMon;
            }

            set
            {
                _DanhSachMon = value;
                OnPropertyChanged("DanhSachMon");
            }
        }

        public string Mon
        {
            get
            {
                return _Mon;
            }

            set
            {
                _Mon = value;
                OnPropertyChanged("Mon");
            }
        }

        public object DonGia
        {
            get
            {
                return _DonGia;
            }

            set
            {
                _DonGia = double.Parse(value.ToString()).ToString("N0");
            }
        }

        public ThucDonModels SelectedItemMon
        {
            get
            {
                return _SelectedItemMon;
            }

            set
            {
                _SelectedItemMon = value;
            }
        }

        public ThucDonViewModels()
        {
            DanhMucThucDon = thucdondal.sp_danhmucloadthucdon();
            ThemDanhMucTdComand = new RelayCommand<object>((p) => true, (p) =>
            {
                if (TenDanhMuc == "" ||TenDanhMuc==null)
                {
                    ThongBao tb = new ThongBao("Chưa nhập tên danh mục","CanhBao");
                    tb.ShowDialog();                    
                }
                else
                {
                    thucdondal.sp_themdanhmucthucdon(TenDanhMuc);
                    DanhMucThucDon = thucdondal.sp_danhmucloadthucdon();
                }
            });
            XoaDanhMucTdComand = new RelayCommand<object>((p) => true, (p) =>
            {
                if (SelectedItemDanhMucTd == null)
                {
                    ThongBao tb = new ThongBao("Chọn danh mục trên để xóa", "CanhBao");
                    tb.ShowDialog();                   
                }
                else
                {
                    ThongBao tb = new ThongBao { DataContext = this };
                    tb.EventYesNo("Xóa danh mục: " + SelectedItemDanhMucTd.TENDM, "CauHoi");
                    tb.ShowDialog();
                    if (tb.Yes == true)
                    {
                        thucdondal.sp_xoadanhmucthucdon(SelectedItemDanhMucTd.MADM);
                        DanhMucThucDon = thucdondal.sp_danhmucloadthucdon();
                    }
                }
            });
            ThemMonComand = new RelayCommand<object>((p) => true, (p) =>
            {
                if (SelectedItemDanhMucTd == null)
                {
                    ThongBao tb = new ThongBao("Chọn danh mục để hiển thị món", "CanhBao");
                    tb.ShowDialog();       
                }
                else if (Mon == "" || Mon == null)
                {
                    ThongBao tb = new ThongBao("Chưa nhập món cần thêm", "CanhBao");
                    tb.ShowDialog();
                }
                else if (DonGia.ToString() == "" || DonGia == null)
                {
                    ThongBao tb = new ThongBao("Chưa nhập đơn giá", "CanhBao");
                    tb.ShowDialog();
                }
                else
                {
                    thucdondal.sp_themthucdon(Mon, double.Parse(DonGia.ToString()), SelectedItemDanhMucTd.MADM);
                    DanhSachMon = thucdondal.sp_loadthucdon(SelectedItemDanhMucTd.MADM);
                }
            });
            XoaMonTdComand = new RelayCommand<object>((p) => true, (p) =>
            {
                if (SelectedItemMon == null)
                {
                    ThongBao tb = new ThongBao("Chọn món phía trên để xóa", "CanhBao");
                    tb.ShowDialog();                    
                }
                else
                {
                    ThongBao tb = new ThongBao { DataContext = this };
                    tb.EventYesNo("Xóa món: "+SelectedItemMon.TENTHUCDON, "CauHoi");
                    tb.ShowDialog();
                    if (tb.Yes == true)
                    {
                        thucdondal.sp_xoathucdon(SelectedItemMon.MATHUCDON);
                        DanhSachMon = thucdondal.sp_loadthucdon(SelectedItemDanhMucTd.MADM);
                    }
                }
            });
            SuaMonComand = new RelayCommand<object>((p) => true, (p) => 
            {
                if (SelectedItemMon == null)
                {
                    ThongBao tb = new ThongBao("Chọn món để sửa.", "CanhBao");
                    tb.ShowDialog();
                }
                else
                {
                    thucdondal.sp_suagiathucdon(SelectedItemMon.MATHUCDON, double.Parse(DonGia.ToString()));
                    DanhSachMon = thucdondal.sp_loadthucdon(SelectedItemDanhMucTd.MADM);
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
        #endregion
    }
}
