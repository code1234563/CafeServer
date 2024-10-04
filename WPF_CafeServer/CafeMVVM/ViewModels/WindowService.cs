using CafeMVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CafeMVVM.ViewModels
{
    public class WindowService: Window
    {
        public static void ShowFormSuaBan(bool TatForm,BanViewModels BanVMD,Window wd)
        {
            PageSuaBan suatenban = new PageSuaBan { DataContext = BanVMD };
            Window wn = (Window)suatenban.Parent;
            if (TatForm == false)
            {
                wn.ShowDialog();
            }
            else if (TatForm == true)
            {
                wn.Close();
                wd.Close();
            }
        }
        public static void ShowFormChuyenBan(bool TatForm, KhuVucBanViewModels KhuVucVMD,Window wd)
        {           
            PageChuyenBan chuyenban = new PageChuyenBan { DataContext = KhuVucVMD };           
            if (TatForm == false)
            {
                chuyenban.ShowDialog();
            }
            else if (TatForm == true)
            {
                chuyenban.Close();
                wd.Close();
            }           
        }
        public static void ShowFormGopBan(bool TatForm, KhuVucBanViewModels KhuVucVMD, Window wd)
        {
            PageGopBan gopban = new PageGopBan { DataContext = KhuVucVMD };          
            if (TatForm == false)
            {
                gopban.ShowDialog();
            }
            else if (TatForm == true)
            {
                gopban.Close();
                wd.Close();
            }
        }
        public static void DongFormDangNhap(Window w)
        {
            w.Close();
        }
    }
}
