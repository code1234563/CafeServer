using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVVM.Models
{
    public class TaiKhoanModels
    {
        private string _TENDANGNHAP;
        private string _MATKHAU;
        private string _QUYEN;
        private string _HOTEN;

        public string TENDANGNHAP
        {
            get
            {
                return _TENDANGNHAP;
            }

            set
            {
                _TENDANGNHAP = value;
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
            }
        }

        public string QUYEN
        {
            get
            {
                return _QUYEN;
            }

            set
            {
                _QUYEN = value;
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
    }
}
