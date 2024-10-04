using CafeMVVM.Dal;
using CafeMVVM.Models;
using CafeMVVM.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CafeMVVM.ViewModels
{
    public class BanViewModels:INotifyPropertyChanged
    {
        private List<KhuVucBanModels> _BanDanhMuc;
        private List<KhuVucBanModels> _KhuVuc;
        private KhuVucBanModels _SelectedKhuVuc;
        private KhuVucBanModels _SelectedBan;       
        private string _SOLUONGBAN;
        private string _TENBAN;
        public ICommand ThemBanComand { get; set; }
        public ICommand XoaBanComand { get; set; }
        public ICommand SuaBanComand { get; set; }
        public ICommand SuaBanFormComand { get; set; }
        KhuVucBanDal khuvucdal = new KhuVucBanDal();

        public List<KhuVucBanModels> BanDanhMuc
        {
            get
            {
                return _BanDanhMuc;
            }

            set
            {
                _BanDanhMuc = value;
                OnPropertyChanged("BanDanhMuc");
            }
        }

        public List<KhuVucBanModels> KhuVuc
        {
            get
            {
                return _KhuVuc;
            }

            set
            {
                _KhuVuc = value;
            }
        }

        public string SOLUONGBAN
        {
            get
            {
                return _SOLUONGBAN;
            }

            set
            {
                _SOLUONGBAN = value;
                OnPropertyChanged("SOLUONGBAN");
            }
        }

        public KhuVucBanModels SelectedKhuVuc
        {
            get
            {
                return _SelectedKhuVuc;
            }

            set
            {
                _SelectedKhuVuc = value;
                if (_SelectedKhuVuc != null)
                {
                    BanDanhMuc = khuvucdal.sp_bandanhmuc(_SelectedKhuVuc.MAKHUVUC);
                }
            }
        }

        public KhuVucBanModels SelectedBan
        {
            get
            {
                return _SelectedBan;
            }

            set
            {
                _SelectedBan = value;
            }
        }

        public string TENBAN
        {
            get
            {
                return _TENBAN;
            }

            set
            {
                _TENBAN = value;
                OnPropertyChanged("TENBAN");
            }
        }
        
        public BanViewModels()
        {           
            KhuVuc = khuvucdal.sp_loadkhuvuc();
            ThemBanComand = new RelayCommand<object>((p) => true, (p) =>
            {
                if (SelectedKhuVuc == null)
                {
                    ThongBao tb = new ThongBao("Chưa chọn khu vực để thêm bàn","CanhBao");
                    tb.ShowDialog();                    
                }
                else if (SOLUONGBAN == null || int.Parse(SOLUONGBAN) == 0)
                {
                    ThongBao tb = new ThongBao("Chưa nhập số lượng bạn cần thêm", "CanhBao");
                    tb.ShowDialog();                   
                }
                else
                {
                    int soluongbanhienco = 0;
                    for (int i = 1; i <= int.Parse(SOLUONGBAN); i++)
                    {
                        soluongbanhienco = BanDanhMuc.Count;
                        soluongbanhienco = soluongbanhienco + 1;
                        khuvucdal.sp_thembandanhmuc("Bàn " + soluongbanhienco, SelectedKhuVuc.MAKHUVUC);
                        BanDanhMuc = khuvucdal.sp_bandanhmuc(SelectedKhuVuc.MAKHUVUC);
                    }
                }
            });
            XoaBanComand = new RelayCommand<object>((p) => true, (p) =>
            {
                if (SelectedBan == null)
                {
                    ThongBao tb = new ThongBao("Chọn bàn trên danh sách để xóa", "CanhBao");
                    tb.ShowDialog();
                }
                else
                {
                    ThongBao tb = new ThongBao { DataContext = this };
                    tb.EventYesNo("Xóa: "+SelectedBan.TENBAN+" ?", "CauHoi");
                    tb.ShowDialog();
                    if (tb.Yes == true)
                    {
                        khuvucdal.sp_xoabandanhmuc(SelectedBan.MABAN);
                        BanDanhMuc = khuvucdal.sp_bandanhmuc(SelectedKhuVuc.MAKHUVUC);
                    }                 
                }
            });
            SuaBanComand = new RelayCommand<object>((p) => true, (p) =>
            {
                WindowService.ShowFormSuaBan(false,this,(Window)p);             
            });

            SuaBanFormComand = new RelayCommand<object>((p) => true, (p) =>
                  {                      
                      if (SelectedBan == null)
                      {
                          ThongBao tb = new ThongBao("Chọn bàn trên danh sách để sửa", "CanhBao");
                          tb.ShowDialog();                          
                      }
                      else if (TENBAN == "" || TENBAN == null)
                      {
                          ThongBao tb = new ThongBao("Chưa nhập tên bàn", "CanhBao");
                          tb.ShowDialog();                         
                      }
                      else
                      {
                          khuvucdal.sp_suaban(SelectedBan.MABAN, TENBAN);
                          BanDanhMuc = khuvucdal.sp_bandanhmuc(SelectedKhuVuc.MAKHUVUC);
                          WindowService.ShowFormSuaBan(true, this, (Window)p);
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
