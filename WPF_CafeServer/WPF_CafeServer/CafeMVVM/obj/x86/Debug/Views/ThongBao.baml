   M S B A M L   `   `   `  ����C  ?CafeMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CafeMVVM.ViewModelsCafeMVVM.ViewModels  5   	       CafeMVVM.Views.ThongBao   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:CafeMVVM.ViewModels     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	     � WindowStartupLocation$  CenterScreen=�5       � WindowStyle$
 None=�6?    � AllowsTransparency . 
������ $	��150��5	   	   $	��350��6      MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont#���  5       � DataContext 5      +   %CafeMVVM.ViewModels.DanhMucViewModels  5   
   6$   .��5      ��  �� CornerRadius$ 25��6   
�������$��0q�63   ���#cccc00._�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    60   �� 5      6"   �� 5      $
��Auto �6    60   .+�5      �� -   5         ��Name$ hinhanh��5      $��5,5,5,5q�6%   $��50��66   $��Center=�6B   $��Center=�6]   $��0��6{   6�   �� 5      -   5        	 ��Name$	 	lbNoidung��5      $��5,5,5,5q�6'   $��Segoe UI)�68   $��15(�6N   
���   �$=��7Đây là thông báo nội dung của chường trình��6o   $��Center=�6�   $��1��6�   6�   �� 5      $��2��6   
 �� Orientation$
 
Horizontal=�6&   $��Right=�6?   .+�5      �� -   5         ��Name$ btnOk��5      $��Segoe UI)�6<   $��15(�6R   $
��Bold"�6`   $��70��6r    " MaterialDesignRaisedDarkButton#��[ 6}   $��Ok��6�   $��	10,5,15,5q�6�   $��0��6�   6�   �� 5      -   5        $ btnYes��5   O   $��Segoe UI)�6_   $��15(�6u   $
��Bold"�6�   $��70��6�   #��[ 6�   $	��Yes��6�   $��5,5,15,5q�6�   $��1��6�   ��6   �� *ThongBaoYes+6
  �� 5       -   5        $ btnNo��5    M   $��Segoe UI)�6\   $��15(�6r   $
��Bold"�6�   $��70��6�   #��[ 6�   $��No��6�   $��5,5,15,5q�6�   $��2��6�   ��6   �� *
ThongBaoNo+6  5!      5"      5#      5$      