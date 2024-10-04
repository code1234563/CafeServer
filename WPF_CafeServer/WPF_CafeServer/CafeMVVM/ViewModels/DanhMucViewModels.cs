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
    public class DanhMucViewModels:INotifyPropertyChanged
    {
        private List<KhuVucBanModels> _DanhMucKhuVuc;
        private KhuVucBanModels _SelectedKhuVucDanhMuc;
        private string _TENKHUVUCNHAP;
        public ICommand ThongBaoYes { get; set; }
        public ICommand ThongBaoNo { get; set; }
        KhuVucBanDal khuvucbandal = new KhuVucBanDal();
        public ICommand ThemDanhMucKhuVuc { get; set; }
        public ICommand XoaDanhMucKhuVuc { get; set; }
        public List<KhuVucBanModels> DanhMucKhuVuc
        {
            get
            {
                return _DanhMucKhuVuc;
            }

            set
            {
                _DanhMucKhuVuc = value;
                OnPropertyChanged("DanhMucKhuVuc");
            }
        }

        public string TENKHUVUCNHAP
        {
            get
            {
                return _TENKHUVUCNHAP;
            }

            set
            {
                _TENKHUVUCNHAP = value;
                OnPropertyChanged("TENKHUVUCNHAP");
            }
        }

        public KhuVucBanModels SelectedKhuVucDanhMuc
        {
            get
            {
                return _SelectedKhuVucDanhMuc;
            }

            set
            {
                _SelectedKhuVucDanhMuc = value;
            }
        }

        

        public DanhMucViewModels()
        {
            bool btnYes = false, btnNo = false;
            DanhMucKhuVuc = khuvucbandal.sp_loadkhuvuc_danhmuc();
            ThemDanhMucKhuVuc = new RelayCommand<object>((p) => true, (p) =>
            {
                if (TENKHUVUCNHAP == null || TENKHUVUCNHAP == "")
                {
                    ThongBao tb = new ThongBao("Chưa nhập tên khu vực cần thêm.", "CanhBao");
                    tb.ShowDialog();                   
                }
                else
                {
                    khuvucbandal.sp_themkhuvuc(TENKHUVUCNHAP);
                    DanhMucKhuVuc = khuvucbandal.sp_loadkhuvuc_danhmuc();
                }
            });
           
            XoaDanhMucKhuVuc = new RelayCommand<object>((p) => true, (p) =>
            {
                if (SelectedKhuVucDanhMuc == null)
                {
                    ThongBao tb = new ThongBao("Chọn một khu vực để xóa","CanhBao");
                    tb.ShowDialog();                   
                }
                else
                {
                    ThongBao tb = new ThongBao { DataContext = this };
                    tb.EventYesNo("Xóa: " + SelectedKhuVucDanhMuc.TENKHUVUC + " ?", "CauHoi");
                    tb.ShowDialog();
                    if (tb.Yes == true)
                    {
                        khuvucbandal.sp_xoakhuvuc(SelectedKhuVucDanhMuc.MAKHUVUC);
                        DanhMucKhuVuc = khuvucbandal.sp_loadkhuvuc_danhmuc();
                    }
                }
                
            });
            ThongBaoYes = new RelayCommand<object>((c) => true, (c) =>
            {
                btnYes = true;
            });
            ThongBaoNo = new RelayCommand<object>((c) => true, (c) =>
            {
                btnNo = true;
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
