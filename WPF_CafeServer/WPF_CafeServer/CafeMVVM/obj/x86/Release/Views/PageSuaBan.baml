   M S B A M L   `   `   `  ���� C  ?CafeMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CafeMVVM.ViewModelsCafeMVVM.ViewModels      CafeMVVM.Views.PageSuaBan   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:CafeMVVM.ViewModels     V RMaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    N� Title$  
PageSuaBan��   MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper N� 
Background# �    MaterialDesignFont N� 
FontFamily# �   � DataContext '   !CafeMVVM.ViewModels.BanViewModels  .��� ���#b8b894 � RowDefinitions �� $
��Auto ��� $
��Auto �.+��� $��5,5,5,5q�$��Center=�$��15(�$��Segoe UI)�
���   �)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nhập tên bàn������ *TENBAN+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�� $��1��
 � ColumnDefinitions
 �� �� .+��� $��Segoe UI)�$��15(�
���   �$
��Lưu��$
��Bold"� $  MaterialDesignRaisedAccentButton#��[ $��5,5,5,5q����� *SuaBanFormComand+����  �� ElementName$ WSuaBan���� -    ��Name$ btnthoat��$��Segoe UI)�$��15(�
���   �$��Thoát��$
��Bold"�#��[ $��5,5,5,5q�$��1��