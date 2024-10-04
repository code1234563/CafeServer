using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVVM.Models
{
    public class ThongKeModels
    {
        private string _TENTHUCDON;
        private int _IDHOADON;
        private string _TENKHUVUC;
        private int _SOLUONG;
        private object _DONGIA;
        private int _GIAMGIA;
        private string _TENBAN;
        private object _TONGTIEN;
        private object _NGAYLAP;
        private string _GIOLAP;

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

        public object DONGIA
        {
            get
            {
                return _DONGIA=double.Parse(_DONGIA.ToString()).ToString("N0");
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

        public object TONGTIEN
        {
            get
            {
                return _TONGTIEN=double.Parse(_TONGTIEN.ToString()).ToString("N0");
            }

            set
            {
                _TONGTIEN = value;
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
    }
}
