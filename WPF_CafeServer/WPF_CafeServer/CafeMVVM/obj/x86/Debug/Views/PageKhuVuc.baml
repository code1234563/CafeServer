   M S B A M L   `   `   `  ����C  ?CafeMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CafeMVVM.ViewModelsCafeMVVM.ViewModels  5          CafeMVVM.Views.PageKhuVuc   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:CafeMVVM.ViewModels     5      V RMaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
         MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5       � DataContext 5      +   %CafeMVVM.ViewModels.DanhMucViewModels  5   
   6$   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      6   �� 5      $
��Auto �6   6,   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ Accent=�6#   .��5      �� $��20��6   6"   5      &   System.Windows.Controls.DataGrid  5   
   $��5q�6   $��1��6      
IsReadOnly .    AutoGenerateColumns .  ��6Y   �� *DanhMucKhuVuc+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�	 �� SelectedItem	 6�   �� *SelectedKhuVucDanhMuc+
 � 	Resources
 5      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%�   '        �� 5       "  6    5!      P� 5"       �@ 
IsSelected . . �5#      ��  � ��
 � ���6;   5$      5&      5'         Columns 5(      4  .System.Windows.Controls.DataGridTemplateColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$ Tên khu vực��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6>      HeaderStyle 5*      �� 5+      =	  7System.Windows.Controls.Primitives.DataGridColumnHeader" 	 6    .�5,      ��  � ��$ Center=�6K   6\   �� 5-       � ��$ Segoe UI)�6;   6N   �� 5.       � ��$ 15(�69   6F   �� 5/       � ��$
 Bold"�6;   6J   �� 50       � ��
 ��  �6J   51         CellTemplate 53      �� 54      .R�55      �� $��15(�6$   $��Segoe UI)�62   $��Center=�6f   ��6H   �� *	TENKHUVUC+6�   56      58        59      $ Số lượng bàn��6)   $ * 6?    5:      �� 5;      " 	 6    .�5<      ��  � ��$ Center=�6K   6\   �� 5=       � ��$ Segoe UI)�6;   6N   �� 5>       � ��$ 15(�69   6F   �� 5?       � ��$
 Bold"�6;   6J   �� 5@       � ��
 ��  �6J   5A       5C      �� 5D      .R�5E      �� $��15(�6$   $��Segoe UI)�62   $��Center=�6H   ��6l   �� *SLBAN+6�   5F      5H      5J      � 5K   
   $��5q�6   $��2��6    5L      �� 5M      6"   �� 5N      6"   .+�5P      �� 
���   �$��Center=�6*   $��0,0,0,5q�6N   $��15(�6�   $��Segoe UI)�6�   )
  #MaterialDesignThemes.Wpf.HintAssist 
  Hint$' !Nhập tên khu vực cần thêm��6�   $��0��6  ��6_   �� *TENKHUVUCNHAP+$ TwoWay=�$ PropertyChanged=�6  � 5Q      $��1��6    � ColumnDefinitions 5R      �� 5S      6)   �� 5T      6)   .+�5V      �� $��5q�6   $��15(�6J   $��Segoe UI)�6X   $
��Bold"�6n   
���   �$��Thêm��6�    $  MaterialDesignRaisedAccentButton#��[ 6�   $��Bottom=�6�   ��6$   �� *ThemDanhMucKhuVuc+6�   �� 5W      $��5q�6   $��15(�6I   $��Segoe UI)�6W   $
��Bold"�6m   
���   �$
��Xóa��6�   #��[ 6�   $��Bottom=�6�   $��1��6�   ��6$   �� *XoaDanhMucKhuVuc+6  5X      5Y      5Z      5[      