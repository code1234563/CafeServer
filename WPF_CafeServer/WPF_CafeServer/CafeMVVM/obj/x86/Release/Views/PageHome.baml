   M S B A M L   `   `   `  ���� C  ?CafeMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CafeMVVM.ViewModelsCafeMVVM.ViewModels      CafeMVVM.Views.PageHome   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:CafeMVVM.ViewModels     V RMaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���   � DataContext -   'CafeMVVM.ViewModels.KhuVucBanViewModels   � 	Resources $   CafeMVVM.ViewModels.ConvertMau  
ConvertMau�� %   &	         .���  � RowDefinitions �� $
��Auto ��� �� $
��Auto �.+�(  "MaterialDesignThemes.Wpf.ColorZone  $��0��   Mode$ Accent=�.���� $��20��� $��1�� � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� �� .+�� $��0�� �� $
��Auto ��� .+�&   System.Windows.Controls.DataGrid  $��5,5,5,5q�   
IsReadOnly . $��1��   AutoGenerateColumns .  ���� *KhuVuc+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=� �� SelectedItem �� *SelectedItem+$	 OneWayToSource=� *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%R   '        �� "   P�  �@ 
IsSelected . . ���  � ��
 � ���   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	Khu vực��   HeaderStyle �� =	  7System.Windows.Controls.Primitives.DataGridColumnHeader" 	 .���  � ��$ Center=���  � ��$ Segoe UI)���  � ��$ 15(���  � ��$
 Bold"���  � ��
 ��  �   CellTemplate �� .R��� $��Center=�
���   �$��Segoe UI)�$��15(����� *	TENKHUVUC+� $��1��$	��210��$��Center=� �� $
��Auto ��� .+�  $��5,5,5,5q� .   . $��1������ *	BanKhuVuc+$	 TwoWay=�$
 PropertyChanged=� �� *SelectedItemBan+$	 TwoWay=�$
 PropertyChanged=� �� SelectedIndex �� *SelectedIndexOfBan+ ��%R   '        �� "   P�  �@ 
IsSelected . . ���  � ��
 � ���      Width5
  /System.Windows.Controls.DataGridLengthConverter$ *
 $ 	Tên bàn��   
IsReadOnly .  �� " 	 .���  � ��$ Center=���  � ��$ Segoe UI)���  � ��$ 15(���  � ��$
 Bold"���  � ��
 ��  � �� .R��� $��Center=�$��Segoe UI)�$��15(����� *TENBAN+���� *	TRANGTHAI+ �� 	Converter# [   $ *
 $ Trạng thái�� .  �� " 	 .���  � ��$ Center=���  � ��$ Segoe UI)���  � ��$ 15(���  � ��$
 Bold"���  � ��
 ��  � �� .R��� $��Center=�$��Segoe UI)�$��15(����� *	TRANGTHAI+���� *	TRANGTHAI+# [ � $
��Left=�$��2��{��� *EnableGridDanhmuc+ �� $
��Auto ��� $
��Auto �.+��� $��5,5,5,5q�$��Center=� �� DisplayMemberPath$ TENDM��$��15(�$
��Bold"�$��Segoe UI)�$��0��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Danh mục thực đơn������ *DanhMucThucDon+ �� *SelectedItemDMThucDon+$	 TwoWay=�$
 PropertyChanged=�  $��5,5,5,5q� . $��1�� .  $	��440��$��Bottom=����� *	ThucDon+$	 TwoWay=�$
 PropertyChanged=� �� *ChonThucDonBan+$	 TwoWay=�$
 PropertyChanged=� ��%R   '        �� "   P�  �@ 
IsSelected . . ���  � ��
 � ���   $ 	Tên món��$ *
  �� " 	 .���  � ��$ Center=���  � ��$ Segoe UI)���  � ��$ 15(���  � ��$
 Bold"���  � ��
 ��  � �� .R��� $��Center=�
���   �$��Segoe UI)�$��15(����� *
TENTHUCDON+  $ 
Đơn giá��$ *
  �� " 	 .���  � ��$ Center=���  � ��$ Segoe UI)���  � ��$ 15(���  � ��$
 Bold"���  � ��
 ��  � �� .R��� $��Center=�
���   �$��Segoe UI)�$��15(����� *DONGIA+  $ Giảm giá (%)��$ *
  �� " 	 .���  � ��$ Center=���  � ��$ Segoe UI)���  � ��$ 15(���  � ��$
 Bold"���  � ��
 ��  � �� .R��� $��Center=�
���   �$��Segoe UI)�$��15(����� *	GIAMGIA+� $��3�� �� $
��Auto ��� $
��Auto ��� �� $
��Auto �.+��� $��Center=�$��Segoe UI)�$��15(�$
��Bold"�
���   �$��1������ *TieuDeHoaDon+$	 TwoWay=�$
 PropertyChanged=�  $��5,5,5,5q� . $��2�� .  ���� *DanhSachThucDonBan+$	 TwoWay=�$
 PropertyChanged=� �� *	SelectMon+$	 OneWayToSource=� ��%R   '        �� "   P�  �@ 
IsSelected . . ���  � ��
 � ���   $ *
 $ 	Tên món�� �� " 	 .���  � ��$ Center=���  � ��$ Segoe UI)���  � ��$ 15(���  � ��$
 Bold"���  � ��
 ��  � �� .R��� $��Center=�
���   �$��Segoe UI)�$��15(����� *
TENTHUCDON+  $ *
 $ 
Đơn giá�� �� " 	 .���  � ��$ Center=���  � ��$ Segoe UI)���  � ��$ 15(���  � ��$
 Bold"���  � ��
 ��  � �� .R��� $��Center=�
���   �$��Segoe UI)�$��15(����� *DONGIA+  $ *
 $ Số lượng�� �� " 	 .���  � ��$ Center=���  � ��$ Segoe UI)���  � ��$ 15(���  � ��$
 Bold"���  � ��
 ��  � �� .R��� 
���   �$��Center=�$��Segoe UI)�$��15(����� *	SOLUONG+�� $��Right=� �� Orientation$ 
Horizontal=�$��2��.+��� $��5,5,5,5q�+  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth5=�$��Segoe UI)�$��15(�$
��Bold"�
���   �$%��Tìm khu vực có bàn trống�� $  MaterialDesignRaisedAccentButton#��[ ���� *TimBanTrongCommand+�� $��Center=�$��Center=�$��Segoe UI)�$��15(�$
��Bold"�
���  ������ *
TongTien+$	 TwoWay=�$
 PropertyChanged=��� $��5,5,5,5q�$ Depth5=�$��Segoe UI)�$��15(�$
��Bold"�
���   �$��	Xóa món��#��[ ���� *XoaMon+�� $��5,5,5,5q�$ Depth5=�$��Segoe UI)�$��15(�$
��Bold"�
���   �$��Chuyển bàn��#��[ ���� *ChuyenBanCommand+�� $��5,5,5,5q�$ Depth5=�$��Segoe UI)�$��15(�$
��Bold"�
���   �$��
Gộp bàn��#��[ ���� *GopBan+�� $��5,5,5,5q�$ Depth5=�$��Segoe UI)�$��15(�$
��Bold"�
���   �$��Thanh toán��#��[ ���� *ThanhToanComand+