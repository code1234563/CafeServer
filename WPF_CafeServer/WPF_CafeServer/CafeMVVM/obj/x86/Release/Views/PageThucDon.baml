   M S B A M L   `   `   `  ���� C  ?CafeMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CafeMVVM.ViewModelsCafeMVVM.ViewModels       CafeMVVM.Views.PageThucDon   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:CafeMVVM.ViewModels     V RMaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���   � DataContext +   %CafeMVVM.ViewModels.ThucDonViewModels  .���  � RowDefinitions �� $
��Auto ��� .+�(  "MaterialDesignThemes.Wpf.ColorZone     Mode$ Accent=�.���� $��20��� $��1�� � ColumnDefinitions �� �� .+�� $��0�� �� �� $
��Auto �.+�&   System.Windows.Controls.DataGrid  $��5q�   
IsReadOnly .    AutoGenerateColumns .  ���� *DanhMucThucDon+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� SelectedItem
 �� *SelectedItemDanhMucTd+$ OneWayToSource=� � 	Resources *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%R   '        �� "   P�  �@ 
IsSelected . . ���  � ��
 � ���   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Tên danh mục��   Width5  /System.Windows.Controls.DataGridLengthConverter$ *    HeaderStyle �� =	  7System.Windows.Controls.Primitives.DataGridColumnHeader" 	 .���  � ��$ Center=���  � ��$ Segoe UI)���  � ��$ 15(���  � ��$
 Bold"���  � ��
 ��  �   CellTemplate �� .R��� $��Center=�$��Segoe UI)�$��15(�
���   ����� *TENDM+� $��1��.+��  �� �� .+��� $��5q�$��Center=�
���   �$��15(�$��Segoe UI)�)
  #MaterialDesignThemes.Wpf.HintAssist 
  Hint$ Nhập danh mục món��$��Bottom=����� *
TenDanhMuc+$ TwoWay=�$	 PropertyChanged=�� $��1�� �� �� $
��Auto �.+��� $��5q�$��Segoe UI)�$��15(�
���   � $  MaterialDesignRaisedAccentButton#��[ $��Thêm��$��0��$��Bottom=����� *ThemDanhMucTdComand+�� $��5q�$��Segoe UI)�$��15(�
���  ��#��[ $
��Xóa��$��1��$��Bottom=����� *XoaDanhMucTdComand+� $��1�� �� �� $
��Auto �.+�  $��5q� .  .  ���� *DanhSachMon+$ TwoWay=�$	 PropertyChanged=�
 �� *SelectedItemMon+$ OneWayToSource=� ��%R   '        �� "   P�  �@ 
IsSelected . . ���  � ��
 � ���   $ 	Tên món��$ *  �� " 	 .���  � ��$ Center=���  � ��$ Segoe UI)���  � ��$ 15(���  � ��$
 Bold"���  � ��
 ��  � �� .R��� $��Center=�$��15(�$��Segoe UI)�
���   ����� *
TENTHUCDON+  $ 
Đơn giá��$ *  �� " 	 .���  � ��$ Center=���  � ��$ Segoe UI)���  � ��$ 15(���  � ��$
 Bold"���  � ��
 ��  � �� .R��� $��Center=�$��15(�$��Segoe UI)�
���   ����� *DONGIA+� $��1��.+��  �� �� �� .+��� $��5q�
���   �$��Center=�$��0��$��15(�$��Segoe UI)�$ Nhập tên món��$��Bottom=����� *Mon+$ TwoWay=�$	 PropertyChanged=��� -   $��5q�
���   �$��Center=�$��1��$��15(�$��Segoe UI)�$ Nhập đơn giá��$��Bottom=����� *DonGia+$ TwoWay=�$	 PropertyChanged=�� $��2�� �� �� �� $
��Auto �.+��� $��5q�$��Segoe UI)�$��15(�
���   �#��[ $��Thêm��$��0��$��Bottom=����� *ThemMonComand+�� $��5q�$��Segoe UI)�$��15(�
���   �#��[ $��Sửa��$��1��$��Bottom=����� *SuaMonComand+�� $��5q�$��Segoe UI)�$��15(�
���  ��#��[ $
��Xóa��$��2��$��Bottom=����� *XoaMonTdComand+