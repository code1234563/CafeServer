using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CafeMVVM.Models
{
    public class KhuVucBanModels
    {
        private int _MAKHUVUC;
        private string _TENKHUVUC;
        private int _MABAN;
        private string _TENBAN;
        private string _TRANGTHAI;
        private int _SLBAN;
        private int _IDHOADON;

        public int MAKHUVUC
        {
            get
            {
                return _MAKHUVUC;
            }

            set
            {
                _MAKHUVUC = value;
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

        public string TRANGTHAI
        {
            get
            {
                return _TRANGTHAI;
            }

            set
            {
                _TRANGTHAI = value;
            }
        }

        public int SLBAN
        {
            get
            {
                return _SLBAN;
            }

            set
            {
                _SLBAN = value;
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
