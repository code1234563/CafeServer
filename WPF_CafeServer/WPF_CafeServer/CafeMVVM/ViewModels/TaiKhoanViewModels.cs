using CafeMVVM.Dal;
using CafeMVVM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using CafeMVVM.Views;

namespace CafeMVVM.ViewModels
{
    public class TaiKhoanViewModels:INotifyPropertyChanged
    {
        List<TaiKhoanModels> _DanhSachTaiKhoan;
        TaiKhoanDal taikhoandal = new TaiKhoanDal();
        TaiKhoanModels _SelectedTaiKhoan;
        private Boolean _ADMIN;
        private Boolean _USER;
        private string _TENDANGNHAP;
        private string _MATKHAU;
        private string _TEN;
        private string _TrangThai;
        public ICommand TaoTaiKhoanComand { get; set; }
        public ICommand XoaTaiKhoanComand { get; set; }
        public ICommand ResetPassComand { get; set; }
        public ICommand rdAdmin { get; set; }
        public ICommand rdUser { get; set; }
        public ICommand DangNhapCommand { get; set; }
        public List<TaiKhoanModels> DanhSachTaiKhoan
        {
            get
            {
                return _DanhSachTaiKhoan;
            }

            set
            {
                _DanhSachTaiKhoan = value;
                OnPropertyChanged("DanhSachTaiKhoan");
            }
        }

        public string TENDANGNHAP
        {
            get
            {
                return _TENDANGNHAP;
            }

            set
            {
                _TENDANGNHAP = value;
                OnPropertyChanged("TENDANGNHAP");
            }
        }

        public string MATKHAU
        {
            get
            {
                return _MATKHAU;
            }

            set
            {
                _MATKHAU = value;
                OnPropertyChanged("MATKHAU");
            }
        }

        public bool ADMIN
        {
            get
            {
                return _ADMIN;
            }

            set
            {
                _ADMIN = value;
                OnPropertyChanged("ADMIN");
            }
        }

        public bool USER
        {
            get
            {
                return _USER;
            }

            set
            {
                _USER = value;
                OnPropertyChanged("USER");
            }
        }

        public string TEN
        {
            get
            {
                return _TEN;
            }

            set
            {
                _TEN = value;
                OnPropertyChanged("TEN");
            }
        }

        public TaiKhoanModels SelectedTaiKhoan
        {
            get
            {
                return _SelectedTaiKhoan;
            }

            set
            {
                _SelectedTaiKhoan = value;
            }
        }

        public string TrangThai
        {
            get
            {
                return _TrangThai;
            }

            set
            {
                _TrangThai = value;
                OnPropertyChanged("TrangThai");
            }
        }

        public TaiKhoanViewModels()
        {
            TENDANGNHAP = "duyphan95z";
            DanhSachTaiKhoan = taikhoandal.sp_loadtaikhoan();
            bool QuyenAdmin = false, QuyenUser = false;
            rdAdmin = new RelayCommand<RadioButton>((p) => true, (p) => 
            {
                if (p.IsChecked == true)
                {
                    QuyenAdmin = true;
                    QuyenUser = false;
                }
                else
                {
                    QuyenAdmin = false;
                    QuyenUser = true;
                }
            });
            rdUser = new RelayCommand<RadioButton>((p) => true, (p) => 
            {
                if (p.IsChecked == true)
                {
                    QuyenUser = true;
                    QuyenAdmin = false;
                }
                else
                {
                    QuyenUser = false;
                    QuyenAdmin = true;
                }
            });
            TaoTaiKhoanComand = new RelayCommand<PasswordBox>((p) => true, (p) =>
            {
                if (TEN == null || TEN=="")
                {
                    ThongBao tb = new ThongBao("Chưa nhập họ tên", "CanhBao");
                    tb.ShowDialog();
                }
                else if (TENDANGNHAP == null || TENDANGNHAP=="")
                {
                    ThongBao tb = new ThongBao("Chưa nhập tên đăng nhập", "CanhBao");
                    tb.ShowDialog();
                }
                else if (p == null || string.IsNullOrEmpty(p.Password))
                {
                    ThongBao tb = new ThongBao("Chưa nhập mật khẩu", "CanhBao");
                    tb.ShowDialog();
                }
                else if (QuyenAdmin == false && QuyenUser == false)
                {
                    ThongBao tb = new ThongBao("Chưa chọn quyền tài khoản", "CanhBao");
                    tb.ShowDialog();
                }

                else
                {
                    try
                    {
                        
                        TaiKhoanModels tk_md = new TaiKhoanModels();
                        tk_md.TENDANGNHAP = TENDANGNHAP;
                        tk_md.MATKHAU = fMaHoa(p.Password);
                        tk_md.HOTEN = TEN;
                        if (QuyenAdmin == true)
                        {
                            tk_md.QUYEN = "Admin";
                        }
                        else if (QuyenUser == true)
                        {
                            tk_md.QUYEN = "User";
                        }
                        taikhoandal.sp_themtaikhoan(tk_md);
                        DanhSachTaiKhoan = taikhoandal.sp_loadtaikhoan();
                        TENDANGNHAP = "";
                        p.Password = "";
                        TEN = "";
                    }
                    catch
                    {
                        ThongBao tb = new ThongBao("Tên đăng nhập bị trùng, xin đặt tên khác", "CanhBao");
                        tb.ShowDialog();
                    }
                }
            });
            XoaTaiKhoanComand = new RelayCommand<object>((p) => true, (p) => 
            {
                if (SelectedTaiKhoan == null)
                {
                    ThongBao tb = new ThongBao("Chọn tài khoản trên danh sách để xóa", "CanhBao");
                    tb.ShowDialog();
                }
                else
                {
                    ThongBao tb = new ThongBao { DataContext = this };
                    tb.EventYesNo("Xóa tài khoản: " + SelectedTaiKhoan.TENDANGNHAP + " ?", "CauHoi");
                    tb.ShowDialog();
                    if (tb.Yes == true)
                    {
                        TaiKhoanModels tk_md = new TaiKhoanModels();
                        tk_md.TENDANGNHAP = SelectedTaiKhoan.TENDANGNHAP;
                        taikhoandal.sp_xoataikhoan(tk_md);
                        DanhSachTaiKhoan = taikhoandal.sp_loadtaikhoan();
                    }
                }
            });
            ResetPassComand = new RelayCommand<object>((p) => true, (p) =>
            {
                if (SelectedTaiKhoan == null)
                {
                    ThongBao tb = new ThongBao("Chọn tài khoản trên danh sách để Reset mật khẩu.", "CanhBao");
                    tb.ShowDialog();
                }
                else
                {
                    ThongBao tb = new ThongBao { DataContext = this };
                    tb.EventYesNo("Mật khẩu sẽ được đặt lại là: 123", "CauHoi");
                    tb.ShowDialog();
                    if (tb.Yes == true)
                    {
                        TaiKhoanModels tk_md = new TaiKhoanModels();
                        tk_md.TENDANGNHAP = SelectedTaiKhoan.TENDANGNHAP;
                        taikhoandal.sp_resetmatkhau(tk_md);
                        DanhSachTaiKhoan = taikhoandal.sp_loadtaikhoan();
                    }
                }
            });
            DangNhapCommand = new RelayCommand<PasswordBox>((p) => true, (p) =>
            {
                if (TENDANGNHAP == null || TENDANGNHAP == "")
                {
                    TrangThai = "Chưa điền tên đăng nhập";            
                }
                else if (p == null | p.Password == "")
                {
                    TrangThai = "Chưa điền mật khẩu";              
                }
                else
                {
                    TaiKhoanModels tk_md = new TaiKhoanModels();
                    tk_md.TENDANGNHAP = TENDANGNHAP;
                    List<TaiKhoanModels> danhsachtaikhoan = new List<TaiKhoanModels>();
                    danhsachtaikhoan=taikhoandal.sp_kiemtradangnhap(tk_md);
                    if (danhsachtaikhoan.Count > 0)
                    {
                        if (fMaHoa(p.Password) == danhsachtaikhoan[0].MATKHAU)
                        {
                            BienDungChung.idnhanvien = danhsachtaikhoan[0].TENDANGNHAP;
                            Cafe.fHome.capquyen(danhsachtaikhoan[0].QUYEN);
                            PageNen.pnen.setquyen(danhsachtaikhoan[0].HOTEN, danhsachtaikhoan[0].QUYEN);                    
                            PageDangNhap.dn.Close();
                        }
                        else
                        {
                            TrangThai = "Sai mật khẩu";                          
                        }
                    }
                    else
                    {
                        TrangThai = "Tên đăng nhập không đúng";                    
                    }
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
        public string fMaHoa(string pMatKhau)
        {
            try
            {
                MD5 md5 = MD5.Create();
                StringBuilder strBuilder = new StringBuilder();
                Byte[] bMd5 = md5.ComputeHash(Encoding.Default.GetBytes(pMatKhau));
                for (int iloop = 0; iloop < bMd5.Length; iloop++)
                {
                    strBuilder.Append(bMd5[iloop].ToString("x2"));
                }
                return strBuilder.ToString();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
        #endregion
    }
}
