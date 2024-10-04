using CafeMVVM.Dal;
using CafeMVVM.Models;
using CafeMVVM.Reports;
using CafeMVVM.Views;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace CafeMVVM.ViewModels
{
    public class KhuVucBanViewModels:INotifyPropertyChanged
    {
        KhuVucBanDal KhuVucDal = new KhuVucBanDal();
        ThucDonDal ThucDonDal = new ThucDonDal();
        HoaDonDal HoaDonDal = new HoaDonDal(); 
        private KhuVucBanModels _SelectedItem;
        private ThucDonModels _SelectedItemDMThucDon;
        private ThucDonModels _SelectedItemDMThucDonGiamGia;
        private KhuVucBanModels _SelectedItemBan;
        private KhuVucBanModels _SelectedBanCoNguoi;
        private KhuVucBanModels _SelectedBanTrong;
        private KhuVucBanModels _SelectedBanMuonGop;
        private KhuVucBanModels _SelectedBanDcGop;
        private ThucDonModels _ChonThucDonBanGiamGia;
        private List<KhuVucBanModels> _KhuVuc;
        private List<KhuVucBanModels> _BanKhuVuc;
        private List<KhuVucBanModels> _BanSoSanh;
        private List<ThucDonModels> _DanhMucThucDon;
        private List<ThucDonModels> _ThucDon;
        private List<KhuVucBanModels> _BanCoNguoi;
        private List<KhuVucBanModels> _BanTrong;
        private List<KhuVucBanModels> _BanMuonGop;
        private List<KhuVucBanModels> _BanDcGop;
        private ThucDonModels _ChonThucDonBan;
        private List<HoaDonModels> _DanhSachThucDonBan;
        private List<HoaDonModels> _DanhSachCTHDBanMuonGop;
        private List<KhuVucBanModels> _DanhSachBanTrong;
        private List<HoaDonModels> _DanhSachLoadHoaDonDeIn;
        private HoaDonModels _SelectMon;
        private Boolean _EnableGridDanhmuc;
        private object _TongTien;
        private int _SelectedIndexOfBan;
        private string _TieuDeHoaDon;
        private int _PhanTramGiamGia;

        public ICommand ThanhToanComand { private get; set; }
        public ICommand XoaMon { private get; set; }
        public ICommand ChuyenBanCommand { private get; set; }
        public ICommand XacNhanChuyenBanIcommand { private get; set; }
        public ICommand GopBan { private get; set; }
        public ICommand XacNhanGopBan { private get; set; }
        public ICommand ThemGiamGia { private get; set; }
        public ICommand GoGiamGia { private get; set; }
        public ICommand TimBanTrongCommand { private get; set; }
        int makhuvuc = 0;
        public KhuVucBanModels SelectedItem
        {
            get
            {
                return _SelectedItem;
            }

            set
            {
                _SelectedItem = value;
                if (_SelectedItem != null)
                {
                    BanKhuVuc = KhuVucDal.sp_loadbantheokhuvuc(_SelectedItem.MAKHUVUC);
                    makhuvuc = _SelectedItem.MAKHUVUC;
                    DanhSachThucDonBan = null;
                }
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
                OnPropertyChanged("KhuVuc");
            }
        }

        public List<KhuVucBanModels> BanKhuVuc
        {
            get
            {
                return _BanKhuVuc;
            }

            set
            {
                _BanKhuVuc = value;
                OnPropertyChanged("BanKhuVuc");
            }
        }

        public List<ThucDonModels> DanhMucThucDon
        {
            get
            {
                return _DanhMucThucDon;
            }

            set
            {
                _DanhMucThucDon = value;
            }
        }

        public ThucDonModels SelectedItemDMThucDon
        {
            get
            {
                return _SelectedItemDMThucDon;
            }

            set
            {
                _SelectedItemDMThucDon = value;
                if (_SelectedItemDMThucDon != null)
                {
                    ThucDon = ThucDonDal.sp_loadthucdon(_SelectedItemDMThucDon.MADM);
                }
                OnPropertyChanged("SelectedItemDMThucDon");
            }
        }

        public List<ThucDonModels> ThucDon
        {
            get
            {
                return _ThucDon;
            }

            set
            {
                _ThucDon = value;
                OnPropertyChanged("ThucDon");
            }
        }
        
        public KhuVucBanModels SelectedItemBan
        {
            get
            {
                return _SelectedItemBan;
            }

            set
            {
                _SelectedItemBan = value;
                if (_SelectedItemBan != null)
                {
                    index = SelectedIndexOfBan;
                    TieuDeHoaDon = "Hóa đơn " + SelectedItemBan.TENBAN + " | " + SelectedItem.TENKHUVUC;
                    // LÀM VẦY ĐỂ KHI CẬP NHẬT TRẠNG THÁI BÀN KHI THÊM HÓA ĐƠN . SELECTITEMBAN SẼ NULL VÌ LOAD LẠI TRẠNG THÁI, CÁI NÀY GÁN BIẾN TOÀN CỤC CHO MÃ BÀN VÀ TÊN BÀN
                    MABANKHISELECT = SelectedItemBan.MABAN;
                    TENBANKHISELECT = SelectedItemBan.TENBAN;
                    EnableGridDanhmuc = true;
                    List<HoaDonModels> listhoadon;
                    listhoadon = HoaDonDal.sp_layidhoadontheo_khuvucban(SelectedItemBan.MABAN, SelectedItem.MAKHUVUC);
                    if (listhoadon.Count > 0)
                    {
                        IDHOADON = listhoadon[0].IDHOADON;
                        DanhSachThucDonBan = HoaDonDal.sp_loaddanhsachthucdoncuaban(SelectedItemBan.MABAN, IDHOADON);
                         Tong = 0;
                        for (int i = 0; i < DanhSachThucDonBan.Count; i++)
                        {
                            Tong = Tong + (DanhSachThucDonBan[i].SOLUONG * double.Parse(DanhSachThucDonBan[i].DONGIA.ToString()));
                        }
                        TongTien = "Tổng " + SelectedItemBan.TENBAN + " | " + SelectedItem.TENKHUVUC + " : " + double.Parse(Tong.ToString()).ToString("N0") + " Vnđ";
                        TieuDeHoaDon = "Hóa đơn " + SelectedItemBan.TENBAN + " | " + SelectedItem.TENKHUVUC;
                    }
                    else
                    {
                        TieuDeHoaDon = "";
                        DanhSachThucDonBan = null;
                        TongTien = "";
                    }
                }
            }
        }
        private int MABANKHISELECT = 0;
        string TENBANKHISELECT = "";
        private int IDHOADON = 0;
        public List<HoaDonModels> DanhSachThucDonBan
        {
            get
            {
                return _DanhSachThucDonBan;
            }

            set
            {
                _DanhSachThucDonBan = value;
                OnPropertyChanged("DanhSachThucDonBan");
            }
        }
      
        public bool EnableGridDanhmuc
        {
            get
            {
                return _EnableGridDanhmuc;
            }

            set
            {
                _EnableGridDanhmuc = value;
                OnPropertyChanged("EnableGridDanhmuc");
            }
        }
        double Tong = 0;
        public ThucDonModels ChonThucDonBan
        {
            get
            {
                return _ChonThucDonBan;
            }

            set
            {
                _ChonThucDonBan = value;
                if (_ChonThucDonBan != null)
                {
                    TieuDeHoaDon = "Hóa đơn " + TENBANKHISELECT + " | " + SelectedItem.TENKHUVUC;
                    if (SelectedItemBan == null)
                    {
                        ThongBao tb = new ThongBao("Chưa chọn bàn", "CanhBao");
                        tb.ShowDialog();
                    }
                    else
                    {
                        List<HoaDonModels> listhoadon;
                        listhoadon = HoaDonDal.sp_layidhoadontheo_khuvucban(MABANKHISELECT, SelectedItem.MAKHUVUC);
                        if (listhoadon.Count > 0)
                        {
                            IDHOADON = listhoadon[0].IDHOADON;
                            HoaDonDal.sp_themcthdban(IDHOADON, ChonThucDonBan.MATHUCDON, 1, ChonThucDonBan.GIAMGIA);
                            DanhSachThucDonBan = HoaDonDal.sp_loaddanhsachthucdoncuaban(MABANKHISELECT, IDHOADON);

                            if (DanhSachThucDonBan.Count > 0)
                            {
                                double Tong = 0;
                                for (int i = 0; i < DanhSachThucDonBan.Count; i++)
                                {
                                    Tong = Tong + (DanhSachThucDonBan[i].SOLUONG * double.Parse(DanhSachThucDonBan[i].DONGIA.ToString()));
                                }
                                TongTien = "Tổng tiền hóa đơn " + TENBANKHISELECT + " | " + SelectedItem.TENKHUVUC + " : " + double.Parse(Tong.ToString()).ToString("N0") + " Vnđ";

                            }
                            else
                            {
                                TongTien = "";
                            }
                            ChonThucDonBan = null;
                            OnPropertyChanged("ChonThucDonBan");
                        }

                        else
                        {
                            if (SelectedItemBan == null)
                            {
                                ThongBao tb = new ThongBao("Chưa chọn bàn", "CanhBao");
                                tb.ShowDialog();                                
                            }
                            else
                            {
                                HoaDonDal.sp_themhoadon(DateTime.Now.ToString("yyyy-MM-dd"), SelectedItemBan.MABAN);
                                List<HoaDonModels> listhoadon1;
                                listhoadon1 = HoaDonDal.sp_layidhoadontheo_khuvucban(MABANKHISELECT, SelectedItem.MAKHUVUC);
                                if (listhoadon1.Count > 0)
                                {
                                    IDHOADON = listhoadon1[0].IDHOADON;
                                    HoaDonDal.sp_themcthdban(IDHOADON, ChonThucDonBan.MATHUCDON, 1, ChonThucDonBan.GIAMGIA);
                                    DanhSachThucDonBan = HoaDonDal.sp_loaddanhsachthucdoncuaban(MABANKHISELECT, IDHOADON);

                                    for (int i = 0; i < DanhSachThucDonBan.Count; i++)
                                    {
                                        Tong = Tong + (DanhSachThucDonBan[i].SOLUONG * double.Parse(DanhSachThucDonBan[i].DONGIA.ToString()));
                                    }
                                    TongTien = "Tổng tiền hóa đơn " + TENBANKHISELECT + " | " + SelectedItem.TENKHUVUC + " : " + double.Parse(Tong.ToString()).ToString("N0") + " Vnđ";

                                }
                                else
                                {
                                    TongTien = "";
                                }
                                ChonThucDonBan = null;
                                OnPropertyChanged("ChonThucDonBan");
                            }
                        }
                        BanKhuVuc = KhuVucDal.sp_loadbantheokhuvuc(SelectedItem.MAKHUVUC); // load tại trạng thái bàn    
                        SelectedIndexOfBan = index;
                    }
                }
            }
        }

        public object TongTien
        {
            get
            {
                return _TongTien;
            }

            set
            {
                _TongTien = value;
                OnPropertyChanged("TongTien");
            }
        }
        int index = 0;
        public int SelectedIndexOfBan
        {
            get
            {
                return _SelectedIndexOfBan;
            }

            set
            {
                _SelectedIndexOfBan = value;
                OnPropertyChanged("SelectedIndexOfBan");
            }
        }

        public string TieuDeHoaDon
        {
            get
            {
                return _TieuDeHoaDon;
            }

            set
            {
                _TieuDeHoaDon = value;
                OnPropertyChanged("TieuDeHoaDon");
            }
        }

        public HoaDonModels SelectMon
        {
            get
            {
                return _SelectMon;
            }

            set
            {
                _SelectMon = value;               
            }
        }

        public List<KhuVucBanModels> BanCoNguoi
        {
            get
            {
                return _BanCoNguoi;
            }

            set
            {
                _BanCoNguoi = value;
                OnPropertyChanged("BanCoNguoi");
            }
        }

        public List<KhuVucBanModels> BanTrong
        {
            get
            {
                return _BanTrong;
            }

            set
            {
                _BanTrong = value;
                OnPropertyChanged("BanTrong");
            }
        }

        public KhuVucBanModels SelectedBanCoNguoi
        {
            get
            {
                return _SelectedBanCoNguoi;
            }

            set
            {
                _SelectedBanCoNguoi = value;
            }
        }

        public KhuVucBanModels SelectedBanTrong
        {
            get
            {
                return _SelectedBanTrong;
            }

            set
            {
                _SelectedBanTrong = value;
            }
        }

        public List<KhuVucBanModels> BanMuonGop
        {
            get
            {
                return _BanMuonGop;
            }

            set
            {
                _BanMuonGop = value;
                OnPropertyChanged("BanMuonGop");       
            }
        }

        public List<KhuVucBanModels> BanDcGop
        {
            get
            {
                return _BanDcGop;
            }

            set
            {
                _BanDcGop = value;
                OnPropertyChanged("BanDcGop");
            }
        }

        public KhuVucBanModels SelectedBanMuonGop
        {
            get
            {
                return _SelectedBanMuonGop;
            }

            set
            {
                _SelectedBanMuonGop = value;
                if (_SelectedBanMuonGop != null)
                {
                    BanDcGop = KhuVucDal.sp_loadbancangop(SelectedItem.MAKHUVUC, _SelectedBanMuonGop.MABAN);
                }
            }
        }

        public KhuVucBanModels SelectedBanDcGop
        {
            get
            {
                return _SelectedBanDcGop;
            }

            set
            {
                _SelectedBanDcGop = value;
            }
        }

        public List<HoaDonModels> DanhSachCTHDBanMuonGop
        {
            get
            {
                return _DanhSachCTHDBanMuonGop;
            }

            set
            {
                _DanhSachCTHDBanMuonGop = value;
                OnPropertyChanged("DanhSachCTHDBanMuonGop");
            }
        }

        public ThucDonModels SelectedItemDMThucDonGiamGia
        {
            get
            {
                return _SelectedItemDMThucDonGiamGia;
            }

            set
            {
                _SelectedItemDMThucDonGiamGia = value;
                if (_SelectedItemDMThucDonGiamGia != null)
                {
                    ThucDon = ThucDonDal.sp_loadthucdon(SelectedItemDMThucDonGiamGia.MADM);
                }
            }
        }

        public ThucDonModels ChonThucDonBanGiamGia
        {
            get
            {
                return _ChonThucDonBanGiamGia;
            }

            set
            {
                _ChonThucDonBanGiamGia = value;
            }
        }

        public int PhanTramGiamGia
        {
            get
            {
                return _PhanTramGiamGia;
            }

            set
            {
                _PhanTramGiamGia = value;
                OnPropertyChanged("PhanTramGiamGia");
            }
        }

        public List<KhuVucBanModels> DanhSachBanTrong
        {
            get
            {
                return _DanhSachBanTrong;
            }

            set
            {
                _DanhSachBanTrong = value;
                OnPropertyChanged("DanhSachBanTrong");
            }
        }

        public List<KhuVucBanModels> BanSoSanh
        {
            get
            {
                return _BanSoSanh;
            }

            set
            {
                _BanSoSanh = value;
                OnPropertyChanged("BanSoSanh");
            }
        }

        public List<HoaDonModels> DanhSachLoadHoaDonDeIn
        {
            get
            {
                return _DanhSachLoadHoaDonDeIn;
            }

            set
            {
                _DanhSachLoadHoaDonDeIn = value;
                OnPropertyChanged("DanhSachLoadHoaDonDeIn");
            }
        }
        
        private void thanhtoanhoadon()
        {
            if (MABANKHISELECT == 0 || SelectedItem == null)
            {
                ThongBao tb = new ThongBao("Hóa đơn trống", "CanhBao");
                tb.ShowDialog();               
            }
            else
            {
                List<HoaDonModels> listhoadon;
                int makhuvuc = SelectedItem.MAKHUVUC;
                listhoadon = HoaDonDal.sp_layidhoadontheo_khuvucban(MABANKHISELECT, makhuvuc);
                if (listhoadon.Count > 0)
                {
                    HoaDonDal.sp_thanhtoanban(MABANKHISELECT, listhoadon[0].IDHOADON, Tong,BienDungChung.idnhanvien);
                    //ThongBao tb = new ThongBao("Thanh toán hóa đơn " + TENBANKHISELECT + " | " + SelectedItem.TENKHUVUC + " thành công.", "ThanhCong");
                    //tb.ShowDialog();         
                    //Show hóa đơn, sau này thì chi in trực tiếp  
                    HoaDonRpt hdrpt = new HoaDonRpt();
                    hdrpt.RequestParameters = false;
                    hdrpt.DataSource = HoaDonDal.sp_loaddanhsachthucdoncuaban_rpt(MABANKHISELECT, listhoadon[0].IDHOADON, DateTime.Now.ToShortTimeString().ToString().Substring(0,5));
                    hdrpt.DataMember = null;
                    ReportPrintTool toolrpt = new ReportPrintTool(hdrpt);
                    toolrpt.AutoShowParametersPanel = false;                    
                    toolrpt.ShowRibbonPreview();
                    //load lại bàn và hóa đơn
                    BanKhuVuc = KhuVucDal.sp_loadbantheokhuvuc(makhuvuc);                                    
                    EnableGridDanhmuc = false;                  
                    TongTien = "";
                    TieuDeHoaDon = "";
                    DanhSachThucDonBan = null;                   
                }
            }
        }
        
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        DispatcherTimer dispatcherTimer1 = new DispatcherTimer();
        public KhuVucBanViewModels()
        {
            SelectedIndexOfBan = -1;
            PhanTramGiamGia = 0;
               KhuVuc = KhuVucDal.sp_loadkhuvuc();
            DanhMucThucDon = ThucDonDal.sp_danhmucloadthucdon();
            EnableGridDanhmuc = false;
            ThanhToanComand = new RelayCommand<object>((p) => true, (p) => 
            {
                thanhtoanhoadon();
            });
            XoaMon = new RelayCommand<object>((p) => true, (p) =>
            {
                if (IDHOADON == 0)
                {
                    ThongBao tb = new ThongBao("Hóa đơn trống", "CanhBao");
                    tb.ShowDialog();
                }
                else if (SelectMon == null)
                {
                    ThongBao tb = new ThongBao("Chọn món trên danh sách để xóa.", "CanhBao");
                    tb.ShowDialog();                   
                }
                else
                {                      
                    KhuVucDal.sp_xoachitiethoadon(IDHOADON, SelectMon.MATHUCDON, SelectMon.GIAMGIA);
                    DanhSachThucDonBan = HoaDonDal.sp_loaddanhsachthucdoncuaban(MABANKHISELECT, IDHOADON);
                    if (DanhSachThucDonBan.Count == 0)
                    {
                        KhuVucDal.sp_xoahoadonkhihetmon(IDHOADON,SelectedItemBan.MABAN);
                        int makhuvuc = SelectedItem.MAKHUVUC;
                        BanKhuVuc = KhuVucDal.sp_loadbantheokhuvuc(makhuvuc);
                        DanhSachThucDonBan = HoaDonDal.sp_loaddanhsachthucdoncuaban(MABANKHISELECT, IDHOADON);
                        SelectedIndexOfBan = index;
                    }
                }
            });
            ChuyenBanCommand = new RelayCommand<object>((p) => true, (p) => 
            {
                if (SelectedItem == null)
                {
                    ThongBao tb = new ThongBao("Chưa chọn khu vực", "CanhBao");
                    tb.ShowDialog();
                }
                else
                {
                    BanTrong = KhuVucDal.sp_loadbantrangthaitrong(SelectedItem.MAKHUVUC);
                    BanCoNguoi = KhuVucDal.sp_loadbantrangthaiconguoi(SelectedItem.MAKHUVUC);
                    WindowService.ShowFormChuyenBan(false, this, (Window)p);
                }
            });
            XacNhanChuyenBanIcommand = new RelayCommand<object>((p) => true, (p) =>
            {
                if (SelectedBanCoNguoi == null)
                {
                    ThongBao tb = new ThongBao("Chưa chọn bàn cần chuyển", "CanhBao");
                    tb.ShowDialog();                    
                }
                else if (SelectedBanTrong == null)
                {
                    ThongBao tb = new ThongBao("Chưa chọn bàn trống", "CanhBao");
                    tb.ShowDialog();                   
                }
                else
                {
                    KhuVucDal.sp_chuyenbantable(SelectedBanTrong.MABAN, SelectedBanCoNguoi.MABAN);
                    BanKhuVuc = KhuVucDal.sp_loadbantheokhuvuc(SelectedItem.MAKHUVUC);
                    WindowService.ShowFormChuyenBan(true, this, (Window)p);
                }
            });
            GopBan = new RelayCommand<object>((p) => true, (p) =>
            {
                if (SelectedItem == null)
                {
                    ThongBao tb = new ThongBao("Chưa chọn khu vực", "CanhBao");
                    tb.ShowDialog();                    
                }
                else
                {
                    BanMuonGop = KhuVucDal.sp_loadbantrangthaiconguoi(SelectedItem.MAKHUVUC);
                    WindowService.ShowFormGopBan(false, this, (Window)p);
                }
            });
            XacNhanGopBan = new RelayCommand<object>((p) => true, (p) =>
            {
                if (SelectedBanMuonGop == null)
                {
                    ThongBao tb = new ThongBao("Chưa chọn bạn gộp", "CanhBao");
                    tb.ShowDialog();                   
                }
                else if (SelectedItem == null)
                {
                    ThongBao tb = new ThongBao("Chưa chọn khu vực", "CanhBao");
                    tb.ShowDialog();                   
                }
                else if (SelectedBanDcGop == null)
                {
                    ThongBao tb = new ThongBao("Chưa chọn bạn muốn gộp", "CanhBao");
                    tb.ShowDialog();                   
                }
                else
                {
                    DanhSachCTHDBanMuonGop = KhuVucDal.sp_loadcthdbangop(SelectedBanMuonGop.MABAN);
                    if (DanhSachCTHDBanMuonGop != null)
                    {
                        for (int i = 0; i < DanhSachCTHDBanMuonGop.Count; i++)
                        {
                            HoaDonDal.sp_themcthdban(SelectedBanDcGop.IDHOADON, DanhSachCTHDBanMuonGop[i].MATHUCDON, DanhSachCTHDBanMuonGop[i].SOLUONG, DanhSachCTHDBanMuonGop[i].GIAMGIA);
                        }
                        KhuVucDal.sp_xoahoadongopban(SelectedBanMuonGop.MABAN);
                        BanKhuVuc = KhuVucDal.sp_loadbantheokhuvuc(SelectedItem.MAKHUVUC);
                        WindowService.ShowFormGopBan(true, this, (Window)p);
                    }
                }
            });
            ThemGiamGia = new RelayCommand<object>((p) => true, ((p) => 
            {  
                    if (ChonThucDonBanGiamGia == null)
                    {
                        ThongBao tb = new ThongBao("Chưa chọn món cần giảm", "CanhBao");
                        tb.ShowDialog();                        
                    }
                    else if (PhanTramGiamGia < 0)
                    {
                        ThongBao tb = new ThongBao("Giảm giá không được âm", "CanhBao");
                        tb.ShowDialog();                        
                    }
                    else if (PhanTramGiamGia > 100)
                    {
                        ThongBao tb = new ThongBao("Giảm giá không lớn hơn 100%", "CanhBao");
                        tb.ShowDialog();                        
                    }
                    else
                    {
                        ThucDonDal.sp_themgiamgia(ChonThucDonBanGiamGia.MATHUCDON, PhanTramGiamGia);
                        ThucDon = ThucDonDal.sp_loadthucdon(SelectedItemDMThucDonGiamGia.MADM);
                    }                            
            }));
            GoGiamGia = new RelayCommand<object>((p) => true, ((p) =>
            {
                if (ChonThucDonBanGiamGia == null)
                {
                    ThongBao tb = new ThongBao("Chưa chọn món gỡ bỏ giảm giá", "CanhBao");
                    tb.ShowDialog();                   
                }
                else
                {
                    ThucDonDal.sp_xoagiamgia(ChonThucDonBanGiamGia.MATHUCDON);
                    ThucDon = ThucDonDal.sp_loadthucdon(SelectedItemDMThucDonGiamGia.MADM);
                }
            }));
            TimBanTrongCommand = new RelayCommand<object>((p) => true, (p) => 
            {
                DanhSachBanTrong = KhuVucDal.sp_danhsachkhuvuccobantrong();
                KhuVucBanTrong khuvucbantrong = new KhuVucBanTrong { DataContext = this };
                khuvucbantrong.ShowDialog();
            });
            Thread TrangThai = new Thread(TimerTrangThai);
            TrangThai.IsBackground = false;
            TrangThai.Start();
            Thread ThreadInHoaDon = new Thread(TimerInHoaDon);
            ThreadInHoaDon.IsBackground = false;
            ThreadInHoaDon.Start();
        }
        private void TimerTrangThai()
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
            dispatcherTimer.Start();
        }
        private void TimerInHoaDon()
        {           
            dispatcherTimer1.Interval = new TimeSpan(0, 0, 2);
            dispatcherTimer1.Tick += new EventHandler(HamInHoaDonTuClient);
            dispatcherTimer1.Start();
        }

        private void HamInHoaDonTuClient(object sender, EventArgs e)
        {
            DanhSachLoadHoaDonDeIn = HoaDonDal.sp_loadhoadoncanin();
            if (DanhSachLoadHoaDonDeIn.Count > 0)
            {
                for (int i = 0; i < DanhSachLoadHoaDonDeIn.Count; i++)
                {
                    if (DanhSachLoadHoaDonDeIn[i].INHOADON == 1)
                    {
                        HoaDonRpt hdrpt = new HoaDonRpt();
                        hdrpt.RequestParameters = false;
                        hdrpt.DataSource = HoaDonDal.sp_loaddanhsachthucdoncuaban_rpt(DanhSachLoadHoaDonDeIn[i].MABAN, DanhSachLoadHoaDonDeIn[i].IDHOADON, DateTime.Now.ToShortTimeString().ToString().Substring(0, 5));
                        hdrpt.DataMember = null;
                        ReportPrintTool toolrpt = new ReportPrintTool(hdrpt);
                        toolrpt.AutoShowParametersPanel = false;
                        toolrpt.ShowRibbonPreview();
                        HoaDonDal.sp_capnhathoadondain(DanhSachLoadHoaDonDeIn[i].IDHOADON);
                        break;
                    }
                }
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (SelectedItem != null)
            {
                BanSoSanh = KhuVucDal.sp_loadbantheokhuvuc(makhuvuc);
                for (int i = 0; i < BanKhuVuc.Count; i++)
                {
                    if (BanKhuVuc[i].TRANGTHAI != BanSoSanh[i].TRANGTHAI)
                    {
                        BanKhuVuc = KhuVucDal.sp_loadbantheokhuvuc(makhuvuc);
                        break;
                    }
                }
            }
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
