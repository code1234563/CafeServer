using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVVM.Models
{
    public class HoaDonModels
    {
        private int _IDHOADON;
        private int _MABAN;
        private object _NGAYLAP;
        private double _TONGTIEN;
        private int _TRANGTHAIHOADON;
        private int _IDCTHD;
        private int _MATHUCDON;
        private int _SOLUONG;
        private string _TENTHUCDON;
        private object _DONGIA;
        private int _GIAMGIA;
        private string _HOTEN;
        private string _GIOLAP;
        private string _TENBAN;
        private string _TENKHUVUC;
        private string _GIORA;
        private double _TTIEN;
        private int _INHOADON;

        public int IDHOADON
        {
            get
            {
                return _IDHOADON;
            }

            set
            {
                _IDHOADON = value;
            }
        }

        public int MABAN
        {
            get
            {
                return _MABAN;
            }

            set
            {
                _MABAN = value;
            }
        }

        public object NGAYLAP
        {
            get
            {
                return _NGAYLAP;
            }

            set
            {
                _NGAYLAP = value;
            }
        }

        public double TONGTIEN
        {
            get
            {
                return _TONGTIEN;
            }

            set
            {
                _TONGTIEN = value;
            }
        }

        public int TRANGTHAIHOADON
        {
            get
            {
                return _TRANGTHAIHOADON;
            }

            set
            {
                _TRANGTHAIHOADON = value;
            }
        }

        public int IDCTHD
        {
            get
            {
                return _IDCTHD;
            }

            set
            {
                _IDCTHD = value;
            }
        }

        public int MATHUCDON
        {
            get
            {
                return _MATHUCDON;
            }

            set
            {
                _MATHUCDON = value;
            }
        }

        public int SOLUONG
        {
            get
            {
                return _SOLUONG;
            }

            set
            {
                _SOLUONG = value;
            }
        }

        public string TENTHUCDON
        {
            get
            {
                return _TENTHUCDON;
            }

            set
            {
                _TENTHUCDON = value;
            }
        }

        public object DONGIA
        {
            get
            {
                return _DONGIA =double.Parse(_DONGIA.ToString()).ToString("N0");
            }

            set
            {
                _DONGIA = value;
            }
        }

        public int GIAMGIA
        {
            get
            {
                return _GIAMGIA;
            }

            set
            {
                _GIAMGIA = value;
            }
        }

        public string HOTEN
        {
            get
            {
                return _HOTEN;
            }

            set
            {
                _HOTEN = value;
            }
        }

        public string GIOLAP
        {
            get
            {
                return _GIOLAP;
            }

            set
            {
                _GIOLAP = value;
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
            }
        }

        public string TENKHUVUC
        {
            get
            {
                return _TENKHUVUC;
            }

            set
            {
                _TENKHUVUC = value;
            }
        }

        public string GIORA
        {
            get
            {
                return _GIORA;
            }

            set
            {
                _GIORA = value;
            }
        }

        public double TTIEN
        {
            get
            {
                return _TTIEN;
            }

            set
            {
                _TTIEN = value;
            }
        }

        public int INHOADON
        {
            get
            {
                return _INHOADON;
            }

            set
            {
                _INHOADON = value;
            }
        }
    }
}
