   M S B A M L   `   `   `  ���� C  ?CafeMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CafeMVVM.ViewModelsCafeMVVM.ViewModels      CafeMVVM.Views.PageBan   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:CafeMVVM.ViewModels     V RMaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���   � DataContext '   !CafeMVVM.ViewModels.BanViewModels  .���  � RowDefinitions �� $
��Auto ��� �� $
��Auto �.+�(  "MaterialDesignThemes.Wpf.ColorZone     Mode$ Accent=�.���� $��20��&   System.Windows.Controls.DataGrid  $��5,5,5,5q�$��1��   
IsReadOnly .    AutoGenerateColumns .  ���� *
BanDanhMuc+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�	 �� SelectedItem	 �� *SelectedBan+$ OneWayToSource=�
 � 	Resources
 *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%R   '        �� "   P�  �@ 
IsSelected . . ���  � ��
 � ���   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	Tên bàn��   Width5  /System.Windows.Controls.DataGridLengthConverter$ *    HeaderStyle �� =	  7System.Windows.Controls.Primitives.DataGridColumnHeader" 	 .���  � ��$ Center=���  � ��$ Segoe UI)���  � ��$ 15(���  � ��$
 Bold"���  � ��
 ��  �   CellTemplate �� .R��� $��Center=�$��15(�$��Segoe UI)�
���   ����� *TENBAN+� $��2�� �� �� $
��Auto �.+�� $��0�� �� �� .+��� $��5,5,5,5q� �� DisplayMemberPath$ 	TENKHUVUC��$��15(�$��Segoe UI)�$
��Bold"�$��Bottom=�)
  #MaterialDesignThemes.Wpf.HintAssist 
  Hint$* $Chọn khục vực để thêm bàn��$��0������ *KhuVuc+	 �� *SelectedKhuVuc+$ OneWayToSource=�$ PropertyChanged=��� -   $��5,5,5,5q�$��15(�$��Segoe UI)�$
��Bold"�$��Bottom=�$+ %Nhập số lượng bàn cần thêm��$��1������ *
SOLUONGBAN+$ TwoWay=�$ PropertyChanged=�� $��1�� � ColumnDefinitions �� �� �� .+��� $��15(�$��Segoe UI)�$
��Bold"�
���   �$��Thêm�� $  MaterialDesignRaisedAccentButton#��[ $��5,5,5,5q�$��0������ *ThemBanComand+�� $��15(�$��Segoe UI)�$
��Bold"�
���   �$��Sửa��#��[ $��5,5,5,5q�$��1������ *SuaBanComand+�� $��15(�$��Segoe UI)�$
��Bold"�
���   �$
��Xóa��#��[ $��5,5,5,5q�$��2������ *XoaBanComand+