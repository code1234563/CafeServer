   M S B A M L   `   `   `  ����C  ?CafeMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CafeMVVM.ViewModelsCafeMVVM.ViewModels  5   	   M IWpfPageTransitions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS<clr-namespace:WpfPageTransitions;assembly=WpfPageTransitionsWpfPageTransitions 5   	       CafeMVVM.Views.Cafe   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:CafeMVVM.ViewModels     5   	   XpageTransitions<clr-namespace:WpfPageTransitions;assembly=WpfPageTransitions     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   
   -   5          � Title$
  Cafe��5	   	   $	��640��6   $
��1200��6#    � 
ResizeMode$ NoResize=�60    � WindowStartupLocation$ CenterScreen=�6F      MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .��5      � ��5   
   �� 5      -   5        igridnen�� j� Stretch$
 Fill=�5   +   6<    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   6.   �� 5      6!   .+�5   
   �� .+�5      �� -   5         ��Name$ 	btnphucvu��5   �   {�.   � ToolTip$' !Dành cho nhân viên phục vụ��6'    " MaterialDesignRaisedDarkButton#��[ 6L   $��5,10,0,5q�6�   $
��Left=�6�   $��60��6�   $	��160��6�   .��5      �� 	 �� Orientation$	 
Horizontal=�6   .+�5      �� -   5        
 ��Name$
 
hinhphucvu��5      $
��Left=�60   $
��Fill=�6K   $��30��6Z   $��30��6e   6t   �� 5      $��  PHỤC VỤ��6   $��Segoe UI)�60   $��15(�6F   $��Center=�6T   
�������$��0,0,0,0q�6�   $
��Bold"�6�   $��Center=�6�   $��1��6�   6�   5      5       �� 5!      -   5        $ 	btnkhuvuc��5!   '   {�.  $ Thêm khu vực cho quán��6R   #��[ 6r   $��5,0,0,5q�6�   $
��Left=�6�   $��60��6�   $	��160��6�   .��5"      �� $	 
Horizontal=�6   .+�5#      �� -   5        $
 
hinhkhuvuc��5#      $
��Left=�60   $
��Fill=�6K   $��30��6Z   $��30��6e   6t   �� 5$      $��   KHU VỰC��6   $��Segoe UI)�62   $��15(�6H   $��Center=�6V   
�������$��0,0,0,0q�6�   $
��Bold"�6�   $��Center=�6�   $��1��6�   6�   5%      5&      �� 5'      -   5        $ btnban��5'   (   {�.  $ Thêm bàn cho khu vực��6M   #��[ 6l   $��5,0,0,5q�6�   $
��Left=�6�   $��60��6�   $	��160��6�   .��5(      �� $	 
Horizontal=�6   .+�5)      �� -   5        $
 hinhban��5)      $
��Left=�6-   $
��Fill=�6H   $��30��6W   $��30��6b   6q   �� 5*      $��BÀN            ��6   $��Segoe UI)�66   $��15(�6L   $��Center=�6Z   
�������$��0,0,0,0q�6�   $
��Bold"�6�   $��Center=�6�   $��1��6�   6�   5+      5,      �� 5-      -	   5        $ 
btnthucdon��5-   (   {�.  $ Thêm danh mục và món��6U   #��[ 6t   $��5,0,0,5q�6�   $
��Left=�6�   $��60��6�   $	��160��6�   .��5.      �� $	 
Horizontal=�6   .+�5/      �� -
   5        $
 hinhthucdon��5/      $
��Left=�61   $
��Fill=�6L   $��30��6[   $��30��6f   6u   �� 50      $��THỰC ĐƠN��6   $��Segoe UI)�6/   $��15(�6E   $��Center=�6S   
�������$��0,0,0,0q�6�   $
��Bold"�6�   $��Center=�6�   $��1��6�   6�   51      52      �� 53      -   5        $ 
btngiamgia��53   '   {�.  $ GIẢM GIÁ��6T   #��[ 6g   $��5,0,0,5q�6�   $
��Left=�6�   $��60��6�   $	��160��6�   .��54      �� $	 
Horizontal=�6   .+�55      �� -   5        $
 hinhgiamgia��55      $
��Left=�61   $
��Fill=�6L   $��30��6[   $��30��6f   6u   �� 56      $��GIẢM GIÁ  ��6   $��Segoe UI)�61   $��15(�6G   $��Center=�6U   
�������$��0,0,0,0q�6�   $
��Bold"�6�   $��Center=�6�   $��1��6�   6�   57      58      �� 59      -   5        $ 
btnthongke��59   '   {�.  $ Thống kê danh thu��6T   #��[ 6p   $��5,0,0,5q�6�   $
��Left=�6�   $��60��6�   $	��160��6�   .��5:      �� $	 
Horizontal=�6   .+�5;      �� -   5        $
 hinhthongke��5;      $
��Left=�61   $
��Fill=�6L   $��30��6[   $��30��6f   6u   �� 5<      $��THỐNG KÊ��6   $��Segoe UI)�6/   $��15(�6E   $��Center=�6S   
�������$��0,0,0,0q�6�   $
��Bold"�6�   $��Center=�6�   $��1��6�   6�   5=      5>      �� 5?      -   5        $ btntaikhoan��5?   '   {�.  $ Quản lý tài khoản��6V   #��[ 6s   $��5,0,0,5q�6�   $
��Left=�6�   $��60��6�   $	��160��6�   .��5@      �� $	 
Horizontal=�6   .+�5A      �� -   5        $
 hinhtaikhoan��5A      $
��Left=�62   $
��Fill=�6M   $��30��6\   $��30��6g   6v   �� 5B      $��TÀI KHOẢN��6   $��Segoe UI)�60   $��15(�6F   $��Center=�6T   
�������$��0,0,0,0q�6�   $
��Bold"�6�   $��Center=�6�   $��1��6�   6�   5C      5D      �� 5E      -   5        $ btndangxuat��5E   '   {�.  $ Đăng xuất��6W   #��[ 6l   $��5,0,0,5q�6�   $
��Left=�6�   $��60��6�   $	��160��6�   .��5F      �� $	 
Horizontal=�6   .+�5G      �� -   5        $
 hinhdangxuat��5G      $
��Left=�62   $
��Fill=�6M   $��30��6\   $��30��6g   6v   �� 5H      $��ĐĂNG XUẤT��6   $��Segoe UI)�60   $��15(�6F   $��Center=�6T   
�������$��0,0,0,0q�6�   $
��Bold"�6�   $��Center=�6�   $��1��6�   6�   5I      5J      �� 5K      -   5        $ btnthoat��5K   B   {�.  $ Tắt chương trình��6'   #��[ 6k   $��5,0,0,5q�6�   $
��Left=�6�   $��60��6�   $	��160��6�   .��5L      �� $	 
Horizontal=�6   .+�5M      �� -   5        $
 	hinhthoat��5M      $
��Left=�6/   $
��Fill=�6J   $��30��6Y   $��30��6d   6s   �� 5N      $��THOÁT       ��6   $��Segoe UI)�63   $��15(�6I   $��Center=�6W   
�������$��0,0,0,0q�6�   $
��Bold"�6�   $��Center=�6�   $��1��6�   6�   5O      5P      5Q      � 5R   
   $��1��6   .+�5S      '  !WpfPageTransitions.PageTransition  -   5        $��pageTransitionControl��5S   -   $��15q�6J      TransitionType$ SlideAndFade=�6V   5T      5U      5V      