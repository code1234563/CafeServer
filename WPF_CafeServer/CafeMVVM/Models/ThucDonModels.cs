using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVVM.Models
{
    public class ThucDonModels
    {
        private int _MADM;
        private string _TENDM;
        private int _MATHUCDON;
        private string _TENTHUCDON;
        private object _DONGIA;
        private int _GIAMGIA;

        public int MADM
        {
            get
            {
                return _MADM;
            }

            set
            {
                _MADM = value;
            }
        }

        public string TENDM
        {
            get
            {
                return _TENDM;
            }

            set
            {
                _TENDM = value;
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
    }
}
